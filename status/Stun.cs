using Godot.Collections;

///<summary>
/// Stun is a class that extends the StatusCondition
/// class. Stun is a status condition that randomly
/// prevents the character from moving.
///</summary>
public class Stun : StatusCondition
{
    private int _stunProbability;

    //Constructor
    ///<param name="stunProbability">
    /// the number that determines the stun probability from 1-3.
    /// See <see cref="Unit.STUN_PROB_1"/>, <see cref="Unit.STUN_PROB_2"/>, and
    /// <see cref="Unit.STUN_PROB_3"/>.
    ///</param>
    public Stun(int stunProbability)
    {
        Name = "STUN";
        
        switch(stunProbability)
        {
            case 1:
                _stunProbability = Unit.STUN_PROB_1;
                break;
            case 2:
                _stunProbability = Unit.STUN_PROB_2;
                break;
            case 3:
                _stunProbability = Unit.STUN_PROB_3;
                break;
            default:
                _stunProbability = Unit.STUN_PROB_1;
                break;
        }
        _statusCompatabilityDictionary = new Dictionary<string, bool>()
        {
            {"BURN", true},
            {"POISON", true},
            {"STUN", false},
            {"SLEEP", false},
            {"FROZEN", false},
            {"PETRIFIED", false}
        };
    }

    ///<summary>
    /// Determines if the <paramref name="character"> should still be stunned due
    /// to their status condition, or if the <paramref name="character"> can
    /// move based on the _stunProbability.
    ///<summary>
    ///<param name="character"> the character being stunned </param>
    public override void ImplementStatusCondition(Character character)
    {
        Unit.RANDOM.Randomize();
        int percent = Unit.RANDOM.RandiRange(1, 100);
        if(_stunProbability >= percent)
        {
            character.BattleStatus.SetTurnStatus("CANNOT MOVE");
            character.BattleStatus.TurnStatusTag = character.Name + " is stunned!";
        }
    }
}