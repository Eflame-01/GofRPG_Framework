
///<summary>
/// KeyItem is a class that extends
/// the Item class. KeyItems have no
/// real benefit apart from being a key
/// item. They are mainly used to progress
/// the plot forward within the game.
///</summary>
public class KeyItem : Item
{
    ///<summary> UseItem let's the game know that the item is now in use. </summary>
    ///<param name="character"> the character that will be using the item. </param>
    public override void UseItem(Character character)
    {
        InUse = true;
    }
}