using UnityEngine;

public class AFRICANWILDDOG : MonoBehaviour
{
    public static AnimalsCollection.animalsSystem _africanwilddog = new AnimalsCollection.animalsSystem( );

    public static GameObject[ ] africanwilddog;
    public static int africanwilddogsNum;
    public static int findsNum;

    void Start( )
    {
        
    }

    void Update( )
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
        africanwilddog = this.gameObject.GetComponent<GetNum>( )._animals;
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
