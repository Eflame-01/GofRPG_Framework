
///<summary>
/// MedicalItem is a class that extends
/// the Item class. MedicalItem works by
/// healing the character's health, and/or
/// curing the character of any status
/// condition.
///</summary>
public class MedicalItem : Item
{
    private int _healAmount;
    private string[] _statusConditions;

    //Constructor
    public MedicalItem(string id, string name, string description, string type, int healAmount, string[] statusConditions)
    {
        Id = id;
        Name = name;
        Description = description;
        Type = type;
        DiscardAfterUse = true;
        _healAmount = healAmount;
        _statusConditions = statusConditions;
    }

    ///<summary>
    /// Restores the <paramref name="character"/>'s base HP
    /// either by a fixed amount or by half/all
    /// their HP. If possible, it will also cure the
    /// <paramref name="character"/>'s status conditions if character
    /// has one.
    ///</summary>
    ///<param name="character"> the character that will be using the item. </param>
    public override void UseItem(Character character)
    {
        HealPlayer(character);
        CureStatusCondition(character);
        InUse = true;
    }

    private void HealPlayer(Character character)
    {
        int hp = character.BaseStats.Hp;
        int fullHp = character.BaseStats.FullHp;
        switch(_healAmount)
        {
            case 0:
                break;
            case Unit.FULL_HEAL:
                character.BaseStats.SetHp(fullHp);
                break;
            case Unit.HALF_HEAL:
                int halfHp = fullHp/2;
                if(hp < halfHp)
                    character.BaseStats.SetHp(halfHp);
                break;
            default:
                hp += _healAmount;
                character.BaseStats.SetHp(hp);
                break;
        }
    }

    private void CureStatusCondition(Character character)
    {
        if(_statusConditions[0] == "ALL")
        {
            character.BattleStatus.StatusConditions.Clear();
            return;
        }
        
        for(int i = 0; i < _statusConditions.Length; i++)
        {
            character.BattleStatus.StatusConditions.Remove(_statusConditions[i]);
        }
    }
}