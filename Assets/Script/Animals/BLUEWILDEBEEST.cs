using UnityEngine;

public class BLUEWILDEBEEST : MonoBehaviour
{
    public static AnimalsCollection.animalsSystem _bluewildebeest = new AnimalsCollection.animalsSystem( );

    public static GameObject[ ] bluewildebeest;
    public static int bluewildebeestsNum;
    public static int findsNum;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        findNum( );
        getAnimalsType( );
        numsProbability( );
    }

    private void findNum( )
    {
        findsNum = this.gameObject.GetComponent<GetNum>( ).getAnimalsNum( );
    }

    private void getAnimalsType( )
    {
        bluewildebeest = this.gameObject.GetComponent<GetNum>( )._animals;
    }

    void numsProbability( )
    {
        switch ( InstallAnimals.whiterhinosNumProbability )
        {
            case 0:
                _bluewildebeest.animalsNUM = 0;
                break;
            case 1:
                _bluewildebeest.animalsNUM = 1;
                break;
            case 2:
                _bluewildebeest.animalsNUM = 2;
                break;
            case 3:
                _bluewildebeest.animalsNUM = 3;
                break;
            case 4:
            case 5:
                _bluewildebeest.animalsNUM = 4;
                break;
            case 6:
            case 7:
            case 8:
            case 9:
            case 10:
                _bluewildebeest.animalsNUM = 5;
                break;
        }
    }

}
