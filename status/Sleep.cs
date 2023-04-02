using Godot.Collections;

///<summary>
/// Sleep is a class that extends the StatusCondition
/// class. Sleep is a status condition that puts a
/// character to sleep for up to 3 rounds.
///</summary>
public class Sleep : StatusCondition
{
    private int _sleepRounds;
    private int _countDown;

    //Constructor
    ///<param name="rounds"> 
    /// the amount of rounds a character will be asleep when under this status condition. 
    ///</param>
    public Sleep(int rounds)
    {
        Name = "SLEEP";
        
        if(rounds < 1)
            _sleepRounds = 1;
        else if(rounds > 3)
            _sleepRounds = 3;
        else   
            _sleepRounds = rounds;
        
        _countDown = _sleepRounds;
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
    /// Determines if the <paramref name="character"> should still be asleep due
    /// to their status condition, or if the <paramref name="character"> should
    /// wake up based on the _countDown value.
    ///<summary>
    ///<param name="character"> the character being slept... lol </param>
    public override void ImplementStatusCondition(Character character)
    {
        if(_countDown > 0)
        {
            _countDown--;
            character.BattleStatus.SetTurnStatus("CANNOT MOVE");
            character.BattleStatus.TurnStatusTag = character.Name + " is asleep!";
        }
        else
            RemoveStatusCondition(character, Name);
    }
}