using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZEBRA : MonoBehaviour
{
    public static animalsCollection.animalsSystem _zebra = new animalsCollection.animalsSystem( );
    
    GameObject ITEM;
    GameObject goStage;
    bool canFind;
    void Start( )
    {
        _zebra.animals = this.gameObject;
        _zebra.moveSpeed = 3.0f;

        canFind = true;
        goStage = GameObject.Find( "zebraTarget" );
    }
        
    void Update( )
    {
        zebraMove( );
        Debug.Log( "ITEMIN" + ItemMovement._item );
    }

    void zebraMove( )
    {
        if ( _zebra.animals )
        {
            _zebra.animals.transform.position = Vector3.MoveTowards( _zebra.animals.transform.position, goStage.transform.position, Time.deltaTime * 3.0f );
        }
        if ( ItemMovement._item )
        {
            goStage.transform.position = ItemMovement._grass.transform.position;
        }
        if ( !ItemMovement._item )
        {
            goStage.transform.position = new Vector3( 35.0f, 8.0f, 0 );
        }
    }
}
