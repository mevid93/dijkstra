using System;
using System.Collections.Generic;

namespace PathFinder
{   
    /// <summary>
    /// Class to find the shortest path and the number of trees along the shortest path.
    /// </summary>
    class PathFinder
    {
        /// <summary>
        /// Function to find the number of trees along the shortest path
        /// from start to end point.
        /// </summary>
        /// <param name="map">map of area</param>
        /// <returns>number of trees</returns>
        public static int FindNumberOfTrees(Map map)
        {
            int numberOfTrees = 0;

            // find the shortest path
            List<Point> path = FindTheShortestPath(map);
            
            // count the number of trees along the shortest path
            foreach(Point point in path)
            {
                // check if there is tree in some direction from point
                numberOfTrees += CountNearbyTrees(point, map);
            }
            
            // return the number of trees that were found
            return numberOfTrees;
        }

        /// <summary>
        /// Function to find shortest path by using Djikstra's algorithm.
        /// </summary>
        /// <param name="map">map of area</param>
        /// <returns>List of points that form the shortest path</returns>
        public static List<Point> FindTheShortestPath(Map map)
        {
            // get width of the map area
            int height = map.area.GetLength(0);
            int width = map.area.GetLength(1);

            // create two dimensional array for holding distance information
            int[,] distances = new int[height, width];
            // create two dimensional array for holding infomration about previous point
            Point[,] previous = new Point[height, width];
            // create set of points that need still to be visited
            List<Point> Q = new List<Point>();

            // initialize array values
            for (int i = 0; i < height; i++)
            {
                for(int j = 0; j < width; j++)
                {
                    distances[i, j] = Int32.MaxValue;
                    previous[i, j] = null;
                    if (map.area[i, j] == '.')      // only points where it is possible to move
                        Q.Add(new Point(j, i)); 
                }
            }

            // initialize distance to start point as zero
            distances[map.start.y, map.start.x] = 0;
            
            // process until no more points to visit
            while(Q.Count > 0)
            {
                // extract the point with smallest possible distance
                Point u = ExtractMininimum(Q, distances);

                // make sure to terminate if no path exists
                if (distances[u.y, u.x] == Int32.MaxValue) return null;

                // for each possible direction from u, update distances
                UpdateDistance(u, u.x + 1, u.y, map, distances, previous);   // RIGTH
                UpdateDistance(u, u.x - 1, u.y, map, distances, previous);   // LEFT
                UpdateDistance(u, u.x, u.y + 1, map, distances, previous);   // UP
                UpdateDistance(u, u.x, u.y - 1, map, distances, previous);   // DOWN
            }

            // backtrack to form the shortest path and return it
            return BacktrackSolution(map.end, previous);
        }

        /// <summary>
        /// Function to extract point with minimum distance. 
        /// Removes the point from the input list and returns it.
        /// </summary>
        private static Point ExtractMininimum(List<Point> points, int[,] distances)
        {
            // initialize minimum point and minimum distance
            Point minPoint = null;
            int minDistance = Int32.MaxValue;

            // search the min point
            foreach(Point point in points)
            {
                if(distances[point.y, point.x] < minDistance)
                {
                    minPoint = point;
                    minDistance = distances[point.y, point.x];
                }
            }

            // remove min point from the list of points to be visited
            points.Remove(minPoint);
            
            // return the minimum point
            return minPoint;
        }

        /// <summary>
        /// Function to update distances and information about previous point.
        /// </summary>
        private static void UpdateDistance(Point u, int x, int y, Map map, int[,] distances, Point[,] previous)
        {
            // get width of the map area
            int maxHeight = map.area.GetLength(0) - 1;
            int maxWidth = map.area.GetLength(1) - 1;

            // check that position is within area
            if (x < 0 || x > maxWidth || y < 0 || y > maxHeight) return;

            // check that it is possible to move to new position
            if (map.area[y, x] != '.') return;
            
            // check if new distance is less than previous known distance
            if (distances[y, x] > distances[u.y, u.x] + 1)
            {
                distances[y, x] = distances[u.y, u.x] + 1;
                previous[y, x] = u;
            }
        }

        /// <summary>
        /// Function to find form the shortest path from the results of Djikstra's algorithm.
        /// </summary>
        private static List<Point> BacktrackSolution(Point end, Point[,] previous)
        {
            List<Point> path = new List<Point>();

            Point u = previous[end.y, end.x];

            while(u != null)
            {
                path.Insert(0, u);

                u = previous[u.y, u.x];
            }

            return path;
        }

        /// <summary>
        /// Function to count trees that are near given point. Trees will be removed from the map
        /// in order to prevent duplicates to be found later.
        /// </summary>
        private static int CountNearbyTrees(Point point, Map map)
        {
            int numberOfTrees = 0;

            // get width of the map area
            int maxHeight = map.area.GetLength(0) - 1;
            int maxWidth = map.area.GetLength(1) - 1;

            // check top
            if (point.y - 1 >= 0 && map.area[point.y - 1, point.x] == 'X')
            {
                numberOfTrees += 1;
                map.area[point.y - 1, point.x] = 'C';
            }

            // check bottom
            if (point.y + 1 <= maxHeight && map.area[point.y + 1, point.x] == 'X')
            {
                numberOfTrees += 1;
                map.area[point.y + 1, point.x] = 'C';
            }

            // check right
            if (point.x + 1 < maxWidth && map.area[point.y, point.x + 1] == 'X')
            {
                numberOfTrees += 1;
                map.area[point.y, point.x + 1] = 'C';
            }

            // check left
            if (point.x - 1 >= 0 && map.area[point.y, point.x - 1] == 'X')
            {
                numberOfTrees += 1;
                map.area[point.y, point.x - 1] = 'C';
            }

            return numberOfTrees;
        }
    }
}
