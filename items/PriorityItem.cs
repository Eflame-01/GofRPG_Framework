
///<summary>
/// PriorityItem is a class that extends
/// the Item class. PriorityItems are items
/// that have a probability of making the
/// wielder of the item go first every
/// round.
///</summary>
public class PriorityItem : Item
{
    private int _priorityProb;

    //Constructor
    public PriorityItem(string id, string name, string description, string type, int priorityStage)
    {
        Id = id;
        Name = name;
        Description = description;
        Type = type;
        DiscardAfterUse = false;
        
        switch(priorityStage)
        {
            case 1:
                _priorityProb = Unit.PRIORITY_ITEM_STAGE_1;
                break;
            case 2:
                _priorityProb = Unit.PRIORITY_ITEM_STAGE_2;
                break;
            case 3:
                _priorityProb = Unit.PRIORITY_ITEM_STAGE_3;
                break;
            default:
                _priorityProb = Unit.PRIORITY_ITEM_STAGE_3;
                break;
        }
    }
    
    ///<summary>
    /// Determines if the <paramref name="character"/> can 
    /// move first. If they can, it will adjust
    /// the <paramref name="character"/>'s turn status to 'MOVE FIRST'.
    ///</summary>
    ///<param name="character"> the character that will be using the item. </param>
    public override void UseItem(Character character)
    {
        Unit.RANDOM.Randomize();
        int percent = Unit.RANDOM.RandiRange(1, 100);
        if(_priorityProb >= percent)
            character.BattleStatus.SetTurnStatus("MOVE FIRST");
        InUse = true;
    }
}