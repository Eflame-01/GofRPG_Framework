
///<summary>
/// The WeaponSpecialist Class is a class that extends
/// the Archetype Class. WeaponSpecialist are in the
/// SPECIALIST class, which are known for their 
/// EVASION.
///</summary>
public class WeaponSpecialist : Archetype
{
    //Constructor
    public WeaponSpecialist()
    {
        ClassName = "SPECIALIST";
        ArchetypeName = "WEAPON SPECIALIST";
        BaseStats = new BaseStats(6, 4, 5, 6, 4);
        StatBoost1 = new int[5]{1,2,1,2,1};
        StatBoost2 = new int[5]{2,1,1,2,2};
        StatBoost3 = new int[5]{1,1,3,1,1};
        StatBoost4 = new int[5]{1,2,2,1,1};
        StatBoost5 = new int[5]{1,1,2,2,1};
    }
}