using Godot.Collections;

///<summary>
/// Petrified is a class that extends the StatusCondition
/// class. Petrified is a status condition that freezes the
/// opponent in place. Petrification lasts until the character
/// is unpetrified, either by an item, by chance, or until
/// the battle is over.
///</summary>
public class Petrified : StatusCondition
{
    //Constructor
    public Petrified()
    {
        Name = "PETRIFIED";
        _statusCompatabilityDictionary = new Dictionary<string, bool>()
        {
            {"BURN", false},
            {"POISON", false},
            {"STUN", false},
            {"SLEEP", false},
            {"FROZEN", false},
            {"PETRIFIED", false}
        };
    }

    ///<summary>
    /// Determines if the <paramref name="character"/> should
    /// become/remain petrified based on the PETRIFIED_RATE.
    /// See <see cref="Unit.PETRIFIED_RATE"/>
    ///</summary>
    ///<param name="character"> the character being petrified. </param>
    public override void ImplementStatusCondition(Character character)
    {
        Unit.RANDOM.Randomize();
        int percent = Unit.RANDOM.RandiRange(1, 100);
        if(Unit.PETRIFIED_RATE >= percent)
        {
            character.BattleStatus.SetTurnStatus("CANNOT MOVE");
            character.BattleStatus.TurnStatusTag = character.Name + " is petrified!";
        }
        else
            RemoveStatusCondition(character, Name);
    }
}