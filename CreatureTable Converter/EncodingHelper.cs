using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CreatureTable_Converter
{
    public static class EncodingHelper
    {
        public static Encoding encName = Encoding.ASCII;

        public static void Initialize()
        {
            if (File.Exists("./encoding.ini"))
            {
                string str = File.ReadAllText("./encoding.ini");

                string del = ";";
                string name = "NAME=";

                int inm = str.IndexOf(name) + name.Length;
                int idel = 0;

                //HName encoding
                idel = str.IndexOf(del, inm);
                string enc = str.Substring(inm, idel - inm);
                try
                {
                    encName = Encoding.GetEncoding(enc);
                }
                catch
                {
                    Console.WriteLine("[encoding.ini]Could not find Name encoding \"" + enc + "\". Falling back to ASCII (English).");
                }
            }
            else
            {
                StreamWriter sw = File.CreateText("./encoding.ini");

                sw.WriteLine("#Encoding settings for item.inf converter");
                sw.WriteLine("#Use correct encoding for English, Korean or Chinese characters.");
                sw.WriteLine("#ENGLISH is \"ASCII\"");
                sw.WriteLine("#KOREAN is \"EUC-KR\"");
                sw.WriteLine("#CHINESE is \"EUC-CN\"");
                sw.WriteLine("NAME=ASCII;");

                sw.Close();
            }
        }
    }
}
