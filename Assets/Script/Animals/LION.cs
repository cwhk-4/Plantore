using UnityEngine;

public class LION : MonoBehaviour
{

    public static AnimalsCollection.animalsSystem _lion = new AnimalsCollection.animalsSystem( );

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
        _lion.moveSpeed = 4.0f;
        _lion.Minus = 5;
        _lion.startPredationProbability = 30;
        _lion.canMove = false;
        _lion.canPredation = false;
        _lion.needTurn = false;
        _lion.predationProbability = Random.Range( 0, 9 );

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
            _lion.moveSpeed = 6.0f;
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
            goStage.transform.position = getItemsIndex( ItemBase.GetIndex( ) + Define.ROCK_TERRITORY[ i ] ).position;
            if ( gameObject.transform.position == goStage.transform.position )
            {
                i++;
                if ( i > 4 )
                {
                    i = 0;
                }
            }
            canFindRock = true;
        }
        if ( gameObject.transform.position == item.transform.position )
        {
            goPredation = true;
            runaway = true;
        }
        
        if ( ( item == null && canFindRock ) || ( goPredation && !itempro.targetAnimal ) )
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
        if ( itempro.targetAnimal )
        {
            if ( itempro.canPredation )
            {
                goStage.transform.position = itempro.targetAnimal.transform.position;
            }
            if ( gameObject.transform.position == itempro.targetAnimal.transform.position )
            {
                Destroy( itempro.targetAnimal );
            }
        }
    }
}
