
///<summary>
/// The Berserker Class is a class that extends
/// the Archetype Class. Berserkers are in the
/// BRAWLER class, which are known for their 
/// SPEED.
///</summary>
public class Berserker : Archetype
{
    //Constructor
    public Berserker()
    {
        ClassName = "BRAWLER";
        ArchetypeName = "BERSERKER";
        BaseStats = new BaseStats(7, 5, 2, 3, 8);
        StatBoost1 = new int[5]{2,1,1,1,2};
        StatBoost2 = new int[5]{1,2,1,1,2};
        StatBoost3 = new int[5]{1,1,2,2,1};
        StatBoost4 = new int[5]{1,1,2,2,1};
        StatBoost5 = new int[5]{1,2,1,2,1};
    } 
}