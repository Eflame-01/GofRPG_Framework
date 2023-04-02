
///<summary>
/// StatusChangingMove is a class that
/// extends the Move class. StatusChangingMoves
/// inflict status conditions on the target.
///</summary>
public class StatusChangingMove : Move
{
    private StatusCondition[] _statusConditions {get; init;}

    //Constructor
    //TODO: add extra parameter for secondary effects
    public StatusChangingMove(string id, string name, string description, double power, double accuracy, string archetypeName, string target, string[] types, string physicalOrSpecial, int elixirPoints, StatusCondition[] statusConditions)
    {
        Id = id;
        Name = name;
        Description = description;
        Power = power;
        Accuracy = accuracy;
        ArchetypeName = archetypeName;
        Target = target;
        Types = types;
        PhysicalOrSpecial = physicalOrSpecial;
        CurrentEP = elixirPoints;
        MaxEP = elixirPoints;

        _statusConditions = statusConditions;
    }
    
    ///<summary>
    /// Loops though the list of status conditions
    /// and applies them to the <paramref name="target"/>. If the status condition
    /// is not compatible with what the <paramref name="target"/> already has,
    /// then it will not stack.
    ///</summary>
    ///<param name="user"> the user of the move. </param>
    ///<param name="target"> the target for the move. </param>
    public override void UseMove(Character user, Character target)
    {
        foreach(StatusCondition statusCondition in _statusConditions)
        {
            if(StatusCondition.CanStackStatusCondition(target, statusCondition.Name))
               target.BattleStatus.StatusConditions.Add(statusCondition.Name, statusCondition); 
        }
    }
}