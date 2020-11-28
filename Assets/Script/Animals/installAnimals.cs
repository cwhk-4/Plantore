using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class installAnimals : MonoBehaviour
{
    public GameObject lion;
    public GameObject zebra;
    private int zebra_num = 3;

    public static int predationProbability;

    public struct Animals
    {
        public bool IN_LION;
        public bool IN_ZEBRA;
    };
    public static Animals in_animals = new Animals( );

    void Start( )
    {
        
    }

    void Update( )
    {
        environmentAndanimalsType( environment._environment );
        animalsInstall( );
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
                //caution
                //if ( timeController.canInstallZebra )
                //{
                //    Instantiate( zebra, new Vector3( 20.0f, 0.0f, 0.0f ), Quaternion.identity );
                //    zebra_num++;
                //}
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
    void environmentAndanimalsType ( environment.ENVIRONMENT _environment )
    {
        switch( _environment )
        {
            case environment.ENVIRONMENT.GRASSLAND:
                in_animals.IN_LION = true;
                in_animals.IN_ZEBRA = true;
                break;
            case environment.ENVIRONMENT.ROCKY:
                in_animals.IN_LION = true;
                in_animals.IN_ZEBRA = false;
                break;
            case environment.ENVIRONMENT.OTHER:
                in_animals.IN_LION = false;
                in_animals.IN_ZEBRA = false;
                break;
        }
    }
}
