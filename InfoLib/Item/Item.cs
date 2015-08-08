using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace InfoLib
{
    public class Item
    {
        public string HName;
        public string EName;
        public string Description;

        public UInt16 TileFrameID;
        public UInt16 InventoryFrameID;
        public UInt16 GearFrameID;
        public UInt16 DropFrameID;
        public UInt16 AddonMaleFrameID;
        public UInt16 AddonFemaleFrameID;
        public UInt16 UseFrameID;

        public UInt16 UseSoundID;
        public UInt16 TileSoundID;
        public UInt16 InventorySoundID;
        public UInt16 GearSoundID;

        public byte GridWidth;
        public byte GridHeight;

        public UInt32 Price;

        public UInt16 Weight;

        public Int32 Value1;
        public Int32 Value2;
        public Int32 Value3;
        public Int32 Value4;
        public Int32 Value5;
        public Int32 Value6;
        public Int32 Value7;

        public byte RequireSTR;
        public byte RequireDEX;
        public byte RequireINT;

        public UInt16 RequireSUM;

        public byte RequireLevel;
        public byte RequireAdvancementLevel;

        public bool bMaleOnly;
        public bool bFemaleOnly;

        public UInt32 UseActionInfo;

        public Int32 SilverMax;
        public Int32 ToHit;

        public UInt32 MaxNumber;

        public Int32 CriticalHit;

        //public byte DefaultOptionListSize;

        public List<byte> DefaultOptionList;

        public Int32 ItemStyle;

        public int ElementalType; //ELEMENTAL_TYPE

        public UInt16 Elemental;

        public byte Race;

        public UInt16 DescriptionFrameID;

        public byte ItemMoveControl;//UInt32

        public byte ItemCanAdvance;//UInt32

        public UInt32 DropItemNameTag;

        public Int32 NormalItemGrade;

        //public List<byte> NewValue668;

        public Item() { } // JSON.Net bug workaround

        public Item(ref FileStream file)
        {
            //HName
            this.HName = BinarySerializer.ReadString(ref file, Encoding.ASCII);

            //EName
            this.EName = BinarySerializer.ReadString(ref file, Encoding.ASCII);

            //Description
            this.Description = BinarySerializer.ReadString(ref file, Encoding.ASCII);

            //FrameID's
            this.TileFrameID = BinarySerializer.ReadUInt16(ref file);
            this.InventoryFrameID = BinarySerializer.ReadUInt16(ref file);
            this.GearFrameID = BinarySerializer.ReadUInt16(ref file);
            this.DropFrameID = BinarySerializer.ReadUInt16(ref file);
            this.AddonMaleFrameID = BinarySerializer.ReadUInt16(ref file);
            this.AddonFemaleFrameID = BinarySerializer.ReadUInt16(ref file);
            this.UseFrameID = BinarySerializer.ReadUInt16(ref file);

            //SoundID's
            this.UseSoundID = BinarySerializer.ReadUInt16(ref file);
            this.TileSoundID = BinarySerializer.ReadUInt16(ref file);
            this.InventorySoundID = BinarySerializer.ReadUInt16(ref file);
            this.GearSoundID = BinarySerializer.ReadUInt16(ref file);

            //GridSize
            this.GridWidth = BinarySerializer.ReadByte(ref file);
            this.GridHeight = BinarySerializer.ReadByte(ref file);

            //Price
            this.Price = BinarySerializer.ReadUInt32(ref file);

            //Weight
            this.Weight = BinarySerializer.ReadUInt16(ref file);

            //Values
            this.Value1 = BinarySerializer.ReadInt32(ref file);
            this.Value2 = BinarySerializer.ReadInt32(ref file);
            this.Value3 = BinarySerializer.ReadInt32(ref file);
            this.Value4 = BinarySerializer.ReadInt32(ref file);
            this.Value5 = BinarySerializer.ReadInt32(ref file);
            this.Value6 = BinarySerializer.ReadInt32(ref file);
            this.Value7 = BinarySerializer.ReadInt32(ref file);

            //Requirements
            this.RequireSTR = BinarySerializer.ReadByte(ref file);
            this.RequireDEX = BinarySerializer.ReadByte(ref file);
            this.RequireINT = BinarySerializer.ReadByte(ref file);

            //RequireSUM
            this.RequireSUM = BinarySerializer.ReadUInt16(ref file);

            //RequireLevels
            this.RequireLevel = BinarySerializer.ReadByte(ref file);
            this.RequireAdvancementLevel = BinarySerializer.ReadByte(ref file);

            //Sex Restrictions
            this.bMaleOnly = BinarySerializer.ReadBool(ref file);
            this.bFemaleOnly = BinarySerializer.ReadBool(ref file);

            //UseActionInfo
            this.UseActionInfo = BinarySerializer.ReadUInt32(ref file);

            //Silver Max
            this.SilverMax = BinarySerializer.ReadInt32(ref file);

            //ToHit
            this.ToHit = BinarySerializer.ReadInt32(ref file);

            //Max Number
            this.MaxNumber = BinarySerializer.ReadUInt32(ref file);

            //Critical Hit
            this.CriticalHit = BinarySerializer.ReadInt32(ref file);

            //DefaultOptionList
            this.DefaultOptionList = new List<byte>();
            int _dolsize = BinarySerializer.ReadByte(ref file);

            for (int i = 0; i < _dolsize; i++)
            {
                byte _opt = BinarySerializer.ReadByte(ref file);
                this.DefaultOptionList.Add(_opt);
            }

            //Item Style
            this.ItemStyle = BinarySerializer.ReadInt32(ref file);

            //ElementalType
            this.ElementalType = BinarySerializer.ReadInt32(ref file);

            //Elemental
            this.Elemental = BinarySerializer.ReadUInt16(ref file);

            //Race
            this.Race = BinarySerializer.ReadByte(ref file);

            //DescriptionFrameID
            this.DescriptionFrameID = BinarySerializer.ReadUInt16(ref file);

            //ItemMoveControl
            this.ItemMoveControl = BinarySerializer.ReadByte(ref file);

            //ItemCanAdvance
            this.ItemCanAdvance = BinarySerializer.ReadByte(ref file);

            //DropItemNameTag
            this.DropItemNameTag = BinarySerializer.ReadByte(ref file);

            //NormalItemGrade
            this.NormalItemGrade = BinarySerializer.ReadInt32(ref file);

            //NewValue668
            /*byte[] _nv668count = new byte[4];
            file.Read(_nv668count, 0, 4);
            int nv668count = 0;
            this.NewValue668 = new List<byte>();
            for (int i = 0; i < nv668count; i++)
                this.NewValue668.Add((byte)file.ReadByte());*/
        }

        public void SaveToFile(ref FileStream file)
        {
            //HName
            BinarySerializer.WriteString(ref file, Encoding.ASCII, this.HName);

            //EName
            BinarySerializer.WriteString(ref file, Encoding.ASCII, this.EName);

            //Description
            BinarySerializer.WriteString(ref file, Encoding.ASCII, this.Description);

            //FrameID's
            BinarySerializer.WriteUInt16(ref file, this.TileFrameID);
            BinarySerializer.WriteUInt16(ref file, this.InventoryFrameID);
            BinarySerializer.WriteUInt16(ref file, this.GearFrameID);
            BinarySerializer.WriteUInt16(ref file, this.DropFrameID);
            BinarySerializer.WriteUInt16(ref file, this.AddonMaleFrameID);
            BinarySerializer.WriteUInt16(ref file, this.AddonFemaleFrameID);
            BinarySerializer.WriteUInt16(ref file, this.UseFrameID);

            //SoundID's
            BinarySerializer.WriteUInt16(ref file, this.UseSoundID);
            BinarySerializer.WriteUInt16(ref file, this.TileSoundID);
            BinarySerializer.WriteUInt16(ref file, this.InventorySoundID);
            BinarySerializer.WriteUInt16(ref file, this.GearSoundID);

            //Grid Size
            BinarySerializer.WriteByte(ref file, this.GridWidth);
            BinarySerializer.WriteByte(ref file, this.GridHeight);

            //Price
            BinarySerializer.WriteUInt32(ref file, this.Price);

            //Weight
            BinarySerializer.WriteUInt16(ref file, this.Weight);

            //Values
            BinarySerializer.WriteInt32(ref file, this.Value1);
            BinarySerializer.WriteInt32(ref file, this.Value2);
            BinarySerializer.WriteInt32(ref file, this.Value3);
            BinarySerializer.WriteInt32(ref file, this.Value4);
            BinarySerializer.WriteInt32(ref file, this.Value5);
            BinarySerializer.WriteInt32(ref file, this.Value6);
            BinarySerializer.WriteInt32(ref file, this.Value7);

            //Requirements
            BinarySerializer.WriteByte(ref file, this.RequireSTR);
            BinarySerializer.WriteByte(ref file, this.RequireDEX);
            BinarySerializer.WriteByte(ref file, this.RequireINT);

            //RequireSUM
            BinarySerializer.WriteUInt16(ref file, this.RequireSUM);


            //RequireLevels
            BinarySerializer.WriteByte(ref file, this.RequireLevel);
            BinarySerializer.WriteByte(ref file, this.RequireAdvancementLevel);

            //Sex Restrictions
            BinarySerializer.WriteBool(ref file, this.bMaleOnly);
            BinarySerializer.WriteBool(ref file, this.bFemaleOnly);

            //UseActionInfo
            BinarySerializer.WriteUInt32(ref file, this.UseActionInfo);

            //Silver Max
            BinarySerializer.WriteInt32(ref file, this.SilverMax);

            //ToHit
            BinarySerializer.WriteInt32(ref file, this.ToHit);

            //Max Number
            BinarySerializer.WriteUInt32(ref file, this.MaxNumber);

            //Critical Hit
            BinarySerializer.WriteInt32(ref file, this.CriticalHit);

            //DefaultOptionsList
            BinarySerializer.WriteByte(ref file, (byte)this.DefaultOptionList.Count);
            
            foreach (byte b in this.DefaultOptionList)
                BinarySerializer.WriteByte(ref file, b);


            //ItemStyle
            BinarySerializer.WriteInt32(ref file, this.ItemStyle);

            //ElementalType
            BinarySerializer.WriteInt32(ref file, this.ElementalType);

            //Elemental
            BinarySerializer.WriteUInt16(ref file, this.Elemental);

            //Race
            BinarySerializer.WriteByte(ref file, this.Race);

            //DescriptionFrameID
            BinarySerializer.WriteUInt16(ref file, this.DescriptionFrameID);

            //ItemMoveControl
            BinarySerializer.WriteByte(ref file, this.ItemMoveControl);

            //ItemCanAdvance
            BinarySerializer.WriteByte(ref file, this.ItemCanAdvance);

            //DropItemNameTag
            BinarySerializer.WriteUInt32(ref file, this.DropItemNameTag);


            //NormalItemGrade
            BinarySerializer.WriteInt32(ref file, this.NormalItemGrade);

            //NewValue668
            /*file.WriteByte((byte)this.NewValue668.Count);
            foreach (byte b in NewValue668)
            {
                file.WriteByte(b);
            }*/
        }
    }
}
