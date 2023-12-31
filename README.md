# ViewSpotFinder

This C# solution is designed to identify view spots in a hilly landscape represented by a mesh. The mesh is composed of triangular elements, each assigned a scalar value representing the average spot height compared to sea level.

The program takes a JSON file as input, containing the mesh and height values. The file includes sections for nodes, elements, and values. Nodes represent locations on the map, elements define triangles by referencing node IDs, and values assign height values to elements.

The goal is to find the first N view spots based on their spot height, ordered from highest to lowest. A view spot is an element where the height is a local maximum, meaning none of its neighboring elements are higher. Neighboring elements share at least one vertex.

The output is a list of N view spots, including their element IDs and corresponding height values, sorted in descending order. The program provides a command line interface.

Example mesh files are attached for testing purposes, including small files and larger meshes with 10,000 and 20,000 elements in the Assignment folder.

By using this solution, users can easily identify view spots in a hilly landscape and analyze the height distribution within the mesh, aiding in tasks such as planning walking tours or studying geographical features.

![Casadasdpture](https://github.com/Pourya-Nejadensan/ViewSpotFinder/assets/64536102/872105a8-4835-43ac-9698-5a05ef680d9f)

# How to use an example:
 In CMD: ViewSpotFinder.exe C:\...\ViewSpotFinder\Assignment\mesh_x_sin_cos_20000[1][1][1][1][1][1].json 5

