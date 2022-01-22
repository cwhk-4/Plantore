using UnityEngine;

public static class AnimalData
{
    public struct AnimalBase
    {
        public int AnimalType { get; set; }
        public int TypeNum { get; set; }
        public int TargetIndex { get; set; }
        public int TargetType { get; set; }
        public Vector3 TargetPos { get; set; }
        public Vector3 OriginalPos { get; set; }
        public float CDStartingTime { get; set; }
        public float Speed { get; set; }
        public int[] Territory { get; set; }
        public bool IsCarnivore { get; set; }
        public int State { get; set; }
        public bool[] IsActionable { get; set; }
    }

    public enum ANIMAL_STATE
    {
        LEAVE_ITEM,
        STARTING_CD,
        STARTING_PATROL,
        COOL_DOWN,
        DECIDING,
        MAKING_DECISION,
        PATROL,
        WAITING_FOR_HUNTING,
        WAITING_FOR_FIGHTING,
        HUNTING,
        FIGHTING,
        REST,
        MAX,
    }

    #region animalType
    public static readonly int[] HERBIVORE = { ( int )Define.ANIMAL.ZEBRA, ( int )Define.ANIMAL.GIRAFFE, ( int )Define.ANIMAL.BUFFALO,
                                               ( int )Define.ANIMAL.ELEPHANT, ( int )Define.ANIMAL.RHINO };
    public static readonly int[] CARNIVORE = { ( int )Define.ANIMAL.LION, ( int )Define.ANIMAL.LEOPARD, ( int )Define.ANIMAL.HYENA };
    #endregion

    #region hunting
    public static readonly int[] LION_TO_HERB = { 7, 6, 9, 0, 6 };
    public static readonly int[] LEOPARD_TO_HERB = { 8, 7, 8, 0, 1 };
    public static readonly int[] HYENA_TO_HERB = { 7, 6, 9, 0, 6 };

    public static readonly int[][] CARN_TO_HERB_PROBI = { LION_TO_HERB, LEOPARD_TO_HERB, HYENA_TO_HERB };
    #endregion

    #region fighting
    public static readonly int[] LION_TO_CARN = { 5, 10, 5 };
    public static readonly int[] LEOPARD_TO_CARN = { 0, 5, 1 };
    public static readonly int[] HYENA_TO_CARN = { 5, 10, 5 };

    public static readonly int[][] CARN_PROBI = { LION_TO_CARN, LEOPARD_TO_CARN, HYENA_TO_CARN };
    #endregion

    #region ActionablePeriod
    //herb all true la :D
    public static readonly bool[] LION_PERIOD = { true, true, false };
    public static readonly bool[] LEOPARD_PERIOD = { false, false, true };
    public static readonly bool[] HYENA_PERIOD = { true, false, true };

    public static readonly bool[][] CARN_ACTIONABLE_PERIOD = { LION_PERIOD, LEOPARD_PERIOD, HYENA_PERIOD };
    #endregion
}
