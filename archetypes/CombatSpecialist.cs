
///<summary>
/// The CombatSpecialist Class is a class that extends
/// the Archetype Class. CombatSpecialist are in the
/// SPECIALIST class, which are known for their 
/// EVASION.
///</summary>
public class CombatSpecialist : Archetype
{
    //Constructor
    public CombatSpecialist()
    {
        ClassName = "SPECIALIST";
        ArchetypeName = "COMBAT SPECIALIST";
        BaseStats = new BaseStats(4, 6, 5, 4, 6);
        StatBoost1 = new int[5]{2,1,1,1,2};
        StatBoost2 = new int[5]{1,2,1,2,1};
        StatBoost3 = new int[5]{1,1,3,1,1};
        StatBoost4 = new int[5]{1,1,2,2,1};
        StatBoost5 = new int[5]{1,2,2,1,1};
    }
}