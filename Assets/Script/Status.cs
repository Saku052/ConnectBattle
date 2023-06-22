using UnityEngine;

[CreateAssetMenu(fileName = "Status", menuName = "ScriptableObjects/Status")]
public class Status : ScriptableObject
{
    public int MaxLevel;
    public int MaxHp;
    public int MaxAtk;
    public int MaxDef;
    public int MaxExp;

    private int _level;
    private int _hp;
    private int _atk;
    private int _def;
    private int _exp;

    // init 
    private void OnEnable()
    {
        Level = 1;
        Hp = MaxHp;
        Atk = MaxAtk;
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
                LevelUp(_exp - MaxExp);
            }
        }}

        private void LevelUp(int leftExp)
        {
            // increase status
            MaxHp += Level;
            MaxAtk += Level;
            MaxDef += Level;
            MaxExp += Level;

            // reset status
            Hp = MaxHp;
            Atk = MaxAtk;
            Def = MaxDef;
            Exp = leftExp;

            // increase level
            Level++;
        }   
}