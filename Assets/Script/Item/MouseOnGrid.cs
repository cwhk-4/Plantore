using UnityEngine;

public class MouseOnGrid : MonoBehaviour
{
    private AvailabilityControl availabilityControl;
    private InstantiateMoveControl imController;

    private void Start( )
    {
        imController = GameObject.FindWithTag( "InstantiateMoveControl" ).GetComponent<InstantiateMoveControl>( );
        availabilityControl = GameObject.FindWithTag( "GridAvailability" ).GetComponent<AvailabilityControl>( );
    }

    private void OnMouseOver( )
    {
        if( imController.GetIsInstantiating( ) || imController.GetIsMoving( ) )
        {
            availabilityControl.OnGrid( transform.GetSiblingIndex( ) );

            if( transform.childCount == 0 )
            {
                GameObject.FindWithTag( "Instantiate" ).GetComponent<InstantiateItem>( )
                                           .SetParentGO( this.gameObject );
            }
            else
            {
                GameObject.FindWithTag( "Instantiate" ).GetComponent<InstantiateItem>( )
                                        .SetParentGO( null );
            }
        }


        if( transform.childCount != 0 )
        {
            if( transform.GetChild( 0 ).name != "ExtraGrid(Clone)" )
            {
                GetComponentInChildren<ItemBase>( ).setOnMouse( );
                GetComponentInChildren<CountDown>( ).showGauge( );
            }
        }
    }

    private void OnMouseExit( )
    {
        availabilityControl.OnGrid( -1 );

        if( imController.GetIsInstantiating( ) || imController.GetIsMoving( ) )
        {
            GameObject.FindWithTag( "Instantiate" ).GetComponent<InstantiateItem>( )
                           .SetParentGO( null );
        }

        if( transform.childCount != 0 )
        {
            if( transform.GetChild( 0 ).name != "ExtraGrid(Clone)" )
            {
                GetComponentInChildren<ItemBase>( ).setExitMouse( );
                GetComponentInChildren<CountDown>( ).closeGauge( );
            }
        }
    }
}
