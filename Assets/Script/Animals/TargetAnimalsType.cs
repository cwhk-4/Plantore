using UnityEngine;

public class TargetAnimalsType : MonoBehaviour
{
    public static bool canPredation;
    public static GameObject targetAnimal;
    //[SerializeField] private bool haveTargetAnimal;
    // Start is called before the first frame update
    void Start()
    {
        //haveTargetAnimal = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ( LION._lion.canMove && ( ZEBRA._zebra.canMove || GIRAFFE._giraffe.canMove ) /*&& !haveTargetAnimal*/)
        {
            canPredation = true;
            if( GIRAFFE._giraffe.canMove == false )
            {
                targetAnimal = ZEBRA._zebra.animals;
            }
            else if( ZEBRA._zebra.canMove == false )
            {
                targetAnimal = GIRAFFE._giraffe.animals;
            }
            else if( ZEBRA._zebra.canMove && GIRAFFE._giraffe.canMove )
            {
                randomTargetAnimal( );
            }
            else
            {
                Debug.Log( "noA" );
            }

            Debug.Log( "noB" );
            //haveTargetAnimal = true;
            
        }
        else
        {
            canPredation = false;
            targetAnimal = null;
        }
    }

    void randomTargetAnimal( )
    {
        int animals = Random.Range( 1, 3 );
        switch( animals )
        {
            case 1: targetAnimal = ZEBRA._zebra.animals;
                break;
            case 2: targetAnimal = GIRAFFE._giraffe.animals;
                break;
        }
    }
}
