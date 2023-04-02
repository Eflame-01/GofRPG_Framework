using Godot;

///<summary>
/// PriorityMove is a class that extends the Move
/// class. PriorityMoves are moves that hit the
/// target and have the potential to make them 
/// FLINCH. The likelyhood of the target flinches
/// decreases every time the move is used.
///</summary>
public class PriorityMove : Move
{
    public int PriorityLevel {get; init;}
    private int _stage;
    private int _flinchPercent;

    //Constructor
    //TODO: add extra parameter for secondary effects
    public PriorityMove(string id, string name, string description, double power, double accuracy, string archetypeName, string target, string[] types, string physicalOrSpecial, int elixirPoints, int priorityLevel)
    {
        Id = id;
        Name = name;
        Description = description;
        Power = power;
        Accuracy = accuracy;
        ArchetypeName = archetypeName;
        Target = target;
        Types = types;
        PhysicalOrSpecial = physicalOrSpecial;
        CurrentEP = elixirPoints;
        MaxEP = elixirPoints;

        PriorityLevel = priorityLevel;
        SetFlinchPercent(priorityLevel);
    }

    ///<summary>
    /// Damages the <paramref name="target"/>. After damaging the
    /// <paramref name="target"/>, it will then check if the <paramref name="target"/> should
    /// flinch. After this, it will change the likelihood
    /// of flinch working in the future.
    ///</summary>
    ///<param name="user"> the user of the move. </param>
    ///<param name="target"> the target for the move. </param>
    public override void UseMove(Character user, Character target)
    {
        int dmg = CalculateDamage(user, target);
        target.BaseStats.SetHp(target.BaseStats.Hp - dmg);
        if(Flinched())
            target.BattleStatus.SetTurnStatus("FLINCHED");
        _stage++;
        SetFlinchPercent(_stage);
    }

    ///summary>
    /// Resets the _stage and the 
    /// _flinchPercent based on the PriorityLevel
    /// of the move.
    ///</summary>
    public override void ResetMove()
    {
        SetFlinchPercent(PriorityLevel);
    }

    private bool Flinched()
    {
        Unit.RANDOM.Randomize();
        int percent = Unit.RANDOM.RandiRange(1, 100);
        if(_flinchPercent >= percent)
            return true;
        return false;
    }

    private void SetFlinchPercent(int stage)
    {
        _stage = Mathf.Clamp(stage, 1, 3);

        switch(_stage)
        {
            case 1:
                _flinchPercent = Unit.FLINCH_STAGE_1;
                break;
            case 2:
                _flinchPercent = Unit.FLINCH_STAGE_2;
                break;
            case 3:
                _flinchPercent = Unit.FLINCH_STAGE_3;
                break;
            default:
                _flinchPercent = Unit.FLINCH_STAGE_3;
                break;
        }
    }
}