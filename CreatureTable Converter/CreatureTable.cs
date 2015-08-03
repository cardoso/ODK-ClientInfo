using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CreatureTable_Converter
{
    public class CreatureTable
    {
        public List<Creature> Creatures;

        public CreatureTable() { } // JSON.Net bug workaround
        public CreatureTable(ref FileStream file)
        {
            //Quantity
            byte[] _quantity = new byte[4];

            file.Read(_quantity, 0, 4);

            UInt32 quantity = BitConverter.ToUInt32(_quantity, 0);

            //Creatures
            this.Creatures = new List<Creature>();
            for (int i = 0; i < quantity; i++)
            {
                this.Creatures.Add(new Creature(ref file));
            }
        }

        public void SaveToFile(ref FileStream file)
        {
            //Quantity
            byte[] quantity = BitConverter.GetBytes(this.Creatures.Count);

            file.Write(quantity, 0, quantity.Length);

            //Creatures
            foreach (Creature i in this.Creatures)
            {
                i.SaveToFile(ref file);
            }
        }
    }
}
