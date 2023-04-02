
///<summary>
/// The MixedMartialArtist Class is a class that extends
/// the Archetype Class. MixedMartialArtist are in the
/// BRAWLER class, which are known for their 
/// SPEED.
///</summary>
public class MixedMartialArtist : Archetype
{
    //Constructor
    public MixedMartialArtist()
    {
        ClassName = "BRAWLER";
        ArchetypeName = "MIXED MARTIAL ARTIST";
        BaseStats = new BaseStats(6, 5, 3, 4, 7);
        StatBoost1 = new int[5]{2,1,1,1,2};
        StatBoost2 = new int[5]{1,2,1,1,2};
        StatBoost3 = new int[5]{1,1,2,2,1};
        StatBoost4 = new int[5]{1,1,2,2,1};
        StatBoost5 = new int[5]{1,2,1,2,1};
    }
}