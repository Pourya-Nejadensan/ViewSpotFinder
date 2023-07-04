# ViewSpotFinder

This C# solution is designed to identify view spots in a hilly landscape represented by a mesh. The mesh is composed of triangular elements, each assigned a scalar value representing the average spot height compared to sea level.

The program takes a JSON file as input, containing the mesh and height values. The file includes sections for nodes, elements, and values. Nodes represent locations on the map, elements define triangles by referencing node IDs, and values assign height values to elements.

The goal is to find the first N view spots based on their spot height, ordered from highest to lowest. A view spot is an element where the height is a local maximum, meaning none of its neighboring elements are higher. Neighboring elements share at least one vertex.

The output is a list of N view spots, including their element IDs and corresponding height values, sorted in descending order. The program provides a command line interface and can be executed using the provided command examples for different platforms (C#, Java, JavaScript, or Python).

The solution has performance requirements, aiming to identify view spots in a mesh with 10,000 elements in less than 15 seconds, ideally under 1 second. The execution time for a mesh with 20,000 elements should be less than three times higher than that of a mesh with 10,000 elements.

Example mesh files are attached for testing purposes, including a small file and larger meshes with 10,000 and 20,000 elements.

By using this solution, users can easily identify view spots in a hilly landscape and analyze the height distribution within the mesh, aiding in tasks such as planning walking tours or studying geographical features.
