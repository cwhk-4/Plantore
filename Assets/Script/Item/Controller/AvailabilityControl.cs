using UnityEngine;

public class AvailabilityControl : MonoBehaviour
{
    [SerializeField] private GridColorControl[] Grids;
    [SerializeField] private InstantiateMoveControl imController;

    private int xCount;
    private int yCount;

    [SerializeField] private int onGridNum;
    [SerializeField] private int lastGridNum = 0;

    private void Start( )
    {
        onGridNum = -1;
    }

    public void SetGridSize( int x, int y)
    {
        xCount = x;
        yCount = y;
        Grids = new GridColorControl[xCount * yCount];
    }

    public void SetGrid( int num, GameObject child )
    {
        Grids[num] = child.GetComponent<GridColorControl>( );
    }

    public void OnGrid( int num )
    {
        if( onGridNum != num )
        {
            lastGridNum = onGridNum;
            onGridNum = num;

            imController.setNowGrid( onGridNum );
            
            DisableLastGrid( );
        }
    }

    private void Update( )
    {
        if( onGridNum != -1 && ( imController.GetIsInstantiating( ) || imController.GetIsMoving( ) ) )
        {
            Grids[onGridNum].EnableAvailability( );

            switch( imController.getGOItemNum( ) )
            {
                case ( int )Define.ITEM.WOOD:
                    EnableWood( );
                    break;

                case ( int )Define.ITEM.GRASSLAND:
                    EnableGrassland( );
                    break;

                case ( int )Define.ITEM.MARSH:
                    EnableMarsh( );
                    break;
            }
        }
    }

    private void EnableWood( )
    {
        Grids[onGridNum + xCount].EnableAvailability( );
    }

    private void EnableGrassland( )
    {
        Grids[onGridNum - 1].EnableAvailability( );
    }

    private void EnableMarsh( )
    {
        for( int i = 1; i < Define.MARSH_SIZE.Length; i++ )
        {
            Grids[onGridNum - Define.MARSH_SIZE[i]].EnableAvailability( );
        }
    }

    private void DisableLastGrid( )
    {
        if( lastGridNum != -1 )
        {
            Grids[lastGridNum].DisableAvailability( );

            switch( imController.getGOItemNum( ) )
            {
                case ( int )Define.ITEM.WOOD:
                    DisableWood( );
                    break;

                case ( int )Define.ITEM.GRASSLAND:
                    DisableGrassland( );
                    break;

                case ( int )Define.ITEM.MARSH:
                    DisableMarsh( );
                    break;
            }
        }
    }


    private void DisableWood( )
    {
        Grids[lastGridNum + xCount].DisableAvailability( );
    }

    private void DisableGrassland( )
    {
        Grids[lastGridNum - 1].DisableAvailability( );
    }

    private void DisableMarsh( )
    {
        for( int i = 1; i < Define.MARSH_SIZE.Length; i++ )
        {
            Grids[lastGridNum - Define.MARSH_SIZE[i]].DisableAvailability( );
        }
    }

    private void ShowTerritories( int AnimalNum )
    {

    }
}
