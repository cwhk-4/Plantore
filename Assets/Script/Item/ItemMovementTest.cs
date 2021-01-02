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

    //testNew
    public static GameObject _grass;

    private void Start( )
    {
        cursor = GameObject.FindWithTag( "Cursor" );
        toolConvertion = cursor.GetComponent<ToolConvertion>( );

        itemCountDown = GetComponentInChildren<ItemCountDown>( );
    }

    private void Update( )
    {
        findItem( );
    }

    private void OnMouseOver( )
    {
        toolConvertion.setOnGO( );

        if( !toolConvertion.getIsCan( ) )
        {
            if( Input.GetMouseButtonDown( 1 ) )
            {
                var mousePos = Camera.main.ScreenToWorldPoint( Input.mousePosition );
                mousePos = new Vector3( mousePos.x, mousePos.y, 0 );

                //instantiate
                Instantiate( InstantiateUI, mousePos, Quaternion.identity );
                var startTime = GetComponentInChildren<ItemCountDown>( ).getStartTime( );
                InstantiateUI.GetComponent<ItemInstantiate>( ).setGOStartTime( startTime );
                Destroy( this.gameObject );
            }
        }
    }

    //
    void findItem( )
    {
        _grass = GameObject.FindGameObjectWithTag( "Grass" );
    }
}