
///<summary>
/// StatChangingMove is a class that extends
/// the Move class. StatChangingMoves change
/// the stats of the target by the amount of
/// stages provided.
///</summary>
public class StatChangingMove : Move
{
    private string[] _stats {get; init;}
    private int[] _stages {get; init;}

    //Constructor
    //TODO: add extra parameter for secondary effects
    public StatChangingMove(string id, string name, string description, double power, double accuracy, string archetypeName, string target, string[] types, string physicalOrSpecial, int elixirPoints, string[] stats, int[] stages)
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

        _stats = stats;
        _stages = stages;
    }

    //TODO: update method to let user know if stats can go any higher or lower,
    ///<summary>
    /// Changes the stats of the <paramref name="target"/> based off of
    /// the _stats and the _stages array.
    ///</summary>
    ///<param name="user"> the user of the move. </param>
    ///<param name="target"> the target for the move. </param>
    public override void UseMove(Character user, Character target)
    {
        for(int i = 0; i < _stats.Length; i++)
            target.BaseStats.ChangeStat(_stats[i], _stages[i]);
    }
}