using UnityEngine;

public class GridStructBase : MonoBehaviour
{
    public struct PassThrough
    {
        public bool[] animals;
    }
    public static GridStructBase.PassThrough passThrough = new GridStructBase.PassThrough( );
}
