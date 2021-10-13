using UnityEngine;

public class AnimalBase : MonoBehaviour
{
    [SerializeField] private TimeController TimeController; 
    private AnimalData.AnimalBase _animal = new AnimalData.AnimalBase( );

    private readonly float StartingCD = 10f;
    private bool IsStartingCD = false;
    private Transform GridParent;
    private Transform TargetTransform;
    private Transform AnimalParent;
    private Transform CameraTransform;
    private MapLevel MapLevel;


    public void Init( int animal_type, int target_index )
    {
        _animal.AnimalType = animal_type;
        _animal.TargetIndex = target_index;

        GridParent = GameObject.FindGameObjectWithTag( "GridParent" ).transform;
        TargetTransform = GridParent.GetChild( target_index ).GetChild( 0 );

        AnimalParent = GameObject.FindGameObjectWithTag( "AnimalParent" ).transform;
        CameraTransform = GameObject.FindGameObjectWithTag( "MainCamera" ).transform;
        MapLevel = GameObject.FindGameObjectWithTag( "Map" ).GetComponent<MapLevel>( );
        _animal.OriginalPos = RandomPos( );
        this.transform.parent = AnimalParent;
        this.transform.position = _animal.OriginalPos;

        TimeController = GameObject.FindObjectOfType<TimeController>( );
        _animal.StartingTime = TimeController.getNowRealSec( );
        _animal.CanMove = false;
        _animal.Speed = 5f;

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
        }
        else
        {
            x = 12 + ( ( CameraCenter - 2 ) * 3.2f );
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
            if( TimeController.getNowRealSec( ) - _animal.StartingTime >= 10f )
            {
                _animal.CanMove = true;
            }
        }

        if( _animal.CanMove )
        {
            this.transform.position = Vector3.MoveTowards( this.transform.position, TargetTransform.position, Time.deltaTime * _animal.Speed );

            if( this.transform.position == TargetTransform.position )
            {
                _animal.CanMove = false;
            }
        }
    }
}
