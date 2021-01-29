using UnityEngine;

public class WHITERHINO : MonoBehaviour
{
    public static AnimalsCollection.animalsSystem _whiterhino = new AnimalsCollection.animalsSystem( );

    private GameObject target;
    private GameObject item;
    private Vector3 newPosition;

    private int itemsNum;
    private bool onItem = false;
    private bool runaway = false;
    private bool canFindItem = true;

    public static GameObject[ ] whiterhino;
    public static int whiterhinosNum;
    public static int findsNum;

    void Start()
    {
        _whiterhino.animals = this.gameObject;
        _whiterhino.moveSpeed = 3.0f;
        _whiterhino.canMove = false;
        _whiterhino.needTurn = false;

        target = GameObject.Find( "whiterhinoTarget" );
        newPosition = new Vector3( 15.0f, Random.Range( -10, 12 ), 0.0f );
    }

    private void FixedUpdate( )
    {
        whiterhinoMove( );
    }

    void Update( )
    {
        timeIn( );
        findNum( );
        getAnimalsType( );
        numsProbability( );
        setTurnScale( );
        itemsNum = this.gameObject.GetComponent<FindItemType>( ).getItemsNum( );
        item = this.gameObject.GetComponent<FindItemType>( ).getItemType( );
    }

    private void whiterhinoMove( )
    {
        if ( _whiterhino.canMove )
        {
            _whiterhino.animals.transform.position = Vector3.MoveTowards( _whiterhino.animals.transform.position, target.transform.position, Time.deltaTime * _whiterhino.moveSpeed );
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
            newPosition = new Vector3( 15.0f, Random.Range( -10, 12 ), 0.0f );
            target.transform.position = newPosition;
            canFindItem = false;
        }
        if ( this.gameObject.transform.position == AFRICANWILDDOG._africanwilddog.animals.transform.position )
        {
            newPosition = new Vector3( 15.0f, Random.Range( -10, 12 ), 0.0f );
            runaway = true;
            target.transform.position = newPosition;
        }
        if ( item == null && this.gameObject.transform.position == newPosition )
        {
            runaway = false;
            _whiterhino.canMove = false;
        }
    }

    private void timeIn( )
    {
        if ( itemsNum == 2 && InstallAnimals.in_animals.in_whiterhino )
        {
            _whiterhino.canMove = true;
        }
    }

    private void findNum( )
    {
        findsNum = this.gameObject.GetComponent<GetNum>( ).getAnimalsNum( );
    }

    private void getAnimalsType( )
    {
        whiterhino = this.gameObject.GetComponent<GetNum>( )._animals;
    }

    void numsProbability( )
    {
        switch ( InstallAnimals.whiterhinosNumProbability )
        {
            case 0:
                _whiterhino.animalsNUM = 0;
                break;
            case 1:
                _whiterhino.animalsNUM = 1;
                break;
            case 2:
            case 3:
            case 4:
            case 5:
                _whiterhino.animalsNUM = 2;
                break;
            case 6:
            case 7:
            case 8:
            case 9:
            case 10:
                _whiterhino.animalsNUM = 3;
                break;
        }
    }

    private void setTurnScale( )
    {
        if ( target.transform.position.x >= _whiterhino.animals.transform.position.x )
        {
            _whiterhino.needTurn = true;
        }
        else
        {
            _whiterhino.needTurn = false;
        }
    }

    public bool itemAndAnimalPosition( )
    {
        if ( item )
        {
            if ( this.gameObject.transform.position == item.transform.position )
            {
                onItem = true;
            }
            else
            {
                onItem = false;
            }
        }
        return onItem;
    }

    public GameObject getItem( )
    {
        return item;
    }
}
