using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassRepairing : MonoBehaviour
{
    public GameObject cursor;
    public ToolConvertion toolConvertion;

    public ItemCountDown itemCountDown;

    void Start()
    {
        cursor = GameObject.FindWithTag( "Cursor" );
        toolConvertion = cursor.GetComponent<ToolConvertion>( );

        itemCountDown = GetComponentInChildren<ItemCountDown>( );
    }

    private void OnMouseOver( )
    {
        itemCountDown.showGauge( );        
    }

    private void OnMouseDown( )
    {
        if( toolConvertion.GetIsCan( ) )
        {
            itemCountDown.repair( );
        }
    }

    private void OnMouseExit( )
    {
        itemCountDown.closeGauge( );
    }
}
