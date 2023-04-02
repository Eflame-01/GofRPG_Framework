
///<summary>
/// Item is an abstract class that is
/// created so characters can use an
/// item and it's effects.
///</summary>
public abstract class Item
{
    protected string Id {get; init;}
    public string Name {get; init;}
    public string Description {get; init;}
    public string Type {get; init;}
    public bool DiscardAfterUse {get; init;}
    public bool InUse {get; protected set;}

    ///<summary> 
    /// The <paramref name="character"/> uses the item.
    /// The item's effect will vary depending on the type of item.
    ///</summary>
    ///<param name="character"> the character using the item. </param>
    public abstract void UseItem(Character character);
}