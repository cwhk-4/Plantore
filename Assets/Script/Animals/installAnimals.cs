﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class installAnimals : MonoBehaviour
{
    public GameObject lion;
    public GameObject zebra;
    private int zebra_num = 3;
    public static int predationProbability;

    //new
    int period;

    public struct Animals
    {
        public bool IN_LION_ENVIRONMENT;
        public bool IN_ZEBRA_ENVIRONMENT;

        public bool IN_LION_PERIOD;
        //public bool IN_ZEBRA_PERIOD;  ( true )

        public bool IN_LION;
        public bool IN_ZEBRA;
    };
    public static Animals in_animals = new Animals( );

    private void Awake( )
    {

    }
    void Start( )
    {
       
    }

    void Update( )
    {
        period = GameObject.Find( "System" ).GetComponent<TimeController>( ).getNowGamePeriod( );

        environmentAnimalsType( environment._environment );
        periodAnimalsType( );
        animalsType( );
        animalsInstall( );
        debugText( );
    }

    void animalsInstall( )
    {
        //LION
        if ( ZEBRA._zebra.animals )
        {
            if ( in_animals.IN_LION )
            {
                if ( Input.GetKeyDown( KeyCode.A ) )
                {
                    Debug.Log( "123" );
                    Instantiate( lion, new Vector3( -10.0f + 1.0f, 0.0f - 1.0f, 0.0f ), Quaternion.identity );
                    predationProbability = Random.Range( 0, 3 );
                }
            }
        }

        //ZEBRA
        if ( in_animals.IN_ZEBRA )
        {
            if ( zebra_num <= 3 )
            {
                if ( ItemMovement._item )
                {
                    Instantiate( zebra, new Vector3( 15.0f, 0.0f, 0.0f ), Quaternion.identity );
                    zebra_num++;
                }
            }
        }
        if ( zebra_num == 0 )
        {
            Debug.Log( "zebra : true" + zebra_num );
        }
        else if ( zebra_num != 0 )
        {
            Debug.Log( "zebra : false" + zebra_num );
        }
    }

    //環境と動物関係
    void environmentAnimalsType( environment.ENVIRONMENT _environment )
    {
        switch ( _environment )
        {
            case environment.ENVIRONMENT.GRASSLAND:
                in_animals.IN_LION_ENVIRONMENT = true;
                in_animals.IN_ZEBRA = true;
                break;
            case environment.ENVIRONMENT.ROCKY:
                in_animals.IN_LION_ENVIRONMENT = true;
                in_animals.IN_ZEBRA = false; 
                break;
            case environment.ENVIRONMENT.OTHER:
                in_animals.IN_LION_ENVIRONMENT = false;
                in_animals.IN_ZEBRA = false;
                break;
        }
    }

    //new
    void periodAnimalsType( )
    {
        switch ( period )
        {
            case 1:
                in_animals.IN_LION_PERIOD = true;
                break;
            case 2:
                in_animals.IN_LION_PERIOD = false;
                break;
            case 3:
                in_animals.IN_LION_PERIOD = true;
                break;
            case 4:
                in_animals.IN_LION_PERIOD = false;
                break;
            case 5:
                in_animals.IN_LION_PERIOD = false;
                break;
            case 6:
                in_animals.IN_LION_PERIOD = false;
                break;
        }
    }

    void animalsType( )
    {
        if ( in_animals.IN_LION_ENVIRONMENT && in_animals.IN_LION_PERIOD )
        {
            in_animals.IN_LION = true;
        }
    }

    void debugText( )
    {
        Debug.Log( "inZebra : " + in_animals.IN_ZEBRA );
        Debug.Log( "period : " + period );
        Debug.Log( "inLion : " + in_animals.IN_LION );
        Debug.Log( "prob : " + LION._lion.predationProbability );
    }
}
