using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LION : MonoBehaviour
{
    GameObject TARGET;
    GameObject target;
    
    public static animalsCollection.animalsSystem _lion = new animalsCollection.animalsSystem( );

    void Start( )
    {
        _lion.animals = this.gameObject;
        _lion.moveSpeed = 4.0f;
        _lion.predationProbability = Random.Range( 0, 3 );

        target = ZEBRA._zebra.animals;
        TARGET = GameObject.FindGameObjectWithTag( "tag" );
    }

    void Update( )
    {
        lionMove( );
        Debug.Log( "lionMoveSpeed : " + _lion.moveSpeed );
    }

    void lionMove( )
    {
        if ( ZEBRA._zebra.animals )
        {
            _lion.animals.transform.position = Vector3.MoveTowards( _lion.animals.transform.position, target.transform.position, _lion.moveSpeed * Time.deltaTime );
            if ( _lion.animals.transform.position == ZEBRA._zebra.animals.transform.position )
            {
                TARGET.transform.position = new Vector2( Random.Range( -60, 60 ), Random.Range( -60, 60 ) );
                target = TARGET;
                if ( _lion.predationProbability == 2 )
                {
                    Destroy( ZEBRA._zebra.animals );
                }
                else
                {
                    Debug.Log( "MISS!" );
                }
            }
        }
        Destroy( _lion.animals, 30 );
    }


}
