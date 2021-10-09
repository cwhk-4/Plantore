using UnityEngine;

public class AnimalInstantiate : MonoBehaviour
{
    [SerializeField] private GameObject AnimalParent;
    [SerializeField] private GameObject[] Animals;

    private int now_item_type;
    private int now_item_index;

    public void ItemCreated(int item_type, int index)
    {
        now_item_type = item_type;
        now_item_index = index;

        switch( now_item_type )
        {
            case ( int )Define.ITEM.GRASS:
                InstantiateZebra( );
                break;

            case ( int )Define.ITEM.WOOD:
                InstantiateGiraffe( );
                break;

            case ( int )Define.ITEM.SMALL_ROCK:
                InstantiateLion( );
                break;

            case ( int )Define.ITEM.GRASSLAND:
                GrasslandCreated( );
                break;

            case ( int )Define.ITEM.MARSH:
                MarshCreated( );
                break;

            case ( int )Define.ITEM.ROCK:
                RockCreated( );
                break;
        }
    }

    private void GrasslandCreated( )
    {
        int rand = Random.Range( 1, 11 );

        if( rand <= 2 )
        {
            InstantiateGiraffe( );
        }
        else
        {
            if( rand <= 5 )
            {
                InstantiateZebra( );
            }
            else
            {
                InstantiateBuffalo( );
            }

        }
    }

    private void MarshCreated( )
    {
        int rand = Random.Range( 1, 11 );

        if( rand <= 4 )
        {
            InstantiateRhino( );
        }
        else
        {
            InstantiateElephant( );

        }
    }

    private void RockCreated( )
    {
        int rand = Random.Range( 1, 11 );

        if( rand <= 2 )
        {
            InstantiateLion( );
        }
        else
        {
            if( rand <= 6 )
            {
                InstantiatePanther( );
            }
            else
            {
                InstantiateHyena( );
            }

        }
    }

    private void InstantiateZebra( )
    {
        var animal = Instantiate( Animals[(int)Define.ANIMAL.ZEBRA], AnimalParent.transform.position , Quaternion.identity );
        animal.SetActive( false );
        animal.GetComponent<AnimalBase>( ).Init( ( int )Define.ANIMAL.ZEBRA , now_item_index);
    }

    private void InstantiateLion( )
    {
        var animal = Instantiate( Animals[( int )Define.ANIMAL.LION], AnimalParent.transform.position, Quaternion.identity );
        animal.SetActive( false );
        animal.GetComponent<AnimalBase>( ).Init( ( int )Define.ANIMAL.ZEBRA, now_item_index );
    }

    private void InstantiateGiraffe( )
    {
        var animal = Instantiate( Animals[( int )Define.ANIMAL.GIRAFFE], AnimalParent.transform.position, Quaternion.identity );
        animal.SetActive( false );
        animal.GetComponent<AnimalBase>( ).Init( ( int )Define.ANIMAL.ZEBRA, now_item_index );
    }

    private void InstantiateHyena( )
    {
        var animal = Instantiate( Animals[( int )Define.ANIMAL.HYENA], AnimalParent.transform.position, Quaternion.identity );
        animal.SetActive( false );
        animal.GetComponent<AnimalBase>( ).Init( ( int )Define.ANIMAL.ZEBRA, now_item_index );
    }

    private void InstantiateRhino( )
    {
        var animal = Instantiate( Animals[( int )Define.ANIMAL.RHINO], AnimalParent.transform.position, Quaternion.identity );
        animal.SetActive( false );
        animal.GetComponent<AnimalBase>( ).Init( ( int )Define.ANIMAL.ZEBRA, now_item_index );
    }

    private void InstantiateBuffalo( )
    {
        var animal = Instantiate( Animals[( int )Define.ANIMAL.BUFFALO], AnimalParent.transform.position, Quaternion.identity );
        animal.SetActive( false );
        animal.GetComponent<AnimalBase>( ).Init( ( int )Define.ANIMAL.ZEBRA, now_item_index );
    }

    private void InstantiatePanther( )
    {
        var animal = Instantiate( Animals[( int )Define.ANIMAL.LEOPARD], AnimalParent.transform.position, Quaternion.identity );
        animal.SetActive( false );
        animal.GetComponent<AnimalBase>( ).Init( ( int )Define.ANIMAL.ZEBRA, now_item_index );
    }

    private void InstantiateElephant( )
    {
        var animal = Instantiate( Animals[( int )Define.ANIMAL.ELEPHANT], AnimalParent.transform.position, Quaternion.identity );
        animal.SetActive( false );
        animal.GetComponent<AnimalBase>( ).Init( ( int )Define.ANIMAL.ZEBRA, now_item_index );
    }
}
