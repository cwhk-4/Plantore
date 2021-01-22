using UnityEngine;

public class SPOTTEDHYENA : MonoBehaviour
{
    public static AnimalsCollection.animalsSystem _spottedhyena = new AnimalsCollection.animalsSystem( );

    public static GameObject[ ] spottedhyena;
    public static int spottedhyenasNum;
    public static int findsNum;

    void Start()
    {
        
    }

    void Update()
    {
        numsProbability( );
        findNum( );
        getAnimalsType( );
    }

    private void findNum( )
    {
        findsNum = this.gameObject.GetComponent<GetNum>( ).getAnimalsNum( );
    }

    private void getAnimalsType( )
    {
        spottedhyena = this.gameObject.GetComponent<GetNum>( )._animals;
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
