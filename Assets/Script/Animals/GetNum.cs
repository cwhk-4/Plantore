using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetNum : MonoBehaviour
{
    public static GameObject[ ] _LION;
    public static GameObject[ ] _ZEBRA;
    public static GameObject[ ] _GRAFFE;

    public static GameObject[ ] _GRASS;

    public static int lionsNum;
    public static int zebrasNum;
    public static int graffesNum;

    public static int grassNum;
    void Start( )
    {

    }

    // Update is called once per frame
    void Update( )
    {
        getLionsNum( );
        getZebrasNum( );
        getGrassNum( );
    }

    void getLionsNum( )
    {
        _LION = GameObject.FindGameObjectsWithTag( "lion" );
        lionsNum = _LION.Length;  
    }
    void getZebrasNum( )
    {
        _ZEBRA = GameObject.FindGameObjectsWithTag( "zebra" );
        zebrasNum = _ZEBRA.Length;
    }

    void getGrassNum( )
    {
        _GRASS = GameObject.FindGameObjectsWithTag( "Grass" );
        grassNum = _GRASS.Length;
    }

    void getGraffeNum( )
    {
        _GRASS = GameObject.FindGameObjectsWithTag( "Grass" );
        grassNum = _GRASS.Length;
    }
}
