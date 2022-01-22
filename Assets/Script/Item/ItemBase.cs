using UnityEngine;
using UnityEngine.EventSystems;

public class ItemBase : MonoBehaviour
{
    [SerializeField] private TimeController TimeController;
    [SerializeField] private InstantiateMoveControl IMController;
    [SerializeField] private MapLevel MapLevel;
    [SerializeField] private MissionControl MissionControl;
    [SerializeField] private ToolConvertion ToolConvertion;
    [SerializeField] private AnimalInstantiate AnimalInstantiate;

    private CountDown CountDown;
    private MoveItem MoveItemScript;

    [SerializeField] private int itemType;
    [SerializeField] private int gridNum;

    [SerializeField]private bool isOnMouse;
    private float holding = 1;
    private float holdTime;
    private bool isLastStateHold;

    [SerializeField] private float AnimalLeaveStamp = -1;
    private float AnimalRespawnCD = 3 * 10;

    void Start( )
    {
        ToolConvertion = GameObject.FindWithTag( "Cursor" ).GetComponent<ToolConvertion>( );
        MissionControl = GameObject.FindWithTag( "MissionController" ).GetComponent<MissionControl>( );
        MapLevel = GameObject.FindWithTag( "Map" ).GetComponent<MapLevel>( );
        AnimalInstantiate = GameObject.FindWithTag( "AnimalController" ).GetComponent<AnimalInstantiate>( );
        CountDown = GetComponent<CountDown>( );
        MoveItemScript = GetComponent<MoveItem>( );
        isOnMouse = false;
        AnimalLeaveStamp = -1;
        isLastStateHold = false;
    }

    public void Init( TimeController timeController, InstantiateMoveControl imController, int itemIndex, int gridIndex )
    {
        TimeController = timeController;
        IMController = imController;
        itemType = itemIndex;
        gridNum = gridIndex;
    }

    private void FixedUpdate( )
    {
        if( isOnMouse )
        {
            if( IMController.GetIsInstantiating( ) || IMController.GetIsMoving( ) )
            {
                return;
            }

            if( Input.GetMouseButtonDown( 1 ) )
            {
                if( CountDown.GetCD( ) <= 0 )
                {
                    Repair( );
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
                Debug.Log( "OnHold" + holdTime );
            }

            if( Input.GetMouseButtonUp( 0 ) )
            {
                if( holdTime >= holding )
                {
                    MoveItem( );
                }

                isLastStateHold = false;
                holdTime = 0;
            }
        }

        if( AnimalLeaveStamp != -1 )
        {
            if( CountDown.GetCD( ) > 0 )
            {
                if( TimeController.GetNowSec( ) - AnimalLeaveStamp >= AnimalRespawnCD )
                {
                    AnimalInstantiate.ItemCreated( itemType, gridNum );
                    AnimalLeaveStamp = -1;
                }
            }
        }
    }

    public void Repair( )
    {
        CountDown.StartRepairing( );

        if( MapLevel.GetMapLevel( ) == 1 )
        {
            MissionControl.FixedItem1( );
        }

        if( MapLevel.GetMapLevel( ) == 2 )
        {
            MissionControl.FixedItem2( );
        }   
    }

    public void MoveItem( )
    {
        var GO = transform.parent.GetComponent<GridBase>( ).GetAnimal( );
        MoveItemScript.StartMoving( CountDown.GetStartTime( ), GO, itemType );
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

    public void AnimalRemoved()
    {
        AnimalLeaveStamp = TimeController.GetNowSec( );
    }
}
