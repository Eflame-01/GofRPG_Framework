
///<summary>
/// The RegularSwordsman Class is a class that extends
/// the Archetype Class. RegularSwordsman are in the
/// SWORDSMAN class, which are known for their 
/// ATTACK.
///</summary>
public class RegularSwordsman : Archetype
{
    //Constructor
    public RegularSwordsman()
    {
        ClassName = "SWORDSMAN";
        ArchetypeName = "REGULAR SWORDSMAN";
        BaseStats = new BaseStats(8,3,3,5,6);
        StatBoost1 = new int[5]{2,1,1,1,2};
        StatBoost2 = new int[5]{2,1,1,2,1};
        StatBoost3 = new int[5]{1,2,2,1,1};
        StatBoost4 = new int[5]{1,1,2,1,2};
        StatBoost5 = new int[5]{1,2,1,2,1};
    }
}