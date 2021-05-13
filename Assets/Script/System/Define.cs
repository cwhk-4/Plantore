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
        GRASSLAND,
        MARSH,
        ROCK,
        TOTAL_NUM,
    }

    public static readonly int XCOUNT = 12;
    public static readonly int YCOUNT = 11;

    public static readonly int[] GRASS_SIZE = { 0 };
    public static readonly int[] WOOD_SIZE = { 0, XCOUNT };
    public static readonly int[] GRASSLAND_SIZE = { 0, -1 };
    public static readonly int[] MARSH_SIZE = { 0, -1 };
    public static readonly int[] ROCK_SIZE = { 0, -1, XCOUNT, XCOUNT - 1 };

    public static readonly int[] GRASS_TERRITORY = { -12, -1, 0, 1, 12 };
    public static readonly int[] WOOD_TERRITORY = { -12, -1, 1, 0, 11, 12, 13, 24 };

    public static readonly int[] GRASS_ANIMAL = { ( int )ANIMAL.ZEBRA };
    public static readonly int[] WOOD_ANIMAL = { ( int )ANIMAL.GIRAFFE };

    //caution -> not yet setup
    public static readonly int[] ROCK_TERRITORY = { -12, -1, 1, 0, 11, 12, 13, 24 };
    public static readonly int[] GRASSLAND_TERRITORY = { -12, -1, 1, 0, 11, 12, 13, 24 };
    public static readonly int[] MARSH_TERRITORY = { -12, -1, 1, 0, 11, 12, 13, 24 };

    public static readonly int[] ROCK_ANIMAL = { ( int )ANIMAL.LION };
    public static readonly int[] GRASSLAND_ANIMAL = { ( int )ANIMAL.LION };
    public static readonly int[] MARSH_ANIMAL = { ( int )ANIMAL.LION };
}
