
///<summary>
/// The NatureManipulator Class is a class that extends
/// the Archetype Class. NatureManipulator are in the
/// ESOIC class, which are known for their 
/// HEALTH.
///</summary>
public class NatureManipulator : Archetype
{
    //Constructor
    public NatureManipulator()
    {
        ClassName = "ESOIC";
        ArchetypeName = "NATURE MANIPULATOR";
        BaseStats = new BaseStats(6, 5, 2, 10, 2);
        StatBoost1 = new int[5]{1,2,1,2,1};
        StatBoost2 = new int[5]{2,1,1,2,1};
        StatBoost3 = new int[5]{1,1,2,1,2};
        StatBoost4 = new int[5]{1,2,2,1,1};
        StatBoost5 = new int[5]{2,1,1,1,2};
    }
}