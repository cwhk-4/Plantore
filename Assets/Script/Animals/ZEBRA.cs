using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZEBRA : MonoBehaviour
{
    public static animalsCollection.animalsSystem _zebra = new animalsCollection.animalsSystem( );

    GameObject goStage;

    private float startTime = 0; 
    bool canMove;

    void Start( )
    {
        startTime = GameObject.Find( "System" ).GetComponent<TimeController>( ).getNowRealSec( );
        _zebra.animals = this.gameObject;
        _zebra.moveSpeed = 3.0f;
        _zebra.timeOut = 2;

        canMove = false;
        goStage = GameObject.Find( "zebraTarget" );
    }
        
    void Update( )
    {
        zebraMove( );
        timeIn( );
        Debug.Log( "ITEMIN" + ItemMovement._item );
    }

    void zebraMove( )
    {
        if ( canMove )
        {
            if ( _zebra.animals )
            {
                _zebra.animals.transform.position = Vector3.MoveTowards( _zebra.animals.transform.position, goStage.transform.position, Time.deltaTime * _zebra.moveSpeed );
            }
            if ( ItemMovement._item )
            {
                goStage.transform.position = ItemMovement._grass.transform.position + new Vector3( 0, 2.0f, 0 );
            }
            if ( !ItemMovement._item && ItemCountDown.CD < -7 )
            {
                goStage.transform.position = new Vector3( 35.0f, 8.0f, 0 );
                Destroy( _zebra.animals, 5 );
            }
        }
    }
    void timeIn( )
    {
        if ( ItemMovement._item && installAnimals.in_animals.IN_ZEBRA )
        {
            float timeOver = _zebra.timeOut - ( GameObject.Find( "System" ).GetComponent<TimeController>( ).getNowRealSec( ) - startTime );
            if ( timeOver <= 0 )
            {
                canMove = true;
            }
        }
    }
}
