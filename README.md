# djikstra
Path finding algorithm implementation

##
Program gets an ascii file as argument. The file contains 2 coordinates (x, y) and a map. The map contains trees (marked as X), rocks (marked as O) and free surface (marked with .). One cannot traverse through rocks or trees, only through the free terrain. Only horizontal and vertical movement is possible. The picture below is an example of the input file content. Files do not actually contain S or E letters. They are only presented to help visualize start point and end point.

![Input file content](Images/file.PNG)

The PathFinder program takes the file as argument and finds the shortest path through the map from start point to end point, and calculate how many trees (X) were passed on the way. The program used Djikstra's algorithm. For the example file above, the result is 9, and the path is shown below. The actual path is not returned to the user.

![Solution path](Images/path.PNG)

## Instructions
* Download the repository to your computer.
* Open PahtFinder Visual Studio Project and build the program.
* Run the program and give an input file as a parameter (see Examples folder)

```
PathFinder.exe map.txt
```

## Map file limitations
* first row should contain starting point coordinate (must be inside map area)
* second row should contain end point coordinate (must be inside map area)
* the following lines should contain area of the map ('X', 'O', '.')
* make sure that the map file does not contain any empty lines
