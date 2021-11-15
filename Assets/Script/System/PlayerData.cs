using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private TimeController TimeController;
    [SerializeField] private MapLevel MapLevel;

    public float nowTime;
    public int mapLevel;

    private void Start( )
    {
        TimeController = GetComponent<TimeController>( );
    }

    public void getPlayerData( )
    {
        nowTime = TimeController.GetNowSec( ) - 1;
        mapLevel = MapLevel.getMapLevel( );
    }

    public void loadPlayerData( )
    {
        TimeController.loadNowSec( nowTime );
        MapLevel.loadMapLevel( mapLevel );
    }

    public void savePlayer( )
    {
        getPlayerData( );

        SaveSystem.savePlayer( this );

        Debug.Log( "Saved!" );
    }

    public void loadPlayer( )
    {
        SaveData data = SaveSystem.loadPlayer( );

        nowTime = data.nowTime;
        mapLevel = data.mapLevel;

        loadPlayerData( );
        Debug.Log( "Loaded!" );
    }
}
