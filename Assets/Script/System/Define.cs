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

    public static readonly int[] GRASS_TERRITORY = { -12, -1, 0, 1, 12 };
    public static readonly int[] GRASS_ANIMAL = { ( int )Define.ANIMAL.ZEBRA };
    public static readonly int[] WOOD_TERRITORY = { -12, -1, 1, 0, 11, 12, 13, 24 };
    public static readonly int[] WOOD_ANIMAL = { ( int )Define.ANIMAL.GIRAFFE };

    //caution -> not yet setup
    public static readonly int[] ROCK_TERRITORY = { -12, -1, 1, 0, 11, 12, 13, 24 };
    public static readonly int[] ROCK_ANIMAL = { ( int )Define.ANIMAL.LION };
}
