using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindItemType : MonoBehaviour
{
    private GameObject MapLevel;
    private GameObject nowItem;
    private GameObject[ ] itemsNum;
    private int nowMapLevel;
    void Start( )
    {
        MapLevel = GameObject.Find( "MapInfo" );
    }

    void Update( )
    {
        changeItemType( );
        nowMapLevel = MapLevel.GetComponent<MapLevel>( ).getMapLevel( );
    }

    private void changeItemType( )
    {
        switch ( this.gameObject.tag )
        {
            case "ZEBRAS":
                nowItem = GameObject.FindGameObjectWithTag( "Grass" );
                break;
            case "GIRAFFES":
                if ( nowMapLevel == 1 )
                {
                    nowItem = GameObject.FindGameObjectWithTag( "Wood" );
                }
                else if ( nowMapLevel == 2 )
                {
                    nowItem = GameObject.FindGameObjectWithTag( "Grassland" );
                }
                break;
            case "IMPALAS":
                nowItem = GameObject.FindGameObjectWithTag( "Grass" );
                itemsNum = GameObject.FindGameObjectsWithTag( "Grass" );
                break;
            case "BLUEWILDEBEESTS":
                nowItem = GameObject.FindGameObjectWithTag( "Grass" );
                break;
            case "WHITERHINOS":
                nowItem = GameObject.FindGameObjectWithTag( "Grass" ); ;
                itemsNum = GameObject.FindGameObjectsWithTag( "Grass" );
                break;
            case "SPOTTEDHYENAS":
                nowItem = GameObject.FindGameObjectWithTag( "Grassland" );
                break;
        }
    }

    public GameObject getItemType( )
    {
        return nowItem;
    }

    public int getItemsNum( )
    {
        return itemsNum.Length;
    }
}
