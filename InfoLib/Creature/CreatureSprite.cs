using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace InfoLib
{
    public class CreatureSprite
    {
        public UInt16 FrameID;

        public UInt32 SpriteFilePosition;
        public UInt32 SpriteShadowFilePosition;

        public UInt16 FirstSpriteID;
        public UInt16 LastSpriteID;
        public UInt16 FirstShadowSpriteID;
        public UInt16 LastShadowSpriteID;

/*
 * FLAG_CREATURESPRITE_SLAYER				0x01
 * FLAG_CREATURESPRITE_VAMPIRE				0x02
 * FLAG_CREATURESPRITE_OUSTERS				0x04
 * FLAG_CREATURESPRITE_PLAYER				0x10
 * FLAG_CREATURESPRITE_NPC					0x20
 * FLAG_CREATURESPRITE_MONSTER				0x40
 */

        public byte CreatureType;

        // JSON.NET bug workaround
        public CreatureSprite() { }

        public CreatureSprite(ref FileStream file)
        {
            //FrameID
            this.FrameID = BinarySerializer.ReadUInt16(ref file);

            //SpriteFilePosition
            this.SpriteFilePosition = BinarySerializer.ReadUInt32(ref file);

            //SpriteShadowFilePosition
            this.SpriteShadowFilePosition = BinarySerializer.ReadUInt32(ref file);

            //FirstSpriteID
            this.FirstSpriteID = BinarySerializer.ReadUInt16(ref file);

            //LastSpriteID
            this.LastSpriteID = BinarySerializer.ReadUInt16(ref file);

            //FirstShadowSpriteID
            this.FirstShadowSpriteID = BinarySerializer.ReadUInt16(ref file);

            //LastShadowSpriteID
            this.LastShadowSpriteID = BinarySerializer.ReadUInt16(ref file);
        }

        public void SaveToFile(ref FileStream file)
        {
            //FrameID
            BinarySerializer.WriteUInt16(ref file, this.FrameID);

            //SpriteFilePosition
            BinarySerializer.WriteUInt32(ref file, this.SpriteFilePosition);

            //SpriteShadowFilePosition
            BinarySerializer.WriteUInt32(ref file, this.SpriteShadowFilePosition);

            //FirstSpriteID
            BinarySerializer.WriteUInt16(ref file, this.FirstSpriteID);

            //LastSpriteID
            BinarySerializer.WriteUInt16(ref file, this.LastSpriteID);

            //FirstShadowSpriteID
            BinarySerializer.WriteUInt16(ref file, this.FirstShadowSpriteID);

            //LastShadowSpriteID
            BinarySerializer.WriteUInt16(ref file, this.LastShadowSpriteID);
        }
    }
}
