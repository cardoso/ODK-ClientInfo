using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CreatureTable_Converter
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

        public byte[] NewValue668;

        public Creature() { }

        public Creature(ref FileStream file)
        {
            //Name
            this.Name = BinarySerializer.DeserializeString(ref file, EncodingHelper.encName);

            //SpriteTypes
            int stc = BinarySerializer.DeserializeInt32(ref file);
            this.SpriteTypes = new List<Int32>();
            for(int i = 0; i < stc; i++)
                this.SpriteTypes.Add(BinarySerializer.DeserializeInt32(ref file));

            //bMale
            this.bMale = BinarySerializer.DeserializeBool(ref file);

            //CreatureTribe
            this.CreatureTribe = (CREATURETRIBE)BinarySerializer.DeserializeByte(ref file);

            //MoveTimes
            this.MoveTimes = BinarySerializer.DeserializeByte(ref file);

            //MoveRatio
            this.MoveRatio = BinarySerializer.DeserializeByte(ref file);

            //MoveTimesMotor
            this.MoveTimesMotor = BinarySerializer.DeserializeByte(ref file);

            //Height, Width
            this.Height = BinarySerializer.DeserializeInt32(ref file);
            this.Width = BinarySerializer.DeserializeInt32(ref file);

            //DeadHeight
            this.DeadHeight = BinarySerializer.DeserializeInt32(ref file);

            //DeadActionInfo
            this.DeadActionInfo = BinarySerializer.DeserializeUInt16(ref file);

            //ColorSet
            this.ColorSet = BinarySerializer.DeserializeInt32(ref file);

            //bFlyingCreature
            this.bFlyingCreature = BinarySerializer.DeserializeBool(ref file);

            //FlyingHeight
            this.FlyingHeight = BinarySerializer.DeserializeInt32(ref file);

            //bHeadCut
            this.bHeadCut = BinarySerializer.DeserializeInt32(ref file);

            //HPBarWidth
            this.HPBarWidth = BinarySerializer.DeserializeInt32(ref file);

            //ChangeColorSet
            this.ChangeColorSet = BinarySerializer.DeserializeUInt16(ref file);

            //ShadowCount
            this.ShadowCount = BinarySerializer.DeserializeUInt16(ref file);

            //EffectStatus
            this.EffectStatus = BinarySerializer.DeserializeInt32(ref file);

            //Level
            this.Level = BinarySerializer.DeserializeInt32(ref file);

            //ActionSound
            this.ActionSound = new UInt16[this.GetActionMax()];
            for(int i = 0; i < this.ActionSound.Length; i++)
                this.ActionSound[i] = BinarySerializer.DeserializeUInt16(ref file);

            //ActionCount
            this.ActionCount = new Int32[this.GetActionMax()];
            for (int i = 0; i < this.ActionCount.Length; i++)
                this.ActionCount[i] = BinarySerializer.DeserializeInt32(ref file);

            //ItemWearInfo
            if(BinarySerializer.DeserializeBool(ref file)) // ItemWearInfo exists
                this.ItemWearInfo = new ItemWearInfo(ref file);

            //bFade
            this.bFade = BinarySerializer.DeserializeBool(ref file);

            //bFadeShadow
            this.bFadeShadow = BinarySerializer.DeserializeBool(ref file);

            //NewValue668
            this.NewValue668 = new byte[8];
            for (int i = 0; i < 8; i++)
                this.NewValue668[i] = BinarySerializer.DeserializeByte(ref file);
        }

        public void SaveToFile(ref FileStream file)
        {
            //Name
            BinarySerializer.SerializeString(ref file, EncodingHelper.encName, this.Name);

            //SpriteTypes
            BinarySerializer.SerializeInt32(ref file, this.SpriteTypes.Count);
            foreach (Int32 i in this.SpriteTypes)
                BinarySerializer.SerializeInt32(ref file, i);

            //bMale
            BinarySerializer.SerializeBool(ref file, this.bMale);

            //CreatureTribe
            BinarySerializer.SerializeByte(ref file, (byte)this.CreatureTribe);

            //MoveTimes
            BinarySerializer.SerializeByte(ref file, this.MoveTimes);

            //MoveRatio
            BinarySerializer.SerializeByte(ref file, this.MoveRatio);

            //MoveTimesMotor
            BinarySerializer.SerializeByte(ref file, this.MoveTimesMotor);

            //Height, Width
            BinarySerializer.SerializeInt32(ref file, this.Height);
            BinarySerializer.SerializeInt32(ref file, this.Width);

            //DeadHeight
            BinarySerializer.SerializeInt32(ref file, this.DeadHeight);

            //DeadActionInfo
            BinarySerializer.SerializeUInt16(ref file, this.DeadActionInfo);

            //ColorSet
            BinarySerializer.SerializeInt32(ref file, this.ColorSet);

            //bFlyingCreature
            BinarySerializer.SerializeBool(ref file, this.bFlyingCreature);

            //FlyingHeight
            BinarySerializer.SerializeInt32(ref file, this.FlyingHeight);

            //bHeadCut
            BinarySerializer.SerializeInt32(ref file, this.bHeadCut);

            //HPBarWidth
            BinarySerializer.SerializeInt32(ref file, this.HPBarWidth);

            //ChangeColorSet
            BinarySerializer.SerializeUInt16(ref file, this.ChangeColorSet);

            //ShadowCount
            BinarySerializer.SerializeUInt16(ref file, this.ShadowCount);

            //EffectStatus
            BinarySerializer.SerializeInt32(ref file, this.EffectStatus);

            //Level
            BinarySerializer.SerializeInt32(ref file, this.Level);

            //ActionSound
            foreach (UInt16 i in this.ActionSound)
                BinarySerializer.SerializeUInt16(ref file, i);

            //ActionCount
            foreach (Int32 i in this.ActionCount)
                BinarySerializer.SerializeInt32(ref file, i);

            //ItemWearInfo
            if (this.ItemWearInfo == null) BinarySerializer.SerializeBool(ref file, false);
            else
            {
                BinarySerializer.SerializeBool(ref file, true);
                this.ItemWearInfo.SaveToFile(ref file);
            }

            //bFade
            BinarySerializer.SerializeBool(ref file, this.bFade);

            //bFadeShadow
            BinarySerializer.SerializeBool(ref file, this.bFadeShadow);

            //NewValue668
            for (int i = 0; i < 8; i++)
                BinarySerializer.SerializeByte(ref file, this.NewValue668[i]);
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
