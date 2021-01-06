using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AFRICANWILDDOG : MonoBehaviour
{
    public static animalsCollection.animalsSystem _africanwilddog = new animalsCollection.animalsSystem( );

    void Start( )
    {
        
    }

    void Update( )
    {
        numsProbability( );
    }

    void numsProbability( )
    {
        switch ( InstallAnimals.africanwilddogsNumProbability )
        {
            case 0:
                _africanwilddog.animalsNUM = 0;
                break;
            case 1:
                _africanwilddog.animalsNUM = 1;
                break;
            case 2:
            case 3:
                _africanwilddog.animalsNUM = 2;
                break;
            case 4:
            case 5:
                _africanwilddog.animalsNUM = 3;
                break;
            case 6:
            case 7:
                _africanwilddog.animalsNUM = 4;
                break;
            case 8:
            case 9:
            case 10:
                _africanwilddog.animalsNUM = 5;
                break;
        }
    }
}
