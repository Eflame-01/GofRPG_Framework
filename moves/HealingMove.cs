using Godot;

///<summary>
/// HealingMove is a class that extends the Move
/// class. HealingMoves are designed to heal the 
/// target. Because of this, the move is uneffected
/// by the target's DEF stat.
///</summary>
public class HealingMove : Move
{
    //Constructor
    //TODO: add extra parameter for secondary effects
    public HealingMove(string id, string name, string description, double power, double accuracy, string archetypeName, string target, string[] types, string physicalOrSpecial, int elixirPoints)
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
    /// After calculating the healAmount, the
    /// <paramref name="user"/> proceeds to heal the
    /// <paramref name="target"/> by said heal amount.
    /// This bypasses the <paramref name="target"/>'s
    /// defense.
    ///</summary>
    ///<param name="user"> the user of the move. </param>
    ///<param name="target"> the target for the move. </param>
    public override void UseMove(Character user, Character target)
    {
        //TODO: calculate healingpower
        int healAmount = CalculateDamage(user, target);
        target.BaseStats.SetHp(healAmount);
    }

    //helper to the UseMov method.
    private int CalculateHealingPower(Character user, Character target)
    {
        int healingPower = user.BaseStats.Atk;
        int max = target.BaseStats.FullHp - target.BaseStats.Hp;

        healingPower += (int)(healingPower * Power);

        if(user.Archetype.ClassName == ArchetypeName || user.Archetype.ClassName == ArchetypeName)
            healingPower += (int)(healingPower * Unit.STAB_DMG);
        
        return Mathf.Clamp(healingPower, 1, max);
    }
}