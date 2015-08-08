using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace InfoLib
{
    public class ZoneTable
    {
        public List<Zone> Zones;

        public ZoneTable() { } // JSON.Net bug workaround
        public ZoneTable(ref FileStream file)
        {
            //Quantity
            UInt32 quantity = BinarySerializer.ReadUInt32(ref file);

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
            BinarySerializer.WriteUInt32(ref file, (UInt32)this.Zones.Count);

            //ItemTables
            foreach (Zone i in this.Zones)
            {
                i.SaveToFile(ref file);
            }
        }
    }
}
