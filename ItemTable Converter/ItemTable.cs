using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ItemTable_Converter
{
    class ItemTable
    {
        //public UInt32 Quantity;

        public List<Item> Items;

        public ItemTable() { } // JSON.Net bug workaround
        public ItemTable(ref FileStream file)
        {
            //Quantity
            byte[] _quantity = new byte[4];

            file.Read(_quantity, 0, 4);

            UInt32 quantity = BitConverter.ToUInt32(_quantity, 0);

            //Items
            this.Items = new List<Item>();
            for (int i = 0; i < quantity; i++)
            {
                this.Items.Add(new Item(ref file));
            }
        }

        public void SaveToFile(ref FileStream file)
        {
            //Quantity
            byte[] quantity = BitConverter.GetBytes(this.Items.Count);

            file.Write(quantity, 0, quantity.Length);

            //Items
            foreach (Item i in this.Items)
            {
                i.SaveToFile(ref file);
            }
        }
    }
}
