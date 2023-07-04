using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewSpotFinder.Util;

namespace ViewSpotFinder
{
    public class ViewSpotFinder
    {
        public List<Dictionary<string, object>> FindViewSpots(string meshFile, int numViewSpots)
        {
            try
            {
                Logger.Log(LogLevel.Information, "Start to read JSON file!");

                string json = File.ReadAllText(meshFile);
                MeshData meshData = JsonConvert.DeserializeObject<MeshData>(json);

                Logger.Log(LogLevel.Information, "The JSON file has been read!");

                List<Node> nodes = meshData.nodes;
                List<Element> elements = meshData.elements;
                List<Value> values = meshData.values;

                Dictionary<string, double> elementHeights = new Dictionary<string, double>();
                foreach (Value item in values)
                {
                    string elementId = item.element_id;
                    double height = item.value;
                    elementHeights[elementId] = height;
                }

                // Build a mapping of nodes to their adjacent elements
                Dictionary<string, List<string>> nodeToElements = new Dictionary<string, List<string>>();
                foreach (Element element in elements)
                {
                    string elementId = element.id;
                    List<string> elementNodes = element.nodes;

                    foreach (string node in elementNodes)
                    {
                        if (!nodeToElements.ContainsKey(node))
                        {
                            nodeToElements[node] = new List<string>();
                        }

                        nodeToElements[node].Add(elementId);
                    }
                }

                List<Dictionary<string, object>> viewSpots = new List<Dictionary<string, object>>();

                foreach (Element element in elements)
                {
                    string elementId = element.id;
                    List<string> elementNodes = element.nodes;
                    double elementHeight = elementHeights[elementId];

                    bool isViewSpot = true;
                    foreach (string node in elementNodes)
                    {
                        // if (nodeToElements.ContainsKey(node))
                        // {
                        foreach (string neighborElementId in nodeToElements[node])
                        {
                            if (neighborElementId != elementId)
                            {
                                double neighborHeight = elementHeights[neighborElementId];
                                if (neighborHeight >= elementHeight)
                                {
                                    isViewSpot = false;
                                    break;
                                }
                            }
                        }
                        //  }

                        if (!isViewSpot)
                        {
                            break;
                        }
                    }

                    if (isViewSpot)
                    {
                        viewSpots.Add(new Dictionary<string, object>
                {
                    { "element_id", elementId },
                    { "value", elementHeight }
                });
                    }
                }

                viewSpots.Sort((x, y) => -Comparer<double>.Default.Compare((double)x["value"], (double)y["value"]));

                Logger.Log(LogLevel.Information, "Successful!");
                return viewSpots.GetRange(0, Math.Min(numViewSpots, viewSpots.Count));
            }
            catch (Exception ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);
                return null;
            }
            finally
            {
                Logger.Log(LogLevel.Information, "Finished!");
            }
        }
    }
}
