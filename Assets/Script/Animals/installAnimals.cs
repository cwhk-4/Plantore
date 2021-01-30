using UnityEngine;

public class InstallAnimals : MonoBehaviour
{
    [SerializeField] private int nowMapLevel;
    public GameObject MapLevel;
    public GameObject System;
    //
    GameObject[ ] lion;
    public static GameObject lionObj;
    GameObject[ ] zebra;
    public static GameObject zebraObj;
    GameObject[ ] giraffe;
    public static GameObject giraffeObj;
    GameObject[ ] impala;
    public static GameObject impalaObj;
    GameObject[ ] spottedhyena;
    public static GameObject spottedhyenaObj;
    GameObject[ ] africanwilddog;
    public static GameObject africanwilddogObj;
    GameObject[ ] bluewildebeest;
    public static GameObject bluewildebeestObj;
    GameObject[ ] whiterhino;
    public static GameObject whiterhinoObj;

    public static int lionsNumProbability;
    public static int zebrasNumProbability;
    public static int giraffesNumProbability;
    public static int impalasNumProbability;
    public static int spottedhyenasNumProbability;
    public static int africanwilddogsNumProbability;
    public static int bluewildebeestsNumProbability;
    public static int whiterhinosNumProbability;
    //

    private int period;

    public struct Animals
    {
        public bool in_lion_environment;

        public bool in_lion_period;

        public bool in_lion;
        public bool in_zebra;
        public bool in_giraffe;
        public bool in_impala;
        public bool in_spottedhyena;
        public bool in_africanwinddog;
        public bool in_whiterhino;
        public bool in_bluewildebeest;
    };
    public static Animals in_animals = new Animals( );

    void Start( )
    {
        //
        lionObj = Resources.Load( "Animal/Prefabs/lion" ) as GameObject;
        zebraObj = Resources.Load( "Animal/Prefabs/zebra" ) as GameObject;
        giraffeObj = Resources.Load( "Animal/Prefabs/giraffe" ) as GameObject;
        impalaObj = Resources.Load( "Animal/Prefabs/impala" ) as GameObject;
        spottedhyenaObj = Resources.Load( "Animal/Prefabs/spottedhyena" ) as GameObject;
        africanwilddogObj = Resources.Load( "Animal/Prefabs/africanwilddog" ) as GameObject;
        whiterhinoObj = Resources.Load( "Animal/Prefabs/whiterhino" ) as GameObject;
        bluewildebeestObj = Resources.Load( "Animal/Prefabs/bluewildebeest" ) as GameObject;

        //
        lionsNumProbability = Random.Range( 1, 21 );
        zebrasNumProbability = Random.Range( 1, 5 );
        giraffesNumProbability = Random.Range( 1, 3 );
        impalasNumProbability = Random.Range( 1, 11 );
        spottedhyenasNumProbability = Random.Range( 1, 11 );
        africanwilddogsNumProbability = Random.Range( 1, 11 );
        bluewildebeestsNumProbability = Random.Range( 1, 11 );
        whiterhinosNumProbability = Random.Range( 1, 11 );
    }

    void Update( )
    {
        nowMapLevel = MapLevel.GetComponent<MapLevel>( ).getMapLevel( );
        period = System.GetComponent<TimeController>( ).getNowGamePeriod( );

        environmentAnimalsType( environment._environment );
        periodAnimalsType( );
        animalsType( );
        animalsInstall( );
    }

