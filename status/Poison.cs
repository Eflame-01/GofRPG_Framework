using Godot.Collections;

///<summary>
/// Poison is a class that extends the StatusCondition
/// class. Like <see cref="Burn"/>, Poison also deals damage
/// incrementally. However, there is more than one rate
/// to poison a character.
///</summary>
public class Poison : StatusCondition
{
    private double _poisonDmg;

    //Constructor
    ///<param name="stage">
    /// the poison rate from a scale of 1-3.
    /// See <see cref="Unit.POISON_DMG_STG_1"/>, <see cref="Unit.POISON_DMG_STG_2"/>, and
    /// <see cref="Unit.POISON_DMG_STG_3"/>
    ///</param>
    public Poison(int stage)
    {
        Name = "POISON";
        
        switch(stage)
        {
            case 1:
                _poisonDmg = Unit.POISON_DMG_STG_1;
                break;
            case 2:
                _poisonDmg = Unit.POISON_DMG_STG_2;
                break;
            case 3:
                _poisonDmg = Unit.POISON_DMG_STG_3;
                break;
            default:
                _poisonDmg = Unit.POISON_DMG_STG_1;
                break;
        }
        _statusCompatabilityDictionary = new Dictionary<string, bool>()
        {
            {"BURN", true},
            {"POISON", false},
            {"STUN", true},
            {"SLEEP", true},
            {"FROZEN", false},
            {"PETRIFIED", false}
        };
    }

    ///<summary>
    /// Takes the <paramref name="character"/> and decrements
    /// their base hp by the _poisonDmg value.
    ///</summary>
    ///<param name="character"> the character being poisoned. </param>
    public override void ImplementStatusCondition(Character character)
    {
        int oldHp = character.BaseStats.Hp;
        int newHp = oldHp - (int)(oldHp * _poisonDmg);
        if(oldHp == newHp)
            newHp--;
        character.BaseStats.SetHp(newHp);
    }
}