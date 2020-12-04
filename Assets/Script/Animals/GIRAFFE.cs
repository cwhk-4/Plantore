using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GIRAFFE : MonoBehaviour
{
    public static animalsCollection.animalsSystem _giraffe = new animalsCollection.animalsSystem( );

    GameObject goStage;

    private float startTime = 0;
    bool canMove;

    void Start()
    {
        startTime = GameObject.Find( "System" ).GetComponent<TimeController>( ).getNowRealSec( );
        _giraffe.animals = this.gameObject;
        _giraffe.moveSpeed = 4.0f;
        _giraffe.timeOut = 4;

        canMove = false;
        goStage = GameObject.Find( "giraffeTarget" );
    }

    void Update()
    {
        giraffeMove( );
        timeIn( );
    }

    void giraffeMove( )
    {
        if ( canMove )
        {
            if( _giraffe.animals )
            {
                _giraffe.animals.transform.position = Vector3.MoveTowards( _giraffe.animals.transform.position, goStage.transform.position, Time.deltaTime * 3.0f );
            }
            if ( ItemMovement._item )
            {
                goStage.transform.position = ItemMovement._grass.transform.position - new Vector3( 0, 2.0f, 0 );
            }
            if ( !ItemMovement._item && ItemCountDown.CD < -2 )
            {
                goStage.transform.position = new Vector3( 35.0f, -5.0f, 0 );
                Destroy( _giraffe.animals, 5 );
            }
        }
    }

    void timeIn( )
    {
        if ( ItemMovement._item && installAnimals.in_animals.IN_GIRAFFE )
        {
            float timeOver = _giraffe.timeOut - ( GameObject.Find( "System" ).GetComponent<TimeController>( ).getNowRealSec( ) - startTime );
            if ( timeOver <= 0 )
            {
                canMove = true;
            }
        }
    }
}
