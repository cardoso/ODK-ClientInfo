using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using InfoLib;

namespace ItemTable_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Item.inf Converter v1.0 - OpenDarkEden";

            //args = new string[] { @"C:\OpenDarkEden\ItemTable Converter\item2.inf.js" };

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("       ItemTable v6 Converter v1.0      ");
            Console.WriteLine("              Open DarkEden             ");
            Console.WriteLine("       Author: Matheus M. Cardoso       ");
            Console.WriteLine("----------------------------------------");

            if (args.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No valid itemtable or json was passed as an argument to this program.");
                Console.WriteLine("Drag and drop a valid v6 ItemTable file (.inf) or a valid JSON file (.js)");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
                return;
            }

            if (!File.Exists(args[0]))
            {
                string msg = "File \"{0}\" not found.";
                object[] objs = { args[0] };

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(String.Format(msg, objs));
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }

            DirectoryInfo dir = new DirectoryInfo(args[0]);

            if (dir.Extension != ".inf" && dir.Extension != ".js")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Not a .inf or .js file.");
                Console.WriteLine("Drag and drop a valid v6 ItemTable file (.inf) or a valid JSON file (.js)");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
                return;
            }

            if (dir.Extension == ".inf")
            {
                FileStream file = File.Open(args[0], FileMode.Open);
                ItemTableList itl = new ItemTableList(ref file);

                File.WriteAllText(dir.FullName + ".js", ItemTableListToJson(itl));
            }

            if (dir.Extension == ".js")
            {
                try
                {
                    FileStream file = File.Open(Path.ChangeExtension(dir.FullName, null), FileMode.OpenOrCreate);
                    JsonToItemTableList(File.ReadAllText(args[0])).SaveToFile(ref file);
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    if (e as JsonException != null)
                    {
                        Console.WriteLine("Could not deserialize JSON File. Check the syntax:");
                        Console.WriteLine(e.Message);
                    }
                    else
                    {
                        Console.WriteLine("Something bad happened:");
                        Console.WriteLine(e.Message);
                    }

                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("Press any key to exit.");
                    Console.ReadKey();
                }
            }
        }

        static string ItemTableListToJson(ItemTableList tl)
        {
            Console.WriteLine("Serializing ItemTable. Please Wait.");
            string json = JsonConvert.SerializeObject(tl, Formatting.Indented);
            Console.WriteLine("Finished serializing JSON File");

            return json;
        }

        static ItemTableList JsonToItemTableList(string json)
        {
            Console.WriteLine("Deserializing JSON File. Please Wait.");
            ItemTableList tl = JsonConvert.DeserializeObject<ItemTableList>(json);
            Console.WriteLine("Finished deserializing JSON File.");

            return tl;
        }
    }
}
