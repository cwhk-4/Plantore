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
            //caution -> enable set return?
            //**show territory
            //then show other?

            Grids[onGridNum].EnableAvailability( );

            if(imController.getGOName() == "wood_Instan(Clone)" )
            {
                Grids[onGridNum + xCount].EnableAvailability( );
            }

            if( imController.getGOName( ) == "grassland_Instan(Clone)" )
            {
                Grids[onGridNum - 1].EnableAvailability( );
            }

            if( imController.getGOName( ) == "marsh_Instan(Clone)" )
            {
                Grids[onGridNum - 1].EnableAvailability( );
                Grids[onGridNum + xCount].EnableAvailability( );
                Grids[onGridNum + xCount - 1].EnableAvailability( );
            }
        }
    }

    private void DisableLastGrid( )
    {
        if( lastGridNum != -1 )
        {
            Grids[lastGridNum].DisableAvailability( );

            if( imController.getGOName( ) == "wood_Instan(Clone)" )
            {
                Grids[lastGridNum + xCount].DisableAvailability( );
            }

            if( imController.getGOName( ) == "grassland_Instan(Clone)" )
            {
                Grids[lastGridNum - 1].DisableAvailability( );
            }

            if( imController.getGOName( ) == "marsh_Instan(Clone)" )
            {
                Grids[lastGridNum - 1].DisableAvailability( );
                Grids[lastGridNum + xCount].DisableAvailability( );
                Grids[lastGridNum + xCount - 1].DisableAvailability( );
            }
        }
    }

    private void ShowTerritories( int AnimalNum )
    {

    }
}
