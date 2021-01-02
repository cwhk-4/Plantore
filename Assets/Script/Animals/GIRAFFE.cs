using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GIRAFFE : MonoBehaviour
{
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
            _giraffe.animals.transform.position = Vector3.MoveTowards( _giraffe.animals.transform.position, goStage.transform.position, Time.deltaTime * _giraffe.moveSpeed );
            changeTarget( );
        }
    }

    void changeTarget( )
    {

    }

    void timeIn( )
    {

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
}
