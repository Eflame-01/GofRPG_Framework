using System.Collections;
using Godot.Collections;

///<summary>
///BattleStatus is a class that holds the
///status of a character during battle.
///</summary>
public class BattleStatus
{
    public Move ChosenMove;
    public ArrayList ChosenTargets {get; init;}
    public Dictionary<string, StatusCondition> StatusConditions {get; init;}
    public string ProtectionStatus {get; private set;}
    public string TurnStatus {get; private set;}
    public string TurnStatusTag;

    //Constructor
    public BattleStatus()
    {
        ChosenTargets = new ArrayList();
        StatusConditions = new Dictionary<string, StatusCondition>();
        ProtectionStatus = "NONE";
        TurnStatus = "NOTHING";
    }

    //Getters and Setters
    public void SetProtectionStatus(string protectionStatus)
    {
        if(protectionStatus == null)
            protectionStatus = "NONE";
        ProtectionStatus = protectionStatus;
    }
    public void SetTurnStatus(string turnStatus)
    {
        if(turnStatus == null)
            turnStatus = "NOTHING";
        TurnStatus = turnStatus;
        
    }

    ///<summary>
    /// Resets the battle
    /// status of the player, but does not
    /// remove status conditions that are
    /// BURN, POISON, or STUN from the character.
    ///</summary>
    public void ResetBattleStatus()
    {
        ChosenTargets.Clear();
        ProtectionStatus = "NONE";
        TurnStatus = "NOTHING";
        TurnStatusTag = null;
        StatusConditions.Remove("PETRIFIED");
        StatusConditions.Remove("FROZEN");
        StatusConditions.Remove("SLEEP");
    }
}