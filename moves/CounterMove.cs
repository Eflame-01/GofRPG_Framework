
///<summary>
/// CounterMove is a class that extends
/// the Move class. CounterMoves are moves
/// that sets up a counter. This allows incoming physical
/// attacks to be reflected back at the opponent.
///</summary>
public class CounterMove : Move
{
    //Constructor
    //TODO: add extra parameter for secondary effects
    public CounterMove(string id, string name, string description, double power, double accuracy, string archetypeName, string[] types, string physicalOrSpecial, int elixirPoints)
    {
        Id = id;
        Name = name;
        Description = description;
        Power = power;
        Accuracy = accuracy;
        ArchetypeName = archetypeName;
        Target = "USER";
        Types = types;
        PhysicalOrSpecial = physicalOrSpecial;
        CurrentEP = elixirPoints;
        MaxEP = elixirPoints;
    }

    ///<summary>
    /// Sets the <paramref name="target"/> 
    /// (in this case the <paramref name="user"/>'s)
    /// protection status to 'COUNTER'
    ///</summary>
    ///<param name="user">the user of the move.</param>
    ///<param name="target">the target for the move.</param>
    public override void UseMove(Character user, Character target)
    {
        if(target.BattleStatus.ProtectionStatus == "NONE")
            target.BattleStatus.SetProtectionStatus("COUNTER");
    }
}