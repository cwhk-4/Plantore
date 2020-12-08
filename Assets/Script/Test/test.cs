using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    GameObject[ ] LIONS;
    void Start()
    {
        GameObject obj = Resources.Load( "Animals/Prefabs/lion" ) as GameObject;
        for ( int i = 0; i < 4; i++ )
        {
            Instantiate( obj );
        }
        LIONS = GameObject.FindGameObjectsWithTag( "lion" );
        for( int e = 0; e < 4; e++ )
        {
            LIONS[ e ].name = "lion" + e;
        }
    }


    void Update()
    {

    }
}

//AddScripts

//_LION = GameObject.FindGameObjectWithTag( "LIONS" ).AddComponent<LION>( );
