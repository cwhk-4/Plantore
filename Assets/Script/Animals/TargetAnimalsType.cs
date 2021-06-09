using UnityEngine;

public class TargetAnimalsType : MonoBehaviour
{
    public static bool canPredation;
    public static GameObject targetAnimal;
    [SerializeField] private bool haveTargetAnimal;
    private bool canCheckIndex;
    private int[ ] itemIndex;
    private int[ ] lionIndex;
    private int indexNum;

    private int A;
    private int B;
    

    void Start()
    {
        canCheckIndex = false;
    }

    void Update()
    {
        chouceTragetAnimal( );
        TargetAnimalsIndex( );
    }

    void chouceTragetAnimal( )
    {
        if ( LION._lion.canMove && ( ZEBRA._zebra.canMove || GIRAFFE._giraffe.canMove ) )
        {
            for ( int i = 0; i < Define.ROCK_TERRITORY.Length; i++ )
            {
                Debug.Log( Define.ROCK_TERRITORY[ i ] );
                lionIndex[ i ] = LION.index + Define.ROCK_TERRITORY[ i ];
            }
            canPredation = true;
            if ( GIRAFFE._giraffe.canMove == false )
            {
                targetAnimal = ZEBRA._zebra.animals;
            }
            else if ( ZEBRA._zebra.canMove == false )
            {
                targetAnimal = GIRAFFE._giraffe.animals;
            }
            else if ( !haveTargetAnimal )
            {
                randomTargetAnimal( );
                haveTargetAnimal = true;
            }
            canCheckIndex = true;
        }
        else
        {
            canPredation = false;
            targetAnimal = null;
            haveTargetAnimal = false;
        }
    }

    void TargetAnimalsIndex( )
    {
        if ( canCheckIndex )
        {
            if ( targetAnimal == ZEBRA._zebra.animals )
            {
                indexNum = ZEBRA.index;
                for ( int i = 0; i < Define.ROCK_TERRITORY.Length; i++ )
                {
                    itemIndex[ i ] = indexNum + Define.ROCK_TERRITORY[ i ];
                }
            }
            if ( targetAnimal == GIRAFFE._giraffe.animals )
            {
                indexNum = GIRAFFE.index;
                for ( int i = 0; i < Define.WOOD_TERRITORY.Length; i++ )
                {
                    itemIndex[ i ] = indexNum + Define.WOOD_TERRITORY[ i ];
                }
            }
            for ( int i = 0; i < lionIndex.Length; i++ )
            {
                A = lionIndex[ i ];
                for ( int e = 0; e < itemIndex.Length; e++ )
                {
                    B = itemIndex[ e ];
                    if ( A == B )
                    {
                        Debug.Log( "123" );
                    }
                }
            }
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

    void getItemsTutorial( )
    {

    }
}
