using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ZoneTable_Converter
{
    public class ZoneTable
    {
        public List<Zone> Zones;

        public ZoneTable() { } // JSON.Net bug workaround
        public ZoneTable(ref FileStream file)
        {
            //Quantity
            byte[] _quantity = new byte[4];

            file.Read(_quantity, 0, 4);

            UInt32 quantity = BitConverter.ToUInt32(_quantity, 0);

            //Zones
            this.Zones = new List<Zone>();
            for (int i = 0; i < quantity; i++)
            {
                this.Zones.Add(new Zone(ref file));
            }
        }

        public void SaveToFile(ref FileStream file)
        {
            //Quantity
            byte[] quantity = BitConverter.GetBytes(this.Zones.Count);

            file.Write(quantity, 0, quantity.Length);

            //ItemTables
            foreach (Zone i in this.Zones)
            {
                i.SaveToFile(ref file);
            }
        }
    }
}
