
///<summary>
/// The DualSwordsman Class is a class that extends
/// the Archetype Class. DualSwordsman are in the
/// SWORDSMAN class, which are known for their 
/// ATTACK.
///</summary>
public class DualSwordsman : Archetype
{
    //Constructor
    public DualSwordsman()
    {
        ClassName = "SWORDSMAN";
        ArchetypeName = "DUAL SWORDSMAN";
        BaseStats = new BaseStats(10,3,3,4,5);
        StatBoost1 = new int[5]{2,1,1,1,2};
        StatBoost2 = new int[5]{2,1,1,2,1};
        StatBoost3 = new int[5]{1,2,2,1,1};
        StatBoost4 = new int[5]{1,1,2,1,2};
        StatBoost5 = new int[5]{1,2,1,2,1};
    }
}