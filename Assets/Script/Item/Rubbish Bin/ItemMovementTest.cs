using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemMovementTest : MonoBehaviour
{
    public GameObject cursor;
    public ToolConvertion toolConvertion;

    public ItemCountDown itemCountDown;

    public GameObject InstantiateUI;

    private void Start( )
    {
        cursor = GameObject.FindWithTag( "Cursor" );
        toolConvertion = cursor.GetComponent<ToolConvertion>( );

        itemCountDown = GetComponentInChildren<ItemCountDown>( );
    }

    private void OnMouseOver( )
    {
        toolConvertion.SetOnGO( );

        if( !toolConvertion.GetIsCan( ) )
        {
            if( Input.GetMouseButtonDown( 1 ) )
            {
                var mousePos = Camera.main.ScreenToWorldPoint( Input.mousePosition );
                mousePos = new Vector3( mousePos.x, mousePos.y, 0 );

                //instantiate
                Instantiate( InstantiateUI, mousePos, Quaternion.identity );
                var startTime = GetComponentInChildren<ItemCountDown>( ).getStartTime( );
                //caution
                //setStartTime
                Destroy( this.gameObject );
            }
        }
    }
}