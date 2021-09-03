public static class Define
{
    public enum ANIMAL
    {
        ZEBRA,
        LION,
        GIRAFFE,
        IMPALA,
        HIPPO,
        AFRICAN_WILD_DOG,
        HYENA,
        WILDEBEEST,
        RHINO,
        BUFFALO,
        PANTHER,
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
        RICE,
        ROCK,
        LAKE,
        ROCK_GROUP,
        TOTAL_NUM,
    }

    public static readonly int XCOUNT = 12;
    public static readonly int YCOUNT = 11;
    public static readonly int TOTAL_GRID_NUM = XCOUNT * YCOUNT;

    #region item-animal
    public static readonly int[] GRASS_ANIMAL = { ( int )ANIMAL.ZEBRA };
    public static readonly int[] WOOD_ANIMAL = { ( int )ANIMAL.GIRAFFE };
    public static readonly int[] SMALL_ROCK_ANIMAL = { ( int )ANIMAL.LION };

    public static readonly int[] GRASSLAND_ANIMAL = { ( int )ANIMAL.RHINO, ( int )ANIMAL.HIPPO };
    public static readonly int[] MARSH_ANIMAL = { ( int )ANIMAL.IMPALA };

    public static readonly int[] RICE_ANIMAL = { ( int )ANIMAL.BUFFALO, ( int )ANIMAL.WILDEBEEST };
    public static readonly int[] ROCK_ANIMAL = { ( int )ANIMAL.HYENA };

    public static readonly int[] LAKE_ANIMAL = { ( int )ANIMAL.ELEPHANT };
    public static readonly int[] ROCK_GROUP_ANIMAL = { ( int )ANIMAL.PANTHER, (int)ANIMAL.AFRICAN_WILD_DOG };
    #endregion

    #region itemSize
    public static readonly int[] GRASS_SIZE = { 0 };
    public static readonly int[] WOOD_SIZE = { 0, XCOUNT };
    public static readonly int[] SMALL_ROCK_SIZE = { 0 };

    public static readonly int[] GRASSLAND_SIZE = { 0, -1 };
    public static readonly int[] MARSH_SIZE = { 0, -1, XCOUNT, XCOUNT - 1 };

    public static readonly int[] RICE_SIZE = { 0, -1, XCOUNT, XCOUNT - 1 };
    public static readonly int[] ROCK_SIZE = { 0, -1, XCOUNT, XCOUNT - 1 };

    public static readonly int[] LAKE_SIZE = { 0, -1, XCOUNT, XCOUNT - 1 };
    public static readonly int[] ROCK_GROUP_SIZE = { 0, -1, XCOUNT, XCOUNT - 1 };
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

    public static readonly int[] RICE_TERRITORY = { 0, -1, XCOUNT, XCOUNT - 1,
                                                    -XCOUNT-1, -XCOUNT,
                                                    -2, +1,
                                                    XCOUNT-2, XCOUNT+1,
                                                    (2*XCOUNT)-1, 2*XCOUNT};
    public static readonly int[] ROCK_TERRITORY = { 0, -1, XCOUNT, XCOUNT - 1,
                                                    -XCOUNT-2, -XCOUNT-1, -XCOUNT, -XCOUNT+1,
                                                    -2, +1,
                                                    XCOUNT-2, XCOUNT+1,
                                                    (2*XCOUNT)-2, (2*XCOUNT)-1, 2*XCOUNT, (2*XCOUNT)+1};

    public static readonly int[] LAKE_TERRITORY = { 0, -1, XCOUNT, XCOUNT - 1,
                                                    -XCOUNT-1, -XCOUNT,
                                                    -2, +1,
                                                    XCOUNT-2, XCOUNT+1,
                                                    (2*XCOUNT)-1, 2*XCOUNT};
    public static readonly int[] ROCK_GROUP_TERRITORY = { 0, -1, XCOUNT, XCOUNT - 1,
                                                          -XCOUNT-2, -XCOUNT-1, -XCOUNT, -XCOUNT+1,
                                                          -2, +1,
                                                          XCOUNT-2, XCOUNT+1,
                                                          (2*XCOUNT)-2, (2*XCOUNT)-1, 2*XCOUNT, (2*XCOUNT)+1 };
    #endregion
}