    void animalsInstall( )
    {
        //LION
        if ( environment.nowLevel == 1 )
        {
            if ( lion == null )
            {
                if ( LION.findsNum < LION.lionsNUM )
                {
                    for ( int i = 0; i < LION.lionsNUM; i++ )
                    {
                        Instantiate( lionObj, new Vector3( -4.0f - i * 1.0f, 9.5f - i * 1.0f, 0.0f ), Quaternion.identity );
                        lion = GameObject.FindGameObjectsWithTag( "lion" );
                        lion[ i ].name = "lion" + i;
                        lion[ i ].transform.parent = GameObject.Find( "LIONS" ).transform;
                    }
                }
            }

            //ZEBRA

            if ( zebra == null )
            {
                if ( ZEBRA.findsNum < ZEBRA.zebrasNUM )
                {
                    for ( int i = 0; i < ZEBRA.zebrasNUM; i++ )
                    {
                        Instantiate( zebraObj, new Vector3( 0.5f - i * 1.0f, 9.7f - i * 1.0f, 0.0f ), Quaternion.identity );
                        zebra = GameObject.FindGameObjectsWithTag( "zebra" );
                        zebra[ i ].name = "zebra" + i;
                        zebra[ i ].transform.parent = GameObject.Find( "ZEBRAS" ).transform;
                    }
                }
            }

            //GIRAFFE
            if ( giraffe == null )
            {
                if ( GIRAFFE.findsNum < GIRAFFE.giraffesNUM )
                {
                    for ( int i = 0; i < GIRAFFE.giraffesNUM; i++ )
                    {
                        Instantiate( giraffeObj, new Vector3( 4.5f - i * 1.0f, 9.0f - i * 1.0f, 0.0f ), Quaternion.identity );
                        giraffe = GameObject.FindGameObjectsWithTag( "giraffe" );
                        giraffe[ i ].name = "giraffe" + i;
                        giraffe[ i ].transform.parent = GameObject.FindGameObjectWithTag( "GIRAFFES" ).transform;
                    }
                }
            }

            //IMPALA
            if ( impala == null )
            {
                if ( IMPALA.findsNum < IMPALA.impalasNUM )
                {
                    for ( int i = 0; i < IMPALA.impalasNUM; i++ )
                    {
                        Instantiate( impalaObj, new Vector3( 10.0f - i * 1.0f, 10.0f - i * 1.0f, 0.0f ), Quaternion.identity );
                        impala = GameObject.FindGameObjectsWithTag( "impala" );
                        impala[ i ].name = "impala" + i;
                        impala[ i ].transform.parent = GameObject.FindGameObjectWithTag( "IMPALAS" ).transform;
                    }
                }
            }
        }

        if ( nowMapLevel == 1 )
        {
            //SPOTTEDHYENA
            if ( spottedhyena == null )
            {
                if ( SPOTTEDHYENA.spottedhyenasNum < SPOTTEDHYENA._spottedhyena.animalsNUM )
                {
                    for ( int i = 0; i < SPOTTEDHYENA._spottedhyena.animalsNUM; i++ )
                    {
                        Instantiate( spottedhyenaObj, new Vector3( -8.0f - i * 1.0f, 16.0f - i * 1.0f, 0.0f ), Quaternion.identity );
                        spottedhyena = GameObject.FindGameObjectsWithTag( "spottedhyena" );
                        spottedhyena[ i ].name = "spottedhyena" + i;
                        spottedhyena[ i ].transform.parent = GameObject.FindGameObjectWithTag( "SPOTTEDHYENAS" ).transform;
                    }
                }
            }

            //AFRICANWILDDOG
            if ( africanwilddog == null )
            {
                if ( AFRICANWILDDOG.africanwilddogsNum < AFRICANWILDDOG._africanwilddog.animalsNUM )
                {
                    for ( int i = 0; i < AFRICANWILDDOG._africanwilddog.animalsNUM; i++ )
                    {
                        Instantiate( africanwilddogObj, new Vector3( -1.5f - i * 1.0f, 16.0f - i * 1.0f, 0.0f ), Quaternion.identity );
                        africanwilddog = GameObject.FindGameObjectsWithTag( "africanwilddog" );
                        africanwilddog[ i ].name = "africanwilddog" + i;
                        africanwilddog[ i ].transform.parent = GameObject.FindGameObjectWithTag( "AFRICANWILDDOGS" ).transform;
                    }
                }
            }

            //BLUEWILDEBEEST
            if ( bluewildebeest == null )
            {
                if ( BLUEWILDEBEEST.bluewildebeestsNum < BLUEWILDEBEEST._bluewildebeest.animalsNUM )
                {
                    for ( int i = 0; i < BLUEWILDEBEEST._bluewildebeest.animalsNUM; i++ )
                    {
                        Instantiate( bluewildebeestObj, new Vector3( 3.25f - i * 1.0f, 16.0f - i * 1.0f, 0.0f ), Quaternion.identity );
                        bluewildebeest = GameObject.FindGameObjectsWithTag( "bluewildebeest" );
                        bluewildebeest[ i ].name = "bluewildebeest" + i;
                        bluewildebeest[ i ].transform.parent = GameObject.FindGameObjectWithTag( "BLUEWILDEBEESTS" ).transform;
                    }
                }
            }

            //WHITERHINO
            if ( whiterhino == null )
            {
                if ( WHITERHINO.whiterhinosNum < WHITERHINO._whiterhino.animalsNUM )
                {
                    for ( int i = 0; i < WHITERHINO._whiterhino.animalsNUM; i++ )
                    {
                        Instantiate( whiterhinoObj, new Vector3( 7.0f - i * 1.0f, 16.0f - i * 1.0f, 0.0f ), Quaternion.identity );
                        whiterhino = GameObject.FindGameObjectsWithTag( "whiterhino" );
                        whiterhino[ i ].name = "whiterhino" + i;
                        whiterhino[ i ].transform.parent = GameObject.FindGameObjectWithTag( "WHITERHINOS" ).transform;
                    }
                }
            }
        }
    }



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
                in_animals.in_spottedhyena = true;
                in_animals.in_bluewildebeest = true;
                in_animals.in_whiterhino = true;
                in_animals.in_africanwinddog = true;
                in_animals.in_spottedhyena = true;
                break;
            case environment.ENVIRONMENT.ROCKY:
                in_animals.in_lion_environment = true;
                in_animals.in_zebra = false;
                in_animals.in_giraffe = false;
                in_animals.in_impala = false;
                in_animals.in_spottedhyena = true;
                in_animals.in_bluewildebeest = false;
                in_animals.in_whiterhino = false;
                in_animals.in_africanwinddog = false;
                in_animals.in_spottedhyena = true;
                break;
            case environment.ENVIRONMENT.OTHER:
                in_animals.in_lion_environment = false;
                in_animals.in_zebra = false;
                in_animals.in_giraffe = false;
                in_animals.in_impala = false;
                in_animals.in_spottedhyena = false;
                in_animals.in_bluewildebeest = false;
                in_animals.in_whiterhino = false;
                in_animals.in_africanwinddog = false;
                in_animals.in_spottedhyena = false;
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

}
