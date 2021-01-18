using UnityEngine;

public class LION : MonoBehaviour
{

    public static animalsCollection.animalsSystem _lion = new animalsCollection.animalsSystem( );

    [SerializeField] private GameObject Target;
    private GameObject goStage;
    private Vector3 newPosition;

    public animalsTimeController _lionTimeController;
    
    public static GameObject[ ] lion;
    public static int lionsNUM;
    public static int findsNum;
    
    private int timeControllerIn = 0;
    private float timeToGo;
    private bool goPredation;
    private bool scriptCount = false;

    void Start( )
    {
        _lion.animals = this.gameObject;
        _lion.moveSpeed = 4.0f;
        _lion.Minus = 5;
        _lion.startPredationProbability = 30;
        _lion.canMove = false;
        _lion.canPredation = false;
        _lion.predationProbability = Random.Range( 0, 9 );

        goPredation = true;
        Target = GameObject.Find( "LIONTARGET" );
        goStage = GameObject.Find( "lionTarget" );
        Target.transform.position = goStage.transform.position;
        newPosition = new Vector3( Random.Range( -10, 10 ), 7.0f, 0.0f );
    }

    void Update( )
    {
        lionMove( );
        timeIn( );
        numsProbability( );
        findNum( );
        getAnimalsType( );
    }

    void lionMove( )
    {
        if ( _lion.canMove )
        {
            this.gameObject.transform.position = Vector3.MoveTowards( this.gameObject.transform.position, Target.transform.position, _lion.moveSpeed * Time.deltaTime );
            changeTarget( );
        }
    }

    void changeTarget( )
    {
        if ( MoveItem._item )
        {
            if ( this.gameObject.transform.position == goStage.transform.position && goPredation && ZEBRA._zebra.animals.transform.position == MoveItem._item.transform.position )
            {
                Target.transform.position = ZEBRA._zebra.animals.transform.position;
                lionPredationProbability( );
            }
            if ( this.gameObject.transform.position == ZEBRA._zebra.animals.transform.position )
            {
                newPosition = new Vector3( Random.Range( -10, 10 ), 7.0f, 0.0f );
                Target.transform.position = newPosition;
                Predation( );
                goPredation = false;
            }
            if ( this.gameObject.transform.position == newPosition && ZEBRA._zebra.animals.transform.position == MoveItem._item.transform.position )
            {
                Target.transform.position = goStage.transform.position;
                goPredation = true;
                scriptCount = false;
                _lion.canMove = false;
                timeControllerIn = 0;
            }
        }
        else if ( goPredation )
        {
            newPosition = new Vector3( Random.Range( -10, 10 ), 7.0f, 0.0f );
            Target.transform.position = newPosition;
            goPredation = false;
        }
    }

    public void lionPredationProbability( )
    {
        _lion.predationProbability = Random.Range( 0, 100 );
        if ( _lion.predationProbability < ( _lion.startPredationProbability - ( 4 - findsNum ) * _lion.Minus ) )
        {
            _lion.canPredation = true;
        }
        else
        {
            _lion.canPredation = false;
        }
        //if ( GetNum.lionsNum == 4 )
        //{
        //    infighting( );
        //}
    }


    void timeIn( )
    {
        if ( MoveItem._item )
        {
            if ( ZEBRA._zebra.animals.transform.position == MoveItem._item.transform.position && InstallAnimals.in_animals.in_lion && timeControllerIn == 0 )
            {
                if ( !scriptCount )
                {
                    _lionTimeController = this.gameObject.AddComponent<animalsTimeController>( );
                    scriptCount = true;
                }
                timeToGo = GameObject.Find( "LIONS" ).GetComponent<animalsTimeController>( ).changeTime( );
                if ( timeToGo < 0 )
                {
                    _lion.canMove = true;
                    Destroy( this.gameObject.GetComponent<animalsTimeController>( ) );
                    timeControllerIn = 1;
                    timeToGo = 0;
                }
            }
        }
    }

    void Predation( )
    {
        if ( _lion.canPredation )
        {
            Destroy( lion[ findsNum - 1] );
        }
        else
        {
            Destroy( ZEBRA.zebra[ ZEBRA.zebrasNUM - 1 ] );
        }
    }

    void numsProbability( )
    {
        if ( InstallAnimals.lionsNumProbability == 0 )
        {
            lionsNUM = 0;
        }
        else if ( InstallAnimals.lionsNumProbability <= 1 )
        {
            lionsNUM = 1;
        }
        else if ( InstallAnimals.lionsNumProbability <= 4 )
        {
            lionsNUM = 2;
        }
        else if ( InstallAnimals.lionsNumProbability <= 8 )
        {
            lionsNUM = 3;
        }
        else
        {
            lionsNUM = 4;
        }
    }

    void findNum( )
    {
        findsNum = this.gameObject.GetComponent<GetNum>( ).getAnimalsNum( );
    }

    void getAnimalsType( )
    {
        lion = this.gameObject.GetComponent<GetNum>( )._animals;
    }

    //
    ////level 3
    //
    //void infighting( )
    //{
    //    _lion.fightProbability = Random.Range( 0, 20 );
    //    if ( _lion.fightProbability < 4 )
    //    {
    //        _lion.fightEachOther = true;
    //    }
    //    else
    //    {
    //        _lion.fightEachOther = false;
    //    }

    //    if ( _lion.fightEachOther )
    //    {
    //        Destroy( GetNum._LION[ GetNum.lionsNum - 1 ] );
    //        Destroy( GetNum._LION[ GetNum.lionsNum - 2 ] );
    //    }
    //}


}
