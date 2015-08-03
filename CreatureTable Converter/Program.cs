using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace CreatureTable_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "CreatureTable file Converter v1.0 - OpenDarkEden";

            //args = new string[] { "C:\\OpenDarkEden\\CreatureTable Converter\\bin\\Debug\\creature.inf" };

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("    CreatureTable file Converter v1.0   ");
            Console.WriteLine("              Open DarkEden             ");
            Console.WriteLine("       Author: Matheus M. Cardoso       ");
            Console.WriteLine("----------------------------------------");

            EncodingHelper.Initialize();

            if (args.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No valid creaturetable or json was passed as an argument to this program.");
                Console.WriteLine("Drag and drop a valid v6 CreatureTable file (.inf) or a valid JSON file (.js)");
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
                Console.WriteLine("Drag and drop a valid v6 CreatureTable file (.inf) or a valid JSON file (.js)");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
                return;
            }

            if (dir.Extension == ".inf")
            {
                FileStream file = File.Open(args[0], FileMode.Open);
                CreatureTable zt = new CreatureTable(ref file);

                File.WriteAllText(dir.FullName + ".js", ZoneTableToJson(zt));
            }

            if (dir.Extension == ".js")
            {
                try
                {
                    FileStream file = File.Open(Path.ChangeExtension(dir.FullName, null), FileMode.OpenOrCreate);
                    JsonToZoneTable(File.ReadAllText(args[0])).SaveToFile(ref file);
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

        static string ZoneTableToJson(CreatureTable zt)
        {
            Console.WriteLine("Serializing CreatureTable. Please Wait.");
            string json = JsonConvert.SerializeObject(zt, Formatting.Indented);
            Console.WriteLine("Finished serializing JSON File");

            return json;
        }

        static CreatureTable JsonToZoneTable(string json)
        {
            Console.WriteLine("Deserializing JSON File. Please Wait.");
            CreatureTable tl = JsonConvert.DeserializeObject<CreatureTable>(json);
            Console.WriteLine("Finished deserializing JSON File.");

            return tl;
        }
    }
}
