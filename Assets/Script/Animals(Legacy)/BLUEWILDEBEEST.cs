using UnityEngine;

public class BLUEWILDEBEEST : MonoBehaviour
{
    public static AnimalsCollection.animalsSystem _bluewildebeest = new AnimalsCollection.animalsSystem( );

    public GameObject otherAnimals;
    private GameObject target;
    private GameObject item;
    private Vector3 newPosition;

    private bool canFindItem = true;
    private bool runaway = false;
    private bool onItem = false;

    public static GameObject[ ] bluewildebeest;
    public static int bluewildebeestsNum;
    public static int findsNum;

    void Start( )
    {
        _bluewildebeest.animals = this.gameObject;
        _bluewildebeest.moveSpeed = 4.0f;
        _bluewildebeest.canMove = false;
        _bluewildebeest.needTurn = false;

        otherAnimals = GameObject.Find( "WHITERHINOS" );
        target = GameObject.Find( "bluewildebeestTarget" );
        newPosition = new Vector3( 14.0f, Random.Range( -10, 12 ), 0.0f );
    }

    void Update()
    {
        timeIn( );
        findNum( );
        getAnimalsType( );
        numsProbability( );
        setTurnScale( );
        bluewildebeestMove( );
        item = this.gameObject.GetComponent<FindItemType>( ).getItemType( );
    }

    private void bluewildebeestMove( )
    {
        if ( _bluewildebeest.canMove )
        {
            _bluewildebeest.animals.transform.position = Vector3.MoveTowards( _bluewildebeest.animals.transform.position, target.transform.position, Time.deltaTime * _bluewildebeest.moveSpeed );
            changeTarget( );
        }
    }

    private void changeTarget( )
    {
        if ( item && !runaway )
        {
            target.transform.position = item.transform.position;
            canFindItem = true;
        }
        if ( item == null && canFindItem )
        {
            newPosition = new Vector3( 14.0f, Random.Range( -10, 12 ), 0.0f );
            target.transform.position = newPosition;
            canFindItem = false;
        }
        if ( this.gameObject.transform.position == SPOTTEDHYENA._spottedhyena.animals.transform.position )
        {
            newPosition = new Vector3( 14.0f, Random.Range( -10, 12 ), 0.0f );
            runaway = true;
            target.transform.position = newPosition;
        }
        if ( item == null && this.gameObject.transform.position == newPosition )
        {
            runaway = false;
            _bluewildebeest.canMove = false;
        }
    }

    private void timeIn( )
    {
        if ( otherAnimals.GetComponent<WHITERHINO>( ).itemAndAnimalPosition( ) && item && InstallAnimals.in_animals.in_bluewildebeest )
        {
            _bluewildebeest.canMove = true;
        }
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

    public bool itemAndAnimalPosition( )
    {
        if ( item )
        {
            if ( this.gameObject.transform.position == item.transform.position )
            {
                onItem = true;
            }
            else
            {
                onItem = false;
            }
        }
        return onItem;
    }

    private void setTurnScale( )
    {
        if ( target.transform.position.x >= _bluewildebeest.animals.transform.position.x )
        {
            _bluewildebeest.needTurn = true;
        }
        else
        {
            _bluewildebeest.needTurn = false;
        }
    }

    public GameObject getItem( )
    {
        return item;
    }
}
