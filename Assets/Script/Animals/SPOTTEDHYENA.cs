using UnityEngine;

public class SPOTTEDHYENA : MonoBehaviour
{
    public static AnimalsCollection.animalsSystem _spottedhyena = new AnimalsCollection.animalsSystem( );

    public static GameObject[ ] spottedhyena;
    public static int spottedhyenasNum;
    public static int findsNum;

    public GameObject TargetAnimals;
    public GameObject item;
    private GameObject target;
    private Vector3 newPosition;
    private bool goPredation;
    private bool hunting = false;

    void Start()
    {
        _spottedhyena.animals = this.gameObject;
        _spottedhyena.moveSpeed = 5.0f;
        _spottedhyena.startPredationProbability = 60;
        _spottedhyena.Minus = 5;
        _spottedhyena.canMove = false;
        _spottedhyena.canPredation = false;
        _spottedhyena.needTurn = false;
        _spottedhyena.predationProbability = Random.Range( 0, 11 );

        goPredation = true;
        target = GameObject.Find( "spottedhyenaTarget" );
        newPosition = new Vector3( Random.Range( -10, 10 ), 12.0f, 0.0f );
    }

    void Update()
    {
        timeIn( );
        numsProbability( );
        findNum( );
        getAnimalsType( );
        setTurnScale( );
        wilddogMove( );
        item = this.gameObject.GetComponent<FindItemType>( ).getItemType( );
    }

    private void wilddogMove( )
    {
        if ( _spottedhyena.canMove )
        {
            this.gameObject.transform.position = Vector3.MoveTowards( this.gameObject.transform.position, target.transform.position, _spottedhyena.moveSpeed * Time.deltaTime );
            changeTarget( );
        }
    }

    private void changeTarget( )
    {
        if ( TargetAnimals.GetComponent<BLUEWILDEBEEST>( ).getItem( ) )
        {
            if ( goPredation && TargetAnimals.GetComponent<BLUEWILDEBEEST>( ).itemAndAnimalPosition( ) )
            {
                target.transform.position = BLUEWILDEBEEST._bluewildebeest.animals.transform.position;
                spottedhyenaPredationProbability( );
            }
            if ( this.gameObject.transform.position == BLUEWILDEBEEST._bluewildebeest.animals.transform.position )
            {
                newPosition = new Vector3( Random.Range( -10, 10 ), 12.0f, 0.0f );
                target.transform.position = newPosition;
                Predation( );
                goPredation = false;
                hunting = true;
            }
            if ( this.gameObject.transform.position == newPosition && TargetAnimals.GetComponent<BLUEWILDEBEEST>( ).itemAndAnimalPosition( ) )
            {
                goPredation = true;
                _spottedhyena.canMove = false;
            }
        }
        else if ( goPredation )
        {
            newPosition = new Vector3( Random.Range( -10, 10 ), 7.0f, 0.0f );
            target.transform.position = newPosition;
            goPredation = false;
        }
    }

    public void spottedhyenaPredationProbability( )
    {
        _spottedhyena.predationProbability = Random.Range( 0, 100 );
        if ( _spottedhyena.predationProbability < ( _spottedhyena.startPredationProbability - ( 6 - findsNum ) * _spottedhyena.Minus ) )
        {
            _spottedhyena.canPredation = true;
        }
        else
        {
            _spottedhyena.canPredation = false;
        }
    }

    private void Predation( )
    {
        if ( !_spottedhyena.canPredation )
        {
            Destroy( spottedhyena[ findsNum - 1 ] );
        }
        else
        {
            Destroy( BLUEWILDEBEEST.bluewildebeest[ BLUEWILDEBEEST.findsNum - 1 ] );
        }
    }

    private void timeIn( )
    {
        if ( item && TargetAnimals.GetComponent<BLUEWILDEBEEST>( ).itemAndAnimalPosition( ) && InstallAnimals.in_animals.in_spottedhyena )
        {
            _spottedhyena.canMove = true;
        }
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

    private void setTurnScale( )
    {
        if ( target.transform.position.x >= _spottedhyena.animals.transform.position.x )
        {
            _spottedhyena.needTurn = true;
        }
        else
        {
            _spottedhyena.needTurn = false;
        }
    }

    public bool huntingHappened( )
    {
        return hunting;
    }
}
