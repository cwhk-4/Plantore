public static class ItemData
{
    public static readonly int[] ItemTime =
    {
        //unit = second

        60/2,     //grass
        60/2,     //small rock
        60/2,     //wood
        180/2,    //grassland
        180/2,    //marsh
        300/2,    //rice
        300/2,    //rock
        600/2,    //lake
        600/2,    //rock group

    };

    public static readonly int[,] ITEM_LIMIT =
        {
            { 2,2,1,0,0,0,0,0,0 },
            { 3,3,2,1,1,0,0,0,0 },
            { 4,4,3,2,2,2,1,0,0 },
            { 5,5,4,3,3,2,2,1,1 },
        };

    #region ItemLimit
    //public static readonly int[] LV1_LIMIT =
    //    { 2,2,1,0,0,0,0,0,0 };

    //public static readonly int[] LV2_LIMIT =
    //    { 3,3,2,1,1,0,0,0,0 };

    //public static readonly int[] LV3_LIMIT =
    //    { 4,4,3,2,2,2,1,0,0 };

    //public static readonly int[] LV4_LIMIT =
    //    { 5,5,4,3,3,2,2,1,1 };
    #endregion

}
