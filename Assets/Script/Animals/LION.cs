using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LION : MonoBehaviour
{
    public static animalsCollection.animalsSystem _lion = new animalsCollection.animalsSystem( );

    GameObject goStage;
    GameObject Target;

    private float timeToStop;
    private float stopTime;
    private int TRUE;

    public static int startProbability;
    public static int lionsNUM;
    public static bool canPredation;
    private float startTime = 0;
    bool canFind;

    void Start( )
    {
        startTime = GameObject.Find( "System" ).GetComponent<TimeController>( ).getNowRealSec( );
        _lion.animals = this.gameObject;
        _lion.moveSpeed = 4.0f;
        _lion.Minus = 5;
        _lion.timeOut = 5;
        _lion.reviveTime = 60;
        _lion.canMove = false;
        _lion.predationProbability = Random.Range( 0, 9 );

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
        numsProbability( );
        Debug.Log( "stopTime   " + stopTime + "    " + timeToStop );
    }

    void lionMove( )
    {
        if ( _lion.canMove )
        {
            if ( ZEBRA._zebra.animals )
            {
                this.gameObject.transform.position = Vector3.MoveTowards( this.gameObject.transform.position, Target.transform.position, _lion.moveSpeed * Time.deltaTime );

                if ( this.transform.position == goStage.transform.position )
                {
                    canFind = true;
                    lionPredationProbability( );
                    //stopTime = GameObject.Find( "System" ).GetComponent<TimeController>( ).getNowRealSec( );
                }

                if ( canFind )
                {
                    //timeToStop = 5 - ( GameObject.Find( "System" ).GetComponent<TimeController>( ).getNowRealSec( ) - stopTime );
                    if ( timeToStop <= 0 )
                    {
                        Target.transform.position = ZEBRA._zebra.animals.transform.position;
                    }
                }

                if( installAnimals.LIONS.transform.position == ZEBRA._zebra.animals.transform.position )
                {
                    canFind = false;
                    Target.transform.position = goStage.transform.position;
                }
            }
            //else
            //{
            //    Target.transform.position = new Vector3( -15, Random.Range( -5, 5 ), 0 );
            //    installAnimals.LIONS.transform.position = Vector3.MoveTowardss( installAnimals.LIONS.transform.position, Target.transform.position, _lion.moveSpeed * Time.deltaTime );
            //    Destroy( installAnimals.LIONS , 5 );
            //}
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
            //if ( GetNum.lionsNum == 4 )
            //{
            //    infighting( );
            //}
    }


    void timeIn( )
    {
        if ( ZEBRA._zebra.animals && installAnimals.in_animals.IN_LION )
        {
            float timeOver = _lion.timeOut - ( GameObject.Find( "System" ).GetComponent<TimeController>( ).getNowRealSec( ) - startTime );
            if ( timeOver <= 0 )
            {
                _lion.canMove = true;
            }
            else
            {
                _lion.canMove = false ;
            }
        }
    }

    void timeToRevive ( )
    {
        if ( !_lion.animals )
        {

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

    void numsProbability( )
    {
        if ( installAnimals.lionsNumProbability <= 1 )
        {
            lionsNUM = 1;
        }else if ( installAnimals.lionsNumProbability <= 4 )
        {
            lionsNUM = 2;
        }else if ( installAnimals.lionsNumProbability <= 8 )
        {
            lionsNUM = 3;
        }else
        {
            lionsNUM = 4;
        }
    }

    //
    ////level3
    //
    //void infighting( )
    //{
    //    _lion.fightProbability = Random.Range( 0, 20 );
    //    if ( _lion.fightProbability < 4 )
    //    {
    //        _lion.fightEachOther = true;
    //    }
    //    else
    //    {
    //        _lion.fightEachOther = false;
    //    }

    //    if ( _lion.fightEachOther )
    //    {
    //        Destroy( GetNum._LION[ GetNum.lionsNum - 1 ] );
    //        Destroy( GetNum._LION[ GetNum.lionsNum - 2 ] );
    //    }
    //}
}
