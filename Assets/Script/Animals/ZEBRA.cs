using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZEBRA : MonoBehaviour
{
    public static animalsCollection.animalsSystem _zebra = new animalsCollection.animalsSystem( );
    void Start( )
    {
        _zebra.animals = this.gameObject;
        _zebra.moveSpeed = 3.0f;
    }

    void Update( )
    {
        zebraMove( );
    }

    void zebraMove( )
    {
        //caution
        //if ( _zebra.animals && item.itemIn )
        //{
        //    _zebra.animals.transform.position = Vector2.MoveTowards( _zebra.animals.transform.position, item.dragObj.transform.position, 3.0f * Time.deltaTime );
        //}
    }
}
