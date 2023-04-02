
///<summary>
/// HealingItem is a class that extends
/// the Item class. HealingItems heal
/// the character by a certain percentage
/// at the end of every round.
///</summary>
public class HealingItem : Item
{
    private double _healPercent {get; init;}

    //Constructor
    public HealingItem(string id, string name, string description, string type, double healPercent)
    {
        Id = id;
        Name = name;
        Description = description;
        Type = type;
        DiscardAfterUse = false;
        _healPercent = healPercent;
    }

    ///<summary>
    /// Increments the <paramref name="character"/>'s base by a certain
    /// percentage of the <paramref name="character"/>'s full hp stat.
    ///</summary>
    ///<param name="character"> the character that will be using the item. </param>
    public override void UseItem(Character character)
    {
        int fullHp = character.BaseStats.FullHp;
        int newHp = character.BaseStats.Hp;
        newHp += (int)(fullHp * _healPercent);
        character.BaseStats.SetHp(newHp);
        InUse = true;
    }
}