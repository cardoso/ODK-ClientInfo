using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CreatureTable_Converter
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
            this.SkinColor = BinarySerializer.DeserializeUInt16(ref file);
            this.HairColor = BinarySerializer.DeserializeUInt16(ref file);
            this.JacketColor = BinarySerializer.DeserializeUInt16(ref file);
            this.PantsColor = BinarySerializer.DeserializeUInt16(ref file);
            this.HelmetColor = BinarySerializer.DeserializeUInt16(ref file);
            this.WeaponColor = BinarySerializer.DeserializeUInt16(ref file);
            this.ShieldColor = BinarySerializer.DeserializeUInt16(ref file);
            this.MotorcycleColor = BinarySerializer.DeserializeUInt16(ref file);

            this.Hair = BinarySerializer.DeserializeByte(ref file);
            this.Jacket = BinarySerializer.DeserializeByte(ref file);
            this.Pants = BinarySerializer.DeserializeByte(ref file);
            this.Helmet = BinarySerializer.DeserializeByte(ref file);
            this.Weapon = BinarySerializer.DeserializeByte(ref file);
            this.Shield = BinarySerializer.DeserializeByte(ref file);
            this.Motorcycle = BinarySerializer.DeserializeByte(ref file);
        }

        public void SaveToFile(ref FileStream file)
        {
            BinarySerializer.SerializeUInt16(ref file, this.SkinColor);
            BinarySerializer.SerializeUInt16(ref file, this.HairColor);
            BinarySerializer.SerializeUInt16(ref file, this.JacketColor);
            BinarySerializer.SerializeUInt16(ref file, this.PantsColor);
            BinarySerializer.SerializeUInt16(ref file, this.HelmetColor);
            BinarySerializer.SerializeUInt16(ref file, this.WeaponColor);
            BinarySerializer.SerializeUInt16(ref file, this.ShieldColor);
            BinarySerializer.SerializeUInt16(ref file, this.MotorcycleColor);

            BinarySerializer.SerializeByte(ref file, this.Hair);
            BinarySerializer.SerializeByte(ref file, this.Jacket);
            BinarySerializer.SerializeByte(ref file, this.Pants);
            BinarySerializer.SerializeByte(ref file, this.Helmet);
            BinarySerializer.SerializeByte(ref file, this.Weapon);
            BinarySerializer.SerializeByte(ref file, this.Shield);
            BinarySerializer.SerializeByte(ref file, this.Motorcycle);
        }
    }
}
