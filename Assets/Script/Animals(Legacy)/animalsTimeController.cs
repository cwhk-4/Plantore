﻿using UnityEngine;

public class AnimalsTimeController : MonoBehaviour
{
    private GameObject animalsType;
    public static float timeOut;
    private float startTime = 0;

    void Start( )
    {
        startTime = GameObject.Find( "System" ).GetComponent<TimeController>( ).GetNowSec( );
        animalsType = this.gameObject;
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
                timeOut = 5.0f;
                break;
            case "ZEBRAS":
                timeOut = 10.0f;
                break;
            case "GIRAFFES":
                timeOut = 5.0f;
                break;
            case "IMPALAS":
                timeOut = 6.0f;
                break;
            case "WHITERHINOS":
                timeOut = 10.0f;
                break;
            case "BLUEWILDEBEESTS":
                timeOut = 15.0f;
                break;
            case "HIPPOS":
                timeOut = 6.0f;
                break;
        }
    }

    public float changeTime( )
    {
        float timeOver = timeOut - ( GameObject.Find( "System" ).GetComponent<TimeController>( ).GetNowSec( ) - startTime );
        if ( timeOver <= -1 )
        {
            timeOver = 0;
        }
        return timeOver;
    }

}