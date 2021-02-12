using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HIPPO : MonoBehaviour
{
    public static AnimalsCollection.animalsSystem _hippo = new AnimalsCollection.animalsSystem( );

    public GameObject otherAnimals;
    private GameObject target;
    private GameObject item;
    private Vector3 newPosition;

    public AnimalsTimeController _hippoTimeController;

    private int itemsNum;
    private int timeControllerIn;
    private float timeToGo;
    private bool scriptCount = false;
    private bool canFindItem = true;
    private bool runaway = false;

    public static GameObject[ ] hippo;
    public static int hipposNum;
    public static int findsNum;

    void Start( )
    {
        _hippo.animals = this.gameObject;
        _hippo.moveSpeed = 4.0f;
        _hippo.canMove = false;
        _hippo.needTurn = false;

        target = GameObject.Find( "hippoTarget" );
        newPosition = new Vector3( 14.0f, Random.Range( -10, 12 ), 0.0f );
    }

    void Update( )
    {
        timeIn( );
        findNum( );
        getAnimalsType( );
        numsProbability( );
        setTurnScale( );
        hippoMove( );
        item = this.gameObject.GetComponent<FindItemType>( ).getItemType( );
    }

    private void hippoMove( )
    {
        if ( _hippo.canMove )
        {
            _hippo.animals.transform.position = Vector3.MoveTowards( _hippo.animals.transform.position, target.transform.position, Time.deltaTime * _hippo.moveSpeed );
            changeTarget( );
        }
    }

    private void changeTarget( )
    {
        if ( item && !runaway )
        {
            target.transform.position = item.transform.position;
            canFindItem = true;
        }
        if ( item == null && canFindItem )
        {
            newPosition = new Vector3( 14.0f, Random.Range( -10, 12 ), 0.0f );
            target.transform.position = newPosition;
            canFindItem = false;
        }
        if ( WHITERHINO._whiterhino.animals.transform.position == SPOTTEDHYENA._spottedhyena.animals.transform.position )
        {
            newPosition = new Vector3( 14.0f, Random.Range( -10, 12 ), 0.0f );
            runaway = true;
            target.transform.position = newPosition;
        }
        if ( item == null && this.gameObject.transform.position == newPosition )
        {
            runaway = false;
            _hippo.canMove = false;
        }
    }

    private void timeIn( )
    {
        Debug.Log( item );
        if ( item && InstallAnimals.in_animals.in_hippo&& timeControllerIn == 0 )
        {
            if ( !scriptCount )
            {
                _hippoTimeController = this.gameObject.AddComponent<AnimalsTimeController>( );
                scriptCount = true;
            }
            timeToGo = GameObject.Find( "HIPPOS" ).GetComponent<AnimalsTimeController>( ).changeTime( );

            if ( timeToGo < 0 )
            {
                _hippo.canMove = true;
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
        hippo = this.gameObject.GetComponent<GetNum>( )._animals;
    }

    void numsProbability( )
    {
        switch ( InstallAnimals.hipposNumProbability )
        {
            case 0:
                _hippo.animalsNUM = 0;
                break;
            case 1:
                _hippo.animalsNUM = 1;
                break;
            case 2:
                _hippo.animalsNUM = 2;
                break;
        }
    }

    private void setTurnScale( )
    {
        if ( target.transform.position.x >= _hippo.animals.transform.position.x )
        {
            _hippo.needTurn = true;
        }
        else
        {
            _hippo.needTurn = false;
        }
    }

    public GameObject getItem( )
    {
        return item;
    }
}
