using UnityEngine;

public class InstantiateMoveControl : MonoBehaviour
{
    [SerializeField] private TimeController timeController;
    [SerializeField] private MissionControl MissionControl;
    [SerializeField] private MapLevel MapLevel;

    [SerializeField] private bool isInstantiating = false;
    [SerializeField] private bool isMoving = false;

    [SerializeField] private float startingTime;
    [SerializeField] private float movingStartingTime;
    [SerializeField] private string GOName;

    [SerializeField] private GameObject GridInstan;
    [SerializeField] private int nowGridNum;
    [SerializeField] private int xCount;
    [SerializeField] private GameObject extraGrid;

    private int mapLevel;

    public void StartInstantiate( )
    {
        isInstantiating = true;
    }

    public void FinishInstantiate( )
    {
        var isInstantiate = isInstantiating;
        isInstantiating = false;

        if( isInstantiate )
        {
            MissionControl.PlacedItem( );
        }
    }

    public bool GetIsInstantiating( )
    {
        return isInstantiating;
    }

    public void StartMoving( float time )
    {
        isMoving = true;
        startingTime = time;
    }

    public void FinishMoving( )
    {
        isMoving = false;
    }

    public bool GetIsMoving( )
    {
        return isMoving;
    }

    public float GetStartingTime( )
    {
        return startingTime;
    }

    public void setGOName( string str )
    {
        GOName = str;
    }

    public string getGOName( )
    {
        return GOName;
    }

    public void setNowGrid( int num )
    {
        nowGridNum = num;
    }

    public void setXCount( int num )
    {
        xCount = num;
    }

    public void InstanWoodExtraGrid( )
    {
        var item = Instantiate( extraGrid, Vector3.zero, Quaternion.identity );
        item.transform.SetParent( GridInstan.transform.GetChild( nowGridNum + xCount ) );
        item.transform.position = GridInstan.transform.GetChild( nowGridNum + xCount ).position;
        item.tag = "WoodExtra";
    }

    public void InstanGrasslandExtraGrid( )
    {
        var item = Instantiate( extraGrid, Vector3.zero, Quaternion.identity );
        item.transform.SetParent( GridInstan.transform.GetChild( nowGridNum - 1 ) );
        item.transform.position = GridInstan.transform.GetChild( nowGridNum - 1 ).position;
        item.tag = "GrasslandExtra";
    }

    public void InstanMarshExtraGrid( )
    {
        var itemA = Instantiate( extraGrid, Vector3.zero, Quaternion.identity );
        itemA.transform.SetParent( GridInstan.transform.GetChild( nowGridNum - 1 ) );
        itemA.transform.position = GridInstan.transform.GetChild( nowGridNum - 1 ).position;
        itemA.tag = "MarshExtra";

        var itemB = Instantiate( extraGrid, Vector3.zero, Quaternion.identity );
        itemB.transform.SetParent( GridInstan.transform.GetChild( nowGridNum + xCount ) );
        itemB.transform.position = GridInstan.transform.GetChild( nowGridNum + xCount ).position;
        itemB.tag = "MarshExtra";

        var itemC = Instantiate( extraGrid, Vector3.zero, Quaternion.identity );
        itemC.transform.SetParent( GridInstan.transform.GetChild( nowGridNum + xCount - 1) );
        itemC.transform.position = GridInstan.transform.GetChild( nowGridNum + xCount ).position;
        itemC.tag = "MarshExtra";
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
        }
    }

    public bool CheckWoodGrid( )
    {
        var GridNum = nowGridNum + xCount;

        return GridInstan.transform.GetChild( GridNum ).childCount == 0 && CheckOutOfRange( GridNum );
    }

    public bool CheckGrasslandGrid( )
    {
        var GridNum = nowGridNum - 1;
        return GridInstan.transform.GetChild( GridNum ).childCount == 0 && CheckOutOfRange( GridNum );
    }

    public bool CheckMarshGrid( )
    {
        var flag = false;

        if( GridInstan.transform.GetChild( nowGridNum - 1 ).childCount == 0 && CheckOutOfRange( nowGridNum - 1 ) )
        {
            if( GridInstan.transform.GetChild( nowGridNum + xCount ).childCount == 0 && CheckOutOfRange( nowGridNum + xCount ) )
            {
                if( GridInstan.transform.GetChild( nowGridNum + xCount - 1 ).childCount == 0 && CheckOutOfRange( nowGridNum + xCount - 1 ) )
                {
                    flag = true;
                }
            }
        }

        return flag;
    }

    private bool CheckOutOfRange( int GridNum )
    {
        mapLevel = MapLevel.getMapLevel( );

        var x = 3 + mapLevel;
        var y = 2 + mapLevel;

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
