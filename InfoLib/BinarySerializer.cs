using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace InfoLib
{
    public static class BinarySerializer
    {
        public static string ReadString(ref FileStream file, Encoding enc)
        {
            byte[] _strsize = new byte[4];
            file.Read(_strsize, 0, 4);
            int strsize = BitConverter.ToInt32(_strsize, 0);

            byte[] _str = new byte[strsize];
            file.Read(_str, 0, strsize);

            return enc.GetString(_str);
        }

        public static void WriteString(ref FileStream file, Encoding enc, string str)
        {
            byte[] _strsize = BitConverter.GetBytes(enc.GetBytes(str).Length);
            byte[] _str = enc.GetBytes(str);
            file.Write(_strsize, 0, _strsize.Length);
            file.Write(_str, 0, _str.Length);
        }

        public static Int32 ReadInt32(ref FileStream file)
        {
            byte[] _int = new byte[4];
            file.Read(_int, 0, 4);
            return BitConverter.ToInt32(_int, 0);
        }

        public static void WriteInt32(ref FileStream file, int value)
        {
            byte[] _value = BitConverter.GetBytes(value);
            file.Write(_value, 0, _value.Length);
        }

        public static UInt32 ReadUInt32(ref FileStream file)
        {
            byte[] _int = new byte[4];
            file.Read(_int, 0, 4);
            return BitConverter.ToUInt32(_int, 0);
        }

        public static void WriteUInt32(ref FileStream file, UInt32 value)
        {
            byte[] _value = BitConverter.GetBytes(value);
            file.Write(_value, 0, _value.Length);
        }

        public static Int16 ReadInt16(ref FileStream file)
        {
            byte[] _int = new byte[2];
            file.Read(_int, 0, 2);
            return BitConverter.ToInt16(_int, 0);
        }

        public static Int16 WriteInt16(ref FileStream file)
        {
            byte[] _int = new byte[2];
            file.Read(_int, 0, 2);
            return BitConverter.ToInt16(_int, 0);
        }

        public static UInt16 ReadUInt16(ref FileStream file)
        {
            byte[] _int = new byte[2];
            file.Read(_int, 0, 2);
            return BitConverter.ToUInt16(_int, 0);
        }

        public static void WriteUInt16(ref FileStream file, UInt16 value)
        {
            byte[] _value = BitConverter.GetBytes(value);
            file.Write(_value, 0, _value.Length);
        }

        public static bool ReadBool(ref FileStream file)
        {
            return Convert.ToBoolean(file.ReadByte());
        }

        public static void WriteBool(ref FileStream file, bool value)
        {
            file.WriteByte(BitConverter.GetBytes(value)[0]);
        }

        public static byte ReadByte(ref FileStream file)
        {
            return (byte)file.ReadByte();
        }

        public static void WriteByte(ref FileStream file, byte value)
        {
            file.WriteByte(value);
        }
    }
}
