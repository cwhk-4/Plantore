using UnityEngine;

public class TutorialIMController : MonoBehaviour
{
    [SerializeField] private TimeController timeController;
    [SerializeField] private TutorialMapLevel MapLevel;

    [SerializeField] private bool isInstantiating = false;
    [SerializeField] private bool isMoving = false;

    [SerializeField] private float startingTime;
    [SerializeField] private float movingStartingTime;
    [SerializeField] private string GOName;

    [SerializeField] private GameObject GridInstan;
    [SerializeField] private int nowGridNum;
    [SerializeField] private int xCount;

    private int mapLevel;

    public void StartInstantiate( )
    {
        isInstantiating = true;
    }

    public void FinishInstantiate( )
    {
        var isInstantiate = isInstantiating;
        isInstantiating = false;
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

    public int GetXCount( )
    {
        return xCount;
    }

    public bool CheckThisGrid( )
    {
        var GridNum = nowGridNum;

        return GridInstan.transform.GetChild( GridNum ).childCount == 0 && CheckOutOfRange( GridNum );
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
