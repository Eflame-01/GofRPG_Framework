
///<summary>
/// KnockoutMove is a class that extends the
/// Move class. KnockoutMoves bypass the
/// defense and health of the target and 
/// reduce thier base hp to 0, knocking them
/// out.
///</summary>
public class KnockoutMove : Move
{
    //Constructor
    //TODO: add extra parameter for secondary effects
    public KnockoutMove(string id, string name, string description, double power, double accuracy, string archetypeName, string target, string[] types, string physicalOrSpecial, int elixirPoints)
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
    /// Sets the <paramref name="target"/>'s base hp to 0.
    /// There will be exceptions if the <paramref name="target"/>
    /// has certain abilities that do not allow
    /// for this.
    ///</summary>
    ///<param name="user"> the user of the move. </param>
    ///<param name="target"> the target for the move. </param>
    public override void UseMove(Character user, Character target)
    {
        //TODO: check if target has abilities to counter this.
        target.BaseStats.SetHp(0);
    }
}