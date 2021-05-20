using UnityEngine;

public class AvailabilityControl : MonoBehaviour
{
    [SerializeField] private InstantiateMoveControl imController;
    private TerritoryDisplayControl territoryDisplay;
    private AvailabilityDisplayControl availabilityDisplay;



    [SerializeField] private int onGridNum;
    [SerializeField] private int lastGridNum = 0;

    private void Start( )
    {
        onGridNum = -1;
        territoryDisplay = GetComponent<TerritoryDisplayControl>( );
        availabilityDisplay = GetComponent<AvailabilityDisplayControl>( );
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
        if( onGridNum != -1 )
        {
            if( imController.GetIsInstantiating( ) || imController.GetIsMoving( ) )
            {
                territoryDisplay.EnableTerritories( onGridNum );
                availabilityDisplay.EnableExtraGrids( onGridNum );
            }
        }
    }

    public void ItemInstantiated( int index )
    {
        territoryDisplay.DisableTerritories( index );
        availabilityDisplay.DisableLastGrids( index );
    }

}
