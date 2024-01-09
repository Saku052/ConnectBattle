using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DamageCalc
{
    
    // how much hp is reduced after attack
    public static int AtkCalc(Status atk, Status def)
    {
        float dmg_ratio = (float)atk.Atk / (float)(atk.Atk + def.Def);
        int damage = (int)(atk.Atk * dmg_ratio);

        if(damage < 0)
            damage = 0;
        return damage;
    }

    // how much defence is reduced after attack
    public static int DefCalc(Status atk, Status def)
    {

        float dmg_ratio = (float)atk.Atk / (float)(atk.Atk + def.Def);
        return (int)((float)atk.Atk * (1.0f - dmg_ratio) * 0.2f);;
    }

    public static int DamageCalculation()
    {
        // 基礎攻撃 x ダメージアップ x クリティカル x ダメージ倍率
        return 0;
    }



    public enum StatusType
    {
        HpRate,
        AtkRate,
        DefRate,
        CritRate,
        CritDmg,
        DmgRate
    }

}
