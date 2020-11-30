using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMovement : MonoBehaviour
{
    public GameObject cursor;
    public ToolConvertion toolConvertion;

    private bool isMoving = false;
    public ItemCountDown itemCountDown;

    private bool isOverGO = false;

    //new
    GameObject _grass;
    public static bool _item;

    private void Start( )
    {
        cursor = GameObject.FindWithTag( "Cursor" );
        toolConvertion = cursor.GetComponent<ToolConvertion>( );

        isMoving = false;
        itemCountDown = GetComponentInChildren<ItemCountDown>( );
    }

    void Update()
    {
        if( isMoving )
        {
            moveItem( );
        }
        itemIn( );
    }

    private void OnMouseOver( )
    {
        toolConvertion.setOnGO( );

        itemCountDown.showGauge( );

        if( !toolConvertion.getIsCan( ) )
        { 
            if( Input.GetMouseButtonDown( 1 ) )
            {
                if( isMoving )
                {
                    isMoving = false;
                }
                else
                {
                    isMoving = true;
                }
            }
        }
    }

    private void OnMouseExit( )
    {
        toolConvertion.setExitGO( );
        itemCountDown.closeGauge( );
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

    //new
    public void itemIn( )
    {
        _grass = GameObject.FindGameObjectWithTag( "Grass" );
        if ( _grass != null )
        {
            _item = true;
        }
        else if ( _grass == null )
        {
            _item = false;
        }
    }
}
