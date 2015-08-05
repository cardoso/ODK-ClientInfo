using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ItemTable_Converter
{
    class ItemTableList
    {
        //public UInt32 Quantity;

        public List<ItemTable> ItemTables;

        public ItemTableList() { }
        public ItemTableList(ref FileStream file)
        {
            //Quantity
            byte[] _quantity = new byte[4];

            file.Read(_quantity, 0, 4);

            UInt32 quantity = BitConverter.ToUInt32(_quantity, 0);

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
            byte[] quantity = BitConverter.GetBytes(this.ItemTables.Count);

            file.Write(quantity, 0, quantity.Length);

            //ItemTables
            foreach (ItemTable i in this.ItemTables)
            {
                i.SaveToFile(ref file);
            }
        }
    }
}
