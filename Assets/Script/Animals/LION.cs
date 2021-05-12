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

    private int[ ] rockIndex = { -12, -1, 1, 0, 11, 12, 13, 24 };
    private int timeControllerIn = 0;
    private float timeToGo;
    private bool runaway = false;
    private bool scriptCount = false;
    private bool canFindRock = true;
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
    }

    void lionMove( )
    {
        if ( _lion.canMove )
        {
            this.gameObject.transform.position = Vector3.MoveTowards( this.gameObject.transform.position, goStage.transform.position, _lion.moveSpeed * Time.deltaTime );
            changeTarget( );
        }
    }

    void changeTarget( )
    {
        if ( item && !runaway )
        {
            goStage.transform.position = getItemsIndex( ItemBase.GetIndex( ) + rockIndex[ i ] ).position;
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
        if ( item == null && canFindRock )
        {
            newPosition = new Vector3( 15.0f, Random.Range( -10, 10 ), 0.0f );
            goStage.transform.position = newPosition;
            canFindRock = false;
        }
        if ( item == null && this.gameObject.transform.position == newPosition )
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
            if ( timeToGo <= 0 )
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
}
