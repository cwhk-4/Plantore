using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GIRAFFE : MonoBehaviour
{
    /*
    public static animalsCollection.animalsSystem _giraffe = new animalsCollection.animalsSystem( );

    GameObject goStage;
    public animalsTimeController _giraffeTimeController;
    private Vector3 newPosition;

    public static int giraffesNUM;
    private float timeToGo;
    private bool canFindItem = true;
    private bool runaway = false;

    //
    private bool scriptCount = false;
    private int timeControllerIn = 0;

    void Start( )
    {
        _giraffe.animals = this.gameObject;
        _giraffe.moveSpeed = 4.0f;
        _giraffe.canMove = false;

        goStage = GameObject.Find( "giraffeTarget" );
        newPosition = new Vector3( 11.0f, Random.Range( -10, 10 ), 0.0f );
    }

    void Update( )
    {
        giraffeMove( );
        timeIn( );
        numsProbability( );
    }

    void giraffeMove( )
    {
        if ( _giraffe.canMove )
        {
            this.gameObject.transform.position = Vector3.MoveTowards( this.gameObject.transform.position, goStage.transform.position, Time.deltaTime * _giraffe.moveSpeed );
            changeTarget( );
        }
    }

    void changeTarget( )
    {
        if ( ItemMovementTest._grass && !runaway )
        {
            goStage.transform.position = ItemMovementTest._grass.transform.position;
            canFindItem = true;
        }
        if ( ItemMovementTest._grass == null && canFindItem )
        {
            newPosition = new Vector3( 11.0f, Random.Range( -10, 10 ), 0.0f );
            goStage.transform.position = newPosition;
            canFindItem = false;
        }
        if ( this.gameObject.transform.position == LION._lion.animals.transform.position )
        {
            newPosition = new Vector3( 11.0f, Random.Range( -10, 10 ), 0.0f );
            runaway = true;
            goStage.transform.position = newPosition;
        }
        if ( ItemMovementTest._grass == null && this.gameObject.transform.position == newPosition )
        {
            runaway = false;
            scriptCount = false;
            _giraffe.canMove = false;
            timeControllerIn = 0;
        }
    }

    void timeIn( )
    {
        if ( ItemMovementTest._grass && InstallAnimals.in_animals.in_giraffe && timeControllerIn == 0 )
        {
            if ( !scriptCount )
            {
                _giraffeTimeController = this.gameObject.AddComponent<animalsTimeController>( );
                scriptCount = true;
            }
            timeToGo = GameObject.Find( "GIRAFFES" ).GetComponent<animalsTimeController>( ).changeTime( );

            if ( timeToGo < 0 )
            {
                _giraffe.canMove = true;
                Destroy( this.gameObject.GetComponent<animalsTimeController>( ) );
                timeControllerIn = 1;
                timeToGo = 0;
            }
        }
    }

    void numsProbability( )
    {
        if ( InstallAnimals.giraffesNumProbability == 1 )
        {
            giraffesNUM = 1;
        }else if ( InstallAnimals.giraffesNumProbability == 2 )
        {
            giraffesNUM = 2;
        }
    }

    */
}
