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
        toolConvertion.setOnGO( );
        itemCountDown.showGauge( );        
    }

    private void OnMouseDown( )
    {
        if( toolConvertion.getIsCan( ) )
        {
            itemCountDown.repair( );
        }
    }

    private void OnMouseExit( )
    {
        toolConvertion.setExitGO( );
        itemCountDown.closeGauge( );
    }
}
