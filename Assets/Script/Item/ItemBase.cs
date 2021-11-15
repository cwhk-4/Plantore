using UnityEngine;
using UnityEngine.EventSystems;

public class ItemBase : MonoBehaviour
{
    [SerializeField] private MissionControl MissionControl;
    [SerializeField] private ToolConvertion ToolConvertion;
    [SerializeField] private MapLevel MapLevel;
    [SerializeField] private InstantiateMoveControl IMController;
    private CountDown countDown;
    private MoveItem moveItem;

    [SerializeField]private bool isOnMouse;
    private float clickDelay = 1;
    private float clickTime;
    private int click;

    void Start( )
    {
        ToolConvertion = GameObject.FindWithTag( "Cursor" ).GetComponent<ToolConvertion>( );
        MissionControl = GameObject.FindWithTag( "MissionController" ).GetComponent<MissionControl>( );
        MapLevel = GameObject.FindWithTag( "Map" ).GetComponent<MapLevel>( );
        IMController = GameObject.FindWithTag( "InstantiateMoveControl" ).GetComponent<InstantiateMoveControl>( );
        countDown = GetComponent<CountDown>( );
        moveItem = GetComponent<MoveItem>( );
        isOnMouse = false;
    }

    private void Update( )
    {
        if( isOnMouse )
        {
            if( IMController.GetIsInstantiating( ) || IMController.GetIsMoving( ) )
            {
                return;
            }

            if( ToolConvertion.GetIsCan( ) )
            {
                if( Input.GetMouseButtonDown( 0 ) )
                {
                    if( countDown.GetCD( ) <= 0 )
                    {
                        Repair( );
                    }

                }

            }
            else
            {
                if( Input.GetMouseButtonUp( 0 ) )
                {
                    if( EventSystem.current.IsPointerOverGameObject( ) )
                        return;

                    if( Time.time - clickTime <= clickDelay )
                    {
                        click++;
                    }
                    else
                    {
                        click = 0;
                        clickTime = Time.time;
                    }

                    if( click == 2 )
                    {
                        MoveItem( );
                    }
                }
            }


        }
    }

    public void Repair( )
    {
        countDown.StartRepairing( );

        if( MapLevel.getMapLevel( ) == 1 )
        {
            MissionControl.FixedItem1( );
        }

        if( MapLevel.getMapLevel( ) == 2 )
        {
            MissionControl.FixedItem2( );
        }   
    }

    public void MoveItem( )
    {
        var GO = transform.parent.GetComponent<GridBase>( ).GetAnimal( );
        moveItem.StartMoving( countDown.GetStartTime( ), GO );
    }

    public void SetOnMouse( )
    {
        isOnMouse = true;
        ToolConvertion.SetOnGO( );
    }

    public void SetExitMouse( )
    {
        isOnMouse = false;
        ToolConvertion.SetExitGO( );
    }

    public int GetIndex( )
    {
        return transform.parent.GetSiblingIndex( );
    }
}
