public static class ItemData
{
    public static readonly int[] ItemTime =
    {
        //unit = second

        60,     //grass
        60,     //small rock
        60,     //wood
        180,    //grassland
        180,    //marsh
        300,    //rice
        300,    //rock
        600,    //lake
        600,    //rock group

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
