
///<summary>
/// FoodItem is a class that extends
/// the Item class. A FoodItem essentially
/// heals the character by a set amount
/// of health.
///</summary>
public class FoodItem : Item
{
    private int _healAmount {get; init;}

    //Constructor
    public FoodItem(string id, string name, string description, string type, int healAmount)
    {
        Id = id;
        Name = name;
        Description = description;
        Type = type;
        DiscardAfterUse = true;
        _healAmount = healAmount;
    }

    ///<summary>
    /// Increments the <paramref name="character"/>'s base hp by the _healAmount.
    ///</summary>
    ///<param name="character"> the character that will be using the item. </param>
    public override void UseItem(Character character)
    {
        character.BaseStats.SetHp(character.BaseStats.Hp + _healAmount);
        InUse = true;
    }
}