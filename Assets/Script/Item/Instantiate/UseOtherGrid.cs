using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UseOtherGrid : MonoBehaviour
{
    [SerializeField] private string thisGOName;
    private static string nowGridName;
    private string otherGridName;
    private string oldOtherGridName = null;

    private string tempGridName;
    private int placeToChange;
    private char originalNum;
    private char changeToNum;

    private void Update( )
    {
        if( nowGridName != null )
        {
            itemIdentify( );
            GameObject.Find( oldOtherGridName ).GetComponent<ItemStorage>( ).closeAvailability( );
            GameObject.Find( otherGridName ).GetComponent<ItemStorage>( ).showAvailability( );
        }
        else
        {
            stopAvailability( );
        }
    }

    private void itemIdentify( )
    {
        tempGridName = nowGridName;

        switch( thisGOName )
        {
            case "Wood":
                placeToChange = 3;
                originalNum = tempGridName[placeToChange];
                Debug.Log( originalNum );
                changeToNum = ( char )( originalNum + 1 );
                Debug.Log( changeToNum );
                break;

            default:
                break;
        }

        var temp = tempGridName.ToCharArray( );
        temp[placeToChange] = changeToNum;

        if( temp.ToString() != otherGridName )
        {
            oldOtherGridName = otherGridName;
        }

        otherGridName = new string( temp );
    }

    public static void setNowOnGrid( string gridName )
    {
        nowGridName = gridName;
    }

    private void stopAvailability( )
    { 
        GameObject.Find( oldOtherGridName ).GetComponent<ItemStorage>( ).closeAvailability( );
        GameObject.Find( otherGridName ).GetComponent<ItemStorage>( ).closeAvailability( );
    }

    public string getOtherGridName( )
    {
        return otherGridName;
    }

    private void OnDestroy( )
    {
        stopAvailability( );
    }
}
