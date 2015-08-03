using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreatureTable_Converter
{
    public enum CREATURETRIBE
    {
        SLAYER,
        VAMPIRE,
        NPC,
        SLAYER_NPC,
        OUSTERS,
        OUSTERS_NPC,

        MAX
    }

    enum ACTION
    {
        STAND,								// 0
        MOVE,								// 1
        ATTACK,								// 2
        MAGIC,								// 3
        DAMAGED,								// 4
        DRAINED,								// 5	//구시온과 모르고스는 흡혈을 안한다. 다른 공격 스킬을 사용한다.
        DIE,									// 6

	    MAX
    }

    enum ACTION_SLAYER
    {
	    GUN_SR = ACTION.MAX,	// 7			// 저격용(TR)
	    GUN_AR,						// 8			// 소총(AG)
	    GUN_SG,						// 9			// 샷건(SG)
	    GUN_SMG,						// 10			// 자동소총(SMG)

	    SWORD,						// 11			// 칼
	    BLADE,						// 12			// 도
	    SWORD_2,						// 13			// 칼 특수동작
	    BLADE_2,						// 14			// 도 특수동작

	    MOTOR_MOVE,					// 15
	    MOTOR_STAND,					// 16

	    GUN_SR_SLOW,					// 17			// 저격용(TR)
	    GUN_SR_FAST,					// 18			// 저격용(TR)
	    GUN_AR_SLOW,					// 19			// 소총(AG)
	    GUN_AR_FAST,					// 20	 		// 소총(AG)
	    GUN_SG_SLOW,					// 21			// 샷건(SG)
	    GUN_SG_FAST,					// 22			// 샷건(SG)
	    GUN_SMG_SLOW,					// 23			// 자동소총(SMG)
	    GUN_SMG_FAST,					// 24			// 자동소총(SMG)

	    SWORD_SLOW,					// 25			// 칼
	    SWORD_FAST,					// 26			// 칼
	    BLADE_SLOW,					// 27			// 도
	    BLADE_FAST,					// 28			// 도

	    SWORD_2_SLOW,					// 29			// 칼 특수동작
	    SWORD_2_FAST,					// 30			// 칼 특수동작
	    BLADE_2_SLOW,					// 31			// 도 특수동작
	    BLADE_2_FAST,					// 32			// 도 특수동작

	    BATTLE_STAND_GUN,				// 33
	    BATTLE_STAND_SWORD,			// 34
	    BATTLE_STAND_BLADE,			// 35

	    MOVE_GUN,						// 36

	    MAGIC_CASTING,				// 37
	
	    SWORD_2_REPEAT,				// 38
	    BLADE_2_REPEAT,				// 39

	    MAX,
    }

    enum ACTION_VAMPIRE
    {
	    // 2001.6.5 추가된거
	    DRAIN = ACTION.MAX,	// 7
	    ATTACK_SLOW,					// 8			// vampire전용
	    ATTACK_FAST,					// 9			// vampire전용

	    // chyaya 2007.05.06 뱀파이어 공격 모션x2, 시전형 마법 모션 추가
	    ATTACK_2,					// 10
	    ATTACK_2_SLOW,				// 11
	    ATTACK_2_FAST,				// 12
	    ATTACK_3,					// 13
	    ATTACK_3_SLOW,				// 14
	    ATTACK_3_FAST,				// 15
	    MAGIC_CASTING,				// 16

	    MAX,
    }

    enum ACTION_OUSTERS
    {
        STAND = ACTION.MAX,	// 7			// 서있기
        MOVE,						// 8			// 걷기
        CHAKRAM,						// 9			// 차크람 공격
        MAGIC_ATTACK,				// 10			// 마법 공격
        DRAIN,						// 11			// 흡영
        FAST_MOVE_STAND,				// 12			// 공중 정지
        FAST_MOVE_MOVE,				// 13			// 공중 움직임
        ATTACK_SLOW,					// 14			// 일반 공격 느림
        ATTACK_FAST,					// 15			// 일반 공격 빠름
        CHAKRAM_SLOW,				// 16			// 차크람 공격 느림
        CHAKRAM_FAST,				// 17			// 차크람 공격 빠름
        //#if __CONTENTS(__FAST_TRANSFORTER)
        WING_STAND,					// 18
        WING_MOVE,					// 19
        //#endif //__FAST_TRANSFORTER
        //#if __CONTENTS(__SECOND_TRANSFORTER)
        UNICORN_STAND,				// 20
        UNICORN_MOVE,				// 21
        //#endif //__SECOND_TRANSFORTER
        MAX,							// 20
    }
}
