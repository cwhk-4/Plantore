using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LION : MonoBehaviour
{
    public static animalsCollection.animalsSystem _lion = new animalsCollection.animalsSystem( );

    GameObject goStage;
    GameObject Target;

    public static int startProbability;
    public static int lionsNUM;
    public static bool canPredation;
    private float startTime = 0;
    bool canFind;
    bool canFindPrey;

    //
    private int DEBUG = 0;

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
        canFindPrey = false;
        startProbability = 30;
        goStage = GameObject.Find( "lionTarget" );
        Target = GameObject.Find( "LIONTARGET" );
        Target.transform.position = goStage.transform.position;
    }

    void Update( )
    {
        lionMove( );
        timeIn( );
        numsProbability( );
    }

    void lionMove( )
    {
        if ( _lion.canMove )
        {
            if ( ZEBRA._zebra.animals )
            {
                this.gameObject.transform.position = Vector3.MoveTowards( this.gameObject.transform.position, Target.transform.position, _lion.moveSpeed * Time.deltaTime );
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
                _lion.canMove = false;
            }
        }
    }

    void Predation( )
    {
        if ( canPredation )
        {
            Destroy( GetNum._ZEBRA[ GetNum.zebrasNum - 1 ] );
        }
        else
        {
            Destroy( GetNum._LION[ GetNum.lionsNum - 1 ] );
        }
    }

    void numsProbability( )
    {
        if ( installAnimals.lionsNumProbability == 0)
        {
            lionsNUM = 0;
        }else if ( installAnimals.lionsNumProbability <= 1 )
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
