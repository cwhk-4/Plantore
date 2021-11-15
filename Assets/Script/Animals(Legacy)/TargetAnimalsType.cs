using System.Collections.Generic;
using UnityEngine;

public class TargetAnimalsType : MonoBehaviour
{
    public static bool canPredation;
    public static GameObject targetAnimal;
    [SerializeField] private bool haveTargetAnimal;
    private bool canCheckIndex;
    private List<int> lionIndex = new List<int>( );
    private List<int> itemIndex = new List<int>( );
    private int indexNum;

    private int A;
    private int B;
    private bool canadd;
    int i;

    void Start()
    {
        canCheckIndex = false;
        canadd = true;
    }

    void Update()
    {
        chouceTragetAnimal( );
        TargetAnimalsIndex( );
        Debug.Log( LION.indexIn );
        Debug.Log( "lion " + LION._lion.canMove );
        Debug.Log( "zebra " + ZEBRA._zebra.canMove );
        Debug.Log( "target" + targetAnimal );
    }

    void chouceTragetAnimal( )
    {
        if ( LION._lion.canMove && ( ZEBRA._zebra.canMove || GIRAFFE._giraffe.canMove ) )
        {
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
            canCheckIndex = false;
            canadd = true;
            A = B = 0;
            itemIndex.Clear( );
            lionIndex.Clear( );
        }
    }

    void TargetAnimalsIndex( )
    {
        if ( canCheckIndex )
        {
            if ( canadd )
            {
                for ( int i = 0; i < ItemData.SMALL_ROCK_TERRITORY.Length; i++ )
                {
                    lionIndex.Add( LION.indexIn + ItemData.SMALL_ROCK_TERRITORY[ i ] );
                    Debug.Log( "lion  " + lionIndex[ i ] );
                }

                if ( targetAnimal == ZEBRA._zebra.animals )
                {
                    indexNum = ZEBRA.indexIn;

                    for ( int i = 0; i < ItemData.GRASS_TERRITORY.Length; i++ )
                    {
                        itemIndex.Add( indexNum + ItemData.GRASS_TERRITORY[ i ] );
                        Debug.Log( "zebra  " + itemIndex[ i ] );
                    }
                }

                if ( targetAnimal == GIRAFFE._giraffe.animals )
                {
                    indexNum = GIRAFFE.index;
                    for ( int i = 0; i < ItemData.WOOD_TERRITORY.Length; i++ )
                    {
                        itemIndex.Add( indexNum + ItemData.WOOD_TERRITORY[ i ] );
                    }
                }
                canadd = false;
            }
            for ( int i = 0; i < lionIndex.Count; i++ )
            {
                A = lionIndex[ i ];
                for ( int e = 0; e < itemIndex.Count; e++ )
                {
                    B = itemIndex[ e ];
                    if ( A == B )
                    {
                        canPredation = true;
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
}
