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
    }

    void zebraMove( )
    {
        if ( _zebra.canMove )
        {
            if ( _zebra.animals )
            {
                _zebra.animals.transform.position = Vector3.MoveTowards( _zebra.animals.transform.position, goStage.transform.position, Time.deltaTime * _zebra.moveSpeed );
            }
            if ( ItemMovementTest._grass )
            {
                goStage.transform.position = ItemMovementTest._grass.transform.position;
            }
        }
    }
    void timeIn( )
    {
        if ( ItemMovementTest._grass && installAnimals.in_animals.IN_ZEBRA )
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
