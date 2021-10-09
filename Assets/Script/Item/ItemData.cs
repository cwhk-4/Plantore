public static class ItemData
{
    public static readonly int[] ItemTime =
    {
        //unit = second

        60/6,     //grass
        60/6,     //small rock
        60/6,     //wood
        180/6,    //grassland
        180/6,    //marsh
        300/6,    //rock
    };

    public static readonly int[,] ITEM_LIMIT =
    {
        { 2,2,1,0,0,0 },
        { 3,3,2,1,1,0 },
        { 4,4,3,2,2,1 },
    };
}
