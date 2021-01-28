
namespace PathFinder
{
    /// <summary>
    /// Class representing point on a map (coordinates).
    /// </summary>
    class Point
    {
        public int x { get; set; }
        public int y { get; set; }

        /// <summary>
        /// Constructor for point object.
        /// </summary>
        /// <param name="x">x-coordinate</param>
        /// <param name="y">y-coordinate</param>
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
