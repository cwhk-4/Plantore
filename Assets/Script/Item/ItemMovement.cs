using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMovement : MonoBehaviour
{
    public GameObject cursor;
    public ToolConvertion toolConvertion;

    private bool isMoving = false;
    public ItemCountDown itemCountDown;

    public GameObject tempParent;

    private GameObject parentGO;

    private bool parentHvChild = false;

    public static GameObject _grass;
    public static bool _item;

    private void Start( )
    {
        cursor = GameObject.FindWithTag( "Cursor" );
        toolConvertion = cursor.GetComponent<ToolConvertion>( );

        isMoving = false;
        itemCountDown = GetComponentInChildren<ItemCountDown>( );

        tempParent = GameObject.FindWithTag("Temp Parent");
    }

    void Update()
    {
        if( isMoving )
        {
            moveItem( );
            this.transform.parent = tempParent.transform;
        }

        itemIn( );
    }

    private void OnMouseOver( )
    {
        if( !toolConvertion.getIsCan( ) )
        { 
            if( Input.GetMouseButtonDown( 1 ) )
            {

            }
        }
    }

    private void moveItem( )
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint( Input.mousePosition );
        mousePos = new Vector3( mousePos.x, mousePos.y, 0 );
        this.transform.position = mousePos;
    }

    private void OnDestroy( )
    {
        isMoving = false;
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Grid")
        {
            //parentHvChild = other.gameObject.GetComponent<ItemStorage>().hvChild;

            if(!parentHvChild)
            {
                parentGO = other.gameObject; 
            }

        }
    }

    public void itemIn( )
    {
        _grass = GameObject.FindGameObjectWithTag( this.gameObject.tag );
        if ( _grass != null )
        {
            _item = true;
        }
        else
        {
            _item = false;
        }
    }
}
