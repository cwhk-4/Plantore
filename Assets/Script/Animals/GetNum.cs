using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetNum : MonoBehaviour
{
    public static GameObject[ ] ala;

    public static int lionsNum;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        getLionsNum( );
    }

    void getLionsNum( )
    {
        ala = GameObject.FindGameObjectsWithTag( "lion" );
        Debug.Log( "ala.length : " + ala.Length );

        lionsNum = ala.Length;
    }
}
