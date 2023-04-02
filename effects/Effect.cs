
///<summary>
/// Effect is a class that creates the effects
/// for characters' abilities, moves, and items.
///</summary>
public class Effect
{
    /**list of effects
        - stat change
        - status condition
        - recoil damage
        - recharge
        - health boost
        - immunity
    */
    public string Id {get; private set;}
    public string Name {get; private set;}
    public string Description {get; private set;}
    public string Type {get; private set;}
    public string[] Targets {get; private set;}
}