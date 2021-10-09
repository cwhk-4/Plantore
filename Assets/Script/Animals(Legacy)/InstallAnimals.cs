using UnityEngine;

public class InstallAnimals : MonoBehaviour
{
    //[SerializeField] private int nowMapLevel;
    //public GameObject MapLevel;
    //public GameObject System;
    //
    GameObject[ ] lion;
    public static GameObject lionObj;
    GameObject zebra;
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
    GameObject[ ] hippo;
    public static GameObject hippoObj;

    public static int lionsNumProbability;
    public static int zebrasNumProbability;
    public static int giraffesNumProbability;
    public static int impalasNumProbability;
    public static int spottedhyenasNumProbability;
    public static int africanwilddogsNumProbability;
    public static int bluewildebeestsNumProbability;
    public static int whiterhinosNumProbability;
    public static int hipposNumProbability;

    private bool changedPosition = false;
    //

    private int period;

    public struct Animals
    {
        public bool in_lion_environment;
        public bool in_spottedhyena_environment;
        public bool in_africanwilddog_environment;
        public bool in_whiterhino_environment;
        public bool in_hippo_environment;

        public bool in_lion_period;
        public bool in_spottedhyena_period;
        public bool in_africanwilddog_period;
        public bool in_whiterhino_period;
        public bool in_hippo_period;

        public bool in_lion;
        public bool in_zebra;
        public bool in_giraffe;
        public bool in_impala;
        public bool in_spottedhyena;
        public bool in_africanwilddog;
        public bool in_whiterhino;
        public bool in_bluewildebeest;
        public bool in_hippo;
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
        hippoObj = Resources.Load( "Animal/Prefabs/hippo" ) as GameObject;
    }

    void Update( )
    {
        //nowMapLevel = MapLevel.GetComponent<MapLevel>( ).getMapLevel( );
        //period = System.GetComponent<TimeController>( ).getNowGamePeriod( );

        environmentAnimalsType( environment._environment );
        periodAnimalsType( );
        animalsType( );
        animalsInstall( );
        //
        if ( !changedPosition )
        {
            impalasPosition( );
            africanwilddogsPosition( );
            spottedhyenasPosition( );
            whiterhinosPosition( );
            bluewildebeestsPosition( );
            hippoPosition( );
            changedPosition = true;
        }
    }

