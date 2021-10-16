using UnityEngine;

public class AnimalBase : MonoBehaviour
{
    private TimeController TimeController; 
    private AnimalData.AnimalBase _animal = new AnimalData.AnimalBase( );

    private readonly float StartingCD = 5f;
    private readonly float ActionCD = 3f;
    private bool IsStartingCD = false;

    private Transform GridParent;
    private Transform TargetTransform;
    private Transform AnimalParent;
    private Transform CameraTransform;
    private MapLevel MapLevel;


    public void Init( int animal_type, int target_index, int target_type )
    {
        _animal.AnimalType = animal_type;
        _animal.TargetIndex = target_index;
        _animal.TargetType = target_type;

        GridParent = GameObject.FindGameObjectWithTag( "GridParent" ).transform;
        TargetTransform = GridParent.GetChild( target_index );

        AnimalParent = GameObject.FindGameObjectWithTag( "AnimalParent" ).transform;
        CameraTransform = GameObject.FindGameObjectWithTag( "MainCamera" ).transform;
        MapLevel = GameObject.FindGameObjectWithTag( "Map" ).GetComponent<MapLevel>( );
        _animal.OriginalPos = RandomPos( );
        this.transform.parent = AnimalParent;
        this.transform.position = _animal.OriginalPos;

        TimeController = GameObject.FindObjectOfType<TimeController>( );
        _animal.CDStartingTime = TimeController.getNowRealSec( );
        _animal.CoolDown = true;
        _animal.DecisionMade = true;
        _animal.Speed = 5f;

        _animal.Territory = Define.TERRITORY_ARR[target_type];

        gameObject.SetActive( true );
    }

    private Vector3 RandomPos()
    {
        var x = -13f;

        var TargetX = _animal.TargetIndex % Define.XCOUNT;
        var CameraCenter = Mathf.FloorToInt( CameraTransform.position.x / 3.2f ) + 3;

        if( CameraCenter > TargetX )
        {
            x = -13f;
            gameObject.GetComponent<SpriteRenderer>( ).flipX = true;
        }
        else
        {
            x = 25f;
            gameObject.GetComponent<SpriteRenderer>( ).flipX = false;
        }

        var level = MapLevel.getMapLevel( ) - 1;

        var y = Random.Range( -7, 7 + level );

        Debug.Log( x + " " + y );
        return new Vector3( x, y, 0 );
    }

    private void FixedUpdate( )
    {
        //starting CD
        if( !IsStartingCD )
        {
            if( TimeController.getNowRealSec( ) - _animal.CDStartingTime >= StartingCD )
            {
                IsStartingCD = true;
                _animal.CoolDown = false;
            }
        }

        if( !_animal.DecisionMade )
        {
            RandomTarget( );
        }

        if( !_animal.CoolDown )
        {
            this.transform.position = Vector3.MoveTowards( this.transform.position, TargetTransform.position, Time.deltaTime * _animal.Speed );

            if( this.transform.position == TargetTransform.position )
            {
                _animal.CoolDown = true;
                _animal.DecisionMade = false;
            }
        }
        else
        {
            if( TimeController.getNowRealSec( ) - _animal.CDStartingTime >= ActionCD )
            {
                _animal.CoolDown = false;
            }
        }
        
    }

    private void RandomTarget( )
    {
        //caution -> check range
        int rand = Random.Range( 0, _animal.Territory.Length );
        int target = _animal.TargetIndex + _animal.Territory[rand];

        TargetTransform = GridParent.GetChild( target );

        _animal.CDStartingTime = TimeController.getNowRealSec( );
        _animal.DecisionMade = true;
    }

}
