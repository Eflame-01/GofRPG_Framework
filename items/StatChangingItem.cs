
///<summary>
/// StatChangingItem is a class that extends the 
/// Item class. StatChangingItems change the stats
/// of the user by a FIXED static amount once the 
/// user equips the item.
///</summary>
public class StatChangingItem : Item
{
    private string[] _stats;
    private int[] _values;

    public StatChangingItem(string id, string name, string description, string type, string[] stats, int[] values)
    {
        Id = id;
        Name = name;
        Description = description;
        Type = type;
        DiscardAfterUse = true;
        _stats = stats;
        _values = values;
    }

    
    public override void UseItem(Character character)
    {
        for(int i = 0; i < _stats.Length; i++)
        {
            switch(_stats[i])
            {
                case "ATK":
                    character.BaseStats.SetAtk(character.BaseStats.Atk + _values[i]);
                    break;
                case "Def":
                    character.BaseStats.SetDef(character.BaseStats.Def + _values[i]);
                    break;
                case "EVA":
                    character.BaseStats.SetEva(character.BaseStats.Eva + _values[i]);
                    break;
                case "HP":
                    character.BaseStats.SetHp(character.BaseStats.Hp + _values[i]);
                    character.BaseStats.SetFullHp(character.BaseStats.FullHp + _values[i]);
                    break;
                case "SPD":
                    character.BaseStats.SetSpd(character.BaseStats.Spd + _values[i]);
                    break;
                default:
                    break;
            }
        }
    }
}