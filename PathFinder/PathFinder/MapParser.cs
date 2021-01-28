using System;
using System.IO;
using System.Linq;

namespace PathFinder
{   
    /// <summary>
    /// Class to read map from the input file.
    /// </summary>
    class MapParser
    {
        /// <summary>
        /// Function to parse map from file.
        /// </summary>
        /// <param name="filename">file containing the map</param>
        /// <returns>map</returns>
        public static Map ReadMapFromFile(string filename)
        {
            // read content from input file
            string[] lines = File.ReadAllLines(filename);
            
            // read map content into two dimensional array
            Point start = ParsePointFromTextLine(lines[0]);
            Point end = ParsePointFromTextLine(lines[1]);
            char[,] area = ParseAreaFromTextLines(lines.Skip(2).ToArray());

            // create new map object and return it
            return new Map(start, end, area);
        }

        /// <summary>
        /// Function to parse point coordinates from line.
        /// </summary>
        private static Point ParsePointFromTextLine(string line)
        {
            // xy coordinates are separated by comma
            string[] parts = line.Split(',');

            // convert strings to integers
            int x = Int32.Parse(parts[0].Trim()) - 1;
            int y = Int32.Parse(parts[1].Trim()) - 1;

            // create point object and return it
            return new Point(x, y);
        }

        /// <summary>
        /// Function to parse area from text lines.
        /// </summary>
        /// <param name="lines">lines containing area characters</param>
        /// <returns>two dimension array of characters (X, O, .)</returns>
        private static char[,] ParseAreaFromTextLines(string[] lines)
        {
            // find area size and initialize two-dimensional array according to it
            int x = lines[0].Trim().Length;
            int y = lines.Length;

            char[,] area = new char[y, x];

            // go through all the lines and fill the area with correct characters
            x = 0;
            y = 0;
            foreach(string line in lines)
            {
                foreach(char c in line.Trim())
                {
                    area[y, x] = Char.ToUpper(c);
                    x++;
                }
                
                y++;
                x = 0;
            }

            return area;
        }
    }
}
