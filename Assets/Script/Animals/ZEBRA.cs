using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZEBRA : MonoBehaviour
{
    public static animalsCollection.animalsSystem _zebra = new animalsCollection.animalsSystem( );

    GameObject ITEM;
    void Start( )
    {
        _zebra.animals = this.gameObject;
        _zebra.moveSpeed = 3.0f;
    }

    void Update( )
    {
        findItem( );
        zebraMove( );
    }

    void zebraMove( )
    {
        if ( _zebra.animals && ItemMovement._item )
        {
            _zebra.animals.transform.position = Vector3.MoveTowards( _zebra.animals.transform.position, ITEM.transform.position, Time.deltaTime * 3.0f );
        }
        else if ( ItemMovement._item == null )
        {

        }
    }

    void findItem( )
    {
        ITEM = GameObject.FindGameObjectWithTag( "Grass" );
    }
}
