public static class Define
{
    public enum ANIMAL
    {
        ZEBRA,
        LION,
        GIRAFFE,
        HYENA,
        RHINO,
        BUFFALO,
        LEOPARD,
        ELEPHANT,
        TOTAL_NUM,
    }

    public enum ITEM
    {
        GRASS,
        WOOD,
        SMALL_ROCK,

        GRASSLAND,
        MARSH,

        ROCK,
        TOTAL_NUM,
    }

    public static readonly int XCOUNT = 10;
    public static readonly int YCOUNT = 9;
    public static readonly int TOTAL_GRID_NUM = XCOUNT * YCOUNT;

    #region item-animal
    public static readonly int[] GRASS_ANIMAL = { ( int )ANIMAL.ZEBRA };
    public static readonly int[] WOOD_ANIMAL = { ( int )ANIMAL.GIRAFFE };
    public static readonly int[] SMALL_ROCK_ANIMAL = { ( int )ANIMAL.LION };

    public static readonly int[] GRASSLAND_ANIMAL = { ( int )ANIMAL.ZEBRA, ( int )ANIMAL.GIRAFFE, ( int )ANIMAL.BUFFALO };
    public static readonly int[] MARSH_ANIMAL = { ( int )ANIMAL.RHINO, ( int )ANIMAL.ELEPHANT };

    public static readonly int[] ROCK_ANIMAL = { ( int )ANIMAL.LION, ( int )ANIMAL.LEOPARD, ( int )ANIMAL.HYENA };
    #endregion

    #region itemSize
    public static readonly int[] GRASS_SIZE = { 0 };
    public static readonly int[] WOOD_SIZE = { 0, XCOUNT };
    public static readonly int[] SMALL_ROCK_SIZE = { 0 };

    public static readonly int[] GRASSLAND_SIZE = { 0, -1 };
    public static readonly int[] MARSH_SIZE = { 0, -1, XCOUNT, XCOUNT - 1 };

    public static readonly int[] ROCK_SIZE = { 0, -1, XCOUNT, XCOUNT - 1 };
    #endregion

    #region itemTerritory
    public static readonly int[] GRASS_TERRITORY = { 0,
                                                     -XCOUNT, -1, 1, XCOUNT };
    public static readonly int[] WOOD_TERRITORY = { 0, XCOUNT,
                                                    -XCOUNT, -1, 1, XCOUNT - 1, XCOUNT + 1, 2 * XCOUNT };
    public static readonly int[] SMALL_ROCK_TERRITORY = { 0,
                                                          XCOUNT - 1, XCOUNT, XCOUNT + 1, -1, 1, -XCOUNT - 1, -XCOUNT, -XCOUNT + 1 };


    public static readonly int[] GRASSLAND_TERRITORY = { 0, -1,
                                                         -2, 1, -XCOUNT, -XCOUNT - 1, XCOUNT, XCOUNT - 1 };
    public static readonly int[] MARSH_TERRITORY = { 0, -1, XCOUNT, XCOUNT - 1,
                                                    -XCOUNT-1, -XCOUNT,
                                                    -2, +1,
                                                    XCOUNT-2, XCOUNT+1,
                                                    (2*XCOUNT)-1, 2*XCOUNT};


    public static readonly int[] ROCK_TERRITORY = { 0, -1, XCOUNT, XCOUNT - 1,
                                                    -XCOUNT-2, -XCOUNT-1, -XCOUNT, -XCOUNT+1,
                                                    -2, +1,
                                                    XCOUNT-2, XCOUNT+1, };

    public static readonly int[][] TERRITORY_ARR = { GRASS_TERRITORY, WOOD_TERRITORY, SMALL_ROCK_TERRITORY,
                                                     GRASSLAND_TERRITORY, MARSH_TERRITORY,
                                                     ROCK_TERRITORY};
    #endregion
}
