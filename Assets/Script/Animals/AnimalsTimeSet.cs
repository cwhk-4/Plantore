using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalsTimeSet : MonoBehaviour
{
    void Start( )
    {
        
    }

    void Update( )
    {
        
    }

    public float test( int a, float startTime)
    { 
        float timeOver = a - ( GameObject.Find( "System" ).GetComponent<TimeController>( ).getNowRealSec( ) - startTime) ;
        Debug.Log("startTime" +  startTime );
        return timeOver;
    }
}
