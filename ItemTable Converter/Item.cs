using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ItemTable_Converter
{
    class Item
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
            byte[] _hnamesize = new byte[4];
            file.Read(_hnamesize, 0, 4);
            int hnamesize = BitConverter.ToInt32(_hnamesize, 0);

            byte[] _hname = new byte[hnamesize];
            file.Read(_hname, 0, hnamesize);

            this.HName = EncodingHelper.encHName.GetString(_hname);

            //EName
            byte[] _enamesize = new byte[4];
            file.Read(_enamesize, 0, 4);
            int enamesize = BitConverter.ToInt32(_enamesize, 0);

            byte[] _ename = new byte[enamesize];
            file.Read(_ename, 0, enamesize);

            this.EName = EncodingHelper.encEName.GetString(_ename);

            //Description
            byte[] _descriptionsize = new byte[4];
            file.Read(_descriptionsize, 0, 4);
            int descriptionsize = BitConverter.ToInt32(_descriptionsize, 0);

            byte[] _description = new byte[descriptionsize];
            file.Read(_description, 0, descriptionsize);

            this.Description = EncodingHelper.encDesc.GetString(_description);

            //FrameID's
            byte[] _tileframeid = new byte[2];
            byte[] _inventoryframeid = new byte[2];
            byte[] _gearframeid = new byte[2];
            byte[] _dropframeid = new byte[2];
            byte[] _addonmaleframeid = new byte[2];
            byte[] _addonfemaleframeid = new byte[2];
            byte[] _useframeid = new byte[2];

            file.Read(_tileframeid, 0, 2);
            file.Read(_inventoryframeid, 0, 2);
            file.Read(_gearframeid, 0, 2);
            file.Read(_dropframeid, 0, 2);
            file.Read(_addonmaleframeid, 0, 2);
            file.Read(_addonfemaleframeid, 0, 2);
            file.Read(_useframeid, 0, 2);

            this.TileFrameID = BitConverter.ToUInt16(_tileframeid, 0);
            this.InventoryFrameID = BitConverter.ToUInt16(_inventoryframeid, 0);
            this.GearFrameID = BitConverter.ToUInt16(_gearframeid, 0);
            this.DropFrameID = BitConverter.ToUInt16(_dropframeid, 0);
            this.AddonMaleFrameID = BitConverter.ToUInt16(_addonmaleframeid, 0);
            this.AddonFemaleFrameID = BitConverter.ToUInt16(_addonfemaleframeid, 0);
            this.UseFrameID = BitConverter.ToUInt16(_useframeid, 0);

            //SoundID's
            byte[] _usesoundid = new byte[2];
            byte[] _tilesoundid = new byte[2];
            byte[] _inventorysoundid = new byte[2];
            byte[] _gearsoundid = new byte[2];

            file.Read(_usesoundid, 0, 2);
            file.Read(_tilesoundid, 0, 2);
            file.Read(_inventorysoundid, 0, 2);
            file.Read(_gearsoundid, 0, 2);

            this.UseSoundID = BitConverter.ToUInt16(_usesoundid, 0);
            this.TileSoundID = BitConverter.ToUInt16(_tilesoundid, 0);
            this.InventorySoundID = BitConverter.ToUInt16(_inventorysoundid, 0);
            this.GearSoundID = BitConverter.ToUInt16(_gearsoundid, 0);

            //GridSize
            this.GridWidth = (byte)file.ReadByte();
            this.GridHeight = (byte)file.ReadByte();

            //Price
            byte[] _price = new byte[4];

            file.Read(_price, 0, 4);

            this.Price = BitConverter.ToUInt32(_price, 0);

            //Weight
            byte[] _weight = new byte[2];

            file.Read(_weight, 0, 2);

            this.Weight = BitConverter.ToUInt16(_weight, 0);

            //Values
            byte[] _value1 = new byte[4];
            byte[] _value2 = new byte[4];
            byte[] _value3 = new byte[4];
            byte[] _value4 = new byte[4];
            byte[] _value5 = new byte[4];
            byte[] _value6 = new byte[4];
            byte[] _value7 = new byte[4];

            file.Read(_value1, 0, 4);
            file.Read(_value2, 0, 4);
            file.Read(_value3, 0, 4);
            file.Read(_value4, 0, 4);
            file.Read(_value5, 0, 4);
            file.Read(_value6, 0, 4);
            file.Read(_value7, 0, 4);

            this.Value1 = BitConverter.ToInt32(_value1, 0);
            this.Value2 = BitConverter.ToInt32(_value2, 0);
            this.Value3 = BitConverter.ToInt32(_value3, 0);
            this.Value4 = BitConverter.ToInt32(_value4, 0);
            this.Value5 = BitConverter.ToInt32(_value5, 0);
            this.Value6 = BitConverter.ToInt32(_value6, 0);
            this.Value7 = BitConverter.ToInt32(_value7, 0);

            //Requirements
            this.RequireSTR = (byte)file.ReadByte();
            this.RequireDEX = (byte)file.ReadByte();
            this.RequireINT = (byte)file.ReadByte();

            //RequireSUM
            byte[] _requiresum = new byte[2];

            file.Read(_requiresum, 0, 2);

            this.RequireSUM = BitConverter.ToUInt16(_requiresum, 0);

            //RequireLevels
            this.RequireLevel = (byte)file.ReadByte();
            this.RequireAdvancementLevel = (byte)file.ReadByte();

            //Sex Restrictions
            this.bMaleOnly = Convert.ToBoolean(file.ReadByte());
            this.bFemaleOnly = Convert.ToBoolean(file.ReadByte());

            //UseActionInfo
            byte[] _useactioninfo = new byte[4];

            file.Read(_useactioninfo, 0, 4);

            this.UseActionInfo = BitConverter.ToUInt32(_useactioninfo, 0);

            //Silver Max
            byte[] _silvermax = new byte[4];

            file.Read(_silvermax, 0, 4);

            this.SilverMax = BitConverter.ToInt32(_silvermax, 0);

            //ToHit
            byte[] _tohit = new byte[4];

            file.Read(_tohit, 0, 4);

            this.ToHit = BitConverter.ToInt32(_tohit, 0);

            //Max Number
            byte[] _maxnumber = new byte[4];

            file.Read(_maxnumber, 0, 4);

            this.MaxNumber = BitConverter.ToUInt32(_maxnumber, 0);

            //Critical Hit
            byte[] _criticalhit = new byte[4];

            file.Read(_criticalhit, 0, 4);

            this.CriticalHit = BitConverter.ToInt32(_criticalhit, 0);

            //DefaultOptionList
            this.DefaultOptionList = new List<byte>();
            int _dolsize = file.ReadByte();

            for (int i = 0; i < _dolsize; i++)
            {
                byte _opt = (byte)file.ReadByte();
                this.DefaultOptionList.Add(_opt);
            }

            //Item Style
            byte[] _itemstyle = new byte[4];

            file.Read(_itemstyle, 0, 4);

            this.ItemStyle = BitConverter.ToInt32(_itemstyle, 0);

            //ElementalType
            byte[] _elementaltype = new byte[4];

            file.Read(_elementaltype, 0, 4);

            this.ElementalType = BitConverter.ToInt32(_elementaltype, 0);

            //Elemental
            byte[] _elemental = new byte[2];

            file.Read(_elemental, 0, 2);

            this.Elemental = BitConverter.ToUInt16(_elemental, 0);

            //Race
            this.Race = (byte)file.ReadByte();

            //DescriptionFrameID
            byte[] _descriptionframeid = new byte[2];

            file.Read(_descriptionframeid, 0, 2);

            this.DescriptionFrameID = BitConverter.ToUInt16(_descriptionframeid, 0);

            //ItemMoveControl
            this.ItemMoveControl = (byte)file.ReadByte();

            //ItemCanAdvance
            this.ItemCanAdvance = (byte)file.ReadByte();

            //DropItemNameTag
            byte[] _dropitemnametag = new byte[4];

            file.Read(_dropitemnametag, 0, 4);

            this.DropItemNameTag = BitConverter.ToUInt32(_dropitemnametag, 0);

            //NormalItemGrade
            byte[] _normalitemgrade = new byte[4];

            file.Read(_normalitemgrade, 0, 4);

            this.NormalItemGrade = BitConverter.ToInt32(_normalitemgrade, 0);

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
            byte[] hnamesize = BitConverter.GetBytes(EncodingHelper.encHName.GetBytes(this.HName).Length);
            byte[] hname = EncodingHelper.encHName.GetBytes(this.HName);
            file.Write(hnamesize, 0, hnamesize.Length);
            file.Write(hname, 0, hname.Length);

            //EName
            byte[] enamesize = BitConverter.GetBytes(EncodingHelper.encEName.GetBytes(this.EName).Length);
            byte[] ename = EncodingHelper.encEName.GetBytes(this.EName);
            file.Write(enamesize, 0, enamesize.Length);
            file.Write(ename, 0, ename.Length);

            //Description
            byte[] descriptionsize = BitConverter.GetBytes(EncodingHelper.encDesc.GetBytes(this.Description).Length);
            byte[] description = EncodingHelper.encDesc.GetBytes(this.Description);
            file.Write(descriptionsize, 0, descriptionsize.Length);
            file.Write(description, 0, description.Length);

            //FrameID's
            byte[] tileframeid = BitConverter.GetBytes(this.TileFrameID);
            byte[] inventoryframeid = BitConverter.GetBytes(this.InventoryFrameID);
            byte[] gearframeid = BitConverter.GetBytes(this.GearFrameID);
            byte[] dropframeid = BitConverter.GetBytes(this.DropFrameID);
            byte[] addonmaleframeid = BitConverter.GetBytes(this.AddonMaleFrameID);
            byte[] addonfemaleframeid = BitConverter.GetBytes(this.AddonFemaleFrameID);
            byte[] useframeid = BitConverter.GetBytes(this.UseFrameID);

            file.Write(tileframeid, 0, tileframeid.Length);
            file.Write(inventoryframeid, 0, inventoryframeid.Length);
            file.Write(gearframeid, 0, gearframeid.Length);
            file.Write(dropframeid, 0, dropframeid.Length);
            file.Write(addonmaleframeid, 0, addonmaleframeid.Length);
            file.Write(addonfemaleframeid, 0, addonfemaleframeid.Length);
            file.Write(useframeid, 0, useframeid.Length);

            //SoundID's
            byte[] usesoundid = BitConverter.GetBytes(this.UseSoundID);
            byte[] tilesoundid = BitConverter.GetBytes(this.TileSoundID);
            byte[] inventorysoundid = BitConverter.GetBytes(this.InventorySoundID);
            byte[] gearsoundid = BitConverter.GetBytes(this.GearSoundID);

            file.Write(usesoundid, 0, usesoundid.Length);
            file.Write(tilesoundid, 0, tilesoundid.Length);
            file.Write(inventorysoundid, 0, inventorysoundid.Length);
            file.Write(gearsoundid, 0, gearsoundid.Length);

            //Grid Size
            file.WriteByte(this.GridWidth);
            file.WriteByte(this.GridHeight);

            //Price
            byte[] price = BitConverter.GetBytes(this.Price);

            file.Write(price, 0, price.Length);

            //Weight
            byte[] weight = BitConverter.GetBytes(this.Weight);

            file.Write(weight, 0, weight.Length);

            //Values
            byte[] value1 = BitConverter.GetBytes(this.Value1);
            byte[] value2 = BitConverter.GetBytes(this.Value2);
            byte[] value3 = BitConverter.GetBytes(this.Value3);
            byte[] value4 = BitConverter.GetBytes(this.Value4);
            byte[] value5 = BitConverter.GetBytes(this.Value5);
            byte[] value6 = BitConverter.GetBytes(this.Value6);
            byte[] value7 = BitConverter.GetBytes(this.Value7);

            file.Write(value1, 0, value1.Length);
            file.Write(value2, 0, value2.Length);
            file.Write(value3, 0, value3.Length);
            file.Write(value4, 0, value4.Length);
            file.Write(value5, 0, value5.Length);
            file.Write(value6, 0, value6.Length);
            file.Write(value7, 0, value7.Length);

            //Requirements
            file.WriteByte(this.RequireSTR);
            file.WriteByte(this.RequireDEX);
            file.WriteByte(this.RequireINT);

            //RequireSUM
            byte[] requiresum = BitConverter.GetBytes(this.RequireSUM);

            file.Write(requiresum, 0, requiresum.Length);

            //RequireLevels
            file.WriteByte(this.RequireLevel);
            file.WriteByte(this.RequireAdvancementLevel);

            //Sex Restrictions
            file.WriteByte(BitConverter.GetBytes(this.bMaleOnly)[0]);
            file.WriteByte(BitConverter.GetBytes(bFemaleOnly)[0]);

            //UseActionInfo
            byte[] useactioninfo = BitConverter.GetBytes(this.UseActionInfo);

            file.Write(useactioninfo, 0, useactioninfo.Length);

            //Silver Max
            byte[] silvermax = BitConverter.GetBytes(this.SilverMax);

            file.Write(silvermax, 0, silvermax.Length);

            //ToHit
            byte[] tohit = BitConverter.GetBytes(this.ToHit);

            file.Write(tohit, 0, tohit.Length);

            //Max Number
            byte[] maxnumber = BitConverter.GetBytes(this.MaxNumber);

            file.Write(maxnumber, 0, maxnumber.Length);

            //Critical Hit
            byte[] criticalhit = BitConverter.GetBytes(this.CriticalHit);

            file.Write(criticalhit, 0, criticalhit.Length);

            //DefaultOptionsList
            file.WriteByte((byte)this.DefaultOptionList.Count);

            foreach (byte b in DefaultOptionList)
                file.WriteByte(b);

            //ItemStyle
            byte[] itemstyle = BitConverter.GetBytes(this.ItemStyle);

            file.Write(itemstyle, 0, itemstyle.Length);

            //ElementalType
            byte[] elementaltype = BitConverter.GetBytes(this.ElementalType);

            file.Write(elementaltype, 0, elementaltype.Length);

            //Elemental
            byte[] elemental = BitConverter.GetBytes(this.Elemental);

            file.Write(elemental, 0, elemental.Length);

            //Race
            file.WriteByte(this.Race);

            //DescriptionFrameID
            byte[] descframeid = BitConverter.GetBytes(this.DescriptionFrameID);

            file.Write(descframeid, 0, descframeid.Length);

            //ItemMoveControl
            file.WriteByte(this.ItemMoveControl);

            //ItemCanAdvance
            file.WriteByte(this.ItemCanAdvance);

            //DropItemNameTag
            byte[] dropitemnametag = BitConverter.GetBytes(this.DropItemNameTag);

            file.Write(dropitemnametag, 0, dropitemnametag.Length);

            //NormalItemGrade
            byte[] normalitemgrade = BitConverter.GetBytes(this.NormalItemGrade);

            file.Write(normalitemgrade, 0, normalitemgrade.Length);

            //NewValue668
            /*file.WriteByte((byte)this.NewValue668.Count);
            foreach (byte b in NewValue668)
            {
                file.WriteByte(b);
            }*/
        }
    }
}
