using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itempro : MonoBehaviour
{
    public static bool canPredation;
    public static GameObject targetAnimal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( LION._lion.canMove && ( ZEBRA._zebra.canMove || GIRAFFE._giraffe.canMove ) )
        {
            canPredation = true;
            if ( GIRAFFE._giraffe.canMove == false )
            {
                targetAnimal = ZEBRA._zebra.animals;
            } else if( ZEBRA._zebra.canMove == false )
            {
                targetAnimal = GIRAFFE._giraffe.animals;
            } else
            {
                randomTargetAnimal( );
            }
        }else
        {
            canPredation = false;
            targetAnimal = null;
        }

        Debug.Log( targetAnimal );
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
