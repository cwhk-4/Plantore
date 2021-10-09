using UnityEngine;

public class AnimalBase : MonoBehaviour
{
    [SerializeField] private TimeController TimeController; 
    private AnimalData.AnimalBase _animal = new AnimalData.AnimalBase( );

    private readonly float StartingCD = 10f;
    private bool IsStartingCD = false;
    [SerializeField] private Transform GridParent;
    [SerializeField] private Transform TargetTransform;
    [SerializeField] private Transform AnimalParent;

    public void Init( int animal_type, int target_index )
    {
        _animal.AnimalType = animal_type;
        _animal.TargetIndex = target_index;

        GridParent = GameObject.FindGameObjectWithTag( "GridParent" ).transform;
        TargetTransform = GridParent.GetChild( target_index ).GetChild( 0 );

        AnimalParent = GameObject.FindGameObjectWithTag( "AnimalParent" ).transform;
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
        //caution
        var x = -12;
        var y = Random.Range( -7, 7 );

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
        }
    }
}
