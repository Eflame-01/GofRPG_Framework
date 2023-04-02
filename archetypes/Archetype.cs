
///<summary>
/// Archetype is a class that is assigned to a 
/// character to determine what moves they will learn,
/// what abilities they will develop, how their stats will
/// increase as they level, and how effective certain moves
/// will be.
///</summary>
public class Archetype
{
    public string ClassName {get; init;}
    public string ArchetypeName {get; init;}
    public BaseStats BaseStats  {get; init;}
    protected int[] StatBoost1 {private get; init;} //50% chance of getting boost stat
    protected int[] StatBoost2 {private get; init;} //25% chance of getting boost stat
    protected int[] StatBoost3 {private get; init;} //12% chance of getting boost stat
    protected int[] StatBoost4 {private get; init;} //7% chance of getting boost stat
    protected int[] StatBoost5 {private get; init;} //6% chance of getting boost stat

    ///<summary>
    /// Picks a number between 0 and 100 and selects 1 of 5
    /// stat boosting options based off of the result.
    /// <list> - statBoost1 = 50% likely </list>
    /// <list> - statBoost2 = 25% likely </list>
    /// <list> - statBoost3 = 12% likely </list>
    /// <list> - statBoost4 =  7% likely </list>
    /// <list> - statBoost6 =  6% likely </list>
    ///</summary>
    public int[] ChooseStatBoostRandomly()
    {
        Unit.RANDOM.Randomize();
        int percent = Unit.RANDOM.RandiRange(0, 100);

        if(percent < 50)
            return StatBoost1;
        else if(percent < 75)
            return StatBoost2;
        else if(percent < 87)
            return StatBoost3;
        else if(percent < 94)
            return StatBoost4;
        else
            return StatBoost5;
    }

    ///<summary>
    /// Returns an instance of a new Archetype based off of the
    /// name of the <paramref name="archetype"/>. If the
    /// <paramref name="archetype"/> name does not match,
    /// then it will return null.
    ///</summary>
    ///<param name="archetype">the archetype name in all caps.</param>
    ///<returns> Any of the 10 archetypes that extend the Archetype class, or null </returns>
    public static Archetype GetArchetype(string archetype)
    {
        switch(archetype)
        {
            case "REGULAR SWORDSMAN":
                return new RegularSwordsman();
            case "DUAL SWORDSMAN":
                return new DualSwordsman();
            case "KNIGHT":
                return new Knight();
            case "HEAVY SHIELDER":
                return new HeavyShielder();
            case "ENERGY MANIPULATOR":
                return new EnergyManipulator();
            case "NATURE MANIPULATOR":
                return new NatureManipulator();
            case "MIXED MARTIAL ARTIST":
                return new MixedMartialArtist();
            case "BERSERKER":
                return new Berserker();
            case "WEAPON SPECIALIST":
                return new WeaponSpecialist();
            case "COMBAT SPECIALIST":
                return new CombatSpecialist();
            default:
                return null;
        }
    }
}