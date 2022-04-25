using UnityEngine;

public class AnimalInstantiate : MonoBehaviour
{
    [SerializeField] private Transform AnimalParent;
    [SerializeField] private Transform GridParent;
    [SerializeField] private Transform MainCamera;

    [SerializeField] private TimeController TimeController;
    [SerializeField] private MapLevel MapLevel;
    [SerializeField] private ReactionControl ReactionControl;

    [SerializeField] private GameObject[] Animals;
    [SerializeField] private MissionControl MissionControl;
    [SerializeField] private GridTerritoryControl GridTerritoryControl;

    private int nowItemType;
    private int nowItemIndex;
    private int animalNum;

    [SerializeField] private GameObject animalGO = null;

    //環境を置いたら→動物を呼ぶ
    public GameObject ItemCreated(int item_type, int index)
    {
        nowItemType = item_type;
        nowItemIndex = index;

        switch( nowItemType )
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

        GridParent.GetChild( index ).GetComponent<GridBase>( ).AddMainAnimal( animalGO );
        GridTerritoryControl.SetTerritory( animalGO, nowItemIndex, nowItemType, animalNum );

        return animalGO;
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
                InstantiateLeopard( );
            }
            else
            {
                InstantiateHyena( );
            }

        }
    }

    private void InstantiateZebra( )
    {
        var animal = Instantiate( Animals[(int)Define.ANIMAL.ZEBRA], AnimalParent.position , Quaternion.identity );
        animal.SetActive( false );
        animal.GetComponent<AnimalBase>( ).Init( ( int )Define.ANIMAL.ZEBRA, nowItemIndex, nowItemType,
                                                 GridParent, AnimalParent, MainCamera,
                                                 MapLevel, ReactionControl, MissionControl, TimeController );

        MissionControl.FoundHerbivore( );
        MissionControl.FoundAnimal( ( int )Define.ANIMAL.ZEBRA );

        animalGO = animal;
        animalNum = ( int )Define.ANIMAL.ZEBRA;
    }

    private void InstantiateLion( )
    {
        var animal = Instantiate( Animals[( int )Define.ANIMAL.LION], AnimalParent.position, Quaternion.identity );
        animal.SetActive( false );
        animal.GetComponent<AnimalBase>( ).Init( ( int )Define.ANIMAL.LION, nowItemIndex, nowItemType,
                                                 GridParent, AnimalParent, MainCamera,
                                                 MapLevel, ReactionControl, MissionControl, TimeController );

        MissionControl.FoundAnimal( ( int )Define.ANIMAL.LION );

        animalGO = animal;
        animalNum = ( int )Define.ANIMAL.LION;
    }

    private void InstantiateGiraffe( )
    {
        var animal = Instantiate( Animals[( int )Define.ANIMAL.GIRAFFE], AnimalParent.position, Quaternion.identity );
        animal.SetActive( false );
        animal.GetComponent<AnimalBase>( ).Init( ( int )Define.ANIMAL.GIRAFFE, nowItemIndex, nowItemType,
                                                 GridParent, AnimalParent, MainCamera,
                                                 MapLevel, ReactionControl, MissionControl, TimeController );

        MissionControl.FoundHerbivore( );
        MissionControl.FoundAnimal( ( int )Define.ANIMAL.GIRAFFE );

        animalGO = animal;
        animalNum = ( int )Define.ANIMAL.GIRAFFE;
    }

    private void InstantiateHyena( )
    {
        var animal = Instantiate( Animals[( int )Define.ANIMAL.HYENA], AnimalParent.position, Quaternion.identity );
        animal.SetActive( false );
        animal.GetComponent<AnimalBase>( ).Init( ( int )Define.ANIMAL.HYENA, nowItemIndex, nowItemType,
                                                 GridParent, AnimalParent, MainCamera,
                                                 MapLevel, ReactionControl, MissionControl, TimeController );

        MissionControl.FoundAnimal( ( int )Define.ANIMAL.HYENA );

        animalGO = animal;
        animalNum = ( int )Define.ANIMAL.HYENA;
    }

    private void InstantiateRhino( )
    {
        var animal = Instantiate( Animals[( int )Define.ANIMAL.RHINO], AnimalParent.position, Quaternion.identity );
        animal.SetActive( false );
        animal.GetComponent<AnimalBase>( ).Init( ( int )Define.ANIMAL.RHINO, nowItemIndex, nowItemType,
                                                 GridParent, AnimalParent, MainCamera,
                                                 MapLevel, ReactionControl, MissionControl, TimeController );

        MissionControl.FoundRhino( );
        MissionControl.FoundHerbivore( );
        MissionControl.FoundAnimal( ( int )Define.ANIMAL.RHINO );

        animalGO = animal;
        animalNum = ( int )Define.ANIMAL.RHINO;
    }

    private void InstantiateBuffalo( )
    {
        var animal = Instantiate( Animals[( int )Define.ANIMAL.BUFFALO], AnimalParent.position, Quaternion.identity );
        animal.SetActive( false );
        animal.GetComponent<AnimalBase>( ).Init( ( int )Define.ANIMAL.BUFFALO, nowItemIndex, nowItemType,
                                                 GridParent, AnimalParent, MainCamera,
                                                 MapLevel, ReactionControl, MissionControl, TimeController );

        MissionControl.FoundHerbivore( );
        MissionControl.FoundAnimal( ( int )Define.ANIMAL.BUFFALO );

        animalGO = animal;
        animalNum = ( int )Define.ANIMAL.BUFFALO;
    }

    private void InstantiateLeopard( )
    {
        var animal = Instantiate( Animals[( int )Define.ANIMAL.LEOPARD], AnimalParent.position, Quaternion.identity );
        animal.SetActive( false );
        animal.GetComponent<AnimalBase>( ).Init( ( int )Define.ANIMAL.LEOPARD, nowItemIndex, nowItemType,
                                                 GridParent, AnimalParent, MainCamera,
                                                 MapLevel, ReactionControl, MissionControl, TimeController );

        MissionControl.FoundAnimal( ( int )Define.ANIMAL.LEOPARD );

        animalGO = animal;
        animalNum = ( int )Define.ANIMAL.LEOPARD;
    }

    private void InstantiateElephant( )
    {
        var animal = Instantiate( Animals[( int )Define.ANIMAL.ELEPHANT], AnimalParent.position, Quaternion.identity );
        animal.SetActive( false );
        animal.GetComponent<AnimalBase>( ).Init( ( int )Define.ANIMAL.ELEPHANT, nowItemIndex, nowItemType,
                                                 GridParent, AnimalParent, MainCamera,
                                                 MapLevel, ReactionControl, MissionControl, TimeController );

        MissionControl.FoundElephant( );
        MissionControl.FoundHerbivore( );
        MissionControl.FoundAnimal( ( int )Define.ANIMAL.ELEPHANT );

        animalGO = animal;
        animalNum = ( int )Define.ANIMAL.ELEPHANT;
    }
}
