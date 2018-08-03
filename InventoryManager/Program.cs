using System;
using System.Linq;
using System.IO;

namespace InventoryManager
{
    class Program
    {
        static void Main(string[] args)
        {
            // Retrieve input arguments; there must be 1
            int numArgs = args.Count<string>();

            if (numArgs != 1)
            {
                Console.WriteLine("Need 1 parameter to proceed:");
                Console.WriteLine("The full path including filename of a file containing item names, sellin values and quality values");
            }
            else
            {
                // Extract the name of the input file into a variable
                string inputFilename = args[0].Trim();

                // Process the contents of the input file; pass in the format for the output file name where the results of the execution will be published
                ProcessLines(inputFilename + ".out", System.IO.File.ReadAllLines(inputFilename));
            }

            Console.WriteLine(Environment.NewLine + "Press any key to continue...");
            Console.ReadLine();
        }

        /***********************************************************************
         * ProcessLines
         * 
         * Private method used to process each line from the input file and 
         * output the resulting item and its updated values to an output file
         ***********************************************************************
         * Input Parameters:
         * 
         * 1. Output filename
         * 2. Array of all lines from the input file
         ***********************************************************************
         * Output:
         * 
         * None
         ***********************************************************************
         * Change history:
         * 
         * Date                Username               Changes made
         * 
         * 08/02/2018          Nabil Ahmad            Initial Creation
         **********************************************************************/
        static void ProcessLines(string outputFilename, string[] lines)
        {
            try
            {
                string path = @outputFilename;

                // Remove the output file if it already exists
                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                // Create the output file to write to
                string createText = "Date: " + DateTime.Now.ToString("M/d/yyyy h:mm:ss tt") + Environment.NewLine;
                File.WriteAllText(path, createText);

                // Get the number of lines from the input file
                int numLines = lines.Count<string>();

                // Each line in the input file is a specific item that will be processed here
                foreach (string line in lines)
                {
                    // Split each input line into individual strings
                    string[] tokens = line.Split(' ');
                    int numArgs = tokens.Count<string>();

                    // Create a new item object
                    Item i = new Item();
                    string n = "";
                    int s = 0;
                    int q = 0;

                    // Construct the item name from the input arguments
                    for (int x = 0; x < (tokens.Count<string>() - 2); x++)
                    {
                        if ((n == "") && (x == 1))
                        {
                            n = tokens[x];
                        }
                        else
                        {
                            n += " " + tokens[x];
                        }
                    }

                    // Validate the name of the item retrieved
                    n = i.ValidateName(n.Trim());

                    if (n == "NO SUCH ITEM")
                    {
                        Console.WriteLine(n);
                        File.AppendAllText(path, n + Environment.NewLine);
                        continue;
                    }

                    // Validate the sellin value retrieved
                    if (!Int32.TryParse(tokens[numArgs - 2], out s))
                    {
                        Console.WriteLine("Invalid value of Sellin entered. Must be an integer.");
                        File.AppendAllText(path, "Invalid value of Sellin entered. Must be an integer." + Environment.NewLine);
                        continue;
                    }

                    // Validate the quality value retrieved
                    if (!Int32.TryParse(tokens[numArgs - 1], out q))
                    {
                        Console.WriteLine("Invalid value of Quality entered. Must be an integer.");
                        File.AppendAllText(path, "Invalid value of Quality entered. Must be an integer." + Environment.NewLine);
                        continue;
                    }

                    // Create a new item based on the input values retrieved
                    i = new Item(n, s, q);

                    // Run the program on the item; update item sellin value and quality value after 1 day has passed
                    i.ProcessItem();

                    // Output the updated item and its member values in the same order (name, sellin value, quality) after 1 day to the console and to the output file
                    Console.WriteLine(i.GetName() + " " + i.GetSellin().ToString() + " " + i.GetQuality().ToString());
                    File.AppendAllText(path, i.GetName() + " " + i.GetSellin().ToString() + " " + i.GetQuality().ToString() + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception encountered when attempting to read from the input file: " + ex.Message + ex.ToString());
            }
        }
    }
}
