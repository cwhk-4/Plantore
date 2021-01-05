using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animalsTimeController : MonoBehaviour
{
    private GameObject animalsType;
    public static float timeOut;
    private float startTime = 0;
    private int timeReset;

    void Start( )
    {
        startTime = GameObject.Find( "System" ).GetComponent<TimeController>( ).getNowRealSec( );
        animalsType = this.gameObject;
        timeReset = 0;
    }

    void Update( )
    {
        changeAnimalsType( );
    }

    void changeAnimalsType( )
    {
        switch( animalsType.tag )
        {
            case "LIONS":
                timeOut = 3.0f;
                break;
            case "ZEBRAS":
                timeOut = 2.0f;
                break;
            case "GIRAFFE":
                timeOut = 3.0f;
                break;
            case "IMPALAS":
                timeOut = 3.0f;
                break;
        }
    }

    public float changeTime( )
    {
        float timeOver = timeOut - ( GameObject.Find( "System" ).GetComponent<TimeController>( ).getNowRealSec( ) - startTime );
        if ( timeReset == 0 )
        {
            timeOver = 0;
            timeReset = 1;
        }
        return timeOver;
    }

}
