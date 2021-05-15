using UnityEngine;

public class AvailabilityControl : MonoBehaviour
{
    [SerializeField] private GridColorControl[] Grids;
    [SerializeField] private InstantiateMoveControl imController;
    private TerritoryDisplayControl territoryDisplay;
    private AvailabilityDisplayControl availabilityDisplay;

    private int xCount;
    private int yCount;

    [SerializeField] private int onGridNum;
    [SerializeField] private int lastGridNum = 0;

    private void Start( )
    {
        onGridNum = -1;
        territoryDisplay = GetComponent<TerritoryDisplayControl>( );
        availabilityDisplay = GetComponent<AvailabilityDisplayControl>( );
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

            territoryDisplay.DisableTerritories( lastGridNum );
            availabilityDisplay.DisableLastGrids( lastGridNum );
        }
    }

    private void Update( )
    {
        if( onGridNum != -1 && ( imController.GetIsInstantiating( ) || imController.GetIsMoving( ) ) )
        {
            territoryDisplay.EnableTerritories( onGridNum );
            availabilityDisplay.EnableExtraGrids( onGridNum );
        }
    }

    //ava and ter display control use
    public void EnableAva( int index )
    {
        Grids[index].EnableAvailability( );
    }

    public void DisableAva( int index )
    {
        Grids[index].DisableAvailability( );
    }

    public void EnableTerritory( int index )
    {
        Grids[index].EnableTerritories( );
    }

    public void DisableTerritory( int index )
    {
        Grids[index].DisableAvailability( );
    }
}
