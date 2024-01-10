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

        // calculate if it is a critical hit or not
        damage = (int)((float)damage * CritCalc(atk, def));

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

    // how much atk is reduced after an attack
    public static int RedAtkCalc(Status atk, Status def)
    {
        float def_ratio = (float)def.Def/ (float)(def.Def + atk.Atk);
        return (int)((float)atk.Atk * (1.0f - def_ratio) * 0.2f);
    }

    private static float CritCalc(Status atk, Status def)
    {
        if (Random.Range(0, 100) < atk.CritRate)
            return 1.0f + (float)atk.CritDmg/100;
        else
            return 1.0f;
    }

    public static int DamageCalculation(DamageCalc.StatusType type, int value, MalWare malWare)
    {
        // 基礎攻撃 x ダメージアップ x クリティカル x ダメージ倍率
        int basicValue = 0;
        float valueRate = 1.0f;

        switch (type)
        {
            case StatusType.HpRate:
                if (malWare.BasicStatType == StatusType.HpRate)
                    basicValue = value + malWare.BasicStat;
                else
                    basicValue = value;
                
                if (malWare.MainStatType == StatusType.HpRate)
                    valueRate += (float)malWare.MainStat/100;
                
                break;
            case StatusType.AtkRate:
                if (malWare.BasicStatType == StatusType.AtkRate)
                    basicValue = value + malWare.BasicStat;
                else
                    basicValue = value;
                
                if (malWare.MainStatType == StatusType.AtkRate)
                    valueRate += (float)malWare.MainStat/100;
                
                break;
            case StatusType.DefRate:
                if (malWare.BasicStatType == StatusType.DefRate)
                    basicValue = value + malWare.BasicStat;
                else
                    basicValue = value;

                if (malWare.MainStatType == StatusType.DefRate)
                    valueRate += (float)malWare.MainStat/100;
                break;
            case StatusType.CritRate:
                if (malWare.BasicStatType == StatusType.CritRate)
                    basicValue = value + malWare.BasicStat;
                else
                    basicValue = value;

                break;
            case StatusType.CritDmg:
                if (malWare.BasicStatType == StatusType.CritDmg)
                    basicValue = value + malWare.BasicStat;
                else
                    basicValue = value;

                break;
            default:
                Debug.LogError("DamageCalculation: Invalid StatusType");
                break;
        }
        return (int)((float)basicValue * valueRate);
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
