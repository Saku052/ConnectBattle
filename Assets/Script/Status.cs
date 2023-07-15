using UnityEngine;

[CreateAssetMenu(fileName = "Status", menuName = "ScriptableObjects/Status")]
public class Status : ScriptableObject
{
    public int initMaxHp;
    public int initMaxAtk;
    public int initMaxDef;
    public int initMaxExp;

    public int MaxLevel;
    public int MaxHp;
    public int MaxAtk;
    public int MaxDef;
    public int MaxExp;

    public float ExpRate;

    private int _level;
    private int _hp;
    private int _atk;
    private int _def;
    private int _exp;

    // init 
    private void OnEnable()
    {
        MaxHp = initMaxHp;
        MaxAtk = initMaxAtk;
        MaxDef = initMaxDef;
        MaxExp = initMaxExp;

        Level = 1;
        Hp = MaxHp;
        Atk = MaxAtk/4;
        Def = MaxDef/4;
        Exp = 0;
    }

    public int Level{
        get{
            return _level;
        } set{
            _level = value;
            if(_level > MaxLevel){
                _level = MaxLevel;
            }
        }}

    public int Hp{
        get{
            return _hp;
        } set{
            _hp = value;
            if(_hp > MaxHp){
                _hp = MaxHp;
            }
        }}
    
    public int Atk{
        get{
            return _atk;
        } set{
            _atk = value;
            if(_atk > MaxAtk){
                _atk = MaxAtk;
            }
        }}
    
    public int Def{
        get{
            return _def;
        } set{
            _def = value;
            if(_def > MaxDef){
                _def = MaxDef;
            }
        }}
    
    public int Exp{
        get{
            return _exp;
        } set{
            _exp = value;
            if(_exp > MaxExp){
                StatusController.statusController.Levelup(this, _exp - MaxExp);
            }
        }}

        
}