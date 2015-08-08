using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace InfoLib
{
    public class CreatureTable
    {
        public List<Creature> Creatures;

        public CreatureTable() { } // JSON.Net bug workaround
        public CreatureTable(ref FileStream file)
        {
            //Quantity
            UInt32 quantity = BinarySerializer.ReadUInt32(ref file);

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
            BinarySerializer.WriteUInt32(ref file, (UInt32)this.Creatures.Count);

            //Creatures
            foreach (Creature i in this.Creatures)
            {
                i.SaveToFile(ref file);
            }
        }
    }
}
