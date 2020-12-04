using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LION : MonoBehaviour
{
    public static animalsCollection.animalsSystem _lion = new animalsCollection.animalsSystem( );
    public static installAnimals.Animals _lionStall = new installAnimals.Animals( );
    public static bool canPredation;
    public static int startProbability;
    bool canFind;

    GameObject goStage;
    //GameObject Target;

    void Start( )
    {
        _lion.animals = this.gameObject;
        _lion.moveSpeed = 2.0f;
        _lion.Minus = 5;
        _lion.predationProbability = Random.Range( 0, 9 );

        canPredation = false;
        canFind = false;
        startProbability = 30;
        goStage = GameObject.Find( "lionTarget" );
    }

    void Update( )
    {
        lionPredationProbability( );
        lionMove( );
        Debug.Log( startProbability - ( 4 - GetNum.lionsNum ) * _lion.Minus );
    }

    void lionMove( )
    {
        if ( installAnimals.canMove )
        {
            if ( ZEBRA._zebra.animals )
            {
                installAnimals.LIONS.transform.position = Vector3.MoveTowards( installAnimals.LIONS.transform.position, goStage.transform.position, _lion.moveSpeed * Time.deltaTime );
                if ( installAnimals.LIONS.transform.position == goStage.transform.position )
                {
                    canFind = true;
                }
                if ( canFind )
                {
                    goStage.transform.position = ZEBRA._zebra.animals.transform.position;
                }
            }
        }
    }

    public void lionPredationProbability( )
    {
        if ( Input.GetKeyDown( KeyCode.A ) )
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
            Destroy( GetNum.ala[ GetNum.lionsNum - 1 ] );
            Destroy( GetNum.ala[ GetNum.lionsNum - 2 ] );
        }
    }
}
