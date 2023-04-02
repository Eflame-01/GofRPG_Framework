using Godot.Collections;

///<summary>
/// StatusCondition is an abstract class that the
/// holds the method that allows all the
/// status conditions to be implemented.
///</summary>
public abstract class StatusCondition
{
    protected Dictionary<string, bool> _statusCompatabilityDictionary;
    public string Name {get; init;}

    ///<summary>
    /// Implements the status condition on the
    /// <paramref name="character"/>. The effect will
    /// vary depending on the status condition.
    ///</summary>
    ///<param name="character"> the character being inflicted.</param>
    public abstract void ImplementStatusCondition(Character character);

    ///<summary>
    /// Checks if the <paramref name="statusCondition"/> can be stacked
    /// onto the <paramref name="character"/> based on the 
    /// <paramref name="character"/>'s existing status condition.
    ///</summary>
    ///<param name="character"> the character to be checked. </param>
    ///<param name="statusCondition"> the status condition that wants to be inflicted. </param>
    ///<returns> TRUE it can stack. FALSE if it cannot. </returns>
    public static bool CanStackStatusCondition(Character character, string statusCondition)
    {
        /*Status conditions that stack:
            - BURN: POISON, STUN, SLEEP
            - POISON: BURN, STUN, SLEEP
            - STUN: BURN, POISON
            - SLEEP: BURN, POISON
            - FROZEN: POISON
            - PETRIFIED: NONE
        */
        Dictionary<string, StatusCondition> statusConditions = character.BattleStatus.StatusConditions;
        foreach(var statusInfo in statusConditions)
        {
            if(!statusInfo.Value._statusCompatabilityDictionary[statusCondition])
                return false;
        }
        
        return true;
    }

    ///<summary>
    /// Removes the <paramref name="statusCondition"/> from the 
    /// <paramref name="character"> if it exists.
    ///</summary>
    ///<param name="character"> the character having the status condition removed.</param>
    ///<param name="statusCondition"> the status condition to be removed.</param>
    public static void RemoveStatusCondition(Character character, string statusCondition)
    {
        character.BattleStatus.StatusConditions.Remove(statusCondition);
    }
}