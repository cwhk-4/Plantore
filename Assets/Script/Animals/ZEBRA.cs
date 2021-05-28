using UnityEngine;

public class ZEBRA : MonoBehaviour
{
    public static AnimalsCollection.animalsSystem _zebra = new AnimalsCollection.animalsSystem( );

    private const float SPEED = 3.0f;
    private const float DASH_SPEED = 4.5f;
    private int[ ] indexTutorial;
    private int[ ] index0 = { 0, 1, Define.XCOUNT }; 
    private GameObject MapLevel;
    private GameObject goStage;
    private GameObject item;
    private Vector3 newPosition;

    public AnimalsTimeController _zebraTimeController;
    public GridTerritoryControl getItemIndex;
    public ItemBase ItemBase;

    public static GameObject zebra;
    private int i;

    private int timeControllerIn;

    private bool onItem = false;
    private bool canFindGrass = true;
    private bool runaway = false;
    private bool scriptCount = false;

    void Start( )
    {
        _zebra.animals = this.gameObject;
        _zebra.moveSpeed = SPEED;
        _zebra.canMove = false;
        _zebra.needTurn = false;
        

        MapLevel = GameObject.Find( "MapInfo" );
        goStage = GameObject.Find( "zebraTarget" );
        newPosition = new Vector3( 11.0f, Random.Range( -10, 10 ), 0.0f );
    }

    void Update( )
    {
        timeIn( );
        setTurnScale( );
        if ( MapLevel.GetComponent<MapLevel>( ).getMapLevel( ) == 1 )
        {
            zebraMove( );
        }
        item = this.gameObject.GetComponent<FindItemType>( ).getItemType( );
        if ( item )
        {
            ItemBase = item.GetComponent<ItemBase>( );
        }
    }

    void zebraMove( )
    {
        if ( _zebra.canMove )
        {
            _zebra.animals.transform.position = Vector3.MoveTowards( _zebra.animals.transform.position, goStage.transform.position, Time.deltaTime * _zebra.moveSpeed );
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
                i ++;
                if ( i > indexTutorial.Length - 1 )
                {
                    i = 0;
                }
            }
            
            canFindGrass = true;
        }
        if ( LION._lion.canPredation )
        {
            runaway = true;
            _zebra.moveSpeed = DASH_SPEED;
        }
        if ( ( item == null && canFindGrass ) || runaway == true )
        {
            newPosition = new Vector3( 15.0f, Random.Range( -10, 10 ), 0.0f );
            goStage.transform.position = newPosition;
            canFindGrass = false;
            runaway = false;
        }
        if ( item == null && this.gameObject.transform.position == newPosition )
        {
            scriptCount = false;
            _zebra.canMove = false;
            timeControllerIn = 0;
        }
    }

    void timeIn( )
    {
        if ( item && timeControllerIn == 0 )
        {
            if ( item.tag == "Grass" )
            {
                if ( !scriptCount )
                {
                    _zebraTimeController = this.gameObject.AddComponent<AnimalsTimeController>( );
                    scriptCount = true;
                }
                float timeToGo;
                timeToGo = gameObject.GetComponent<AnimalsTimeController>( ).changeTime( );
                if ( timeToGo < -0.5 )
                {
                    _zebra.canMove = true;
                    Destroy( gameObject.GetComponent<AnimalsTimeController>( ) );
                    timeControllerIn = 1;
                    timeToGo = 0;
                }
            }
        }
    }

    private void setTurnScale( )
    {
        if ( goStage.transform.position.x >= _zebra.animals.transform.position.x )
        {
            _zebra.needTurn = true;
        }
        else
        {
            _zebra.needTurn = false;
        }
    }

    public bool itemAndAnimalPosition( )
    {
        if ( this.gameObject.transform.position == item.transform.position )
        {
            onItem = true;
        }else
        {
            onItem = false;
        }
        return onItem;
    }

    public Transform getItemsIndex( int index )
    {
        return getItemIndex.GetIndexTransform( index );
    }

    private void checkOutOfRange( )
    {
        switch( ItemBase.GetIndex( ) )
        {
            case 0:
                indexTutorial = index0;
                break;
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
                break;
        }
    }
}
