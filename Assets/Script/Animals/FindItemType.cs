using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindItemType : MonoBehaviour
{
    [SerializeField]private GameObject nowItem;
    [SerializeField] private GameObject[ ] itemsNum;
    [SerializeField] private int nowMapLevel;
    void Start()
    {
        
    }

    void Update()
    {
        changeItemType( );
        nowMapLevel = GameObject.Find( "MapInfo" ).GetComponent<MapLevel>( ).getMapLevel( );
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
