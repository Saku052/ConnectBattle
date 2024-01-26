using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using DG.Tweening;  

public class StatusController : MonoBehaviour
{

    // get status scriptable object
    [SerializeField] private Status a_status;
    [SerializeField] private Status b_status;

    // place data inside this array
    public static string[,] Statusdata;
    [SerializeField] private TextAsset csv;

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



    private async void Start()
    {
        // complete reading csv
        await ReadCsv(csv);
        await GetStatus(1);
        a_status.Level = 1;
        a_status.Exp = 0;

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


    public void CrackAttack()
    {   
        // get Change in status after attack
        (Status main, Status enemy, int return_damage) = a_status.MalWare.Crack(a_status, b_status);

        a_status = main;
        b_status = enemy;

        DamageAnimationCommand.damageAnimationCommand.DamageAnima(return_damage);

        // gain exp when enemy is dead
        if (b_status.Hp <= 0)
            a_status.Exp += b_status.MaxExp;


        UpdateValueA();
        UpdateValueB();
    }


    public void BurstAttack()
    {
        // get Change in status after attack
        (Status main, Status enemy, int return_damage) = a_status.MalWare.Burst(a_status, b_status);
        
        a_status = main;
        b_status = enemy;

        DamageAnimationCommand.damageAnimationCommand.DamageAnima(return_damage);

        // gain exp when enemy is dead
        if (b_status.Hp <= 0)
            a_status.Exp += b_status.MaxExp;

        UpdateValueA();
        UpdateValueB();
    }

    public void AttackB()
    {

        a_status.Hp -= DamageCalc.AtkCalc(b_status, a_status);
        a_status.Def -= DamageCalc.DefCalc(b_status, a_status);
        
        // gain exp when enemy is dead
        if (a_status.Hp <= 0)
            b_status.Exp += a_status.MaxExp;

        UpdateValueA();
        UpdateValueB();
    }


    // Level up
    public async void Levelup(Status status, int exp)
    {

        // level up
        status.Level++;

        // update max value
        await GetStatus(status.Level);

        // update value
        a_status.Exp = exp;

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

    // Read csv
    private Task ReadCsv(TextAsset csv)
    {
        // read csv
        string[] lines = csv.text.Split('\n');

        // get row and column
        int rows = lines.Length;
        int columns = lines[0].Split(',').Length;

        // initialize array
        Statusdata = new string[rows, columns];

        // place data inside array
        for (int i = 0; i < rows; i++)
        {
            string[] data = lines[i].Split(',');
            for (int j = 0; j < columns; j++)
            {
                Statusdata[i, j] = data[j];
            }
        }
        return Task.CompletedTask;
    }

    // Get status from csv
    public Task GetStatus(int level)
    {
        a_status.MaxHp = 
        DamageCalc.DamageCalculation(DamageCalc.StatusType.HpRate, int.Parse(Statusdata[level, 1]), a_status.MalWare);
        a_status.MaxAtk =
        DamageCalc.DamageCalculation(DamageCalc.StatusType.AtkRate, int.Parse(Statusdata[level, 2]), a_status.MalWare);
        a_status.MaxDef =
        DamageCalc.DamageCalculation(DamageCalc.StatusType.DefRate, int.Parse(Statusdata[level, 3]), a_status.MalWare);

        a_status.CritRate = int.Parse(Statusdata[level, 4]);
        a_status.CritDmg = int.Parse(Statusdata[level, 5]);

        a_status.Hp = a_status.MaxHp;
        a_status.Atk = a_status.MaxAtk*2/3;
        a_status.Def = a_status.MaxDef;

        return Task.CompletedTask;
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
