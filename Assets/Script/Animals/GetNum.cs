using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetNum : MonoBehaviour
{
    public static GameObject[ ] _lion;
    public static GameObject[ ] _zebra;
    public static GameObject[ ] _giraffe;
    public static GameObject[ ] _impala;
    public static GameObject[ ] _spottedhyena;
    public static GameObject[ ] _africanwilddog;
    public static GameObject[ ] _bluewildebeest;
    public static GameObject[ ] _whiterhino;

    public static GameObject[ ] _grass;

    public static int lionsNum;
    public static int zebrasNum;
    public static int giraffesNum;
    public static int impalasNum;
    public static int spottedhyenasNum;
    public static int africanwilddogsNum;
    public static int bluewildebeestsNum;
    public static int whiterhinosNum;

    public static int grassNum;

    void Start( )
    {

    }

    void Update( )
    {
        getLionsNum( );
        getZebrasNum( );
        getGiraffeNum( );
        getImaplaNum( );
        getSpottedhyenaNum( );
        getAfricanwilddogNum( );
        getBluewildebeestNum( );
        getWhiterhinoNum( );

        getGrassNum( );
    }

    void getLionsNum( )
    {
        _lion = GameObject.FindGameObjectsWithTag( "lion" );
        lionsNum = _lion.Length;  
    }
    void getZebrasNum( )
    {
        _zebra = GameObject.FindGameObjectsWithTag( "zebra" );
        zebrasNum = _zebra.Length;
    }

    void getGiraffeNum( )
    {
        _giraffe = GameObject.FindGameObjectsWithTag( "giraffe" );
        giraffesNum = _giraffe.Length;
    }

    void getImaplaNum( )
    {
        _impala = GameObject.FindGameObjectsWithTag( "impala" );
        impalasNum = _impala.Length;
    }

    void getSpottedhyenaNum( )
    {
        _spottedhyena = GameObject.FindGameObjectsWithTag( "spottedhyena" );
        spottedhyenasNum = _spottedhyena.Length;
    }

    void getAfricanwilddogNum( )
    {
        _africanwilddog = GameObject.FindGameObjectsWithTag( "africanwilddog" );
        africanwilddogsNum = _africanwilddog.Length;
    }

    void getBluewildebeestNum( )
    {
        _bluewildebeest = GameObject.FindGameObjectsWithTag( "bluewildebeest" );
        bluewildebeestsNum = _bluewildebeest.Length;
    }

    void getWhiterhinoNum( )
    {
        _whiterhino = GameObject.FindGameObjectsWithTag( "whiterhino" );
        whiterhinosNum = _whiterhino.Length;
    }


    void getGrassNum( )
    {
        _grass = GameObject.FindGameObjectsWithTag( "Grass" );
        grassNum = _grass.Length;
    }

}
