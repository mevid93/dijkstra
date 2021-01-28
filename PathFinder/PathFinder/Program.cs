using System.IO;

namespace PathFinder
{
    /// <summary>
    /// This class is the driver for the program.
    /// </summary>
    class Program
    {
        static int Main(string[] args)
        {
            // check that user provided input file
            if (args.Length == 0 || !File.Exists(args[0]))
            {
                System.Console.WriteLine("Please provide input file!");
                return -1;
            }
            
            // get file name from argument list
            string filename = args[0];

            // read map content into two dimensional array
            Map map = MapParser.ReadMapFromFile(filename);

            // find the shortest path (the number of trees along it)
            int numberOfTrees = PathFinder.FindNumberOfTrees(map);

            // print the result for the user
            System.Console.WriteLine($"The number of trees along the shortest path: {numberOfTrees}");
            
            return 0;
        }
    }
}
