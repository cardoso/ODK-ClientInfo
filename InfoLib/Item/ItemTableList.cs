using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace InfoLib
{
    public class ItemTableList
    {
        //public UInt32 Quantity;

        public List<ItemTable> ItemTables;

        public ItemTableList() { }
        public ItemTableList(ref FileStream file)
        {
            //Quantity
            UInt32 quantity = BinarySerializer.ReadUInt32(ref file);

            //ItemTables
            this.ItemTables = new List<ItemTable>();
            for (int i = 0; i < quantity; i++)
            {
                this.ItemTables.Add(new ItemTable(ref file));
            }
        }

        public void SaveToFile(ref FileStream file)
        {
            //Quantity
            BinarySerializer.WriteUInt32(ref file, (UInt32)this.ItemTables.Count);

            //ItemTables
            foreach (ItemTable i in this.ItemTables)
            {
                i.SaveToFile(ref file);
            }
        }
    }
}
