
///<summary>
/// The EnergyManipulator Class is a class that extends
/// the Archetype Class. EnergyManipulators are in the
/// ESOIC class, which are known for their 
/// HEALTH.
///</summary>
public class EnergyManipulator : Archetype
{
    //Constructor
    public EnergyManipulator()
    {
        ClassName = "ESOIC";
        ArchetypeName = "ENERGY MANIPULATOR";
        BaseStats = new BaseStats(6, 6, 2, 8, 3);
        StatBoost1 = new int[5]{1,2,1,2,1};
        StatBoost2 = new int[5]{2,1,1,2,1};
        StatBoost3 = new int[5]{1,1,2,1,2};
        StatBoost4 = new int[5]{1,2,2,1,1};
        StatBoost5 = new int[5]{2,1,1,1,2};
    }
}