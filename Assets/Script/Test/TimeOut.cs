using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TimeOut: MonoBehaviour
{
    public int TotalTime = 60;

    void Start( )
    {
        StartCoroutine( Time( ) );
    }

    IEnumerator Time( )
    {
        while ( TotalTime >= 0 )
        {
            yield return new WaitForSeconds( 1 );
            TotalTime--;
        }
    }

    void Update( )
    {
        //Debug.Log( TotalTime );
        if ( TotalTime == 0 )
        {
            Debug.Log( "game over" );
        }
    }
}