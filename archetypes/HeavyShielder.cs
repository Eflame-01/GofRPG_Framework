
///<summary>
/// The HeavyShielder Class is a class that extends
/// the Archetype Class. HeavyShielder are in the
/// DEFENDER class, which are known for their 
/// DEFENSE.
///</summary>
public class HeavyShielder : Archetype
{
    //Constructor
    public HeavyShielder()
    {
        ClassName = "DEFENDER";
        ArchetypeName = "HEAVY SHIELDER";
        BaseStats = new BaseStats(4, 9, 3, 5, 4);
        StatBoost1 = new int[5]{1,2,1,2,1};
        StatBoost2 = new int[5]{1,2,1,1,2};
        StatBoost3 = new int[5]{2,1,2,1,1};
        StatBoost4 = new int[5]{1,1,2,2,1};
        StatBoost5 = new int[5]{2,1,1,1,2};
    }
}