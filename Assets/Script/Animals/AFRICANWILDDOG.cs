using UnityEngine;

public class AFRICANWILDDOG : MonoBehaviour
{
    public static AnimalsCollection.animalsSystem _africanwilddog = new AnimalsCollection.animalsSystem( );

    public static GameObject[ ] africanwilddog;
    public static int africanwilddogsNum;
    public static int findsNum;

    public GameObject TargetAnimals;
    private GameObject target;
    private Vector3 newPosition;
    private bool goPredation;
    private bool hunting = false;


    void Start( )
    {
        _africanwilddog.animals = this.gameObject;
        _africanwilddog.moveSpeed = 5.0f;
        _africanwilddog.startPredationProbability = 80;
        _africanwilddog.Minus = 5;
        _africanwilddog.canMove = false;
        _africanwilddog.canPredation = false;
        _africanwilddog.needTurn = false;
        _africanwilddog.predationProbability = Random.Range( 0, 11 );

        goPredation = true;
        target = GameObject.Find( "africanwilddogTarget" );
        newPosition = new Vector3( Random.Range( -10, 10 ), 12.0f, 0.0f );
    }

    void Update( )
    {
        timeIn( );
        numsProbability( );
        findNum( );
        getAnimalsType( );
        setTurnScale( );
        wilddogMove( );
        Debug.Log( hunting );
    }

    private void wilddogMove( )
    {
        if ( _africanwilddog.canMove )
        {
            this.gameObject.transform.position = Vector3.MoveTowards( this.gameObject.transform.position, target.transform.position, _africanwilddog.moveSpeed * Time.deltaTime );
            changeTarget( );
        }
    }

    private void changeTarget( )
    {
        if ( TargetAnimals.GetComponent<WHITERHINO>( ).getItem( ) )
        {
            if ( goPredation && TargetAnimals.GetComponent<WHITERHINO>( ).itemAndAnimalPosition( ) )
            {
                target.transform.position = WHITERHINO._whiterhino.animals.transform.position;
                Debug.Log( target.transform.position );
                wilddogPredationProbability( );
            }
            if ( this.gameObject.transform.position == WHITERHINO._whiterhino.animals.transform.position )
            {
                hunting = true;
                newPosition = new Vector3( Random.Range( -10, 10 ), 12.0f, 0.0f );
                target.transform.position = newPosition;
                Predation( );
                goPredation = false;
            }
            if ( this.gameObject.transform.position == newPosition && TargetAnimals.GetComponent<WHITERHINO>( ).itemAndAnimalPosition( ) )
            {
                goPredation = true;
                _africanwilddog.canMove = false;
            }
        }
        else if ( goPredation )
        {
            newPosition = new Vector3( Random.Range( -10, 10 ), 7.0f, 0.0f );
            target.transform.position = newPosition;
            goPredation = false;
        }
    }

    public void wilddogPredationProbability( )
    {
        _africanwilddog.predationProbability = Random.Range( 0, 100 );
        if ( _africanwilddog.predationProbability < ( _africanwilddog.startPredationProbability - ( 5 - findsNum ) * _africanwilddog.Minus ) )
        {
            _africanwilddog.canPredation = true;
        }
        else
        {
            _africanwilddog.canPredation = false;
        }
    }

    private void Predation( )
    {
        if ( !_africanwilddog.canPredation )
        {
            Destroy( africanwilddog[ findsNum - 1 ] );
        }
        else
        {
            Destroy( WHITERHINO.whiterhino[ WHITERHINO.findsNum - 1 ] );
        }
    }

    private void timeIn( )
    {
        if ( TargetAnimals.GetComponent<WHITERHINO>( ).getItem( ) )
        {
            if ( TargetAnimals.GetComponent<WHITERHINO>( ).itemAndAnimalPosition( ) && InstallAnimals.in_animals.in_africanwinddog )
            {
                _africanwilddog.canMove = true;
            }
        }
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

    void setTurnScale( )
    {
        if ( target.transform.position.x >= _africanwilddog.animals.transform.position.x )
        {
            _africanwilddog.needTurn = true;
        }
        else
        {
            _africanwilddog.needTurn = false;
        }
    }

    public bool huntingHappened( )
    {
        return hunting;
    }
}
