
namespace PathFinder
{
    /// <summary>
    /// Class representing the map.
    /// </summary>
    class Map
    {
        public Point start { get; set; }      // start point of path
        public Point end { get; set; }        // end point of path
        public char[,] area { get; set; }            // area the map ('X', 'O', '.')

        /// <summary>
        /// Constructor for the Map.
        /// </summary>
        /// <param name="start">starting point for the path</param>
        /// <param name="end">end point for the path</param>
        /// <param name="area">map area ('X', 'O', ',')</param>
        public Map(Point start, Point end, char[,] area){
            this.start = start;
            this.end = end;
            this.area = area;
        }
    }
}
