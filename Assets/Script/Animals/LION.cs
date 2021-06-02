using UnityEngine;

public class LION : MonoBehaviour
{

    public static AnimalsCollection.animalsSystem _lion = new AnimalsCollection.animalsSystem( );
    private const float SPEED = 4.0f;
    private const float DASH_SPEED = 6.0f;
    private int[ ] indexTutorial;
    private int[ ] index0 = { 0, Define.XCOUNT, Define.XCOUNT + 1, 1};
    private int[ ] index1 = { 0, Define.XCOUNT - 1, Define.XCOUNT, Define.XCOUNT + 1, -1, 1 };
    private int[ ] index12 = { 0, Define.XCOUNT, Define.XCOUNT + 1, 1, -Define.XCOUNT, -Define.XCOUNT + 1 };
    private GameObject goStage;
    private Vector3 newPosition;
    private GameObject item;

    public AnimalsTimeController _lionTimeController;
    public GridTerritoryControl getItemIndex;
    public ItemBase ItemBase;
    
    public static GameObject lion;

    private int timeControllerIn = 0;
    private float timeToGo;
    private bool runaway = false;
    private bool scriptCount = false;
    private bool canFindRock = true;
    private bool goPredation = false;
    private int i;

    void Start( )
    {
        _lion.animals = this.gameObject;
        _lion.moveSpeed = SPEED;
        _lion.Minus = 5;
        _lion.startPredationProbability = 30;
        _lion.canMove = false;
        _lion.canPredation = false;
        _lion.needTurn = false;

        goStage = GameObject.Find( "lionTarget" );
        newPosition = new Vector3( Random.Range( -10, 10 ), 7.0f, 0.0f );
    }

    void Update( )
    {
        timeIn( );
        setTurnScale( );
        lionMove( );
        item = this.gameObject.GetComponent<FindItemType>( ).getItemType( );
        if ( item )
        {
            ItemBase = item.GetComponent<ItemBase>( );
        }
        if ( goPredation )
        {
            Predation( );
            _lion.moveSpeed = DASH_SPEED;
        }
    }

    void lionMove( )
    {
        if ( _lion.canMove )
        {
            this.gameObject.transform.position = Vector3.MoveTowards( gameObject.transform.position, goStage.transform.position, _lion.moveSpeed * Time.deltaTime );
            changeTarget( );
        }
    }

    void changeTarget( )
    {
        if ( ( item && !runaway ) )
        {
            checkOutOfRange( );
            var index = ItemBase.GetIndex( ) + indexTutorial[ i ];

            goStage.transform.position = getItemsIndex( index ).position;
            if ( gameObject.transform.position == goStage.transform.position )
            {
                i++;
                if ( i > indexTutorial.Length - 1 )
                {
                    i = 0;
                }
            }
            canFindRock = true;
        }
        if ( item )
        {
            if ( gameObject.transform.position == item.transform.position && TargetAnimalsType.targetAnimal )
            {
                goPredation = true;
                runaway = true;
                _lion.canPredation = true;
            }
        }
        _lion.canPredation = false;

        if ( ( item == null && canFindRock ) || ( goPredation && !TargetAnimalsType.targetAnimal ) )
        {
            runaway = true;
            goPredation = false;
            newPosition = new Vector3( 15.0f, Random.Range( -10, 10 ), 0.0f );
            goStage.transform.position = newPosition;
            canFindRock = false;
        }
        if ( item == null && gameObject.transform.position == newPosition )
        {
            runaway = false;
            scriptCount = false;
            _lion.canMove = false;
            _lion.moveSpeed = SPEED;
            timeControllerIn = 0;
        }
    }


    void timeIn( )
    {
        if ( item && timeControllerIn == 0 )
        {
            if ( !scriptCount )
            {
                _lionTimeController = this.gameObject.AddComponent<AnimalsTimeController>( );
                scriptCount = true;
            }
            timeToGo = this.gameObject.GetComponent<AnimalsTimeController>( ).changeTime( );
            if ( timeToGo < -0.5 )
            {
                _lion.canMove = true;
                Destroy( this.gameObject.GetComponent<AnimalsTimeController>( ) );
                timeControllerIn = 1;
                timeToGo = 0;
            }
        }
    }

    void setTurnScale( )
    {
        if ( goStage.transform.position.x >= _lion.animals.transform.position.x )
        {
            _lion.needTurn = true;
        }
        else
        {
            _lion.needTurn = false;
        }
    }

    public Transform getItemsIndex( int index )
    {
        return getItemIndex.GetIndexTransform( index );
    }

    void Predation( )
    {
        if ( TargetAnimalsType.targetAnimal )
        {
            if ( TargetAnimalsType.canPredation )
            {
                goStage.transform.position = TargetAnimalsType.targetAnimal.transform.position;
            }
            if ( gameObject.transform.position == TargetAnimalsType.targetAnimal.transform.position )
            {
                Destroy( TargetAnimalsType.targetAnimal );
            }
        }
    }

    private void checkOutOfRange( )
    {
        switch ( ItemBase.GetIndex( ) )
        {
            case 0:
                indexTutorial = index0;
                break;
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
                indexTutorial = index1;
                break;
            case 12:
            case 24:
            case 36:
            case 48:
                indexTutorial = index12;
                break;
            default:
                indexTutorial = Define.SMALL_ROCK_TERRITORY;
                break;
        }
    }
}
