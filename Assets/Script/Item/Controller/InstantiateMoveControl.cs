using UnityEngine;
using UnityEngine.UI;

public class InstantiateMoveControl : MonoBehaviour
{
    [SerializeField] private MissionControl missionControl;
    [SerializeField] private MapLevel mapLevel;

    [SerializeField] private bool isInstantiating = false;
    [SerializeField] private bool isMoving = false;

    [SerializeField] private float startingTime;
    [SerializeField] private int GOItemNum;

    [SerializeField] private GameObject gridInstan;
    [SerializeField] private int nowGridNum;
    [SerializeField] private int xCount;
    [SerializeField] private GameObject extraGrid;

    [SerializeField] private Button rubbishBin;

    [SerializeField] private GameObject stageUI;

    private void Start( )
    {
        rubbishBin.gameObject.SetActive( false );
        xCount = Define.XCOUNT;
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
        SetUIActive( false );
    }

    public void FinishInstantiate( )
    {
        var isInstantiate = isInstantiating;
        isInstantiating = false;

        if( isInstantiate )
        {
            missionControl.PlacedItem( );
        }

        SetUIActive( true );
    }

    public bool GetIsInstantiating( )
    {
        return isInstantiating;
    }

    public void StartMoving( float time )
    {
        isMoving = true;
        startingTime = time;
        SetUIActive( false );
    }

    public void FinishMoving( )
    {
        isMoving = false;
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

    private void InstanWoodExtraGrid( )
    {
        for( int i = 1; i < Define.WOOD_SIZE.Length; i++ )
        {
            var item = Instantiate( extraGrid, Vector3.zero, Quaternion.identity );
            item.transform.SetParent( gridInstan.transform.GetChild( nowGridNum + Define.WOOD_SIZE[i] ) );
            item.transform.position = gridInstan.transform.GetChild( nowGridNum + Define.WOOD_SIZE[i] ).position;
            item.tag = "WoodExtra";
        } 
    }

    private void InstanGrasslandExtraGrid( )
    {
        for( int i = 1; i < Define.GRASSLAND_SIZE.Length; i++ )
        {
            var item = Instantiate( extraGrid, Vector3.zero, Quaternion.identity );
            item.transform.SetParent( gridInstan.transform.GetChild( nowGridNum + Define.GRASSLAND_SIZE[i] ) );
            item.transform.position = gridInstan.transform.GetChild( nowGridNum + Define.GRASSLAND_SIZE[i] ).position;
            item.tag = "GrasslandExtra";
        }
    }

    private void InstanMarshExtraGrid( )
    {
        for( int i = 1; i < Define.MARSH_SIZE.Length; i++ )
        {
            var item = Instantiate( extraGrid, Vector3.zero, Quaternion.identity );
            item.transform.SetParent( gridInstan.transform.GetChild( nowGridNum + Define.MARSH_SIZE[i] ) );
            item.transform.position = gridInstan.transform.GetChild( nowGridNum + Define.MARSH_SIZE[i] ).position;
            item.tag = "MarshExtra";
        }
    }

    private void InstanRockExtraGrid( )
    {
        for( int i = 1; i < Define.ROCK_SIZE.Length; i++ )
        {
            var item = Instantiate( extraGrid, Vector3.zero, Quaternion.identity );
            item.transform.SetParent( gridInstan.transform.GetChild( nowGridNum + Define.ROCK_SIZE[i] ) );
            item.transform.position = gridInstan.transform.GetChild( nowGridNum + Define.ROCK_SIZE[i] ).position;
            item.tag = "RockExtra";
        }
    }

    public void InstantiateExtraGrid( string GO_NAME )
    {
        switch( GO_NAME )
        {
            case "wood_Instan(Clone)":
                InstanWoodExtraGrid( );
                break;

            case "grassland_Instan(Clone)":
                InstanGrasslandExtraGrid( );
                break;

            case "marsh_Instan(Clone)":
                InstanMarshExtraGrid( );
                break;

            case "rock_Instan(Clone)":
                InstanRockExtraGrid( );
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

    public bool CheckGrasslandGrid( )
    {
        var GridNum = nowGridNum - 1;
        return gridInstan.transform.GetChild( GridNum ).childCount == 0 && CheckOutOfRange( GridNum );
    }

    public bool CheckMarshGrid( )
    {
        var flag = false;

        if( gridInstan.transform.GetChild( nowGridNum - 1 ).childCount == 0 && CheckOutOfRange( nowGridNum - 1 ) )
        {
            if( gridInstan.transform.GetChild( nowGridNum + xCount ).childCount == 0 && CheckOutOfRange( nowGridNum + xCount ) )
            {
                if( gridInstan.transform.GetChild( nowGridNum + xCount - 1 ).childCount == 0 && CheckOutOfRange( nowGridNum + xCount - 1 ) )
                {
                    flag = true;
                }
            }
        }

        return flag;
    }

    //caution
    public bool CheckRockGrid( )
    {
        var flag = false;

        if( gridInstan.transform.GetChild( nowGridNum - 1 ).childCount == 0 && CheckOutOfRange( nowGridNum - 1 ) )
        {
            if( gridInstan.transform.GetChild( nowGridNum + xCount ).childCount == 0 && CheckOutOfRange( nowGridNum + xCount ) )
            {
                if( gridInstan.transform.GetChild( nowGridNum + xCount - 1 ).childCount == 0 && CheckOutOfRange( nowGridNum + xCount - 1 ) )
                {
                    flag = true;
                }
            }
        }

        return flag;
    }

    public bool CheckGrids( int itemNum )
    {
        var flag = false;

        switch( itemNum )
        {
            case (int)Define.ITEM.WOOD:
                flag = CheckWoodGrid( );
                break;

            case ( int )Define.ITEM.GRASSLAND:
                flag = CheckGrasslandGrid( );
                break;

            case ( int )Define.ITEM.MARSH:
                flag = CheckMarshGrid( );
                break;

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
