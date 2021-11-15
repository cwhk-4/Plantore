using UnityEngine;
using UnityEngine.UI;

public class InstantiateMoveControl : MonoBehaviour
{
    [SerializeField] private MissionControl missionControl;
    [SerializeField] private MapLevel mapLevel;
    [SerializeField] private AnimalInstantiate animalInstantiate;
    [SerializeField] private GridTerritoryControl GridTerritoryControl;

    [SerializeField] private bool isInstantiating = false;
    [SerializeField] private bool isMoving = false;

    [SerializeField] private float startingTime;
    [SerializeField] private int GOItemNum;

    [SerializeField] private GameObject gridInstan;
    [SerializeField] private int nowGridNum;
    [SerializeField] private int xCount;
    [SerializeField] private GameObject extraGrid;

    [SerializeField] private GameObject movingAnimal;

    [SerializeField] private Button rubbishBin;

    [SerializeField] private GameObject stageUI;

    private void Start( )
    {
        rubbishBin.gameObject.SetActive( false );
        xCount = Define.XCOUNT;
        movingAnimal = null;
    }

    private void Update( )
    {
        if( isInstantiating || isMoving )
        {
            rubbishBin.gameObject.SetActive( true );
        }
        else
        {
            rubbishBin.gameObject.SetActive( false );
        }
    }

    private void SetUIActive( bool flag )
    {
        stageUI.SetActive( flag );
    }

    public void StartInstantiate( )
    {
        isInstantiating = true;
        Time.timeScale = 0;
        SetUIActive( false );
    }

    public void FinishedByInstan( )
    {
        Time.timeScale = 1;

        missionControl.PlacedItem( );

        animalInstantiate.ItemCreated( GOItemNum, nowGridNum );
    }

    public void FinishInstantiate( )
    {
        isInstantiating = false;

        Time.timeScale = 1;
        SetUIActive( true );
    }

    public bool GetIsInstantiating( )
    {
        return isInstantiating;
    }

    public void StartMoving( float time, GameObject GO )
    {
        isMoving = true;

        movingAnimal = GO;

        startingTime = time;
        Time.timeScale = 0;
        SetUIActive( false );
    }

    public void FinishMoving( int targetIndex )
    {
        isMoving = false;

        var animalNum = movingAnimal.GetComponent<AnimalBase>( ).GetAnimalNum( );
        GridTerritoryControl.SetTerritory( movingAnimal, targetIndex, GOItemNum, animalNum );

        movingAnimal.GetComponent<AnimalBase>( ).EnvironmentMoved( targetIndex );
        movingAnimal = null;

        Time.timeScale = 1;
        SetUIActive( true );
    }

    public bool GetIsMoving( )
    {
        return isMoving;
    }

    public float GetStartingTime( )
    {
        return startingTime;
    }

    public void setGOItemNum( int itemNum )
    {
        GOItemNum = itemNum;
    }

    public int getGOItemNum( )
    {
        return GOItemNum;
    }

    public void setNowGrid( int num )
    {
        nowGridNum = num;
    }

    private void InstanWoodExtraGrid( GameObject ExtraParent )
    {
        for( int i = 1; i < ItemData.WOOD_SIZE.Length; i++ )
        {
            var item = Instantiate( extraGrid, Vector3.zero, Quaternion.identity );
            item.transform.SetParent( gridInstan.transform.GetChild( nowGridNum + ItemData.WOOD_SIZE[i] ) );
            item.transform.position = gridInstan.transform.GetChild( nowGridNum + ItemData.WOOD_SIZE[i] ).position;
            item.GetComponent<ExtraGridBase>( ).SetParent( ExtraParent );
        } 
    }

    private void InstanSmallRockExtraGrid( GameObject ExtraParent )
    {
        for( int i = 1; i < ItemData.SMALL_ROCK_SIZE.Length; i++ )
        {
            var item = Instantiate( extraGrid, Vector3.zero, Quaternion.identity );
            item.transform.SetParent( gridInstan.transform.GetChild( nowGridNum + ItemData.SMALL_ROCK_SIZE[i] ) );
            item.transform.position = gridInstan.transform.GetChild( nowGridNum + ItemData.SMALL_ROCK_SIZE[i] ).position;
            item.GetComponent<ExtraGridBase>( ).SetParent( ExtraParent );
        }
    }

    private void InstanGrasslandExtraGrid( GameObject ExtraParent )
    {
        for( int i = 1; i < ItemData.GRASSLAND_SIZE.Length; i++ )
        {
            var item = Instantiate( extraGrid, Vector3.zero, Quaternion.identity );
            item.transform.SetParent( gridInstan.transform.GetChild( nowGridNum + ItemData.GRASSLAND_SIZE[i] ) );
            item.transform.position = gridInstan.transform.GetChild( nowGridNum + ItemData.GRASSLAND_SIZE[i] ).position;
            item.GetComponent<ExtraGridBase>( ).SetParent( ExtraParent );
        }
    }

