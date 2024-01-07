using UnityEngine;

[CreateAssetMenu(fileName = "Status", menuName = "ScriptableObjects/Status")]
public class Status : ScriptableObject
{

    public int MaxLevel;
    public int MaxHp;
    public int MaxAtk;
    public int MaxDef;
    public int MaxExp;

    public float ExpRate;
    public int _level;

    private int _hp;
    private int _atk;
    private int _def;
    private int _exp;

    // init 
    private void OnEnable()
    {
        Hp = MaxHp;
        Atk = MaxAtk*2/3;
        Def = MaxDef;
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
            if(_hp <= 0){
                _hp = 0;
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