
///<summary>
/// RegularMove is a class that extends the
/// Move class. Unless they have secondary
/// effects, RegularMoves act like regular
/// moves: the user hits their target to lower
/// their hp with no special gimmick.
///</summary>
public class RegularMove : Move
{
    //Constructor
    //TODO: add extra parameter for secondary effects
    public RegularMove(string id, string name, string description, double power, double accuracy, string archetypeName, string target, string[] types, string physicalOrSpecial, int elixirPoints)
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
    }
    
    ///<summary>
    /// Sets the <paramref name="target"/>'s base hp
    /// and subtracks it by the total damage the move will do.
    ///</summary>
    ///<param name="user"> the user of the move. </param>
    ///<param name="target"> the target for the move. </param>
    public override void UseMove(Character user, Character target)
    {
        int dmg = CalculateDamage(user, target);
        target.BaseStats.SetHp(target.BaseStats.Hp - dmg);
    }
}