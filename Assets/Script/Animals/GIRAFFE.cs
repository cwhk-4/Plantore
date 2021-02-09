using UnityEngine;

public class GIRAFFE : MonoBehaviour
{
    public static AnimalsCollection.animalsSystem _giraffe = new AnimalsCollection.animalsSystem( );

    private GameObject MapLevel;
    private GameObject goStage;
    private GameObject item;
    private Vector3 newPosition;

    public AnimalsTimeController _giraffeTimeController;

    public static GameObject[ ] giraffe;
    public static int giraffesNUM;
    public static int findsNum;

    private int timeControllerIn;
    private float timeToGo;
    private bool canFindItem = true;
    private bool runaway = false;
    private bool scriptCount = false;

    void Start( )
    {
        _giraffe.animals = this.gameObject;
        _giraffe.moveSpeed = 4.0f;
        _giraffe.canMove = false;
        _giraffe.needTurn = false;

        MapLevel = GameObject.Find( "MapInfo" );
        goStage = GameObject.Find( "giraffeTarget" );
        newPosition = new Vector3( 11.0f, Random.Range( -10, 10 ), 0.0f );
    }

    void Update( )
    {
        timeIn( );
        numsProbability( );
        findNum( );
        getAnimalsType( );
        setTurnScale( );
        if ( MapLevel.GetComponent<MapLevel>( ).getMapLevel( ) == 1 )
        {
            giraffeMove( );
        }
        item = this.gameObject.GetComponent<FindItemType>( ).getItemType( );
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
            goStage.transform.position = item.transform.position;
            canFindItem = true;
        }
        if ( item == null && canFindItem )
        {
            newPosition = new Vector3( 15.0f, Random.Range( -10, 10 ), 0.0f );
            goStage.transform.position = newPosition;
            canFindItem = false;
        }
        if ( this.gameObject.transform.position == LION._lion.animals.transform.position )
        {
            newPosition = new Vector3( 15.0f, Random.Range( -10, 10 ), 0.0f );
            runaway = true;
            goStage.transform.position = newPosition;
        }
        if ( item == null && this.gameObject.transform.position == newPosition )
        {
            runaway = false;
            scriptCount = false;
            _giraffe.canMove = false;
            timeControllerIn = 0;
        }
        if ( MapLevel.GetComponent<MapLevel>( ).getMapLevel( ) != 1 )
        {
            newPosition = new Vector3( 15.0f, Random.Range( -10, 10 ), 0.0f );
        }
    }

    void timeIn( )
    {
        if ( item && InstallAnimals.in_animals.in_giraffe && timeControllerIn == 0 )
        {
            if ( !scriptCount )
            {
                _giraffeTimeController = this.gameObject.AddComponent<AnimalsTimeController>( );
                scriptCount = true;
            }
            timeToGo = GameObject.Find( "GIRAFFES" ).GetComponent<AnimalsTimeController>( ).changeTime( );

            if ( timeToGo < 0 )
            {
                _giraffe.canMove = true;
                Destroy( this.gameObject.GetComponent<AnimalsTimeController>( ) );
                timeControllerIn = 1;
                timeToGo = 0;
            }
        }
    }

    private void findNum( )
    {
        findsNum = this.gameObject.GetComponent<GetNum>( ).getAnimalsNum( );
    }

    private void getAnimalsType( )
    {
        giraffe = this.gameObject.GetComponent<GetNum>( )._animals;
    }

    void numsProbability( )
    {
        if ( InstallAnimals.giraffesNumProbability == 1 )
        {
            giraffesNUM = 1;
        }else if ( InstallAnimals.giraffesNumProbability == 2 )
        {
            giraffesNUM = 2;
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
}
