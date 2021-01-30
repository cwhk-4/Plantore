using UnityEngine;

public class ZEBRA : MonoBehaviour
{
    public static AnimalsCollection.animalsSystem _zebra = new AnimalsCollection.animalsSystem( );

    private GameObject MapLevel;
    private GameObject goStage;
    private GameObject item;
    private Vector3 newPosition;

    public AnimalsTimeController _zebraTimeController;

    public static GameObject[ ] zebra;
    public static int zebrasNUM;
    public static int findsNum;
    
    private int timeControllerIn;
    private float timeToGo;
    private bool onItem = false;
    private bool canFindGrass = true;
    private bool runaway = false;
    private bool scriptCount = false;


    void Start( )
    {
        _zebra.animals = this.gameObject;
        _zebra.moveSpeed = 3.0f;
        _zebra.canMove = false;
        _zebra.needTurn = false;

        MapLevel = GameObject.Find( "MapInfo" );
        goStage = GameObject.Find( "zebraTarget" );
        newPosition = new Vector3( 11.0f, Random.Range( -10, 10 ), 0.0f );
    }

    private void Update( )
    {
        timeIn( );
        numsProbability( );
        findNum( );
        getAnimalsType( );
        setTurnScale( );
        if ( MapLevel.GetComponent<MapLevel>( ).getMapLevel( ) == 1 )
        {
            zebraMove( );
        }
        item = this.gameObject.GetComponent<FindItemType>( ).getItemType( );
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
            goStage.transform.position = item.transform.position;
            canFindGrass = true;
        }
        if ( item == null && canFindGrass )
        {
            newPosition = new Vector3( 11.0f, Random.Range( -10, 10 ), 0.0f );
            goStage.transform.position = newPosition;
            canFindGrass = false;
        }
        if ( this.gameObject.transform.position == LION._lion.animals.transform.position )
        {
            newPosition = new Vector3( 11.0f, Random.Range( -10, 10 ), 0.0f );
            runaway = true;
            goStage.transform.position = newPosition;
        }
        if ( item == null && this.gameObject.transform.position == newPosition )
        {
            runaway = false;
            scriptCount = false;
            _zebra.canMove = false;
            timeControllerIn = 0;
        }
    }

    void timeIn( )
    {
        if ( item && InstallAnimals.in_animals.in_zebra == true && timeControllerIn == 0 )
        {
            if ( item.tag == "Grass" )
            {
                {
                    if ( !scriptCount )
                    {
                        _zebraTimeController = this.gameObject.AddComponent<AnimalsTimeController>( );
                        scriptCount = true;
                    }
                    timeToGo = this.gameObject.GetComponent<AnimalsTimeController>( ).changeTime( );

                    if ( timeToGo < 0 )
                    {
                        _zebra.canMove = true;
                        Destroy( this.gameObject.GetComponent<AnimalsTimeController>( ) );
                        timeControllerIn = 1;
                        timeToGo = 0;
                    }
                }
            }
        }
    }

    void numsProbability( )
    {
        if ( InstallAnimals.zebrasNumProbability == 0 )
        {
            zebrasNUM = 0;
        }
        else if ( InstallAnimals.zebrasNumProbability == 1 )
        {
            zebrasNUM = 1;
        }
        else if ( InstallAnimals.zebrasNumProbability == 2 )
        {
            zebrasNUM = 2;
        }
        else
        {
            zebrasNUM = 3;
        }
    }

    private void findNum( )
    {
        findsNum = this.gameObject.GetComponent<GetNum>( ).getAnimalsNum( );
    }

    private void getAnimalsType( )
    {
        zebra = this.gameObject.GetComponent<GetNum>( )._animals;
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

    public GameObject getItem( )
    {
        return item;
    }
}
