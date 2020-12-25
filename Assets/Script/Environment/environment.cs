using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class environment : MonoBehaviour
{
    
    public struct IN_ENVIRONMENT
    {
        public string environmentType;
        public bool inGame;
    };
    public static IN_ENVIRONMENT in_environment = new IN_ENVIRONMENT( );

    public enum ENVIRONMENT
    {
        GRASSLAND,
        ROCKY,
        OTHER,
    };
    public static ENVIRONMENT _environment;

    void Start( )
    {
        _environment = ENVIRONMENT.OTHER;
    }

    void Update( )
    {
        environmentType( _environment );
        changeEnvironment( );
    }

    void environmentType( ENVIRONMENT _environment )
    {
        switch( _environment )
        {
            case ENVIRONMENT.GRASSLAND:
                in_environment.environmentType = "grassland";
                break;
            case ENVIRONMENT.ROCKY:
                in_environment.environmentType = "rocky";
                break;
            case ENVIRONMENT.OTHER:
                in_environment.environmentType = "OTHER";
                break;
        }
    }
    void changeEnvironment( )
    {
        if ( Input.GetKeyDown( KeyCode.Q ) )
        {
            _environment = ENVIRONMENT.GRASSLAND;
        }
        if ( Input.GetKeyDown( KeyCode.W ) )
        {
            _environment = ENVIRONMENT.ROCKY;
        }
        if ( Input.GetKeyDown( KeyCode.P ) )
        {
            _environment = ENVIRONMENT.OTHER;
        }
    }
}
