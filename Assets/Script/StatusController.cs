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

        // Debug all status
        Debug.Log("Level: " + a_status.Level + "\n" +
                  "Hp: " + a_status.Hp + "\n" +
                  "Atk: " + a_status.Atk + "\n" +
                  "Def: " + a_status.Def + "\n" +
                  "Exp: " + a_status.Exp + "\n");
    }


    public void AttackA()
    {
        // do damage
        b_status.Hp -= a_status.Atk;
        // gain exp
        a_status.Exp += 40;

        UpdateValueA();
        UpdateValueB();
    }

    public void AttackB()
    {
        // do damage
        a_status.Hp -= b_status.Atk;
        // gain exp
        b_status.Exp += 40;

        UpdateValueA();
        UpdateValueB();
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