    private void InstanMarshExtraGrid( GameObject ExtraParent )
    {
        for( int i = 1; i < ItemData.MARSH_SIZE.Length; i++ )
        {
            var item = Instantiate( extraGrid, Vector3.zero, Quaternion.identity );
            item.transform.SetParent( gridInstan.transform.GetChild( nowGridNum + ItemData.MARSH_SIZE[i] ) );
            item.transform.position = gridInstan.transform.GetChild( nowGridNum + ItemData.MARSH_SIZE[i] ).position;
            item.GetComponent<ExtraGridBase>( ).SetParent( ExtraParent );
        }
    }

    private void InstanRockExtraGrid( GameObject ExtraParent )
    {
        for( int i = 1; i < ItemData.ROCK_SIZE.Length; i++ )
        {
            var item = Instantiate( extraGrid, Vector3.zero, Quaternion.identity );
            item.transform.SetParent( gridInstan.transform.GetChild( nowGridNum + ItemData.ROCK_SIZE[i] ) );
            item.transform.position = gridInstan.transform.GetChild( nowGridNum + ItemData.ROCK_SIZE[i] ).position;
            item.GetComponent<ExtraGridBase>( ).SetParent( ExtraParent );
        }
    }

    public void InstantiateExtraGrid( int itemNum, GameObject ExtraParent )
    {
        switch( itemNum )
        {
            //Lv 1
            case ( int )Define.ITEM.WOOD:
                InstanWoodExtraGrid( ExtraParent );
                break;

            case ( int )Define.ITEM.SMALL_ROCK:
                InstanSmallRockExtraGrid( ExtraParent  );
                break;

            //Lv 2
            case ( int )Define.ITEM.GRASSLAND:
                InstanGrasslandExtraGrid( ExtraParent );
                break;

            case ( int )Define.ITEM.MARSH:
                InstanMarshExtraGrid( ExtraParent );
                break;

            //Lv 3
            case ( int )Define.ITEM.ROCK:
                InstanRockExtraGrid( ExtraParent );
                break;
        }
    }

    public bool CheckThisGrid( )
    {
        var GridNum = nowGridNum;

        return gridInstan.transform.GetChild( GridNum ).childCount == 0 && CheckOutOfRange( GridNum );
    }

    public bool CheckWoodGrid( )
    {
        var GridNum = nowGridNum + xCount;

        return gridInstan.transform.GetChild( GridNum ).childCount == 0 && CheckOutOfRange( GridNum );
    }

    public bool CheckSmallRockGrid( )
    {
        var flag = false;

        for( int i = 1; i < ItemData.SMALL_ROCK_SIZE.Length; i++ )
        {
            var ExtraNum = nowGridNum + ItemData.SMALL_ROCK_SIZE[i];

            if( ExtraNum < 0 || ExtraNum > Define.YCOUNT * xCount )
            {
                return false;
            }

            if( gridInstan.transform.GetChild( ExtraNum ).childCount == 0 && CheckOutOfRange( ExtraNum ) )
            {
                flag = true;
            }
            else
            {
                return false;
            }
        }

        return flag;
    }

    public bool CheckGrasslandGrid( )
    {
        var GridNum = nowGridNum - 1;
        return gridInstan.transform.GetChild( GridNum ).childCount == 0 && CheckOutOfRange( GridNum );
    }

    public bool CheckMarshGrid( )
    {
        var flag = false;

        for( int i = 1; i < ItemData.MARSH_SIZE.Length; i++ )
        {
            if( gridInstan.transform.GetChild( nowGridNum + ItemData.MARSH_SIZE[i] ).childCount == 0 && CheckOutOfRange( nowGridNum + ItemData.ROCK_SIZE[i] ) )
            {
                flag = true;
            }
            else
            {
                return false;
            }
        }

        return flag;
    }

    public bool CheckRockGrid( )
    {
        var flag = false;

        for( int i = 1; i < ItemData.ROCK_SIZE.Length; i++ )
        {
            if( gridInstan.transform.GetChild( nowGridNum + ItemData.ROCK_SIZE[i] ).childCount == 0 && CheckOutOfRange( nowGridNum + ItemData.ROCK_SIZE[i] ) )
            {
                flag = true;
            }
            else
            {
                return false;
            }
        }

        return flag;
    }

    public bool CheckGrids( int itemNum )
    {
        var flag = false;

        switch( itemNum )
        {
            //Lv 1
            case (int)Define.ITEM.WOOD:
                flag = CheckWoodGrid( );
                break;

            case ( int )Define.ITEM.SMALL_ROCK:
                flag = CheckSmallRockGrid( );
                break;

            //Lv 2
            case ( int )Define.ITEM.GRASSLAND:
                flag = CheckGrasslandGrid( );
                break;

            case ( int )Define.ITEM.MARSH:
                flag = CheckMarshGrid( );
                break;

            //Lv 3
            case ( int )Define.ITEM.ROCK:
                flag = CheckRockGrid( );
                break;
        }

        return flag;
    }

    private bool CheckOutOfRange( int GridNum )
    {
        var x = mapLevel.GetNowMapXCount( );
        var y = mapLevel.GetNowMapYCount( );

        if( GridNum % xCount < x )
        {
            if( GridNum / xCount < y )
            {
                return true;
            }
        }

        return false;
    }
}
