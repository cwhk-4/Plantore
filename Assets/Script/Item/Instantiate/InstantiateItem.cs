using UnityEngine;

public class InstantiateItem : MonoBehaviour
{
    private InstantiateMoveControl IMController;
    private TimeController TimeController;
    private ItemStorage ItemStorage;
    private AvailabilityControl Availability;
    private TutorialControl TutorialControl;
    private TutorialEvent TutorialEvent;
    private GridAvailabilityControl GridAvailabilityControl;

    [SerializeField]private GameObject ItemToInstantiate;
    private GameObject parentGO;
    private Vector3 mousePos = Vector3.zero;
    private float thisStartingTime;

    private int itemNum;

    private void Start( )
    {
        TimeController = GameObject.Find( "System" ).GetComponent<TimeController>( );
        IMController = GameObject.FindWithTag( "InstantiateMoveControl" ).GetComponent<InstantiateMoveControl>( );
        ItemStorage = GameObject.Find( "ItemStorage" ).GetComponent<ItemStorage>( );
        Availability = GameObject.Find( "AvailabilityController" ).GetComponent<AvailabilityControl>( );
        GridAvailabilityControl = GameObject.Find( "AvailabilityController" ).GetComponent<GridAvailabilityControl>( );
        TutorialControl = GameObject.FindWithTag( "Tutorial" ).GetComponent<TutorialControl>( );
        TutorialEvent = GameObject.FindWithTag( "Tutorial" ).GetComponent<TutorialEvent>( );

        thisStartingTime = TimeController.GetNowSec( );

        switch( name )
        {
            //Lv 1
            case "grass_Instan(Clone)":
                itemNum = ( int )Define.ITEM.GRASS;
                break;

            case "wood_Instan(Clone)":
                itemNum = ( int )Define.ITEM.WOOD;
                break;

            case "smallRock_Instan(Clone)":
                itemNum = ( int )Define.ITEM.SMALL_ROCK;
                break;

            //Lv 2
            case "grassland_Instan(Clone)":
                itemNum = ( int )Define.ITEM.GRASSLAND;
                break;

            case "marsh_Instan(Clone)":
                itemNum = ( int )Define.ITEM.MARSH;
                break;

            //Lv 3
            case "rock_Instan(Clone)":
                itemNum = ( int )Define.ITEM.ROCK;
                break;
        }

        IMController.setGOItemNum( itemNum );
    }

    private void Update( )
    {
        mousePos = Camera.main.ScreenToWorldPoint( Input.mousePosition );
        mousePos = new Vector3( mousePos.x, mousePos.y, 0 );
        transform.position = mousePos;

        if( parentGO == null )
        {
            return;
        }

        if( Input.GetMouseButton( 0 ) && parentGO.transform.childCount == 0)
        {
            var available = IMController.CheckThisGrid( );

            if( !available )
            {
                return;
            }

            if( name!= "grass_Instan(Clone)" && name != "smallRock_Instan(Clone)" )
            {
                available = IMController.CheckGrids( itemNum );
            }

            if( !available )
            {
                return;
            }

            //Instantiate
            var item = Instantiate( ItemToInstantiate, mousePos, Quaternion.identity );
            item.transform.SetParent( parentGO.transform );
            item.transform.position = parentGO.transform.position;

            var index = parentGO.transform.GetSiblingIndex( );
            //Debug.Log( index );

            item.GetComponent<ItemBase>( ).Init( TimeController, IMController, itemNum, index, GridAvailabilityControl );

            ItemStorage.PlaceItem( index, itemNum );

            if( name != "grass_Instan(Clone)" && name != "smallRock_Instan(Clone)" )
            {
                IMController.InstantiateExtraGrid( itemNum, item );
            }

            if( IMController.GetIsMoving( ) )
            {
                item.GetComponent<CountDown>( ).SetCD( ItemData.ItemTime[itemNum] );
                var timeDelayed = TimeController.GetNowSec( ) - thisStartingTime;
                item.GetComponent<CountDown>( ).SetStartingTime( IMController.GetStartingTime( ) + timeDelayed );
            }
            else
            {
                item.GetComponent<CountDown>( ).SetCD( ItemData.ItemTime[itemNum] );
                item.GetComponent<CountDown>( ).SetStartingTime( TimeController.GetNowSec( ) );
            }

            if( TutorialControl.GetTextCount( ) < 12 )
            {
                TutorialEvent.ClearGrid( );
                TutorialEvent.HidePointer( );
            }

            Availability.ItemInstantiated( index );

            if( !IMController.GetIsMoving( ) )
            {
                IMController.FinishedByInstan( );
                IMController.FinishInstantiate( );
            }
            else
            {
                IMController.FinishMoving( index );
            }
            Destroy( gameObject );
        }
    }

    public void SetParentGO( GameObject parent )
    {
        parentGO = parent;
    }

    public GameObject getParentGO( )
    {
        return parentGO;
    }
}
