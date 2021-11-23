using UnityEngine;

public class TutorialMouseOnGrid : MonoBehaviour
{
    private TutorialAvailabilityControl availabilityControl;
    private TutorialIMController imController;

    private void Start( )
    {
        imController = FindObjectOfType<TutorialIMController>( );
        availabilityControl = FindObjectOfType<TutorialAvailabilityControl>( );
    }

    private void OnMouseOver( )
    {
        if( imController.GetIsInstantiating( ) || imController.GetIsMoving( ) )
        {
            availabilityControl.OnGrid( transform.GetSiblingIndex( ) );

            FindObjectOfType<TutorialInstantiateItem>( ).SetParentGO( gameObject );
        }

        if( transform.childCount != 0 )
        {
            if( transform.GetChild( 0 ).name != "ExtraGrid(Clone)" && transform.GetChild( 0 ).name != "Tutorial_grass(Clone)" )
            {
                GetComponentInChildren<ItemBase>( ).SetOnMouse( );
                GetComponentInChildren<CountDown>( ).ShowGauge( );
            }
        }
    }

    private void OnMouseExit( )
    {
        availabilityControl.OnGrid( -1 );

        if( imController.GetIsInstantiating( ) || imController.GetIsMoving( ) )
        {
            FindObjectOfType<TutorialInstantiateItem>( ).SetParentGO( null );
        }

        if( transform.childCount != 0 )
        {
            if( transform.GetChild( 0 ).name != "ExtraGrid(Clone)" && transform.GetChild( 0 ).name != "Tutorial_grass(Clone)" )
            {
                GetComponentInChildren<ItemBase>( ).SetExitMouse( );
                GetComponentInChildren<CountDown>( ).CloseGauge( );
            }
        }
    }
}
