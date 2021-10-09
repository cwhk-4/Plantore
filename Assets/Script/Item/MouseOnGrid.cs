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

            GameObject.FindWithTag( "Instantiate" ).GetComponent<InstantiateItem>( ).SetParentGO( this.gameObject );
        }

        if( transform.childCount != 0 )
        {
            //caution
            if( transform.GetChild( 0 ).name != "ExtraGrid(Clone)" && transform.GetChild( 0 ).name != "Tutorial_grass(Clone)" )
            {
                GetComponentInChildren<ItemBase>( ).SetOnMouse( );
                GetComponentInChildren<CountDown>( ).ShowGauge( );
            }

            if( transform.GetChild( 0 ).name == "ExtraGrid(Clone)" )
            {
                GetComponentInChildren<ExtraGridBase>( ).SetOnMouse( );
                GetComponentInChildren<ExtraGridBase>( ).ShowGauge( );
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
            if( transform.GetChild( 0 ).name != "ExtraGrid(Clone)" && transform.GetChild( 0 ).name != "Tutorial_grass(Clone)" )
            {
                GetComponentInChildren<ItemBase>( ).SetExitMouse( );
                GetComponentInChildren<CountDown>( ).CloseGauge( );
            }

            if( transform.GetChild( 0 ).name == "ExtraGrid(Clone)" )
            {
                GetComponentInChildren<ExtraGridBase>( ).SetExitMouse( );
                GetComponentInChildren<ExtraGridBase>( ).CloseGauge( );
            }
        }
    }
}
