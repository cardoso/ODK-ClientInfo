using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CreatureTable_Converter
{
    public static class BinarySerializer
    {
        public static string DeserializeString(ref FileStream file, Encoding enc)
        {
            byte[] _strsize = new byte[4];
            file.Read(_strsize, 0, 4);
            int strsize = BitConverter.ToInt32(_strsize, 0);

            byte[] _str = new byte[strsize];
            file.Read(_str, 0, strsize);

            return EncodingHelper.encName.GetString(_str);
        }

        public static void SerializeString(ref FileStream file, Encoding enc, string str)
        {
            byte[] _strsize = BitConverter.GetBytes(EncodingHelper.encName.GetBytes(str).Length);
            byte[] _str = EncodingHelper.encName.GetBytes(str);
            file.Write(_strsize, 0, _strsize.Length);
            file.Write(_str, 0, _str.Length);
        }

        public static Int32 DeserializeInt32(ref FileStream file)
        {
            byte[] _int = new byte[4];
            file.Read(_int, 0, 4);
            return BitConverter.ToInt32(_int, 0);
        }

        public static void SerializeInt32(ref FileStream file, int value)
        {
            byte[] _value = BitConverter.GetBytes(value);
            file.Write(_value, 0, _value.Length);
        }

        public static UInt16 DeserializeUInt16(ref FileStream file)
        {
            byte[] _int = new byte[2];
            file.Read(_int, 0, 2);
            return BitConverter.ToUInt16(_int, 0);
        }

        public static void SerializeUInt16(ref FileStream file, UInt16 value)
        {
            byte[] _value = BitConverter.GetBytes(value);
            file.Write(_value, 0, _value.Length);
        }

        public static bool DeserializeBool(ref FileStream file)
        {
            return Convert.ToBoolean(file.ReadByte());
        }

        public static void SerializeBool(ref FileStream file, bool value)
        {
            file.WriteByte(BitConverter.GetBytes(value)[0]);
        }

        public static byte DeserializeByte(ref FileStream file)
        {
            return (byte)file.ReadByte();
        }

        public static void SerializeByte(ref FileStream file, byte value)
        {
            file.WriteByte(value);
        }
    }
}
