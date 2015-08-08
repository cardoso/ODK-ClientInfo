using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace InfoLib
{
    public class CreatureSpriteTable
    {
        public List<CreatureSprite> CreatureSprites;

        public CreatureSpriteTable() { } // JSON.Net bug workaround
        public CreatureSpriteTable(ref FileStream file)
        {
            //Quantity
            UInt32 quantity = BinarySerializer.ReadUInt32(ref file);

            //CreatureSprites
            this.CreatureSprites = new List<CreatureSprite>();
            for (int i = 0; i < quantity; i++)
            {
                this.CreatureSprites.Add(new CreatureSprite(ref file));
            }
        }

        public void SaveToFile(ref FileStream file)
        {
            //Quantity
            BinarySerializer.WriteUInt32(ref file, (UInt32)this.CreatureSprites.Count);

            //CreatureSprites
            foreach (CreatureSprite i in this.CreatureSprites)
            {
                i.SaveToFile(ref file);
            }
        }
    }
}
