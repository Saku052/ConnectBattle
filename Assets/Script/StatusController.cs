using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;  

public class StatusController : MonoBehaviour
{

    // get status scriptable object
    [SerializeField] private Status a_status;
    [SerializeField] private Status b_status;

    // get status object
    [SerializeField] GameObject a_hp_object;
    [SerializeField] GameObject a_atk_object;
    [SerializeField] GameObject a_def_object;
    [SerializeField] GameObject a_exp_object;
    [SerializeField] GameObject b_hp_object;
    [SerializeField] GameObject b_atk_object;
    [SerializeField] GameObject b_def_object;
    [SerializeField] GameObject b_exp_object;
    [SerializeField] Text a_level_object;
    [SerializeField] Text b_level_object;

    // get audio source
    [SerializeField] AudioSource audioSource;

    // get audio clip
    [SerializeField] AudioClip attackClip;
    [SerializeField] AudioClip levelUpClip;



    private void Start()
    {

        GetSlider(a_hp_object).maxValue = a_status.MaxHp;
        GetSlider(a_atk_object).maxValue = a_status.MaxAtk;
        GetSlider(a_def_object).maxValue = a_status.MaxDef;
        GetSlider(a_exp_object).maxValue = a_status.MaxExp;
        GetSlider(b_hp_object).maxValue = b_status.MaxHp;
        GetSlider(b_atk_object).maxValue = b_status.MaxAtk;
        GetSlider(b_def_object).maxValue = b_status.MaxDef;
        GetSlider(b_exp_object).maxValue = b_status.MaxExp;

        GetSlider(a_hp_object).value = 0;
        GetSlider(a_atk_object).value = 0;
        GetSlider(a_def_object).value = 0;
        GetSlider(a_exp_object).value = 0;
        GetSlider(b_hp_object).value = 0;
        GetSlider(b_atk_object).value = 0;
        GetSlider(b_def_object).value = 0;
        GetSlider(b_exp_object).value = 0;

        UpdateValueA();
        UpdateValueB();
    }


    public void AttackA()
    {
        // do damage
        float dmg_ratio = (float)a_status.Atk / (float)(a_status.Atk + b_status.Def) ;
        int damage = (int)(a_status.Atk * dmg_ratio);
        if (damage < 0)
            damage = 0;

        b_status.Hp -= damage;
        b_status.Def -= (int)((float)a_status.Atk * (1.0f - dmg_ratio) * 0.2f);

        // gain exp when enemy is dead
        if (b_status.Hp <= 0)
            a_status.Exp += b_status.MaxExp;


        UpdateValueA();
        UpdateValueB();
    }

    public void AttackB()
    {
        // do damage
        float dmg_ratio = (float)b_status.Atk / (float)(b_status.Atk + a_status.Def);
        int damage = (int)(b_status.Atk * dmg_ratio);
        if (damage < 0)
            damage = 0;

        a_status.Hp -= damage;
        a_status.Def -= (int)((float)b_status.Atk * (1.0f - dmg_ratio) * 0.2f);
        
        // gain exp when enemy is dead
        if (a_status.Hp <= 0)
            b_status.Exp += a_status.MaxExp;

        UpdateValueA();
        UpdateValueB();
    }


    // Level up
    public void Levelup(Status status, int exp)
    {
        // level up
        status.Level += 1;
        // update max value
        status.MaxHp = (int)(status.MaxHp * 1.03f+ 9.5f);
        status.MaxAtk = (int)(status.MaxAtk * 1.02f + 7.3f);
        status.MaxDef = (int)(status.MaxDef * 1.02f +5.8f);
        status.MaxExp = (int)(status.MaxExp * 1.1f);
        // update value
        status.Exp = exp;

        // update max value
        UpdateMaxValueA();
        UpdateMaxValueB();

        // play level up sound
        audioSource.PlayOneShot(levelUpClip);
    }
    

    // Update value A
    private void UpdateValueA()
    {
        // Update slider value
        GetSlider(a_hp_object).DOValue(a_status.Hp, 1f);
        GetSlider(a_atk_object).DOValue(a_status.Atk, 1f);
        GetSlider(a_def_object).DOValue(a_status.Def, 1f);
        GetSlider(a_exp_object).DOValue(a_status.Exp, 1f);

        // Update text value
        GetText(a_hp_object).text = a_status.Hp.ToString() + "/" + a_status.MaxHp.ToString();
        GetText(a_atk_object).text = a_status.Atk.ToString() + "/" + a_status.MaxAtk.ToString();
        GetText(a_def_object).text = a_status.Def.ToString() + "/" + a_status.MaxDef.ToString();
        GetText(a_exp_object).text = a_status.Exp.ToString() + "/" + a_status.MaxExp.ToString();
        a_level_object.text = "Lv. " + a_status.Level.ToString();
    }

    // Update value B
    private void UpdateValueB()
    {
        // Update slider value
        GetSlider(b_hp_object).DOValue(b_status.Hp, 1f);
        GetSlider(b_atk_object).DOValue(b_status.Atk, 1f);
        GetSlider(b_def_object).DOValue(b_status.Def, 1f);
        GetSlider(b_exp_object).DOValue(b_status.Exp, 1f);

        // Update text value
        GetText(b_hp_object).text = b_status.Hp.ToString() + "/" + b_status.MaxHp.ToString();
        GetText(b_atk_object).text = b_status.Atk.ToString() + "/" + b_status.MaxAtk.ToString();
        GetText(b_def_object).text = b_status.Def.ToString() + "/" + b_status.MaxDef.ToString();
        GetText(b_exp_object).text = b_status.Exp.ToString() + "/" + b_status.MaxExp.ToString();
        b_level_object.text = "Lv. " + b_status.Level.ToString();
    }

    // update MaxValue A
    public void UpdateMaxValueA()
    {
        GetSlider(a_hp_object).maxValue = a_status.MaxHp;
        GetSlider(a_atk_object).maxValue = a_status.MaxAtk;
        GetSlider(a_def_object).maxValue = a_status.MaxDef;
        GetSlider(a_exp_object).maxValue = a_status.MaxExp;
    }

    // update MaxValue B
    public void UpdateMaxValueB()
    {
        GetSlider(b_hp_object).maxValue = b_status.MaxHp;
        GetSlider(b_atk_object).maxValue = b_status.MaxAtk;
        GetSlider(b_def_object).maxValue = b_status.MaxDef;
        GetSlider(b_exp_object).maxValue = b_status.MaxExp;
    }



    // Get slider from object
    private Slider GetSlider(GameObject obj)
    {
        return obj.transform.GetChild(2).GetComponent<Slider>();
    }
    // Get Text from object
    private Text GetText(GameObject obj)
    {
        return obj.transform.GetChild(1).GetComponent<Text>();
    }


    // make an instance
    public static StatusController statusController;
    private void Awake()
    {
        if (statusController == null)
        {
            statusController = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
