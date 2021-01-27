# djikstra
Path finding algorithm implementation

##
Program gets an ascii file as argument. The file contains 2 coordinates (x, y) and a map. The map contains trees (marked as X), rocks (marked as O) and free surface (marked with .). One cannot traverse through rocks or trees, only through the free terrain. Only horizontal and vertical movement is possible. The picture below is an example of the input file content. Files do not actually contain S or E letters. They are only presented to help visualize start point and end point.

![Input file content](Images/file.PNG)

The PathFinder program takes the file as argument and finds the shortest path through the map from start point to end point, and calculate how many trees (X) were passed on the way. The program used Djikstra's algorithm. For the example file above, the result is 3, and the path is shown below. The actual path is not returned to the user.

![Solution path](Images/path.PNG)
