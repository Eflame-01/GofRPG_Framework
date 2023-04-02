
///<summary>
/// Player is a class that
/// extends the Character class. This 
/// class is only designed for the player
/// and allows the player's extra
/// information to be updated, such as their
/// movesets, inventory, quests, and more.
///</summary>
public class Player : Character
{
    private static Player _player;
    public int CurrXP {get; private set;}
    public int LimXP {get; private set;}
    //TODO: add _inventory;
    //TODO: add _questsManager;
    //TODO: add _moveManager;
    //TODO: add _abilityManager;

    //TODO: finish constructor
    private Player()
    {
        Id = "0";
        Name = "Player 1";
        Level = 1;
        Gold = 500;
        Archetype = Archetype.GetArchetype("archetype");
        Sex = "MALEFE";
        BattleMoves = new Move[4]{null, null, null, null};
        BaseStats = new BaseStats(5, 5, 5, 5, 5);
        BattleStatus = new BattleStatus();
        //TODO: add ability
        Item = null;
        //TODO: add _inventory
        //TODO: add _questManager
        //TODO: add _moveManager
        //TODO: add _abilityManager
    }

    //Getters and Setters
    public void SetCurrentXP(int currXP)
    {
        if(currXP < 0)
            currXP = 0;
        CurrXP = currXP;
    }
    public void SetLimitXP(int limXP)
    {
        if(limXP < 1)
            limXP = 1;
        LimXP = limXP;
    }

    ///<summary>
    /// Allows the game to get the static
    /// instance of the player's information 
    /// every time. If an instance was not
    /// created, it will instantiate one first.
    ///</summary>
    ///<returns> An instance of the player. </returns>
    public static Player Instance()
    {
        if(_player == null)
            _player = new Player();

        return _player;
    }
}