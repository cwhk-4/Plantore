public static class ItemData
{
    public static readonly int[] ItemTime =
    {
        //unit = second

        60/4,     //grass
        60/4,     //small rock
        60/4,     //wood
        180/4,    //grassland
        180/4,    //marsh
        300/4,    //rock
    };

    public static readonly int[,] ITEM_LIMIT =
    {
        { 2,2,1,0,0,0 },
        { 3,3,2,1,1,0 },
        { 4,4,3,2,2,1 },
    };

    #region item-animal
    public static readonly int[] GRASS_ANIMAL = { ( int )Define.ANIMAL.ZEBRA };
    public static readonly int[] WOOD_ANIMAL = { ( int )Define.ANIMAL.GIRAFFE };
    public static readonly int[] SMALL_ROCK_ANIMAL = { ( int )Define.ANIMAL.LION };

    public static readonly int[] GRASSLAND_ANIMAL = { ( int )Define.ANIMAL.ZEBRA, ( int )Define.ANIMAL.GIRAFFE, ( int )Define.ANIMAL.BUFFALO };
    public static readonly int[] MARSH_ANIMAL = { ( int )Define.ANIMAL.RHINO, ( int )Define.ANIMAL.ELEPHANT };

    public static readonly int[] ROCK_ANIMAL = { ( int )Define.ANIMAL.LION, ( int )Define.ANIMAL.LEOPARD, ( int )Define.ANIMAL.HYENA };
    #endregion

    #region itemSize
    public static readonly int[] GRASS_SIZE = { 0 };
    public static readonly int[] WOOD_SIZE = { 0, Define.XCOUNT };
    public static readonly int[] SMALL_ROCK_SIZE = { 0 };

    public static readonly int[] GRASSLAND_SIZE = { 0, -1 };
    public static readonly int[] MARSH_SIZE = { 0, -1, Define.XCOUNT, Define.XCOUNT - 1 };

    public static readonly int[] ROCK_SIZE = { 0, -1, Define.XCOUNT, Define.XCOUNT - 1 };
    #endregion

    #region itemTerritory
    public static readonly int[] GRASS_TERRITORY = { 0,
                                                     -Define.XCOUNT, -1, 1, Define.XCOUNT };
    public static readonly int[] WOOD_TERRITORY = { 0, Define.XCOUNT,
                                                    -Define.XCOUNT, -1, 1, Define.XCOUNT - 1, Define.XCOUNT + 1, 2 * Define.XCOUNT };
    public static readonly int[] SMALL_ROCK_TERRITORY = { 0,
                                                          Define.XCOUNT - 1, Define.XCOUNT, Define.XCOUNT + 1, -1, 1, -Define.XCOUNT - 1, -Define.XCOUNT, -Define.XCOUNT + 1 };


    public static readonly int[] GRASSLAND_TERRITORY = { 0, -1,
                                                         -2, 1, -Define.XCOUNT, -Define.XCOUNT - 1, Define.XCOUNT, Define.XCOUNT - 1 };
   
    public static readonly int[] MARSH_TERRITORY = { 0, -1, Define.XCOUNT, Define.XCOUNT - 1,
                                                    -Define.XCOUNT-1, -Define.XCOUNT,
                                                    -2, +1,
                                                    Define.XCOUNT-2, Define.XCOUNT+1,
                                                    (2*Define.XCOUNT)-1, 2*Define.XCOUNT};


    public static readonly int[] ROCK_TERRITORY = { 0, -1, Define.XCOUNT, Define.XCOUNT - 1,
                                                    -Define.XCOUNT-2, -Define.XCOUNT-1, -Define.XCOUNT, -Define.XCOUNT+1,
                                                    -2, +1,
                                                    Define.XCOUNT-2, Define.XCOUNT+1,
                                                    2*(Define.XCOUNT)-2, 2*(Define.XCOUNT)-1, 2*(Define.XCOUNT), 2*(Define.XCOUNT)+1,};

    public static readonly int[][] TERRITORY_ARR = { GRASS_TERRITORY, WOOD_TERRITORY, SMALL_ROCK_TERRITORY,
                                                     GRASSLAND_TERRITORY, MARSH_TERRITORY,
                                                     ROCK_TERRITORY};
    #endregion
}
