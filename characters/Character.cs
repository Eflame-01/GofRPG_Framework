using Godot;

///<summary>
/// Character is a class that
/// holds all the character's basic information
/// needed for the GofRPG_API.
///</summary>
public class Character
{
    public string Id {get; init;}
    public string Name {get; init;}
    public int Level {get; protected set;}
    public int Gold {get; protected set;}
    public Archetype Archetype {get; init;}
    //TODO: add ability
    public string Sex {get; init;}
    public Move[] BattleMoves {get; init;}
    public BaseStats BaseStats {get; init;}
    public BattleStatus BattleStatus {get; init;}
    public Item Item {get; protected set;}

    //Constructor
    public Character(string id, string name, int level, int gold, string archetype, string sex, string[] battleMoves, int[] stats, Item item)
    {
        Id = id;
        Name = name;
        Level = level;
        Gold = gold;
        Archetype = Archetype.GetArchetype(archetype);
        Sex = sex;
        //TODO: generate move from list of moves based off name
        // BattleMoves = battleMoves;
        BaseStats = new BaseStats(stats[0], stats[1], stats[3], stats[4], stats[5]);
        BattleStatus = new BattleStatus();
        //TODO: add ability
        Item = item;
    }

    //Empty Constructor
    public Character()
    {

    }
    
    //Getters and Setters
    public void SetLevel(int level)
    {
        Level = Mathf.Clamp(level, Level, 100);
    }
    public void SetGold(int gold)
    {
        if(gold < 0)
            gold = 0;
        Gold = gold;
    }
    //TODO: create set for ability
    public void SetItem(Item item)
    {
        if(Item == null)
            Item = item;
    }
}