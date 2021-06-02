using UnityEngine;

public class TargetAnimalsType : MonoBehaviour
{
    public static bool canPredation;
    public static GameObject targetAnimal;
    [SerializeField] private bool haveTargetAnimal;

    void Start()
    {
        haveTargetAnimal = false;
    }

    void Update()
    {
        if ( LION._lion.canMove && ( ZEBRA._zebra.canMove || GIRAFFE._giraffe.canMove ) )
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
            else if ( !haveTargetAnimal )
            {
                randomTargetAnimal( );
                haveTargetAnimal = true;
            }          
        }
        else
        {
            canPredation = false;
            targetAnimal = null;
            haveTargetAnimal = false;
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
