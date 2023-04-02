using Godot;

///<summary>
/// Unit is a class that holds all the unchangable variables/units
/// that the Framework uses for basic calculations, assigning values,
/// and more.
///</summary>
public static class Unit
{
    public static RandomNumberGenerator RANDOM = new RandomNumberGenerator();

    public const double CRIT_DMG = 0.25;

    public const int PRIORITY_ITEM_STAGE_1 = 20;
    public const int PRIORITY_ITEM_STAGE_2 = 10;
    public const int PRIORITY_ITEM_STAGE_3 = 5;


    public const int FULL_HEAL = -1;
    public const int HALF_HEAL = -2;

    public const int FLINCH_STAGE_1 = 100;
    public const int FLINCH_STAGE_2 = 25;
    public const int FLINCH_STAGE_3 = 5;

    public const double STAB_DMG = 0.5;

    public const int ATK_INDEX = 0;
    public const int DEF_INDEX = 1;
    public const int EVA_INDEX = 2;
    public const int HP_INDEX = 3;
    public const int SPD_INDEX = 4;

    public const double BASE_ACC = 1;
    public const double BASE_CRT = 0.05;
    public const double LOWEST_CRT = 0.0125;

    public const double STAGE_POS_6 = 8/2;
    public const double STAGE_POS_5 = 7/2;
    public const double STAGE_POS_4 = 6/2;
    public const double STAGE_POS_3 = 5/2;
    public const double STAGE_POS_2 = 4/2;
    public const double STAGE_POS_1 = 3/2;
    public const double STAGE_0 = 2/2;
    public const double STAGE_NEG_1 = 2/3;
    public const double STAGE_NEG_2 = 2/4;
    public const double STAGE_NEG_3 = 2/5;
    public const double STAGE_NEG_4 = 2/6;
    public const double STAGE_NEG_5 = 2/7;
    public const double STAGE_NEG_6 = 2/8;

    public const double BURN_DMG = 0.1;

    public const int FREEZE_CHANCE_1 = 25;
    public const int FREEZE_CHANCE_2 = 50;
    public const int FREEZE_CHANCE_3 = 75;

    public const int PETRIFIED_RATE = 90;

    public const double POISON_DMG_STG_1 = 0.05;
    public const double POISON_DMG_STG_2 = 0.10;
    public const double POISON_DMG_STG_3 = 0.15;

    public const int STUN_PROB_1 = 25;
    public const int STUN_PROB_2 = 50;
    public const int STUN_PROB_3 = 75;
}