using UnityEngine;
using UnityEngine.EventSystems;

public class ExtraGridBase : MonoBehaviour
{
    [SerializeField] private ToolConvertion ToolConvertion;
    [SerializeField] private InstantiateMoveControl IMController;
    [SerializeField] private GameObject ParentItem;
    [SerializeField] private TutorialControl TutorialControl;

    [SerializeField] private bool isOnMouse;
    [SerializeField] private int click;


    private bool isLastStateOnMouse;

    private float holding = 1;
    private float holdTime;
    private bool isLastStateHold;

    private void Start( )
    {
        IMController = FindObjectOfType<InstantiateMoveControl>( );
        ToolConvertion = GameObject.FindWithTag( "Cursor" ).GetComponent<ToolConvertion>( );
        TutorialControl = FindObjectOfType<TutorialControl>( );
        isOnMouse = false;
    }

    public void SetParent( GameObject gameObject )
    {
        ParentItem = gameObject;
    }

    private void Update( )
    {
        if( isOnMouse )
        {
            if( TutorialControl.GetIfTutorial( ) )
            {
                return;
            }

            if( IMController.GetIsInstantiating( ) || IMController.GetIsMoving( ) )
            {
                return;
            }

            ParentItem.GetComponent<ItemBase>( ).ShowArea( );

            if( Input.GetMouseButtonDown( 1 ) )
            {
                if( ParentItem.GetComponent<CountDown>( ).GetCD( ) <= 0 )
                {
                    ParentItem.GetComponent<ItemBase>( ).Repair( );
                }
            }

            if( Input.GetMouseButton( 0 ) )
            {
                if( EventSystem.current.IsPointerOverGameObject( ) )
                    return;

                if( !isLastStateHold )
                {
                    isLastStateHold = true;
                }

                holdTime += Time.deltaTime;
            }

            ParentItem.GetComponent<ItemBase>( ).ShowArea( );

            if( Input.GetMouseButtonUp( 0 ) )
            {
                if( holdTime >= holding )
                {
                    ParentItem.GetComponent<ItemBase>( ).MoveItem( );
                    ParentItem.GetComponent<ItemBase>( ).ClearArea( );
                }

                isLastStateHold = false;
                holdTime = 0;
            }

            isLastStateOnMouse = true;
        }
        else
        {
            if( isLastStateOnMouse )
            {
                ParentItem.GetComponent<ItemBase>( ).ClearArea( );
            }

            isLastStateOnMouse = false;
        }
    }

    public void SetOnMouse( )
    {
        isOnMouse = true;
    }

    public void SetExitMouse( )
    {
        isOnMouse = false;
    }

    public void ShowGauge( )
    {
        if( ParentItem != null )
        {
            ParentItem.GetComponent<CountDown>( ).ShowGauge( );
        }
    }

    public void CloseGauge( )
    {
        if( ParentItem != null )
        {
            ParentItem.GetComponent<CountDown>( ).CloseGauge( );
        }
    }
}
