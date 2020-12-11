using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZEBRA : MonoBehaviour
{
    public static animalsCollection.animalsSystem _zebra = new animalsCollection.animalsSystem( );

    GameObject goStage;

    public static int zebrasNUM;
    private float startTime = 0;
    private bool runaway = false;

    void Start( )
    {
        startTime = GameObject.Find( "System" ).GetComponent<TimeController>( ).getNowRealSec( );
        _zebra.animals = this.gameObject;
        _zebra.moveSpeed = 3.0f;
        _zebra.timeOut = 2;
        _zebra.canMove = false;

        goStage = GameObject.Find( "zebraTarget" );
    }
        
    void Update( )
    {
        zebraMove( );
        timeIn( );
        numsProbability( );
        Debug.Log( "ITEMIN" + ItemMovement._item );
    }

    void zebraMove( )
    {
        if ( _zebra.canMove )
        {
            if ( _zebra.animals )
            {
                _zebra.animals.transform.position = Vector3.MoveTowards( _zebra.animals.transform.position, goStage.transform.position, Time.deltaTime * _zebra.moveSpeed );
            }
            if ( ItemMovement._item )
            {
                goStage.transform.position = ItemMovement._grass.transform.position;
            }
            if ( this.gameObject.transform.position == LION._lion.animals.transform.position )
            {
                runaway = true;
            }
            if ( runaway )
            {
                goStage.transform.position = new Vector3( 35.0f, 8.0f, 0 );
                for ( int e = 0; e < GetNum.zebrasNum; e++ )
                {
                    Destroy( GetNum._ZEBRA[ e ], 5 );
                }
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
                _zebra.canMove = true;
            }
        }
    }
    void numsProbability( )
    {
        if ( installAnimals.zebrasNumProbability == 0 )
        {
            zebrasNUM = 0;
        }
        else if ( installAnimals.zebrasNumProbability == 1 )
        {
            zebrasNUM = 1;
        }
        else if ( installAnimals.zebrasNumProbability == 2 )
        {
            zebrasNUM = 2;
        }
        else
        {
            zebrasNUM = 3;
        }
    }
}
