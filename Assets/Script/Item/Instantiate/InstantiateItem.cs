using UnityEngine;

public class InstantiateItem : MonoBehaviour
{
    private InstantiateMoveControl imController;
    private TimeController timeController;
    private GridTerritoryControl territoryControl;
    private ItemStorage storage;
    private AvailabilityControl availability;

    [SerializeField]private GameObject ItemToInstantiate;
    private GameObject parentGO;
    private Vector3 mousePos = Vector3.zero;
    private float thisStartingTime;

    private int itemNum;

    private void Start( )
    {
        timeController = GameObject.Find( "System" ).GetComponent<TimeController>( );
        imController = GameObject.FindWithTag( "InstantiateMoveControl" ).GetComponent<InstantiateMoveControl>( );
        territoryControl = GameObject.Find( "TerritoryController" ).GetComponent<GridTerritoryControl>( );
        storage = GameObject.Find( "ItemStorage" ).GetComponent<ItemStorage>( );
        availability = GameObject.Find( "AvailabilityController" ).GetComponent<AvailabilityControl>( );

        thisStartingTime = timeController.GetNowSec( );

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

        imController.setGOItemNum( itemNum );
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
            var available = imController.CheckThisGrid( );

            if( !available )
            {
                return;
            }

            if( name!= "grass_Instan(Clone)" && name != "smallRock_Instan(Clone)" )
            {
                available = imController.CheckGrids( itemNum );
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

            storage.PlaceItem( index, itemNum );

            if( name != "grass_Instan(Clone)" && name != "smallRock_Instan(Clone)" )
            {
                imController.InstantiateExtraGrid( itemNum, item );
            }

            #region !Tutorial
            if( name != "Tutorial_grass(Clone)" )
            {
                if( imController.GetIsMoving( ) )
                {
                    item.GetComponent<CountDown>( ).SetCD( ItemData.ItemTime[itemNum] );
                    var timeDelayed = timeController.GetNowSec( ) - thisStartingTime;
                    item.GetComponent<CountDown>( ).SetStartingTime( imController.GetStartingTime( ) + timeDelayed );
                    Debug.Log( timeDelayed );
                }
                else
                {
                    item.GetComponent<CountDown>( ).SetCD( ItemData.ItemTime[itemNum] );
                    item.GetComponent<CountDown>( ).SetStartingTime( timeController.GetNowSec( ) );
                }

            }
            #endregion

            availability.ItemInstantiated( index );

            if( !imController.GetIsMoving( ) )
            {
                imController.FinishedByInstan( );
                imController.FinishInstantiate( );
            }
            else
            {
                imController.FinishMoving( index );
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
