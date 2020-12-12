using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInstantiate : MonoBehaviour
{
    public static GameObject parentGO = null;
    public GameObject itemToBeInstantiate;
    private Vector3 mousePos;
    public ItemStorage storage;

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
                    item.transform.parent = parentGO.transform;
                    item.transform.position = parentGO.transform.position;
                    Destroy( this.gameObject );
                }
            }
        }
    }

    public static void setParentGO( GameObject parent ) 
    {
        parentGO = parent;
    }
}
