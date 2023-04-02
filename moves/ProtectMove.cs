
///<summary>
/// ProtectMove is a class that extends
/// the Move class. ProtectMoves are moves
/// that sets the character's protection status
/// to protect the character for PHYSICAL,
/// SPECIAL, STATUS, or ALL types of moves.
///</summary>
public class ProtectMove : Move
{
    private string _protectType;
    private double _successionRate;
    private double _tempAccuracy;

    //Constructor
    //TODO: add extra parameter for secondary effects
    public ProtectMove(string id, string name, string description, double power, string archetypeName, string target, string[] types, string physicalOrSpecial, int elixirPoints, string protectType, double successtionRate)
    {
        Id = id;
        Name = name;
        Description = description;
        Power = power;
        Accuracy = 1.0;
        ArchetypeName = archetypeName;
        Target = target;
        Types = types;
        PhysicalOrSpecial = physicalOrSpecial;
        CurrentEP = elixirPoints;
        MaxEP = elixirPoints;

        _protectType = protectType;
        _successionRate = successtionRate;
        _tempAccuracy = 1.0;
    }

    ///<summary>
    /// Takes the <paramref name="target"/>'s protection
    /// status and sets it based on the _protectionType
    /// of the move. After this, the accurracy will continue
    /// to decrease if the move is successful. If the move is
    /// not successful, the move will become successful the next
    /// time it is used.
    ///</summary>
    ///<param name="user"> the user of the move. </param>
    ///<param name="target"> the target for the move. </param>
    public override void UseMove(Character user, Character target)
    {
        if(ProtectMoveWork(target))
        {
            target.BattleStatus.SetProtectionStatus(_protectType);
            _tempAccuracy *= _successionRate;
        }
        else
            _tempAccuracy = Accuracy;
    }

    ///<summary> Resets the _tempAccuracy of the move. </summary>
    public override void ResetMove()
    {
        _tempAccuracy = Accuracy;
    }

    private bool ProtectMoveWork(Character character)
    {
        Unit.RANDOM.Randomize();
        double percent = Unit.RANDOM.RandiRange(1, 100)/100;
        if(_tempAccuracy < percent)
            return false;
        if(character.BattleStatus.ProtectionStatus != "NONE")
            return false;
        return true;
    }
}