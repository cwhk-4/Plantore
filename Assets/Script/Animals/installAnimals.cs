﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class installAnimals : MonoBehaviour
{
    public GameObject giraffe;
    public GameObject impala;

    GameObject[ ] lion;
    public static GameObject lionObj;
    public static GameObject LIONS;
    public LION _LION;
    GameObject[ ] zebra;
    public static GameObject zebraObj;
    public static GameObject ZEBRAS;
    public ZEBRA _ZEBRA;

    public static int lionsNumProbability;
    public static int zebrasNumProbability;

    private int giraffeNum = 0;
    private int impalaNum = 0;
    private int period;
    private int scriptCount = 0;
    private int scriptCounts = 0;

    //キリン仮確率
    int giraffeProbability;

    public struct Animals
    {
        public bool IN_LION_ENVIRONMENT;
        //public bool IN_ZEBRA_ENVIRONMENT;
        //public bool IN_GIRAFFE_ENVIRONMENT;
        //public bool IN_IMPALA_ENVIRONMENT;

        public bool IN_LION_PERIOD;
        //public bool IN_ZEBRA_PERIOD;
        //public bool IN_GIRAFFE_PERIOD;
        //public bool IN_IMPALA_PERIOD;

        public bool IN_LION;
        public bool IN_ZEBRA;
        public bool IN_GIRAFFE;
        public bool IN_IMPALA;
    };
    public static Animals in_animals = new Animals( );

    void Start( )
    {
        lionObj = Resources.Load( "Animals/Prefabs/lion" ) as GameObject;
        LIONS = GameObject.Find( "LIONS" );
        zebraObj = Resources.Load( "Animals/Prefabs/zebra" ) as GameObject;
        ZEBRAS = GameObject.Find( "ZEBRAS" );

        //
        giraffeProbability = Random.Range( 0, 10 );
        lionsNumProbability = Random.Range( 1, 21 );
        zebrasNumProbability = Random.Range( 1, 5 );
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
        if ( ZEBRA._zebra.animals && in_animals.IN_LION )
        {
            if ( scriptCount == 0 )
            {
                _LION = GameObject.FindGameObjectWithTag( "LIONS" ).AddComponent<LION>( );
                scriptCount = 1;
            }

            if ( GetNum.lionsNum < LION.lionsNUM )
            {
                for ( int i = 0; i < LION.lionsNUM; i++ )
                {
                    Instantiate( lionObj, new Vector3( -15.0f + i * 1.0f, -5.0f + i * 1.0f, 0.0f ), Quaternion.identity );
                    lion = GameObject.FindGameObjectsWithTag( "lion" );
                    lion[ i ].name = "lion" + i;
                    lion[ i ].transform.parent = GameObject.FindGameObjectWithTag( "LIONS" ).transform;
                }
            }
        }

        //ZEBRA
        if ( in_animals.IN_ZEBRA )
        {
            if ( ItemMovement._item )
            {
                if ( GetNum.zebrasNum < ZEBRA.zebrasNUM )
                {
                    for ( int i = 0; i < ZEBRA.zebrasNUM; i++ )
                    {
                        Instantiate( zebraObj, new Vector3( 15.0f + i * 2.0f, 0.0f + i * 2.0f, 0.0f ), Quaternion.identity );
                        zebra = GameObject.FindGameObjectsWithTag( "zebra" );
                        zebra[ i ].name = "zebra" + i;
                        zebra[ i ].transform.parent = GameObject.FindGameObjectWithTag( "ZEBRAS" ).transform;
                    }
                }
            }
        }

        //GIRAFFE
        if ( in_animals.IN_GIRAFFE )
        {
            if ( ItemMovement._item && in_animals.IN_ZEBRA )
            {
                if ( scriptCounts == 0 )
                {
                    _ZEBRA = GameObject.FindGameObjectWithTag( "ZEBRAS" ).AddComponent<ZEBRA>( );
                    scriptCounts = 1;
                }
                if ( giraffeProbability > 0 && giraffeNum == 0 )
                {
                    Instantiate( giraffe, new Vector3( 15.0f, 4.0f, 0.0f ), Quaternion.identity );
                    giraffeNum = 1;
                }
            }
        }

        //IMPALA
        if ( ItemMovement._item && in_animals.IN_IMPALA )
        {
            if ( impalaNum == 0 && GetNum.grassNum >= 3 )
            {
                Instantiate( impala, new Vector3( 15.0f, 8.0f, 0.0f ), Quaternion.identity );
                impalaNum = 1;
            }
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
                in_animals.IN_GIRAFFE = true;
                in_animals.IN_IMPALA = true;
                break;
            case environment.ENVIRONMENT.ROCKY:
                in_animals.IN_LION_ENVIRONMENT = true;
                in_animals.IN_ZEBRA = false;
                in_animals.IN_GIRAFFE = false;
                in_animals.IN_IMPALA = false;
                break;
            case environment.ENVIRONMENT.OTHER:
                in_animals.IN_LION_ENVIRONMENT = false;
                in_animals.IN_ZEBRA = false;
                in_animals.IN_GIRAFFE = false;
                in_animals.IN_IMPALA = false;
                break;
        }
    }

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
        Debug.Log( "inLion : " + in_animals.IN_LION );
        Debug.Log( "inZebra : " + in_animals.IN_ZEBRA );
        Debug.Log( "inGiraffe : " + in_animals.IN_GIRAFFE );
        Debug.Log( "inIMPALA : " + in_animals.IN_IMPALA );
        Debug.Log( "period : " + period );
        Debug.Log( "probability : " + LION._lion.predationProbability );
        Debug.Log( "canPredation : " + LION.canPredation );
        Debug.Log( "lionsNUM : " + LION.lionsNUM );
        Debug.Log( "lionsNum : " + GetNum.lionsNum );
        Debug.Log( "zebrasNUM : " + ZEBRA.zebrasNUM );
        Debug.Log( "zebrasNum : " + GetNum.zebrasNum );
        Debug.Log( "lionFightProbability : " + LION._lion.fightProbability );
        Debug.Log( "zebraInstallpro : " + zebrasNumProbability );
    }
}
