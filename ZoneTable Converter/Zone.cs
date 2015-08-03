using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ZoneTable_Converter
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
        public List<UInt32> NewValue668;

        public Zone() { }

        public Zone(ref FileStream file)
        {
            //ID
            byte[] _id = new byte[2];

            file.Read(_id, 0, 2);

            this.ID = BitConverter.ToUInt16(_id, 0);

            //Name
            byte[] _namesize = new byte[4];
            file.Read(_namesize, 0, 4);
            int namesize = BitConverter.ToInt32(_namesize, 0);

            byte[] _name = new byte[namesize];
            file.Read(_name, 0, namesize);

            this.Name = EncodingHelper.encName.GetString(_name);

            //Property
            this.Property = (byte)file.ReadByte();

            //MusicID
            byte[] _musicid = new byte[2];

            file.Read(_musicid, 0, 2);

            this.MusicID = BitConverter.ToUInt16(_musicid, 0);

            //FileName
            byte[] _filenamesize = new byte[4];
            file.Read(_filenamesize, 0, 4);
            int filenamesize = BitConverter.ToInt32(_filenamesize, 0);

            byte[] _filename = new byte[filenamesize];
            file.Read(_filename, 0, filenamesize);

            this.FileName = Encoding.ASCII.GetString(_filename);

            //InfoFileName
            byte[] _infofilenamesize = new byte[4];
            file.Read(_infofilenamesize, 0, 4);
            int infofilenamesize = BitConverter.ToInt32(_infofilenamesize, 0);

            byte[] _infofilename = new byte[infofilenamesize];
            file.Read(_infofilename, 0, infofilenamesize);

            this.InfoFileName = Encoding.ASCII.GetString(_infofilename);

            //TeenFileName
            byte[] _teenfilenamesize = new byte[4];
            file.Read(_teenfilenamesize, 0, 4);
            int teenfilenamesize = BitConverter.ToInt32(_teenfilenamesize, 0);

            byte[] _teenfilename = new byte[teenfilenamesize];
            file.Read(_teenfilename, 0, teenfilenamesize);

            this.TeenFileName = Encoding.ASCII.GetString(_teenfilename);

            //SoundIDList
            byte[] _soundidlistsize = new byte[4];
            file.Read(_soundidlistsize, 0, 4);
            int soundidlistsize = BitConverter.ToInt32(_soundidlistsize, 0);

            this.SoundIDList = new List<UInt16>();

            for(int i = 0; i < soundidlistsize; i++)
            {
                byte[] _soundid = new byte[2];

                file.Read(_soundid, 0, 2);

                this.SoundIDList.Add(BitConverter.ToUInt16(_soundid, 0));
            }
            
            //Safety
            this.Safety = Convert.ToBoolean(file.ReadByte());

            //CreatureColorSet
            byte[] _creaturecolorset = new byte[2];

            file.Read(_creaturecolorset, 0, 2);

            this.CreatureColorSet = BitConverter.ToUInt16(_creaturecolorset, 0);

            //MinimapSpriteID
            byte[] _minimapspriteid = new byte[2];

            file.Read(_minimapspriteid, 0, 2);

            this.MinimapSpriteID = BitConverter.ToUInt16(_minimapspriteid, 0);

            //HolyLand
            this.HolyLand = Convert.ToBoolean(file.ReadByte());
            //ChatMaskByRace
            this.ChatMaskByRace = Convert.ToBoolean(file.ReadByte());
            //CannotAttackInSafe
            this.CannotAttackInSafe = Convert.ToBoolean(file.ReadByte());
            //CannotUseSpecialItem
            this.CannotUseSpecialItem = Convert.ToBoolean(file.ReadByte());
            //CompetenceZone
            this.CompetenceZone = Convert.ToBoolean(file.ReadByte());

            //PKType
            this.PKType = (byte)file.ReadByte();

            //WorldMapType
            byte[] _worldmaptype = new byte[4];
            file.Read(_worldmaptype, 0, 4);
            this.WorldMapType = BitConverter.ToInt32(_worldmaptype, 0);

            if (this.WorldMapType == 0)
            {
                //PaymentType
                byte[] _paymenttype = new byte[4];
                file.Read(_paymenttype, 0, 4);
                this.PaymentType = BitConverter.ToInt32(_paymenttype, 0);

                //WorldMapPosition_X
                byte[] _worldmappositionx = new byte[4];
                file.Read(_worldmappositionx, 0, 4);
                this.WorldMapPosition_X = BitConverter.ToInt32(_worldmappositionx, 0);

                //WorldMapPosition_Y
                byte[] _worldmappositiony = new byte[4];
                file.Read(_worldmappositiony, 0, 4);
                this.WorldMapPosition_Y = BitConverter.ToInt32(_worldmappositiony, 0);

                //WorldMapPosition_Width
                byte[] _worldmappositionwidth = new byte[4];
                file.Read(_worldmappositionwidth, 0, 4);
                this.WorldMapPosition_Width = BitConverter.ToInt32(_worldmappositionwidth, 0);

                //WorldMapPosition_Height
                byte[] _worldmappositionheight = new byte[4];
                file.Read(_worldmappositionheight, 0, 4);
                this.WorldMapPosition_Height = BitConverter.ToInt32(_worldmappositionheight, 0);

                //EncourageSlayerLevelMin
                this.EncourageSlayerLevelMin = (byte)file.ReadByte();
                //EncourageSlayerLevelMax
                this.EncourageSlayerLevelMax = (byte)file.ReadByte();
                //EncourageVampireLevelMin
                this.EncourageVampireLevelMin = (byte)file.ReadByte();
                //EncourageVampireLevelMax
                this.EncourageVampireLevelMax = (byte)file.ReadByte();
                //EncourageOustersLevelMin
                this.EncourageOustersLevelMin = (byte)file.ReadByte();
                //EncourageOustersLevelMax
                this.EncourageOustersLevelMax = (byte)file.ReadByte();

                //MiscDescription
                byte[] _miscdescriptionsize = new byte[4];
                file.Read(_miscdescriptionsize, 0, 4);
                int miscdescriptionsize = BitConverter.ToInt32(_miscdescriptionsize, 0);

                byte[] _miscdescription = new byte[miscdescriptionsize];
                file.Read(_miscdescription, 0, miscdescriptionsize);

                this.MiscDescription = Encoding.ASCII.GetString(_miscdescription);
            }

            //MapShapeList
            byte mapshapelistsize = (byte)file.ReadByte();

            this.MapShapeList = new List<string>();

            for(int i = 0; i < mapshapelistsize; i++)
            {
                byte[] _mapshapesize = new byte[4];
                file.Read(_mapshapesize, 0, 4);
                int mapshapesize = BitConverter.ToInt32(_mapshapesize, 0);

                byte[] _mapshape = new byte[mapshapesize];
                file.Read(_mapshape, 0, mapshapesize);

                this.MapShapeList.Add(Encoding.ASCII.GetString(_mapshape));
            }

            //NewValue668
            byte[] _newvalue668size = new byte[4];
            file.Read(_newvalue668size, 0, 4);
            int newvalue668size = BitConverter.ToInt32(_newvalue668size, 0);

            this.NewValue668 = new List<UInt32>();

            for (int i = 0; i < newvalue668size; i++)
            {
                byte[] _nv668 = new byte[4];

                file.Read(_nv668, 0, 4);

                this.NewValue668.Add(BitConverter.ToUInt32(_nv668, 0));
            }
        }

        public void SaveToFile(ref FileStream file)
        {
            //ID
            byte[] id = BitConverter.GetBytes(this.ID);
            file.Write(id, 0, id.Length);

            //Name
            byte[] namesize = BitConverter.GetBytes(EncodingHelper.encName.GetBytes(this.Name).Length);
            byte[] name = EncodingHelper.encName.GetBytes(this.Name);
            file.Write(namesize, 0, namesize.Length);
            file.Write(name, 0, name.Length);

            //Property
            file.WriteByte(this.Property);

            //MusicID
            byte[] musicid = BitConverter.GetBytes(this.MusicID);
            file.Write(musicid, 0, musicid.Length);

            //FileName
            byte[] filenamesize = BitConverter.GetBytes(Encoding.ASCII.GetBytes(this.FileName).Length);
            byte[] filename = Encoding.ASCII.GetBytes(this.FileName);
            file.Write(filenamesize, 0, filenamesize.Length);
            file.Write(filename, 0, filename.Length);

            //InfoFileName
            byte[] infofilenamesize = BitConverter.GetBytes(Encoding.ASCII.GetBytes(this.InfoFileName).Length);
            byte[] infofilename = Encoding.ASCII.GetBytes(this.InfoFileName);
            file.Write(infofilenamesize, 0, infofilenamesize.Length);
            file.Write(infofilename, 0, infofilename.Length);

            //TeenFileName
            byte[] teenfilenamesize = BitConverter.GetBytes(Encoding.ASCII.GetBytes(this.TeenFileName).Length);
            byte[] teenfilename = Encoding.ASCII.GetBytes(this.TeenFileName);
            file.Write(teenfilenamesize, 0, teenfilenamesize.Length);
            file.Write(teenfilename, 0, teenfilename.Length);

            //SoundIDList
            byte[] soundidlistsize = BitConverter.GetBytes(this.SoundIDList.Count);
            file.Write(soundidlistsize, 0, soundidlistsize.Length);

            for (int i = 0; i < this.SoundIDList.Count; i++)
            {
                byte[] soundid = BitConverter.GetBytes(this.SoundIDList[i]);
                file.Write(soundid, 0, soundid.Length);
            }

            //Safety
            file.WriteByte(BitConverter.GetBytes(this.Safety)[0]);

            //CreatureColorSet
            byte[] creaturecolorset = BitConverter.GetBytes(this.CreatureColorSet);
            file.Write(creaturecolorset, 0, creaturecolorset.Length);

            //MinimapSpriteID
            byte[] minimapspriteid = BitConverter.GetBytes(this.MinimapSpriteID);
            file.Write(minimapspriteid, 0, minimapspriteid.Length);

            //HolyLand
            file.WriteByte(BitConverter.GetBytes(this.HolyLand)[0]);
            //ChatMaskByRace
            file.WriteByte(BitConverter.GetBytes(this.ChatMaskByRace)[0]);
            //CannotAttackInSafe
            file.WriteByte(BitConverter.GetBytes(this.CannotAttackInSafe)[0]);
            //CannotUseSpecialItem
            file.WriteByte(BitConverter.GetBytes(this.CannotUseSpecialItem)[0]);
            //CompetenceZone
            file.WriteByte(BitConverter.GetBytes(this.CompetenceZone)[0]);

            //PKType
            file.WriteByte(this.PKType);

            //WorldMapType
            byte[] worldmaptype = BitConverter.GetBytes(this.WorldMapType);
            file.Write(worldmaptype, 0, worldmaptype.Length);

            if (this.WorldMapType == 0)
            {
                //PaymentType
                byte[] paymenttype = BitConverter.GetBytes(this.PaymentType);
                file.Write(paymenttype, 0, paymenttype.Length);

                //WorldMapPosition_X
                byte[] worldmappositionx = BitConverter.GetBytes(this.WorldMapPosition_X);
                file.Write(worldmappositionx, 0, worldmappositionx.Length);

                //WorldMapPosition_Y
                byte[] worldmappositiony = BitConverter.GetBytes(this.WorldMapPosition_Y);
                file.Write(worldmappositiony, 0, worldmappositiony.Length);

                //WorldMapPosition_Width
                byte[] worldmappositionwidth = BitConverter.GetBytes(this.WorldMapPosition_Width);
                file.Write(worldmappositionwidth, 0, worldmappositionwidth.Length);

                //WorldMapPosition_Height
                byte[] worldmappositionheight = BitConverter.GetBytes(this.WorldMapPosition_Height);
                file.Write(worldmappositionheight, 0, worldmappositionheight.Length);

                //EncourageSlayerLevelMin
                file.WriteByte(EncourageSlayerLevelMin);
                //EncourageSlayerLevelMax
                file.WriteByte(EncourageSlayerLevelMax);
                //EncourageVampireLevelMin
                file.WriteByte(EncourageVampireLevelMin);
                //EncourageVampireLevelMax
                file.WriteByte(EncourageVampireLevelMax);
                //EncourageOustersLevelMin
                file.WriteByte(EncourageOustersLevelMin);
                //EncourageOustersLevelMax
                file.WriteByte(EncourageOustersLevelMax);

                //MiscDescription
                byte[] miscdescriptionsize = BitConverter.GetBytes(Encoding.ASCII.GetBytes(this.MiscDescription).Length);
                byte[] miscdescription = Encoding.ASCII.GetBytes(this.MiscDescription);
                file.Write(miscdescriptionsize, 0, miscdescriptionsize.Length);
                file.Write(miscdescription, 0, miscdescription.Length);
            }

            //MapShapeList
            file.WriteByte((byte)this.MapShapeList.Count);

            for (int i = 0; i < this.MapShapeList.Count; i++)
            {
                byte[] mapshapesize = BitConverter.GetBytes(this.MapShapeList[i].Length);
                byte[] mapshape = Encoding.ASCII.GetBytes(this.MapShapeList[i]);
                file.Write(mapshapesize, 0, mapshapesize.Length);
                file.Write(mapshape, 0, mapshape.Length);
            }

            //NewValue668
            byte[] newvalue668size = BitConverter.GetBytes(this.NewValue668.Count);
            file.Write(newvalue668size, 0, newvalue668size.Length);

            for (int i = 0; i < this.NewValue668.Count; i++)
            {
                byte[] nv668 = BitConverter.GetBytes(this.NewValue668[i]);
                file.Write(nv668, 0, nv668.Length);
            }
        }
    }
}
