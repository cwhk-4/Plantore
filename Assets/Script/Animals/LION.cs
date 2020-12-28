using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LION : MonoBehaviour
{
    public static animalsCollection.animalsSystem _lion = new animalsCollection.animalsSystem( );

    GameObject Target;
    GameObject goStage;

    public static int startProbability;
    public static int lionsNUM;
    public static bool canPredation;
    private float startTime = 0;

    //
    private Vector3 newPosition;
    private bool goPredation;

    void Start( )
    {
        startTime = GameObject.Find( "System" ).GetComponent<TimeController>( ).getNowRealSec( );
        _lion.animals = this.gameObject;
        _lion.moveSpeed = 4.0f;
        _lion.Minus = 5;
        _lion.timeOut = 5.0f;
        _lion.reviveTime = 60;
        _lion.canMove = false;
        _lion.predationProbability = Random.Range( 0, 9 );

        canPredation = false;
        goPredation = true;
        startProbability = 30;
        Target = GameObject.Find( "LIONTARGET" );
        goStage = GameObject.Find( "lionTarget" );
        Target.transform.position = goStage.transform.position;
        newPosition = new Vector3( Random.Range( -10, 10 ), 7.0f, 0.0f );
    }

    void Update( )
    {
        lionMove( );
        timeIn( );
        numsProbability( );
        Debug.Log( "nowPredation" + _lion.predationProbability );
        Debug.Log( canPredation );
        Debug.Log( ( startProbability - ( 4 - GetNum.lionsNum ) * _lion.Minus ) );
    }

    void lionMove( )
    {
        if ( _lion.canMove )
        {
            this.gameObject.transform.position = Vector3.MoveTowards( this.gameObject.transform.position, Target.transform.position, _lion.moveSpeed * Time.deltaTime );
            changeTarget( );
        }
    }

    void changeTarget( )
    {
        if ( ItemMovementTest._grass )
        {
            if ( this.gameObject.transform.position == goStage.transform.position && goPredation && ZEBRA._zebra.animals.transform.position == ItemMovementTest._grass.transform.position )
            {
                Target.transform.position = ZEBRA._zebra.animals.transform.position;
                lionPredationProbability( );
            }
            if ( this.gameObject.transform.position == ZEBRA._zebra.animals.transform.position )
            {
                newPosition = new Vector3( Random.Range( -10, 10 ), 7.0f, 0.0f );
                Target.transform.position = newPosition;
                Predation( );
                goPredation = false;
            }
            if ( this.gameObject.transform.position == newPosition && ZEBRA._zebra.animals.transform.position == ItemMovementTest._grass.transform.position )
            {
                goPredation = true;
                Target.transform.position = goStage.transform.position;
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
