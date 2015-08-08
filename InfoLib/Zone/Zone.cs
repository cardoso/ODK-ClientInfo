using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace InfoLib
{
    public class Zone
    {
        public UInt16 ID;

        public string Name;

        public byte Property;

        public UInt16 MusicID;

        public string FileName;

        public string InfoFileName;

        public string TeenFileName;

        public List<UInt16> SoundIDList;

        public bool Safety;

        public UInt16 CreatureColorSet;

        public UInt16 MinimapSpriteID;

        public bool HolyLand;

        public bool ChatMaskByRace;

        public bool CannotAttackInSafe;

        public bool CannotUseSpecialItem;

        public bool CompetenceZone;

        public byte PKType;

        public int WorldMapType;

        public int PaymentType;

        public int WorldMapPosition_X, WorldMapPosition_Y, WorldMapPosition_Width, WorldMapPosition_Height;

        public byte EncourageSlayerLevelMin;
        public byte EncourageSlayerLevelMax;
        public byte EncourageVampireLevelMin;
        public byte EncourageVampireLevelMax;
        public byte EncourageOustersLevelMin;
        public byte EncourageOustersLevelMax;

        public string MiscDescription;

        public List<string> MapShapeList;

        //6.68 only
        //public List<UInt32> NewValue668;

        public Zone() { }

        public Zone(ref FileStream file)
        {
            //ID
            this.ID = BinarySerializer.ReadUInt16(ref file);

            //Name
            this.Name = BinarySerializer.ReadString(ref file, Encoding.ASCII);

            //Property
            this.Property = (byte)file.ReadByte();

            //MusicID
            this.MusicID = BinarySerializer.ReadUInt16(ref file);

            //FileName
            this.FileName = BinarySerializer.ReadString(ref file, Encoding.ASCII);

            //InfoFileName
            this.InfoFileName = BinarySerializer.ReadString(ref file, Encoding.ASCII);

            //TeenFileName
            this.TeenFileName = BinarySerializer.ReadString(ref file, Encoding.ASCII);

            //SoundIDList
            UInt32 soundidlistsize = BinarySerializer.ReadUInt32(ref file);

            this.SoundIDList = new List<UInt16>();

            for(int i = 0; i < soundidlistsize; i++)
            {
                UInt16 soundid = BinarySerializer.ReadUInt16(ref file);
                this.SoundIDList.Add(soundid);
            }
            
            //Safety
            this.Safety = BinarySerializer.ReadBool(ref file);

            //CreatureColorSet
            this.CreatureColorSet = BinarySerializer.ReadUInt16(ref file);

            //MinimapSpriteID
            this.MinimapSpriteID = BinarySerializer.ReadUInt16(ref file);

            //HolyLand
            this.HolyLand = BinarySerializer.ReadBool(ref file);
            //ChatMaskByRace
            this.ChatMaskByRace = BinarySerializer.ReadBool(ref file);
            //CannotAttackInSafe
            this.CannotAttackInSafe = BinarySerializer.ReadBool(ref file);
            //CannotUseSpecialItem
            this.CannotUseSpecialItem = BinarySerializer.ReadBool(ref file);
            //CompetenceZone
            this.CompetenceZone = BinarySerializer.ReadBool(ref file);

            //PKType
            this.PKType = BinarySerializer.ReadByte(ref file);

            //WorldMapType
            this.WorldMapType = BinarySerializer.ReadInt32(ref file);

            if (this.WorldMapType == 0)
            {
                //PaymentType
                this.PaymentType = BinarySerializer.ReadInt32(ref file);

                //WorldMapPosition_X
                this.WorldMapPosition_X = BinarySerializer.ReadInt32(ref file);

                //WorldMapPosition_Y
                this.WorldMapPosition_Y = BinarySerializer.ReadInt32(ref file);

                //WorldMapPosition_Width
                this.WorldMapPosition_Width = BinarySerializer.ReadInt32(ref file);

                //WorldMapPosition_Height
                this.WorldMapPosition_Height = BinarySerializer.ReadInt32(ref file);

                //EncourageSlayerLevelMin
                this.EncourageSlayerLevelMin = BinarySerializer.ReadByte(ref file);
                //EncourageSlayerLevelMax
                this.EncourageSlayerLevelMax = BinarySerializer.ReadByte(ref file);
                //EncourageVampireLevelMin
                this.EncourageVampireLevelMin = BinarySerializer.ReadByte(ref file);
                //EncourageVampireLevelMax
                this.EncourageVampireLevelMax = BinarySerializer.ReadByte(ref file);
                //EncourageOustersLevelMin
                this.EncourageOustersLevelMin = BinarySerializer.ReadByte(ref file);
                //EncourageOustersLevelMax
                this.EncourageOustersLevelMax = BinarySerializer.ReadByte(ref file);

                //MiscDescription
                this.MiscDescription = BinarySerializer.ReadString(ref file, Encoding.ASCII);
            }

            //MapShapeList
            byte mapshapelistsize = BinarySerializer.ReadByte(ref file);

            this.MapShapeList = new List<string>();

            for(int i = 0; i < mapshapelistsize; i++)
            {
                this.MapShapeList.Add(BinarySerializer.ReadString(ref file, Encoding.ASCII));
            }

            //NewValue668
            /*UInt32 newvalue668size = BinarySerializer.ReadUInt32(ref file);

            this.NewValue668 = new List<UInt32>();

            for (UInt32 i = 0; i < newvalue668size; i++)
            {
                thisNewValue668.Add(BinarySerializer.ReadUInt32(ref file));
            }*/
        }

        public void SaveToFile(ref FileStream file)
        {
            //ID
            byte[] id = BitConverter.GetBytes(this.ID);
            file.Write(id, 0, id.Length);

            //Name
            BinarySerializer.WriteString(ref file, Encoding.ASCII, this.Name);

            //Property
            BinarySerializer.WriteByte(ref file, this.Property);

            //MusicID
            BinarySerializer.WriteUInt16(ref file, this.MusicID);

            //FileName
            BinarySerializer.WriteString(ref file, Encoding.ASCII, this.FileName);

            //InfoFileName
            BinarySerializer.WriteString(ref file, Encoding.ASCII, this.InfoFileName);

            //TeenFileName
            BinarySerializer.WriteString(ref file, Encoding.ASCII, this.TeenFileName);

            //SoundIDList
            BinarySerializer.WriteUInt32(ref file, (UInt32)this.SoundIDList.Count);

            for (int i = 0; i < this.SoundIDList.Count; i++)
                BinarySerializer.WriteUInt16(ref file, this.SoundIDList[i]);

            //Safety
            BinarySerializer.WriteBool(ref file, this.Safety);

            //CreatureColorSet
            BinarySerializer.WriteUInt16(ref file, this.CreatureColorSet);

            //MinimapSpriteID
            BinarySerializer.WriteUInt16(ref file, this.MinimapSpriteID);

            //HolyLand
            BinarySerializer.WriteBool(ref file, this.HolyLand);
            //ChatMaskByRace
            BinarySerializer.WriteBool(ref file, this.ChatMaskByRace);
            //CannotAttackInSafe
            BinarySerializer.WriteBool(ref file, this.CannotAttackInSafe);
            //CannotUseSpecialItem
            BinarySerializer.WriteBool(ref file, this.CannotUseSpecialItem);
            //CompetenceZone
            BinarySerializer.WriteBool(ref file, this.CompetenceZone);

            //PKType
            BinarySerializer.WriteByte(ref file, this.PKType);

            //WorldMapType
            BinarySerializer.WriteInt32(ref file, this.WorldMapType);

            if (this.WorldMapType == 0)
            {
                //PaymentType
                BinarySerializer.WriteInt32(ref file, this.PaymentType);

                //WorldMapPosition_X
                BinarySerializer.WriteInt32(ref file, this.WorldMapPosition_X);

                //WorldMapPosition_Y
                BinarySerializer.WriteInt32(ref file, this.WorldMapPosition_Y);

                //WorldMapPosition_Width
                BinarySerializer.WriteInt32(ref file, this.WorldMapPosition_Width);

                //WorldMapPosition_Height
                BinarySerializer.WriteInt32(ref file, this.WorldMapPosition_Height);

                //EncourageSlayerLevelMin
                BinarySerializer.WriteByte(ref file, EncourageSlayerLevelMin);
                //EncourageSlayerLevelMax
                BinarySerializer.WriteByte(ref file, EncourageSlayerLevelMax);
                //EncourageVampireLevelMin
                BinarySerializer.WriteByte(ref file, EncourageVampireLevelMin);
                //EncourageVampireLevelMax
                BinarySerializer.WriteByte(ref file, EncourageVampireLevelMax);
                //EncourageOustersLevelMin
                BinarySerializer.WriteByte(ref file, EncourageOustersLevelMin);
                //EncourageOustersLevelMax
                BinarySerializer.WriteByte(ref file, EncourageOustersLevelMax);

                //MiscDescription
                BinarySerializer.WriteString(ref file, Encoding.ASCII, this.MiscDescription);
            }

            //MapShapeList
            BinarySerializer.WriteByte(ref file, (byte)this.MapShapeList.Count);

            for (int i = 0; i < this.MapShapeList.Count; i++)
                BinarySerializer.WriteString(ref file, Encoding.ASCII, this.MapShapeList[i]);

            //NewValue668
            /*BinarySerializer.WriteUInt32(ref file, (UInt32)this.NewValue668.Count);

            for (int i = 0; i < this.NewValue668.Count; i++)
            {
                BinarySerializer.WriteUInt32(ref file, this.NewValue668[i]);
            }*/
        }
    }
}
