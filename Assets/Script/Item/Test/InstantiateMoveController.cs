using UnityEngine;

public class InstantiateMoveController : MonoBehaviour
{
    [SerializeField] private TimeController timeController;

    [SerializeField] private bool isInstantiating = false;
    [SerializeField] private bool isMoving = false;

    [SerializeField] private float startingTime;
    [SerializeField] private float movingStartingTime;
    [SerializeField] private string GOName;

    [SerializeField] private GameObject GridInstan;
    [SerializeField] private int nowGridNum;
    [SerializeField] private int xCount;
    [SerializeField] private GameObject extraGrid;

    public void StartInstantiate( )
    {
        isInstantiating = true;
    }

    public void FinishInstantiate( )
    {
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

    public void InstanWoodExtraGrid( )
    {
        var item = Instantiate( extraGrid, Vector3.zero, Quaternion.identity );
        item.transform.SetParent( GridInstan.transform.GetChild( nowGridNum + xCount ) );
        item.transform.position = GridInstan.transform.GetChild( nowGridNum + xCount ).position;
    }

    public bool checkWoodGrid( )
    {
        return GridInstan.transform.GetChild( nowGridNum + xCount ).childCount == 0;
    }
}
