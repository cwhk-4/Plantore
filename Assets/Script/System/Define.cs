public static class Define
{
    public enum ANIMAL
    {
        ZEBRA,          //0
        LION,           //1
        GIRAFFE,        //2
        HYENA,          //3
        RHINO,          //4
        BUFFALO,        //5
        LEOPARD,        //6
        ELEPHANT,       //7
        TOTAL_NUM,      //8
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

    public enum PERIOD
    {
        NOON,
        EVENING,
        NIGHT,
        MAX,
    }

    //map info
    public static readonly int XCOUNT = 10;
    public static readonly int YCOUNT = 9;
    public static readonly int TOTAL_GRID_NUM = XCOUNT * YCOUNT;
}
