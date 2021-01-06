using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMPALA : MonoBehaviour
{
    public static animalsCollection.animalsSystem _impala = new animalsCollection.animalsSystem( );

    GameObject goStage;
    public animalsTimeController _impalaTimeController;
    private Vector3 newPosition;

    public static int impalasNUM;
    private float timeToGo;
    private bool canFindItem = true;
    private bool runaway = false;

    //
    private bool scriptCount = false;
    private int timeControllerIn = 0;

    void Start( )
    {
        _impala.animals = this.gameObject;
        _impala.moveSpeed = 2.0f;
        _impala.canMove = false;

        goStage = GameObject.Find( "impalaTarget" );
        newPosition = new Vector3( 11.0f, Random.Range( -10, 10 ), 0.0f );
    }

    void Update( )
    {
        impalaMove( );
        timeIn( );
        numsProbability( );
    }

    void impalaMove( )
    {
        if ( _impala.canMove )
        {
            _impala.animals.transform.position = Vector3.MoveTowards( _impala.animals.transform.position, goStage.transform.position, Time.deltaTime * _impala.moveSpeed );
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
            _impala.canMove = false;
            timeControllerIn = 0;
        }
    }

    void timeIn( )
    {
        if ( ItemMovementTest._grass && InstallAnimals.in_animals.in_impala && timeControllerIn == 0 )
        {
            if ( !scriptCount )
            {
                _impalaTimeController = this.gameObject.AddComponent<animalsTimeController>( );
                scriptCount = true;
            }
            timeToGo = GameObject.Find( "IMPALAS" ).GetComponent<animalsTimeController>( ).changeTime( );

            if ( timeToGo < 0 )
            {
                _impala.canMove = true;
                Destroy( this.gameObject.GetComponent<animalsTimeController>( ) );
                timeControllerIn = 1;
                timeToGo = 0;
            }
        }
    }

    void numsProbability( )
    {
        if ( InstallAnimals.impalasNumProbability == 0 )
        {
            impalasNUM = 0;
        }
        else if ( InstallAnimals.impalasNumProbability <= 5 )
        {
            impalasNUM = 4;
        }
        else if ( InstallAnimals.impalasNumProbability <= 8 )
        {
            impalasNUM = 3;
        }
        else if ( InstallAnimals.impalasNumProbability <= 9 )
        {
            impalasNUM = 2;
        }
        else if ( InstallAnimals.impalasNumProbability == 10 )
        {
            impalasNUM = 1;
        }
    }
}
