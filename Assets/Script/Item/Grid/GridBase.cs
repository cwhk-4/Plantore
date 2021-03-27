using UnityEngine;

public class GridBase : MonoBehaviour
{
    [SerializeField] private int totalAnimalNum = 13;
    private GridStructBase.PassThrough passThrough = new GridStructBase.PassThrough( );

    private void Start( )
    {
        PassThroughInit( );
    }

    private void PassThroughInit( )
    {
        for( int i = 0; i < totalAnimalNum; i++ )
        {
            passThrough.animals[i] = false;
        }
    }
}
