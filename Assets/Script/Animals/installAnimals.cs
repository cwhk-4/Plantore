using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstallAnimals : MonoBehaviour
{
    public GameObject impala;

    GameObject[ ] lion;
    public static GameObject lionObj;
    public static GameObject LIONS;
    GameObject[ ] zebra;
    public static GameObject zebraObj;
    public static GameObject ZEBRAS;
    GameObject[ ] giraffe;
    public static GameObject giraffeObj;
    public static GameObject GIRAFFES;

    public static int lionsNumProbability;
    public static int zebrasNumProbability;
    public static int giraffesNumProbability;

    private int period;

    //キリン仮確率

    public struct Animals
    {
        public bool in_lion_environment;

        public bool in_lion_period;

        public bool in_lion;
        public bool in_zebra;
        public bool in_giraffe;
        public bool in_impala;
    };
    public static Animals in_animals = new Animals( );

    void Start( )
    {
        lionObj = Resources.Load( "Animals/Prefabs/lion" ) as GameObject;
        LIONS = GameObject.Find( "LIONS" );
        zebraObj = Resources.Load( "Animals/Prefabs/zebra" ) as GameObject;
        ZEBRAS = GameObject.Find( "ZEBRAS" );
        giraffeObj = Resources.Load( "Animals/Prefabs/giraffe" ) as GameObject;
        GIRAFFES = GameObject.Find( "GIRAFFES" );

        //
        lionsNumProbability = Random.Range( 1, 21 );
        zebrasNumProbability = Random.Range( 1, 5 );
        giraffesNumProbability = Random.Range( 1, 3 );
    }

    void Update( )
    {
        period = GameObject.Find( "System" ).GetComponent<TimeController>( ).getNowGamePeriod( );

        environmentAnimalsType( environment._environment );
        periodAnimalsType( );
        animalsType( );
        animalsInstall( );
        debugText( );
        Debug.Log( giraffesNumProbability );
    }

    void animalsInstall( )
    {
        //LION
        
        if ( lion == null )
        {
            if ( GetNum.lionsNum < LION.lionsNUM )
            {
                for ( int i = 0; i < LION.lionsNUM; i++ )
                {
                    Instantiate( lionObj, new Vector3( -8.0f + i * 1.0f, 6.5f + i * 1.0f, 0.0f ), Quaternion.identity );
                    lion = GameObject.FindGameObjectsWithTag( "lion" );
                    lion[ i ].name = "lion" + i;
                    lion[ i ].transform.parent = GameObject.FindGameObjectWithTag( "LIONS" ).transform;
                }
            }
        }

        //ZEBRA

        if ( zebra == null )
        {
            if ( GetNum.zebrasNum < ZEBRA.zebrasNUM )
            {
                for ( int i = 0; i < ZEBRA.zebrasNUM; i++ )
                {
                    Instantiate( zebraObj, new Vector3( -1.5f + i * 1.0f, 6.7f + i * 1.0f, 0.0f ), Quaternion.identity );
                    zebra = GameObject.FindGameObjectsWithTag( "zebra" );
                    zebra[ i ].name = "zebra" + i;
                    zebra[ i ].transform.parent = GameObject.FindGameObjectWithTag( "ZEBRAS" ).transform;
                }
            }
        }

        //GIRAFFE
        if ( giraffe == null )
        {
            if ( GetNum.giraffesNum < GIRAFFE.giraffesNUM )
            {
                for ( int i = 0; i < GIRAFFE.giraffesNUM; i++ )
                {
                    Instantiate( giraffeObj, new Vector3( -1.5f + i * 1.0f, 6.7f + i * 1.0f, 0.0f ), Quaternion.identity );
                    giraffe = GameObject.FindGameObjectsWithTag( "giraffe" );
                    giraffe[ i ].name = "giraffe" + i;
                    giraffe[ i ].transform.parent = GameObject.FindGameObjectWithTag( "GIRAFFES" ).transform;
                }
            }
        }
    }

        //IMPALA
        //if ( ItemMovement._item && in_animals.IN_IMPALA )
        //{
        //    if ( impalaNum == 0 && GetNum.grassNum >= 3 )
        //    {
        //        Instantiate( impala, new Vector3( 15.0f, 8.0f, 0.0f ), Quaternion.identity );
        //        impalaNum = 1;
        //    }
        //}

    //環境と動物関係
    void environmentAnimalsType( environment.ENVIRONMENT _environment )
    {
        switch ( _environment )
        {
            case environment.ENVIRONMENT.GRASSLAND:
                in_animals.in_lion_environment = true;
                in_animals.in_zebra = true;
                in_animals.in_giraffe = true;
                in_animals.in_impala = true;
                break;
            case environment.ENVIRONMENT.ROCKY:
                in_animals.in_lion_environment = true;
                in_animals.in_zebra = false;
                in_animals.in_giraffe = false;
                in_animals.in_impala = false;
                break;
            case environment.ENVIRONMENT.OTHER:
                in_animals.in_lion_environment = false;
                in_animals.in_zebra = false;
                in_animals.in_giraffe = false;
                in_animals.in_impala = false;
                break;
        }
    }

    void periodAnimalsType( )
    {
        switch ( period )
        {
            case 1:
                in_animals.in_lion_period = true;
                break;
            case 2:
                in_animals.in_lion_period = false;
                break;
            case 3:
                in_animals.in_lion_period = true;
                break;
            case 4:
                in_animals.in_lion_period = false;
                break;
            case 5:
                in_animals.in_lion_period = false;
                break;
            case 6:
                in_animals.in_lion_period = false;
                break;
        }
    }

    void animalsType( )
    {
        if ( in_animals.in_lion_environment && in_animals.in_lion_period )
        {
            in_animals.in_lion = true;
        }
    }

    void debugText( )
    {
        
    }
}
