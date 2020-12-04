using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetNum : MonoBehaviour
{
    public static GameObject[ ] _LION;
    public static GameObject[ ] _GRASS;

    public static int lionsNum;
    public static int grassNum;
    void Start( )
    {

    }

    // Update is called once per frame
    void Update( )
    {
        getLionsNum( );
        getGrassNum( );
    }

    void getLionsNum( )
    {
        _LION = GameObject.FindGameObjectsWithTag( "lion" );
        lionsNum = _LION.Length;
        
        Debug.Log( "_LION.length : " + _LION.Length );
    }

    void getGrassNum( )
    {
        _GRASS = GameObject.FindGameObjectsWithTag( "Grass" );
        grassNum = _GRASS.Length;

        Debug.Log( "_Grass.length : " + _GRASS.Length );
    }
}
