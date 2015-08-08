using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace InfoLib
{
    public class ItemTable
    {
        //public UInt32 Quantity;

        public List<Item> Items;

        public ItemTable() { } // JSON.Net bug workaround
        public ItemTable(ref FileStream file)
        {
            //Quantity
            UInt32 quantity = BinarySerializer.ReadUInt32(ref file);

            //Items
            this.Items = new List<Item>();
            for (UInt32 i = 0; i < quantity; i++)
            {
                this.Items.Add(new Item(ref file));
            }
        }

        public void SaveToFile(ref FileStream file)
        {
            //Quantity
            BinarySerializer.WriteUInt32(ref file, (UInt32)this.Items.Count);

            //Items
            foreach (Item i in this.Items)
            {
                i.SaveToFile(ref file);
            }
        }
    }
}
