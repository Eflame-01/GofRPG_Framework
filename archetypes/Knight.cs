
///<summary>
/// The Knight Class is a class that extends
/// the Archetype Class. Knight are in the
/// DEFENDER class, which are known for their 
/// DEFENSE.
///</summary>
public class Knight : Archetype
{
    //Constructor
    public Knight()
    {
        ClassName = "DEFENDER";
        ArchetypeName = "KNIGHT";
        BaseStats = new BaseStats(4, 8, 3, 6, 4);
        StatBoost1 = new int[5]{1,2,1,2,1};
        StatBoost2 = new int[5]{1,2,1,1,2};
        StatBoost3 = new int[5]{2,1,2,1,1};
        StatBoost4 = new int[5]{1,1,2,2,1};
        StatBoost5 = new int[5]{2,1,1,1,2};
    }
}