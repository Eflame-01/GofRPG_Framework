using Godot.Collections;

///<summary>
/// Frozen is a class that extends the StatusCondition
/// class. Frozen is a status condition that freezes 
/// a character, and they have a set chance of thawing
/// out after each round.
///</summary>
public class Frozen : StatusCondition
{
    private int _freezeChance;

    //Constructor
    ///<param name="freezeChance">
    /// the number that determines the percentage they will freeze between 1-3.
    /// See <see cref="Unit.FREEZE_CHANCE_1"/>, <see cref="Unit.FREEZE_CHANCE_2"/>,
    /// and <see cref="Unit.FREEZE_CHANCE_3"/>
    ///</param>
    public Frozen(int freezeChance)
    {
        Name = "FROZEN";
        
        if(freezeChance < 1)
            _freezeChance = Unit.FREEZE_CHANCE_1;
        else if(freezeChance > 3)
            _freezeChance = Unit.FREEZE_CHANCE_2;
        else
            _freezeChance = Unit.FREEZE_CHANCE_3;
        
        _statusCompatabilityDictionary = new Dictionary<string, bool>()
        {
            {"BURN", false},
            {"POISON", true},
            {"STUN", false},
            {"SLEEP", false},
            {"FROZEN", false},
            {"PETRIFIED", false}
        };
    }

    ///<summary>
    /// Determines if the <paramref name="character"/> should
    /// become/remain frozen based on the _freezeChance.
    ///</summary>
    ///<param name="character"> the character being frozen.</param>
    public override void ImplementStatusCondition(Character character)
    {
        Unit.RANDOM.Randomize();
        int percent = Unit.RANDOM.RandiRange(1, 100);
        if(_freezeChance >= percent)
        {
            character.BattleStatus.SetTurnStatus("CANNOT MOVE");
            character.BattleStatus.TurnStatusTag = character.Name + " is frozen!";
        }
        else
            RemoveStatusCondition(character, Name);
    }
}