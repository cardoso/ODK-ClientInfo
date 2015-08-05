using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ItemTable_Converter
{
    static class EncodingHelper
    {
        public static Encoding encHName = Encoding.ASCII;
        public static Encoding encEName = Encoding.ASCII;
        public static Encoding encDesc = Encoding.ASCII;

        public static void Initialize()
        {
            if (File.Exists("./encoding.ini"))
            {
                string str = File.ReadAllText("./encoding.ini");

                string del = ";";
                string hname = "HNAME=";
                string ename = "ENAME=";
                string desc = "DESCRIPTION=";

                int ihnm = str.IndexOf(hname) + hname.Length;
                int ienm = str.IndexOf(ename) + ename.Length;
                int idsc = str.IndexOf(desc) + desc.Length;
                int idel = 0;

                //HName encoding
                idel = str.IndexOf(del, ihnm);
                string henc = str.Substring(ihnm, idel - ihnm);
                try
                {
                    encHName = Encoding.GetEncoding(henc);
                }
                catch
                {
                    Console.WriteLine("[encoding.ini]Could not find HName encoding \"" + henc + "\". Falling back to ASCII (English).");
                }

                //EName encoding
                idel = str.IndexOf(del, ienm);
                string eenc = str.Substring(ienm, idel - ienm);
                try
                {
                    encEName = Encoding.GetEncoding(eenc);
                }
                catch
                {
                    Console.WriteLine("[encoding.ini]Could not find EName encoding \"" + eenc + "\". Falling back to ASCII (English).");
                }

                //Description encoding
                idel = str.IndexOf(del, idsc);
                string denc = str.Substring(idsc, idel - idsc);
                try
                {
                    encDesc = Encoding.GetEncoding(denc);
                }
                catch
                {
                    Console.WriteLine("[encoding.ini]Could not find Description encoding \"" + denc + "\". Falling back to ASCII (English).");
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
                sw.WriteLine("HNAME=ASCII;");
                sw.WriteLine("ENAME=ASCII;");
                sw.WriteLine("DESCRIPTION=ASCII;");

                sw.Close();
            }
        }
    }
}
