using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCalc : MonoBehaviour
{
    
    public static int Calc(Status atk, Status def)
    {
        float dmg_ratio = (float)atk.Atk / (float)(atk.Atk + def.Def);
        int damage = (int)(atk.Atk * dmg_ratio);

        if(damage < 0)
            damage = 0;
        return damage;
    }

    private void AtkCalc()
    {

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
