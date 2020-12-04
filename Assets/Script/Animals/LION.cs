using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LION : MonoBehaviour
{
    public static animalsCollection.animalsSystem _lion = new animalsCollection.animalsSystem( );
    public static bool canPredation;

    void Start( )
    {
        _lion.animals = this.gameObject;
        _lion.moveSpeed = 4.0f;
        _lion.predationProbability = Random.Range( 0, 9 );
        canPredation = false;
    }

    void Update( )
    {
        if ( Input.GetKeyDown( KeyCode.A ) )
        {
            lionPredationProbability( );
        }
        
    }

    public void lionPredationProbability( )
    {
        switch ( installAnimals.lionsNum )
        {
            case 4:
                _lion.predationProbability = Random.Range( 0, 9 );
                if ( _lion.predationProbability > 5 )
                {
                    canPredation = true;
                }
                else
                {
                    canPredation = false;
                }
                break;
            case 3:
                _lion.predationProbability = Random.Range( 0, 4 );
                if ( _lion.predationProbability > 2 )
                {
                    canPredation = true;
                }
                else
                {
                    canPredation = false;
                }
                break;
            case 2:
                _lion.predationProbability = Random.Range( 0, 5 );
                if ( _lion.predationProbability > 3 )
                {
                    canPredation = true;
                }
                else
                {
                    canPredation = false;
                }
                break;
            case 1:
                _lion.predationProbability = Random.Range( 0, 6 );
                if ( _lion.predationProbability > 4 )
                {
                    canPredation = true;
                }
                else
                {
                    canPredation = false;
                }
                break;
            case 0:
                canPredation = false;
                break;
        }
    }

    void lionMove( )
    {

    }

    void infighting( )
    {
        _lion.fightProbability = Random.Range( 0, 20 );
        if ( _lion.fightProbability < 4 )
        {
            _lion.fightEachOther = true;
        }else
        {
            _lion.fightEachOther = false;
        }

        if ( _lion.fightEachOther )
        {
            
        }
    }
}
