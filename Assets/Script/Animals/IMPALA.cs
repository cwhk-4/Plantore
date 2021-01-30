using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMPALA : MonoBehaviour
{
    public static AnimalsCollection.animalsSystem _impala = new AnimalsCollection.animalsSystem( );

    private GameObject MapLevel;
    private GameObject goStage;
    private GameObject item;
    public AnimalsTimeController _impalaTimeController;
    private Vector3 newPosition;

    public static GameObject[ ] impala;
    public static int impalasNUM;
    public static int findsNum;

    private int timeControllerIn = 0;
    private float timeToGo;
    private int itemsNum;
    private bool canFindItem = true;
    private bool runaway = false;
    private bool scriptCount = false;

    void Start( )
    {
        _impala.animals = this.gameObject;
        _impala.moveSpeed = 2.0f;
        _impala.canMove = false;
        _impala.needTurn = false;

        MapLevel = GameObject.Find( "MapInfo" );
        goStage = GameObject.Find( "impalaTarget" );
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
            impalaMove( );
        }
        itemsNum = this.gameObject.GetComponent<FindItemType>( ).getItemsNum( );
        item = this.gameObject.GetComponent<FindItemType>( ).getItemType( );
        
    }

    void impalaMove( )
    {
        if ( _impala.canMove )
        {
            _impala.animals.transform.position = Vector3.MoveTowards( _impala.animals.transform.position, goStage.transform.position, Time.deltaTime * _impala.moveSpeed );
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
            newPosition = new Vector3( 11.0f, Random.Range( -10, 10 ), 0.0f );
            goStage.transform.position = newPosition;
            canFindItem = false;
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
            _impala.canMove = false;
            timeControllerIn = 0;
        }
    }

    void timeIn( )
    {
        if ( itemsNum == 3 && InstallAnimals.in_animals.in_impala && timeControllerIn == 0 )
        {
            if ( !scriptCount )
            {
                _impalaTimeController = this.gameObject.AddComponent<AnimalsTimeController>( );
                scriptCount = true;
            }
            timeToGo = GameObject.Find( "IMPALAS" ).GetComponent<AnimalsTimeController>( ).changeTime( );

            if ( timeToGo < 0 )
            {
                _impala.canMove = true;
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
        impala = this.gameObject.GetComponent<GetNum>( )._animals;
    }

    void numsProbability( )
    {
        if ( InstallAnimals.impalasNumProbability == 0 )
        {
            impalasNUM = 0;
        }
        else if ( InstallAnimals.impalasNumProbability <= 5 )
        {
            impalasNUM = 4;
        }
        else if ( InstallAnimals.impalasNumProbability <= 8 )
        {
            impalasNUM = 3;
        }
        else if ( InstallAnimals.impalasNumProbability <= 9 )
        {
            impalasNUM = 2;
        }
        else if ( InstallAnimals.impalasNumProbability == 10 )
        {
            impalasNUM = 1;
        }
    }

    private void setTurnScale( )
    {
        if ( goStage.transform.position.x >= _impala.animals.transform.position.x )
        {
            _impala.needTurn = true;
        }
        else
        {
            _impala.needTurn = false;
        }
    }
}
