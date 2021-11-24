using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sky : MonoBehaviour
{
    [SerializeField] private MapLevel mapLevel;
    private int level;

    [SerializeField] private Vector3 level1Pos;
    [SerializeField] private Vector3 level2Pos;
    [SerializeField] private Vector3 level3Pos;
    [SerializeField] private Vector3 level4Pos;

    void Start()
    {
        level = mapLevel.GetMapLevel( );
        changeSkyScale( level );
    }

    private void Update( )
    {
        if( level != mapLevel.GetMapLevel( ) )
        {
            level = mapLevel.GetMapLevel( );
            changeSkyScale( level );
        }
    }

    public void changeSkyScale( int newLevel )
    {
        var newPos = level1Pos;

        switch( newLevel )
        {
            case 2:
                newPos = level2Pos;
                break;

            case 3:
                newPos = level3Pos;
                break;

            case 4:
                newPos = level4Pos;
                break;
        }

        transform.position = newPos;
    }
}

