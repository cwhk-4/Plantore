using UnityEngine;

public class GIRAFFE : MonoBehaviour
{
    public static AnimalsCollection.animalsSystem _giraffe = new AnimalsCollection.animalsSystem( );
    //public static readonly int[] WOOD_TERRITORY = { 0, XCOUNT, -XCOUNT, -1, 1, XCOUNT - 1, XCOUNT + 1, 2 * XCOUNT };
    private const float SPEED = 4.0f;
    private const float DASH_SPEED = 5.0f;
    private GameObject MapLevel;
    private GameObject goStage;
    private GameObject item;
    private int[ ] indexTutorial;
    private int[ ] index0 = { 0, Define.XCOUNT, 1, Define.XCOUNT + 1, 2 * Define.XCOUNT };
    private int[ ] index1 = { 0, Define.XCOUNT -1, 1, Define.XCOUNT - 1, Define.XCOUNT + 1, 2 * Define.XCOUNT };
    private int[ ] index12 = { 0, Define.XCOUNT, -Define.XCOUNT, 1, Define.XCOUNT + 1, 2 * Define.XCOUNT };

    private Vector3 newPosition;

    public AnimalsTimeController _giraffeTimeController;
    public ItemBase ItemBase;
    public GridTerritoryControl getItemIndex;

    private int i;
    private int timeControllerIn;
    private float timeToGo;
    private bool canFindItem = true;
    private bool runaway = false;
    private bool scriptCount = false;

    void Start( )
    {
        _giraffe.animals = this.gameObject;
        _giraffe.moveSpeed = SPEED;
        _giraffe.canMove = false;
        _giraffe.needTurn = false;

        MapLevel = GameObject.Find( "MapInfo" );
        goStage = GameObject.Find( "giraffeTarget" );
        newPosition = new Vector3( 11.0f, Random.Range( -10, 10 ), 0.0f );
    }

    void Update( )
    {
        timeIn( );
        setTurnScale( );
        if ( MapLevel.GetComponent<MapLevel>( ).getMapLevel( ) == 1 )
        {
            giraffeMove( );
        }
        item = this.gameObject.GetComponent<FindItemType>( ).getItemType( );
        if ( item )
        {
            ItemBase = item.GetComponent<ItemBase>( );
        }
    }

    void giraffeMove( )
    {
        if ( _giraffe.canMove )
        {
            this.gameObject.transform.position = Vector3.MoveTowards( this.gameObject.transform.position, goStage.transform.position, Time.deltaTime * _giraffe.moveSpeed );
            changeTarget( );
        }
    }

    void changeTarget( )
    {
        if ( item && !runaway )
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
            canFindItem = true;
        }
        if ( LION._lion.canPredation )
        {
            runaway = true;
            _giraffe.moveSpeed = DASH_SPEED;
        }
        if ( ( item == null && canFindItem ) || runaway )
        {
            newPosition = new Vector3( 15.0f, Random.Range( -10, 10 ), 0.0f );
            goStage.transform.position = newPosition;
            canFindItem = false;
            runaway = false;
        }
        if ( item == null && this.gameObject.transform.position == newPosition )
        {
            runaway = false;
            scriptCount = false;
            _giraffe.canMove = false;
            timeControllerIn = 0;
        }
    }

    void timeIn( )
    {
        if ( item && timeControllerIn == 0 )
        {
            if ( !scriptCount )
            {
                _giraffeTimeController = this.gameObject.AddComponent<AnimalsTimeController>( );
                scriptCount = true;
            }
            timeToGo = this.gameObject.GetComponent<AnimalsTimeController>( ).changeTime( );

            if ( timeToGo < -0.5 )
            {
                _giraffe.canMove = true;
                Destroy( this.gameObject.GetComponent<AnimalsTimeController>( ) );
                timeControllerIn = 1;
                timeToGo = 0;
            }
        }
    }


    private void setTurnScale( )
    {
        if ( goStage.transform.position.x >= _giraffe.animals.transform.position.x )
        {
            _giraffe.needTurn = true;
        }
        else
        {
            _giraffe.needTurn = false;
        }
    }

    public Transform getItemsIndex( int index )
    {
        return getItemIndex.GetIndexTransform( index );
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
                indexTutorial = Define.WOOD_TERRITORY;
                break;
        }
    }
}
