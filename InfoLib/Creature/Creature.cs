using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace InfoLib
{
    public class Creature
    {
        public string Name;

        public List<Int32> SpriteTypes;

        public bool bMale;

        public CREATURETRIBE CreatureTribe;

        public byte MoveTimes;
        public byte MoveRatio;
        public byte MoveTimesMotor;

        public Int32 Height;
        public Int32 Width;

        public Int32 DeadHeight;

        public UInt16 DeadActionInfo;

        public Int32 ColorSet;

        public bool bFlyingCreature;

        public Int32 FlyingHeight;

        public Int32 bHeadCut;

        public Int32 HPBarWidth;

        public UInt16 ChangeColorSet;

        public UInt16 ShadowCount;

        public Int32 EffectStatus;

        public Int32 Level;

        public UInt16[] ActionSound;

        public Int32[] ActionCount;

        public ItemWearInfo ItemWearInfo;

        public bool bFade;

        public bool bFadeShadow;

        //6.68 only
        //public byte[] NewValue668;

        public Creature() { }

        public Creature(ref FileStream file)
        {
            //Name
            this.Name = BinarySerializer.ReadString(ref file, Encoding.ASCII);

            //SpriteTypes
            int stc = BinarySerializer.ReadInt32(ref file);
            this.SpriteTypes = new List<Int32>();
            for(int i = 0; i < stc; i++)
                this.SpriteTypes.Add(BinarySerializer.ReadInt32(ref file));

            //bMale
            this.bMale = BinarySerializer.ReadBool(ref file);

            //CreatureTribe
            this.CreatureTribe = (CREATURETRIBE)BinarySerializer.ReadByte(ref file);

            //MoveTimes
            this.MoveTimes = BinarySerializer.ReadByte(ref file);

            //MoveRatio
            this.MoveRatio = BinarySerializer.ReadByte(ref file);

            //MoveTimesMotor
            this.MoveTimesMotor = BinarySerializer.ReadByte(ref file);

            //Height, Width
            this.Height = BinarySerializer.ReadInt32(ref file);
            this.Width = BinarySerializer.ReadInt32(ref file);

            //DeadHeight
            this.DeadHeight = BinarySerializer.ReadInt32(ref file);

            //DeadActionInfo
            this.DeadActionInfo = BinarySerializer.ReadUInt16(ref file);

            //ColorSet
            this.ColorSet = BinarySerializer.ReadInt32(ref file);

            //bFlyingCreature
            this.bFlyingCreature = BinarySerializer.ReadBool(ref file);

            //FlyingHeight
            this.FlyingHeight = BinarySerializer.ReadInt32(ref file);

            //bHeadCut
            this.bHeadCut = BinarySerializer.ReadInt32(ref file);

            //HPBarWidth
            this.HPBarWidth = BinarySerializer.ReadInt32(ref file);

            //ChangeColorSet
            this.ChangeColorSet = BinarySerializer.ReadUInt16(ref file);

            //ShadowCount
            this.ShadowCount = BinarySerializer.ReadUInt16(ref file);

            //EffectStatus
            this.EffectStatus = BinarySerializer.ReadInt32(ref file);

            //Level
            this.Level = BinarySerializer.ReadInt32(ref file);

            //ActionSound
            this.ActionSound = new UInt16[this.GetActionMax()];
            for(int i = 0; i < this.ActionSound.Length; i++)
                this.ActionSound[i] = BinarySerializer.ReadUInt16(ref file);

            //ActionCount
            this.ActionCount = new Int32[this.GetActionMax()];
            for (int i = 0; i < this.ActionCount.Length; i++)
                this.ActionCount[i] = BinarySerializer.ReadInt32(ref file);

            //ItemWearInfo
            if(BinarySerializer.ReadBool(ref file)) // ItemWearInfo exists
                this.ItemWearInfo = new ItemWearInfo(ref file);

            //bFade
            this.bFade = BinarySerializer.ReadBool(ref file);

            //bFadeShadow
            this.bFadeShadow = BinarySerializer.ReadBool(ref file);

            //NewValue668
            /*this.NewValue668 = new byte[8];
            for (int i = 0; i < 8; i++)
                this.NewValue668[i] = BinarySerializer.ReadByte(ref file);*/
        }

        public void SaveToFile(ref FileStream file)
        {
            //Name
            BinarySerializer.WriteString(ref file, Encoding.ASCII, this.Name);

            //SpriteTypes
            BinarySerializer.WriteInt32(ref file, this.SpriteTypes.Count);
            foreach (Int32 i in this.SpriteTypes)
                BinarySerializer.WriteInt32(ref file, i);

            //bMale
            BinarySerializer.WriteBool(ref file, this.bMale);

            //CreatureTribe
            BinarySerializer.WriteByte(ref file, (byte)this.CreatureTribe);

            //MoveTimes
            BinarySerializer.WriteByte(ref file, this.MoveTimes);

            //MoveRatio
            BinarySerializer.WriteByte(ref file, this.MoveRatio);

            //MoveTimesMotor
            BinarySerializer.WriteByte(ref file, this.MoveTimesMotor);

            //Height, Width
            BinarySerializer.WriteInt32(ref file, this.Height);
            BinarySerializer.WriteInt32(ref file, this.Width);

            //DeadHeight
            BinarySerializer.WriteInt32(ref file, this.DeadHeight);

            //DeadActionInfo
            BinarySerializer.WriteUInt16(ref file, this.DeadActionInfo);

            //ColorSet
            BinarySerializer.WriteInt32(ref file, this.ColorSet);

            //bFlyingCreature
            BinarySerializer.WriteBool(ref file, this.bFlyingCreature);

            //FlyingHeight
            BinarySerializer.WriteInt32(ref file, this.FlyingHeight);

            //bHeadCut
            BinarySerializer.WriteInt32(ref file, this.bHeadCut);

            //HPBarWidth
            BinarySerializer.WriteInt32(ref file, this.HPBarWidth);

            //ChangeColorSet
            BinarySerializer.WriteUInt16(ref file, this.ChangeColorSet);

            //ShadowCount
            BinarySerializer.WriteUInt16(ref file, this.ShadowCount);

            //EffectStatus
            BinarySerializer.WriteInt32(ref file, this.EffectStatus);

            //Level
            BinarySerializer.WriteInt32(ref file, this.Level);

            //ActionSound
            foreach (UInt16 i in this.ActionSound)
                BinarySerializer.WriteUInt16(ref file, i);

            //ActionCount
            foreach (Int32 i in this.ActionCount)
                BinarySerializer.WriteInt32(ref file, i);

            //ItemWearInfo
            if (this.ItemWearInfo == null) BinarySerializer.WriteBool(ref file, false);
            else
            {
                BinarySerializer.WriteBool(ref file, true);
                this.ItemWearInfo.SaveToFile(ref file);
            }

            //bFade
            BinarySerializer.WriteBool(ref file, this.bFade);

            //bFadeShadow
            BinarySerializer.WriteBool(ref file, this.bFadeShadow);

            //NewValue668
            /*for (int i = 0; i < 8; i++)
                BinarySerializer.WriteByte(ref file, this.NewValue668[i]);*/
        }

        public int GetActionMax()
        {
            if (this.CreatureTribe == CREATURETRIBE.SLAYER || this.CreatureTribe == CREATURETRIBE.SLAYER_NPC)
                return (int)ACTION_SLAYER.MAX;
            else if (this.CreatureTribe == CREATURETRIBE.VAMPIRE || this.CreatureTribe == CREATURETRIBE.NPC || this.CreatureTribe >= CREATURETRIBE.MAX)
            {
                if (this.SpriteTypes[0] == 204)
                    return (int)ACTION_OUSTERS.MAX;
                return (int)ACTION_VAMPIRE.MAX;
            }
            else if (this.CreatureTribe == CREATURETRIBE.OUSTERS || this.CreatureTribe == CREATURETRIBE.OUSTERS_NPC)
                return (int)ACTION_OUSTERS.MAX;

            return 0;
        }
    }
}