    void animalsInstall( )
    {
        ////LION
        //if ( environment.nowLevel == 1 )
        //{
        //    //if ( lion == null )
        //    //{
        //    //    if ( LION.findsNum < LION.lionsNUM )
        //    //    {
        //    //        for ( int i = 0; i < LION.lionsNUM; i++ )
        //    //        {
        //    //            Instantiate( lionObj, new Vector3( -8.0f, 8.0f , 0.0f ), Quaternion.identity );
        //    //            lion = GameObject.FindGameObjectsWithTag( "lion" );
        //    //            lion[ i ].name = "lion" + i;
        //    //            lion[ i ].transform.parent = GameObject.Find( "LIONS" ).transform;
        //    //        }
        //    //    }
        //    //}

        //    //ZEBRA

        //    //if ( zebra == null )
        //    //{
        //    //    if ( ZEBRA.findsNum < ZEBRA.zebrasNUM )
        //    //    {
        //    //        for ( int i = 0; i < ZEBRA.zebrasNUM; i++ )
        //    //        {
        //    //            Instantiate( zebraObj, new Vector3( 0.5f, 9.7f, 0.0f ), Quaternion.identity, "LIONS" );
        //    //            zebra = GameObject.FindGameObjectsWithTag( "zebra" );
        //    //            zebra[ i ].name = "zebra" + i;
        //    //            zebra[ i ].transform.parent = GameObject.Find( "ZEBRAS" ).transform;
        //    //        }
        //    //    }
        //    //}

        //    //GIRAFFE
        //    if ( giraffe == null )
        //    {
        //        if ( GIRAFFE.findsNum < GIRAFFE.giraffesNUM )
        //        {
        //            for ( int i = 0; i < GIRAFFE.giraffesNUM; i++ )
        //            {
        //                Instantiate( giraffeObj, new Vector3( 4.5f+ 1 * i , 8.0f + 2.4f * i, 0.0f ), Quaternion.identity );
        //                giraffe = GameObject.FindGameObjectsWithTag( "giraffe" );
        //                giraffe[ i ].name = "giraffe" + i;
        //                giraffe[ i ].transform.parent = GameObject.FindGameObjectWithTag( "GIRAFFES" ).transform;
        //            }
        //        }
        //    }

        //    //IMPALA
        //    if ( impala == null )
        //    {
        //        if ( IMPALA.findsNum < IMPALA.impalasNUM )
        //        {
        //            for ( int i = 0; i < IMPALA.impalasNUM; i++ )
        //            {
        //                Instantiate( impalaObj, new Vector3( 10.0f, 10.0f, 0.0f ), Quaternion.identity );
        //                impala = GameObject.FindGameObjectsWithTag( "impala" );
        //                impala[ i ].name = "impala" + i;
        //                impala[ i ].transform.parent = GameObject.FindGameObjectWithTag( "IMPALAS" ).transform;
        //            }
        //        }
        //    }
        //}

        //if ( nowMapLevel == 1 )
        //{
        //    //SPOTTEDHYENA
        //    if ( spottedhyena == null )
        //    {
        //        if ( SPOTTEDHYENA.spottedhyenasNum < SPOTTEDHYENA._spottedhyena.animalsNUM )
        //        {
        //            for ( int i = 0; i < SPOTTEDHYENA._spottedhyena.animalsNUM; i++ )
        //            {
        //                Instantiate( spottedhyenaObj, new Vector3( -8.0f, 16.0f, 0.0f ), Quaternion.identity );
        //                spottedhyena = GameObject.FindGameObjectsWithTag( "spottedhyena" );
        //                spottedhyena[ i ].name = "spottedhyena" + i;
        //                spottedhyena[ i ].transform.parent = GameObject.FindGameObjectWithTag( "SPOTTEDHYENAS" ).transform;
        //            }
        //        }
        //    }

        //    //AFRICANWILDDOG
        //    if ( africanwilddog == null )
        //    {
        //        if ( AFRICANWILDDOG.africanwilddogsNum < AFRICANWILDDOG._africanwilddog.animalsNUM )
        //        {
        //            for ( int i = 0; i < AFRICANWILDDOG._africanwilddog.animalsNUM; i++ )
        //            {
        //                Instantiate( africanwilddogObj, new Vector3( -1.5f, 16.0f, 0.0f ), Quaternion.identity );
        //                africanwilddog = GameObject.FindGameObjectsWithTag( "africanwilddog" );
        //                africanwilddog[ i ].name = "africanwilddog" + i;
        //                africanwilddog[ i ].transform.parent = GameObject.FindGameObjectWithTag( "AFRICANWILDDOGS" ).transform;
        //            }
        //        }
        //    }

        //    //BLUEWILDEBEEST
        //    if ( bluewildebeest == null )
        //    {
        //        if ( BLUEWILDEBEEST.bluewildebeestsNum < BLUEWILDEBEEST._bluewildebeest.animalsNUM )
        //        {
        //            for ( int i = 0; i < BLUEWILDEBEEST._bluewildebeest.animalsNUM; i++ )
        //            {
        //                Instantiate( bluewildebeestObj, new Vector3( 3.25f, 16.0f, 0.0f ), Quaternion.identity );
        //                bluewildebeest = GameObject.FindGameObjectsWithTag( "bluewildebeest" );
        //                bluewildebeest[ i ].name = "bluewildebeest" + i;
        //                bluewildebeest[ i ].transform.parent = GameObject.FindGameObjectWithTag( "BLUEWILDEBEESTS" ).transform;
        //            }
        //        }
        //    }

        //    //WHITERHINO
        //    if ( whiterhino == null )
        //    {
        //        if ( WHITERHINO.whiterhinosNum < WHITERHINO._whiterhino.animalsNUM )
        //        {
        //            for ( int i = 0; i < WHITERHINO._whiterhino.animalsNUM; i++ )
        //            {
        //                Instantiate( whiterhinoObj, new Vector3( 7.0f, 16.0f, 0.0f ), Quaternion.identity );
        //                whiterhino = GameObject.FindGameObjectsWithTag( "whiterhino" );
        //                whiterhino[ i ].name = "whiterhino" + i;
        //                whiterhino[ i ].transform.parent = GameObject.FindGameObjectWithTag( "WHITERHINOS" ).transform;
        //            }
        //        }
        //    }

        //    //HIPPO
        //    if ( hippo == null )
        //    {
        //        if ( HIPPO.hipposNum < HIPPO._hippo.animalsNUM )
        //        {
        //            for ( int i = 0; i < HIPPO._hippo.animalsNUM; i++ )
        //            {
        //                Instantiate( hippoObj, new Vector3( 7.0f, 16.0f, 0.0f ), Quaternion.identity );
        //                hippo = GameObject.FindGameObjectsWithTag( "hippo" );
        //                hippo[ i ].name = "hippo" + i;
        //                hippo[ i ].transform.parent = GameObject.FindGameObjectWithTag( "HIPPOS" ).transform;
        //            }
        //        }
        //    }
        //}
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
                in_animals.in_spottedhyena_environment = true;
                in_animals.in_bluewildebeest = true;
                in_animals.in_whiterhino_environment = true;
                in_animals.in_africanwilddog_environment = true;
                in_animals.in_spottedhyena_environment = true;
                in_animals.in_hippo_environment = true;
                break;
            case environment.ENVIRONMENT.ROCKY:
                in_animals.in_lion_environment = true;
                in_animals.in_zebra = true;
                in_animals.in_giraffe = true;
                in_animals.in_impala = true;
                in_animals.in_spottedhyena_environment = true;
                in_animals.in_bluewildebeest = true;
                in_animals.in_whiterhino_environment = true;
                in_animals.in_africanwilddog_environment = true;
                in_animals.in_spottedhyena_environment = true;
                in_animals.in_hippo_environment = true;
                break;
            case environment.ENVIRONMENT.OTHER:
                in_animals.in_lion_environment = true;
                in_animals.in_zebra = true;
                in_animals.in_giraffe = true;
                in_animals.in_impala = true;
                in_animals.in_spottedhyena_environment = true;
                in_animals.in_bluewildebeest = true;
                in_animals.in_whiterhino_environment = true;
                in_animals.in_africanwilddog_environment = true;
                in_animals.in_spottedhyena_environment = true;
                in_animals.in_hippo_environment = true;
                break;
        }
    }

    void periodAnimalsType( )
    {
        switch ( period )
        {
            case 1:
                in_animals.in_lion_period = true;
                in_animals.in_spottedhyena_period = true;
                in_animals.in_africanwilddog_period = false;
                in_animals.in_whiterhino_period = false;
                in_animals.in_hippo_period = true;
                break;
            case 2:
                in_animals.in_lion_period = false;
                in_animals.in_spottedhyena_period = false;
                in_animals.in_africanwilddog_period = true;
                in_animals.in_whiterhino_period = true;
                in_animals.in_hippo_period = true;
                break;
            case 3:
                in_animals.in_lion_period = true;
                in_animals.in_spottedhyena_period = false;
                in_animals.in_africanwilddog_period = true;
                in_animals.in_whiterhino_period = true;
                in_animals.in_hippo_period = true;
                break;
            case 4:
                in_animals.in_lion_period = false;
                in_animals.in_spottedhyena_period = true;
                in_animals.in_africanwilddog_period = true;
                in_animals.in_whiterhino_period = false;
                in_animals.in_hippo_period = true;
                break;
            case 5:
                in_animals.in_lion_period = false;
                in_animals.in_spottedhyena_period = false;
                in_animals.in_africanwilddog_period = false;
                in_animals.in_whiterhino_period = true;
                in_animals.in_hippo_period = true;
                break;
            case 6:
                in_animals.in_lion_period = false;
                in_animals.in_spottedhyena_period = true;
                in_animals.in_africanwilddog_period = false;
                in_animals.in_whiterhino_period = false;
                in_animals.in_hippo_period = true;
                break;
        }
    }

    void animalsType( )
    {
        if ( in_animals.in_lion_environment && in_animals.in_lion_period )
        {
            in_animals.in_lion = true;
        }
        if ( in_animals.in_spottedhyena_environment && in_animals.in_spottedhyena_period )
        {
            in_animals.in_spottedhyena = true;
        }
        if ( in_animals.in_africanwilddog_environment && in_animals.in_africanwilddog_period )
        {
            in_animals.in_africanwilddog = true;
        }
        if ( in_animals.in_whiterhino_environment && in_animals.in_whiterhino_period )
        {
            in_animals.in_whiterhino = true;
        }
        if ( in_animals.in_hippo_environment && in_animals.in_hippo_period )
        {
            in_animals.in_hippo = true;
        }
    }

    //private void lionsPosition( )
    //{
    //    if ( LION.lionsNUM == 1 )
    //    {
    //        lion[ 0 ].transform.position = new Vector3( -5.0f, 10.4f, 0.0f );
    //    }
    //    if ( LION.lionsNUM == 2 )
    //    {
    //        lion[ 0 ].transform.position = new Vector3( -5.0f, 10.4f, 0.0f );
    //        lion[ 1 ].transform.position = new Vector3( -3.0f, 7.5f, 0.0f );
    //    }
    //    if ( LION.lionsNUM == 3 )
    //    {
    //        lion[ 0 ].transform.position = new Vector3( -5.0f, 10.4f, 0.0f );
    //        lion[ 1 ].transform.position = new Vector3( -3.0f, 7.5f, 0.0f );
    //        lion[ 2 ].transform.position = new Vector3( -7.0f, 6.5f, 0.0f );
    //    }
    //    if ( LION.lionsNUM == 4 )
    //    {
    //        lion[ 0 ].transform.position = new Vector3( -5.0f, 10.4f, 0.0f );
    //        lion[ 1 ].transform.position = new Vector3( -3.0f, 7.5f, 0.0f );
    //        lion[ 2 ].transform.position = new Vector3( -7.0f, 6.5f, 0.0f );
    //        lion[ 3 ].transform.position = new Vector3( -6.0f, 8.5f, 0.0f );
    //    }
    //}
    //private void zebrasPosition( )
    //{
    //    if ( ZEBRA.zebrasNUM == 1 )
    //    {
    //        zebra[ 0 ].transform.position = new Vector3( 1.5f, 7.5f, 0.0f );
    //    }
    //    if ( ZEBRA.zebrasNUM == 2 )
    //    {
    //        zebra[ 0 ].transform.position = new Vector3( 1.5f, 7.5f, 0.0f );
    //        zebra[ 1 ].transform.position = new Vector3( -0.5f, 9.2f, 0.0f );
    //    }
    //    if ( ZEBRA.zebrasNUM == 3 )
    //    {
    //        zebra[ 0 ].transform.position = new Vector3( 1.5f, 7.5f, 0.0f );
    //        zebra[ 1 ].transform.position = new Vector3( -0.5f, 9.2f, 0.0f );
    //        zebra[ 2 ].transform.position = new Vector3( 2.5f, 9.7f, 0.0f );
    //    }
    //}
    private void impalasPosition( )
    {
        if ( IMPALA.impalasNUM == 1 )
        {
            impala[ 0 ].transform.position = new Vector3( 10.0f, 10f, 0.0f );
        }
        if ( IMPALA.impalasNUM == 2 )
        {
            impala[ 0 ].transform.position = new Vector3( 10.0f, 10f, 0.0f );
            impala[ 1 ].transform.position = new Vector3( 11.5f, 7.0f, 0.0f );
        }
        if ( IMPALA.impalasNUM == 3 )
        {
            impala[ 0 ].transform.position = new Vector3( 10.0f, 10f, 0.0f );
            impala[ 1 ].transform.position = new Vector3( 11.5f, 7.0f, 0.0f );
            impala[ 2 ].transform.position = new Vector3( 8.0f, 6.5f, 0.0f );
        }
        if ( IMPALA.impalasNUM == 4 )
        {
            impala[ 0 ].transform.position = new Vector3( 10.0f, 10f, 0.0f );
            impala[ 1 ].transform.position = new Vector3( 11.5f, 7.0f, 0.0f );
            impala[ 2 ].transform.position = new Vector3( 8.0f, 6.5f, 0.0f );
            impala[ 3 ].transform.position = new Vector3( 9.0f, 8.2f, 0.0f );
        }
    }
    private void africanwilddogsPosition( )
    {
        if ( AFRICANWILDDOG._africanwilddog.animalsNUM == 1 )
        {
            africanwilddog[ 0 ].transform.position = new Vector3( -1.5f, 16f, 0.0f );
        }
        if ( AFRICANWILDDOG._africanwilddog.animalsNUM == 2 )
        {
            africanwilddog[ 0 ].transform.position = new Vector3( -1.5f, 16f, 0.0f );
            africanwilddog[ 1 ].transform.position = new Vector3( -3.5f, 16f, 0.0f );
        }
        if ( AFRICANWILDDOG._africanwilddog.animalsNUM == 3 )
        {
            africanwilddog[ 0 ].transform.position = new Vector3( -1.5f, 16f, 0.0f );
            africanwilddog[ 1 ].transform.position = new Vector3( -3.5f, 16f, 0.0f );
            africanwilddog[ 2 ].transform.position = new Vector3( -1.5f, 14.0f, 0.0f );
        }
        if ( AFRICANWILDDOG._africanwilddog.animalsNUM == 4 )
        {
            africanwilddog[ 0 ].transform.position = new Vector3( -1.5f, 16f, 0.0f );
            africanwilddog[ 1 ].transform.position = new Vector3( -3.5f, 16f, 0.0f );
            africanwilddog[ 2 ].transform.position = new Vector3( -1.5f, 14.0f, 0.0f );
            africanwilddog[ 3 ].transform.position = new Vector3( -4.0f, 14.0f, 0.0f );
        }
        if ( AFRICANWILDDOG._africanwilddog.animalsNUM == 5 )
        {
            africanwilddog[ 0 ].transform.position = new Vector3( -1.5f, 16f, 0.0f );
            africanwilddog[ 1 ].transform.position = new Vector3( -3.5f, 16f, 0.0f );
            africanwilddog[ 2 ].transform.position = new Vector3( -1.5f, 14.0f, 0.0f );
            africanwilddog[ 3 ].transform.position = new Vector3( -4.0f, 14.0f, 0.0f );
            africanwilddog[ 4 ].transform.position = new Vector3( -2.5f, 13.0f, 0.0f );
        }
    }
    //-8 16
    private void spottedhyenasPosition( )
    {
        if ( SPOTTEDHYENA._spottedhyena.animalsNUM == 1 )
        {
            spottedhyena[ 0 ].transform.position = new Vector3( -10.0f, 16f, 0.0f );
        }
        if ( SPOTTEDHYENA._spottedhyena.animalsNUM == 2 )
        {
            spottedhyena[ 0 ].transform.position = new Vector3( -10.0f, 16f, 0.0f );
            spottedhyena[ 1 ].transform.position = new Vector3( -8.0f, 14.7f, 0.0f );
        }
        if ( SPOTTEDHYENA._spottedhyena.animalsNUM == 3 )
        {
            spottedhyena[ 0 ].transform.position = new Vector3( -10.0f, 16f, 0.0f );
            spottedhyena[ 1 ].transform.position = new Vector3( -8.0f, 14.7f, 0.0f );
            spottedhyena[ 2 ].transform.position = new Vector3( -8.5f, 13.3f, 0.0f );
        }
        if ( SPOTTEDHYENA._spottedhyena.animalsNUM == 4 )
        {
            spottedhyena[ 0 ].transform.position = new Vector3( -10.0f, 16f, 0.0f );
            spottedhyena[ 1 ].transform.position = new Vector3( -8.0f, 14.7f, 0.0f );
            spottedhyena[ 2 ].transform.position = new Vector3( -8.5f, 13.3f, 0.0f );
            spottedhyena[ 3 ].transform.position = new Vector3( -10.2f, 14.0f, 0.0f );
        }
        if ( SPOTTEDHYENA._spottedhyena.animalsNUM == 5 )
        {
            spottedhyena[ 0 ].transform.position = new Vector3( -10.0f, 16f, 0.0f );
            spottedhyena[ 1 ].transform.position = new Vector3( -8.0f, 14.7f, 0.0f );
            spottedhyena[ 2 ].transform.position = new Vector3( -8.5f, 13.3f, 0.0f );
            spottedhyena[ 3 ].transform.position = new Vector3( -10.2f, 14.0f, 0.0f );
            spottedhyena[ 4 ].transform.position = new Vector3( -7.6f, 16.0f, 0.0f );
        }
        if ( SPOTTEDHYENA._spottedhyena.animalsNUM == 6 )
        {
            spottedhyena[ 0 ].transform.position = new Vector3( -10.0f, 16f, 0.0f );
            spottedhyena[ 1 ].transform.position = new Vector3( -8.0f, 14.7f, 0.0f );
            spottedhyena[ 2 ].transform.position = new Vector3( -8.5f, 13.3f, 0.0f );
            spottedhyena[ 3 ].transform.position = new Vector3( -10.2f, 14.0f, 0.0f );
            spottedhyena[ 4 ].transform.position = new Vector3( -7.6f, 16.0f, 0.0f );
            spottedhyena[ 5 ].transform.position = new Vector3( -6.5f, 13.5f, 0.0f );
        }
    }
    //3 7 16
    private void whiterhinosPosition( )
    {
        if ( WHITERHINO._whiterhino.animalsNUM == 1 )
        {
            whiterhino[ 0 ].transform.position = new Vector3( 9.2f, 18.4f, 0.0f );
        }
        if ( WHITERHINO._whiterhino.animalsNUM == 2 )
        {
            whiterhino[ 0 ].transform.position = new Vector3( 9.2f, 18.4f, 0.0f );
            whiterhino[ 1 ].transform.position = new Vector3( 7.0f, 16.0f, 0.0f );
        }
        if ( WHITERHINO._whiterhino.animalsNUM == 3 )
        {
            whiterhino[ 0 ].transform.position = new Vector3( 9.2f, 18.4f, 0.0f );
            whiterhino[ 1 ].transform.position = new Vector3( 7.0f, 16.0f, 0.0f );
            whiterhino[ 2 ].transform.position = new Vector3( 11.15f, 15.3f, 0.0f );
        }
    }
    //5 3.25 16
    private void bluewildebeestsPosition( )
    {
        if ( BLUEWILDEBEEST._bluewildebeest.animalsNUM == 1 )
        {
            bluewildebeest[ 0 ].transform.position = new Vector3( 4.55f, 18.1f, 0.0f );
        }
        if ( BLUEWILDEBEEST._bluewildebeest.animalsNUM == 2 )
        {
            bluewildebeest[ 0 ].transform.position = new Vector3( 4.55f, 18.1f, 0.0f );
            bluewildebeest[ 1 ].transform.position = new Vector3( 2.1f, 17.0f, 0.0f );
        }
        if ( BLUEWILDEBEEST._bluewildebeest.animalsNUM == 3 )
        {
            bluewildebeest[ 0 ].transform.position = new Vector3( 4.55f, 18.1f, 0.0f );
            bluewildebeest[ 1 ].transform.position = new Vector3( 2.1f, 17.0f, 0.0f );
            bluewildebeest[ 2 ].transform.position = new Vector3( 0f, 19.6f, 0.0f );
        }
        if ( BLUEWILDEBEEST._bluewildebeest.animalsNUM == 4 )
        {
            bluewildebeest[ 0 ].transform.position = new Vector3( 4.55f, 18.1f, 0.0f );
            bluewildebeest[ 1 ].transform.position = new Vector3( 2.1f, 17.0f, 0.0f );
            bluewildebeest[ 2 ].transform.position = new Vector3( 0f, 19.6f, 0.0f );
            bluewildebeest[ 3 ].transform.position = new Vector3( 3.0f, 14.6f, 0.0f );
        }
        if ( BLUEWILDEBEEST._bluewildebeest.animalsNUM == 5 )
        {
            bluewildebeest[ 0 ].transform.position = new Vector3( 4.55f, 18.1f, 0.0f );
            bluewildebeest[ 1 ].transform.position = new Vector3( 2.1f, 17.0f, 0.0f );
            bluewildebeest[ 2 ].transform.position = new Vector3( 0f, 19.6f, 0.0f );
            bluewildebeest[ 3 ].transform.position = new Vector3( 3.0f, 14.6f, 0.0f );
            bluewildebeest[ 4 ].transform.position = new Vector3( 0.75f, 13.7f, 0.0f );
        }
    }
    //15, 14,4
    private void hippoPosition( )
    {
        if ( HIPPO._hippo.animalsNUM == 1 )
        {
            hippo[ 0 ].transform.position = new Vector3( 14.6f, 17.9f, 0.0f );
        }
        if ( HIPPO._hippo.animalsNUM == 2 )
        {
            hippo[ 0 ].transform.position = new Vector3( 14.6f, 17.9f, 0.0f );
            hippo[ 1 ].transform.position = new Vector3( 18.0f, 16.0f, 0.0f );
        }
    }
}
