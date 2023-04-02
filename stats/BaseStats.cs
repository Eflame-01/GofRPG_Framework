using Godot;

///<summary>
/// BaseStats is a class the characters use to determine
/// their situations in battle, from how powerful
/// their move will be, how much they can tank said move,
/// their ability to dodge, how much health they have, how
/// fast they will be, accuracy of strikes, and even
/// the chances of critical hits.
///</summary>
public class BaseStats
{
    public int FullHp {get; private set;}
    public int Atk {get; private set;}
    public int Def {get; private set;}
    public int Eva {get; private set;}
    public int Hp {get; private set;}
    public int Spd {get; private set;}
    public double Acc {get; private set;}
    public double Crt {get; private set;}
    private int _regAtk;
    private int _regDef;
    private int _regEva;
    private int _regHp;
    private int _regSpd;
    private int _atkStage;
    private int _defStage;
    private int _evaStage;
    private int _hpStage;
    private int _spdStage;
    private int _accStage;
    private int _crtStage;

    //Constructor
    public BaseStats(int atk, int def, int eva, int hp, int spd)
    {
        FullHp = hp;
        Atk = atk;
        Def = def;
        Eva = eva;
        Hp = hp;
        Spd = spd;
        Acc = Unit.BASE_ACC;
        Crt = Unit.BASE_CRT;

        _regAtk = atk;
        _regDef = def;
        _regEva = eva;
        _regHp = hp;
        _regSpd = spd;
    }

    //Getters and Setters
    public void SetAtk(int atk)
    {
        if(atk < 0)
            atk = 0;
        Atk = atk;
    }
    public void SetDef(int def)
    {
        if(def < 0)
            def = 0;
        Def = def;
    }
    public void SetEva(int eva)
    {
        if(eva < 0)
            eva = 0;
        Eva = eva;
    }
    public void SetSpd(int spd)
    {
        if(spd < 0)
            spd = 0;
        Spd = spd;
    }
    public void SetHp(int hp)
    {
        Hp = Mathf.Clamp(hp, 0, FullHp);
    }
    public void SetFullHp(int fullHp)
    {
        if(fullHp < 1)
            fullHp = 1;
        FullHp = fullHp;
    }
    public void SetAcc(double acc)
    {
        if(acc < Unit.STAGE_NEG_6)
            acc = Unit.STAGE_NEG_6;
        Acc = acc;
    }
    public void SetCrt(double crt)
    {
        if(crt < Unit.LOWEST_CRT)
            crt = Unit.LOWEST_CRT;
    }

    ///<summary>
    /// Takes the <paramref name="stats"/> array
    /// and boosts the basestats of the character.
    ///</summary>
    ///<param name="stats"> the array of stat values to be added </param>
    public void LevelUpStats(int[] stats)
    {
        _regAtk += stats[Unit.ATK_INDEX];
        _regDef += stats[Unit.DEF_INDEX];
        _regEva += stats[Unit.EVA_INDEX];
        _regHp += stats[Unit.HP_INDEX];
        _regSpd += stats[Unit.SPD_INDEX];

        FullHp += stats[Unit.HP_INDEX];
        Atk += stats[Unit.ATK_INDEX];
        Def += stats[Unit.DEF_INDEX];
        Eva += stats[Unit.EVA_INDEX];
        Hp += stats[Unit.HP_INDEX];
        Spd += stats[Unit.SPD_INDEX];
    }

    ///<summary> Gets the total base stat of the character. </summary>
    ///<returns> The total base stat of a player.</returns>
    public int GetBaseStatTotal()
    {
        return Atk + Def + Eva + FullHp + Spd;
    }

    ///<summary>
    /// Resets the battle stats
    /// to the normal stats except for the
    /// hp.
    ///</summary>
    public void ResetStats()
    {
        if(Hp > _regHp)
            Hp = _regHp;
        
        FullHp = _regHp;
        Atk = _regAtk;
        Def = _regDef;
        Eva = _regEva;
        Spd = _regSpd;
        Acc = Unit.BASE_ACC;
        Crt = Unit.BASE_CRT;
    }

    ///<summary>
    /// Takes the <paramref name="name"> of the stat and the <paramref name="stage">
    /// it will be boosted/reduced by. If the current stage is -6,
    /// then it cannot go any lower. If the current stage is 6,
    /// then it cannot go any higher.
    ///</summary>
    ///<param name="name">the name of the stat</param>
    ///<param name="stage">the stage value between -6 and 6.</param>
    ///<returns>TRUE if the base stat was changed. FALSE if it wasn't. </returns>
    public bool ChangeStat(string name, int stage)
    {
        switch(name)
        {
            case "ATK":
                return ChangeStatHelper(Atk, _regAtk, _atkStage, stage);
            case "DEF":
                return ChangeStatHelper(Def, _regDef, _defStage, stage);
            case "EVA":
                return ChangeStatHelper(Eva, _regEva, _evaStage, stage);
            case "HP":
                return ChangeStatHelper(Hp, _regHp, _hpStage, stage);
            case "SPD":
                return ChangeStatHelper(Spd, _regSpd, _spdStage, stage);
            case "ACC":
                return ChangeStatHelper(Acc, Unit.BASE_ACC, _accStage, stage);
            case "CRT":
                return ChangeStatHelper(Crt, Unit.BASE_CRT, _crtStage, stage);
            default:
                return false;
        }
    }

    //helper method to the ChangeStat method
    private bool ChangeStatHelper(double stat, double regStat, int statStage, int stage)
    {
        if(statStage == 6 || statStage == -6)
            return false;

        stage = Mathf.Clamp(stage, -6, 6);
        statStage += stage;
        
        switch(statStage)
        {
            case -6:
                stat = (int)(regStat * Unit.STAGE_NEG_6);
                break;
            case -5:
                stat = (int)(regStat * Unit.STAGE_NEG_5);
                break;
            case -4:
                stat = (int)(regStat * Unit.STAGE_NEG_4);
                break;
            case -3:
                stat = (int)(regStat * Unit.STAGE_NEG_3);
                break;
            case -2:
                stat = (int)(regStat * Unit.STAGE_NEG_2);
                break;
            case -1:
                stat = (int)(regStat * Unit.STAGE_NEG_1);
                break;
            case 0:
                stat = (int)(regStat * Unit.STAGE_0);
                break;
            case 1:
                stat = (int)(regStat * Unit.STAGE_POS_1);
                break;
            case 2:
                stat = (int)(regStat * Unit.STAGE_POS_2);
                break;
            case 3:
                stat = (int)(regStat * Unit.STAGE_POS_3);
                break;
            case 4:
                stat = (int)(regStat * Unit.STAGE_POS_4);
                break;
            case 5:
                stat = (int)(regStat * Unit.STAGE_POS_5);
                break;
            case 6:
                stat = (int)(regStat * Unit.STAGE_POS_6);
                break;
        }

        if(Hp > FullHp)
            FullHp = Hp;
        
        return true;
    }
}