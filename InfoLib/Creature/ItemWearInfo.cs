using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace InfoLib
{
    public class ItemWearInfo
    {
        public UInt16 SkinColor;
        public UInt16 HairColor;
        public UInt16 JacketColor;
        public UInt16 PantsColor;
        public UInt16 HelmetColor;
        public UInt16 WeaponColor;
        public UInt16 ShieldColor;
        public UInt16 MotorcycleColor;

        public byte Hair;
        public byte Jacket;
        public byte Pants;
        public byte Helmet;
        public byte Weapon;
        public byte Shield;
        public byte Motorcycle;

        public ItemWearInfo() { }

        public ItemWearInfo(ref FileStream file)
        {
            this.SkinColor = BinarySerializer.ReadUInt16(ref file);
            this.HairColor = BinarySerializer.ReadUInt16(ref file);
            this.JacketColor = BinarySerializer.ReadUInt16(ref file);
            this.PantsColor = BinarySerializer.ReadUInt16(ref file);
            this.HelmetColor = BinarySerializer.ReadUInt16(ref file);
            this.WeaponColor = BinarySerializer.ReadUInt16(ref file);
            this.ShieldColor = BinarySerializer.ReadUInt16(ref file);
            this.MotorcycleColor = BinarySerializer.ReadUInt16(ref file);

            this.Hair = BinarySerializer.ReadByte(ref file);
            this.Jacket = BinarySerializer.ReadByte(ref file);
            this.Pants = BinarySerializer.ReadByte(ref file);
            this.Helmet = BinarySerializer.ReadByte(ref file);
            this.Weapon = BinarySerializer.ReadByte(ref file);
            this.Shield = BinarySerializer.ReadByte(ref file);
            this.Motorcycle = BinarySerializer.ReadByte(ref file);
        }

        public void SaveToFile(ref FileStream file)
        {
            BinarySerializer.WriteUInt16(ref file, this.SkinColor);
            BinarySerializer.WriteUInt16(ref file, this.HairColor);
            BinarySerializer.WriteUInt16(ref file, this.JacketColor);
            BinarySerializer.WriteUInt16(ref file, this.PantsColor);
            BinarySerializer.WriteUInt16(ref file, this.HelmetColor);
            BinarySerializer.WriteUInt16(ref file, this.WeaponColor);
            BinarySerializer.WriteUInt16(ref file, this.ShieldColor);
            BinarySerializer.WriteUInt16(ref file, this.MotorcycleColor);

            BinarySerializer.WriteByte(ref file, this.Hair);
            BinarySerializer.WriteByte(ref file, this.Jacket);
            BinarySerializer.WriteByte(ref file, this.Pants);
            BinarySerializer.WriteByte(ref file, this.Helmet);
            BinarySerializer.WriteByte(ref file, this.Weapon);
            BinarySerializer.WriteByte(ref file, this.Shield);
            BinarySerializer.WriteByte(ref file, this.Motorcycle);
        }
    }
}
