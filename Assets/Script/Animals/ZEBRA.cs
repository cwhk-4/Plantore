using UnityEngine;

public class ZEBRA : MonoBehaviour
{

    public static AnimalsCollection.animalsSystem _zebra = new AnimalsCollection.animalsSystem( );

    private GameObject goStage;
    private Vector3 newPosition;

    public AnimalsTimeController _zebraTimeController;
    private MissionControl _foundZebra;

    public static GameObject[ ] zebra;
    public static int zebrasNUM;
    public static int findsNum;
    
    private int timeControllerIn;
    private float timeToGo;
    private bool canFindGrass = true;
    private bool runaway = false;
    private bool scriptCount = false;


    void Start( )
    {
        _zebra.animals = this.gameObject;
        _zebra.moveSpeed = 3.0f;
        _zebra.canMove = false;
        _zebra.needTurn = false;

        goStage = GameObject.Find( "zebraTarget" );
        newPosition = new Vector3( 11.0f, Random.Range( -10, 10 ), 0.0f );
    }

    private void FixedUpdate( )
    {
        zebraMove( );
    }
    private void Update( )
    {
        timeIn( );
        numsProbability( );
        findNum( );
        getAnimalsType( );
        setTurnScale( );
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
        if ( MoveItem._item && !runaway )
        {
            goStage.transform.position = MoveItem._item.transform.position;
            canFindGrass = true;
        }
        if ( MoveItem._item == null && canFindGrass )
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
        if ( MoveItem._item == null && this.gameObject.transform.position == newPosition )
        {
            runaway = false;
            scriptCount = false;
            _zebra.canMove = false;
            timeControllerIn = 0;
        }
    }

    void timeIn( )
    {
        if ( MoveItem._item && InstallAnimals.in_animals.in_zebra == true && timeControllerIn == 0 )
        {
            if ( !scriptCount )
            {
                _zebraTimeController = this.gameObject.AddComponent<AnimalsTimeController>( );
                scriptCount = true;
            }
            timeToGo = GameObject.Find( "ZEBRAS" ).GetComponent<AnimalsTimeController>( ).changeTime( );

            if ( timeToGo < 0 )
            {
                _zebra.canMove = true;
                Destroy( this.gameObject.GetComponent<AnimalsTimeController>( ) );
                timeControllerIn = 1;
                timeToGo = 0;
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
}
