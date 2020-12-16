using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInstantiate : MonoBehaviour
{
    public TimeController timeController;
    public static GameObject parentGO = null;
    public GameObject itemToBeInstantiate;
    public ItemCountDown itemCountDown;
    private Vector3 mousePos;
    public ItemStorage storage;
    private float thisStartTime = 0;
    private float startingTime = 0;
    [SerializeField]private bool isChanged = false;

    private void Start( )
    {
        ItemStorage.isInstantiating = true;
        timeController = GameObject.FindWithTag( "System" ).GetComponent<TimeController>( );
        itemCountDown = itemToBeInstantiate.GetComponentInChildren<ItemCountDown>( );
        thisStartTime = timeController.getNowRealSec( );
    }

    private void Update( )
    {
        mousePos = Camera.main.ScreenToWorldPoint( Input.mousePosition );
        mousePos = new Vector3( mousePos.x, mousePos.y, 0 );
        this.transform.position = mousePos;

        if( parentGO != null )
        {
            storage = parentGO.GetComponent<ItemStorage>( );
        
            if( Input.GetMouseButtonDown( 0 ) )
            {
                if( !storage.hvChild )
                {
                    ItemStorage.isInstantiating = false;
                    var item = Instantiate( itemToBeInstantiate, mousePos, Quaternion.identity );
                    item.transform.position = parentGO.transform.position;
                    item.transform.parent = parentGO.transform;
                    Destroy( this.gameObject );
                }
            }
        }

        
    }

    public static void setParentGO( GameObject parent ) 
    {
        parentGO = parent;
    }

    public void setGOStartTime( float startTime )
    {
        startingTime = startTime;
        isChanged = true;
    }

    private void OnDestroy( )
    {
        ItemStorage.isInstantiating = false;
        if( isChanged )
        {
            startingTime = startingTime + timeController.getNowRealSec( ) - thisStartTime;
            Debug.Log( startingTime );
            itemCountDown.setStartTime( startingTime );
        }
    }
}
