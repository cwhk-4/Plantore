using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMPALA : MonoBehaviour
{
    public static animalsCollection.animalsSystem _impala = new animalsCollection.animalsSystem( );

    GameObject goStage;

    private float startTime = 0;
    bool canMove;

    void Start( )
    {
        startTime = GameObject.Find( "System" ).GetComponent<TimeController>( ).getNowRealSec( );
        _impala.animals = this.gameObject;
        _impala.moveSpeed = 2.0f;
        _impala.timeOut = 3;

        canMove = false;
        goStage = GameObject.Find( "impalaTarget" );
    }

    void Update( )
    {
        impalaMove( );
        timeIn( );
    }

    void impalaMove( )
    {
        if ( canMove )
        {
            if ( _impala.animals )
            {
                _impala.animals.transform.position = Vector3.MoveTowards( _impala.animals.transform.position, goStage.transform.position, Time.deltaTime * _impala.moveSpeed );
            }
            if ( ItemMovement._item )
            {
                goStage.transform.position = ItemMovement._grass.transform.position - new Vector3( 2.0f, 0, 0 );
            }
            if ( !ItemMovement._item && ItemCountDown.CD < -10 )
            {
                goStage.transform.position = new Vector3( 35.0f, -5.0f, 0 );
                Destroy( _impala.animals, 5 );
            }
        }
    }

    void timeIn( )
    {
        if ( ItemMovement._item && installAnimals.in_animals.IN_IMPALA )
        {
            float timeOver = _impala.timeOut - ( GameObject.Find( "System" ).GetComponent<TimeController>( ).getNowRealSec( ) - startTime );
            if ( timeOver <= 0 )
            {
                canMove = true;
            }
        }
    }
}
