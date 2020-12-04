using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LION : MonoBehaviour
{
    public static animalsCollection.animalsSystem _lion = new animalsCollection.animalsSystem( );

    GameObject goStage;
    GameObject Target;

    public static int startProbability;
    public static bool canPredation;
    public static bool timeToInstallLion;
    private float startTime = 0;
    bool canFind;

    void Start( )
    {
        startTime = GameObject.Find( "System" ).GetComponent<TimeController>( ).getNowRealSec( );
        _lion.animals = this.gameObject;
        _lion.moveSpeed = 4.0f;
        _lion.Minus = 5;
        _lion.timeOut = 5;
        _lion.predationProbability = Random.Range( 0, 9 );

        timeToInstallLion = false;
        canPredation = false;
        canFind = false;
        startProbability = 30;
        goStage = GameObject.Find( "lionTarget" );
        Target = GameObject.Find( "LIONTARGET" );
        Target.transform.position = goStage.transform.position;
    }

    void Update( )
    {
        lionMove( );
        Predation( );
        timeIn( );
    }

    void lionMove( )
    {
        if ( installAnimals.canMove )
        {
            if ( ZEBRA._zebra.animals )
            {
                installAnimals.LIONS.transform.position = Vector3.MoveTowards( installAnimals.LIONS.transform.position, Target.transform.position, _lion.moveSpeed * Time.deltaTime );

                if ( installAnimals.LIONS.transform.position == goStage.transform.position )
                {
                    canFind = true;
                    lionPredationProbability( );
                }

                if ( canFind )
                {
                    Target.transform.position = ZEBRA._zebra.animals.transform.position;
                }

                if( installAnimals.LIONS.transform.position == ZEBRA._zebra.animals.transform.position )
                {
                    canFind = false;
                    Target.transform.position = goStage.transform.position;
                }
            }
            else
            {
                Target.transform.position = new Vector3( -15, Random.Range( -5, 5 ), 0 );
                installAnimals.LIONS.transform.position = Vector3.MoveTowards( installAnimals.LIONS.transform.position, Target.transform.position, _lion.moveSpeed * Time.deltaTime );
                Destroy( installAnimals.LIONS , 5 );
            }
        }
    }

    public void lionPredationProbability( )
    {
            _lion.predationProbability = Random.Range( 0, 100 );
            if ( _lion.predationProbability < ( startProbability - ( 4 - GetNum.lionsNum ) * _lion.Minus ) )
            {
                canPredation = true;
            }
            else
            {
                canPredation = false;
            }
            if ( GetNum.lionsNum == 4 )
            {
                infighting( );
            }
    }

    void infighting( )
    {
        _lion.fightProbability = Random.Range( 0, 20 );
        if ( _lion.fightProbability < 4 )
        {
            _lion.fightEachOther = true;
        }
        else
        {
            _lion.fightEachOther = false;
        }

        if ( _lion.fightEachOther )
        {
            Destroy( GetNum._LION[ GetNum.lionsNum - 1 ] );
            Destroy( GetNum._LION[ GetNum.lionsNum - 2 ] );
        }
    }

    void timeIn( )
    {
        if ( ZEBRA._zebra.animals && installAnimals.in_animals.IN_LION )
        {
            float timeOver = _lion.timeOut - ( GameObject.Find( "System" ).GetComponent<TimeController>( ).getNowRealSec( ) - startTime );
            if ( timeOver <= 0 )
            {
                timeToInstallLion = true;
            }
        }
    }

    void Predation( )
    {
        if ( ZEBRA._zebra.animals )
        {
            if ( installAnimals.LIONS.transform.position == ZEBRA._zebra.animals.transform.position )
            {
                if ( canPredation )
                {
                    Destroy( ZEBRA._zebra.animals );
                }
                else
                {
                    Destroy( GetNum._LION[ GetNum.lionsNum - 1 ] );
                }
            }
        }
    }
}
