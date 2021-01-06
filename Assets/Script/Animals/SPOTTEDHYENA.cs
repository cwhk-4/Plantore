using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPOTTEDHYENA : MonoBehaviour
{
    public static animalsCollection.animalsSystem _spottedhyena = new animalsCollection.animalsSystem( );
    void Start()
    {
        
    }

    void Update()
    {
        numsProbability( );
    }

    void numsProbability( )
    {
        switch( InstallAnimals.spottedhyenasNumProbability )
        {
            case 0:
                _spottedhyena.animalsNUM = 0;
                break;
            case 1:
                _spottedhyena.animalsNUM = 1;
                break;
            case 2:
                _spottedhyena.animalsNUM = 2;
                break;
            case 3:
            case 4:
                _spottedhyena.animalsNUM = 3;
                break;
            case 5:
            case 6:
                _spottedhyena.animalsNUM = 4;
                break;
            case 7:
            case 8:
                _spottedhyena.animalsNUM = 5;
                break;
            case 9:
            case 10:
                _spottedhyena.animalsNUM = 6;
                break;
        }
    }
}
