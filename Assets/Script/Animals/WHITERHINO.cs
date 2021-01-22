using UnityEngine;

public class WHITERHINO : MonoBehaviour
{
    public static AnimalsCollection.animalsSystem _whiterhino = new AnimalsCollection.animalsSystem( );

    public static GameObject[ ] whiterhino;
    public static int whiterhinosNum;
    public static int findsNum;

    void Start()
    {
        
    }

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
        whiterhino = this.gameObject.GetComponent<GetNum>( )._animals;
    }

    void numsProbability( )
    {
        switch ( InstallAnimals.whiterhinosNumProbability )
        {
            case 0:
                _whiterhino.animalsNUM = 0;
                break;
            case 1:
                _whiterhino.animalsNUM = 1;
                break;
            case 2:
            case 3:
            case 4:
            case 5:
                _whiterhino.animalsNUM = 2;
                break;
            case 6:
            case 7:
            case 8:
            case 9:
            case 10:
                _whiterhino.animalsNUM = 3;
                break;
        }
    }

}
