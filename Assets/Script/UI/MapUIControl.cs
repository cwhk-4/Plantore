using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapUIControl : MonoBehaviour
{
    public GameObject Map;
    public Transform camPos;

    [SerializeField]
    private const float Height = 10.8f;
    [SerializeField]
    private const float Width = 19.2f;

    public GameObject MapInfo;
    public MapLevel mapLevel;
    [SerializeField]
    private int level;

    public Vector3 Map1;
    public Vector3 Map2;
    public Vector3 Map3;
    public Vector3 Map4;

    public GameObject level1Block;
    public GameObject level2Block;
    public GameObject level3Block;

    void Start()
    {
        mapLevel = MapInfo.GetComponent<MapLevel>( );
        Map1 = camPos.position;
        Map2 = new Vector3(camPos.position.x, camPos.position.y + Height, camPos.position.z);
        Map3 = new Vector3(camPos.position.x + Width, camPos.position.y + Height, camPos.position.z);
        Map4 = new Vector3(camPos.position.x + Width, camPos.position.y, camPos.position.z);
        closeMap();
    }

    public void openMap()
    {
        Map.SetActive(true);
        mapBlocker( );
        Time.timeScale = 0;
    }

    public void closeMap()
    {
        Map.SetActive(false);
        Time.timeScale = 1;
    }

    public void jumpToMap1()
    {
        camPos.position = Map1;
        closeMap();
    }

    public void jumpToMap2()
    {
        camPos.position = Map2;
        closeMap();
    }

    public void jumpToMap3()
    {
        camPos.position = Map3;
        closeMap();
    }

    public void jumpToMap4()
    {
        camPos.position = Map4;
        closeMap();
    }

    private void mapBlocker()
    {
        level = mapLevel.getMapLevel( );

        mapBlockInit( );

        switch( level )
        {
            case 1:
                level1Block.SetActive( true );
                break;
            case 2:
                level2Block.SetActive( true );
                break;
            case 3:
                level3Block.SetActive( true );
                break;
            case 4:
                mapBlockInit( );
                break;
        }
    }

    private void mapBlockInit( )
    {
        level1Block.SetActive( false );
        level2Block.SetActive( false );
        level3Block.SetActive( false );
    }

}
