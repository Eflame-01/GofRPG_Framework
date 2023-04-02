using Godot;

///<summary>
/// Move is an abstract class that holds
/// all the basic information for each 
/// type of move.
///</summary>
public abstract class Move
{
    protected string Id {get; init;}
    public string Name {get; init;}
    public string Description {get; init;}
    public double Power {get; init;}
    public double Accuracy {get; init;}
    public string ArchetypeName {get; init;}
    public string Target {get; init;}
    public string[] Types {get; init;}
    public string PhysicalOrSpecial {get; init;}
    public int CurrentEP {get; protected set;}
    public int MaxEP {get; init;}
    //TODO: public SecondaryEffect[] SecondaryEffects {get; init;}

    //Getters and Setters
    public void SetCurrentEP(int ep)
    {
        CurrentEP = Mathf.Clamp(ep, 0, MaxEP);
    }

    ///<summary>
    /// Let's the <paramref name="user"/> perform
    /// said move on the <paramref name="target"/>.
    /// The move will vary depending on the type of move.
    ///</summary>
    ///<param name="user"> the user of the move.</param>
    ///<param name="target"> the target for the move.</param>
    public abstract void UseMove(Character user, Character target);

    ///<summary> Resets any value or status of a move. </summary>
    public virtual void ResetMove()
    {
        return;
    }

    ///<summary>
    /// Determines if the <paramref name="user"/> was
    /// able to hit <paramref name="target"/> with said move.
    ///</summary>
    ///<param name="user"> the user of the move. </param>
    ///<param name="target"> the target for said move. </param>
    ///<returns> <c>TRUE</c> if the move hit. <c>FALSE</c> if the move missed </returns>
    public bool DidMoveHit(Character user, Character target)
    {
        Unit.RANDOM.Randomize();
        int percent = Unit.RANDOM.RandiRange(1, 100);
        double chanceToHit = Accuracy + (Accuracy * user.BaseStats.Acc);
        double chanceOfDodging = (target.BaseStats.Eva/target.BaseStats.GetBaseStatTotal());

        /*
            DidMoveHit = P(chanceToHit OR chanceOfDoding)
            DidMoveHit = P(chanceToHit) + P(chanceOfDodging) - P(chanceToHit AND chanceOfDoding)
            DidMoveHit = (chanceToHit + chanceOfDodging) - (chanceToHit * chanceOfDoding)
        */
        int didMoveHit = (int)((chanceToHit + chanceOfDodging) - (chanceToHit * chanceOfDodging) * 100);

        return (didMoveHit >= percent);
    }

    ///<summary>
    /// Calculates the damage of a move based on the <paramref name="user"/>'s
    /// attack, the <paramref name="target"/>'s defense, whether the move
    /// is of the same archetype of the <paramref name="user"/>, the <paramref name="user"/>'s 
    /// abilities, the <paramref name="target"/>'s abilities, and the <paramref name="user"/>'s
    /// chance of landing a critical hit.
    ///</summary>
    ///<param name="user"> the user of the move.</param>
    ///<param name="target"> the target for the move.</param>
    ///<returns> The calculated damage for said move.</returns>
    protected int CalculateDamage(Character user, Character target)
    {
        Unit.RANDOM.Randomize();
        double critPercent = (double) (Unit.RANDOM.RandiRange(1, 100)/100.0);
        int userAtk = user.BaseStats.Atk;
        int targetDef = target.BaseStats.Def;
        int dmg;
        double newPower = Power;
        double chanceOfCrit = user.BaseStats.Crt;

        if(user.Archetype.ClassName == ArchetypeName || user.Archetype.ArchetypeName == ArchetypeName)
            newPower += Power * Unit.STAB_DMG;
        if(chanceOfCrit >= critPercent)
            newPower += Power * Unit.CRIT_DMG;
        
        //TODO: check if the user has an ability that increases certain moves
        userAtk += (int)(userAtk * newPower);
        
        //TODO: check if the target has an ability that makes them resistent to certain moves
        dmg = Mathf.Clamp(userAtk - targetDef, 1, userAtk);
        return dmg;
    }
}