using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInstantiate : MonoBehaviour
{
    public GameObject parentGO;
    public GameObject grass;
    private Vector3 mousePos;
    private void Update( )
    {
        mousePos = Camera.main.ScreenToWorldPoint( Input.mousePosition );
        mousePos = new Vector3( mousePos.x, mousePos.y, 0 );
        this.transform.position = mousePos;

        if( Input.GetMouseButtonDown( 0 ) )
        {
            var item = Instantiate( grass, mousePos, Quaternion.identity );
            //caution
            //set parentGO
            item.transform.parent = parentGO.transform;
            Destroy( this.gameObject );
        }
    }
}
