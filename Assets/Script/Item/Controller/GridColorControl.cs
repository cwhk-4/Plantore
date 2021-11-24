using UnityEngine;
using UnityEngine.SceneManagement;

public class GridColorControl : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private MapLevel mapLevel;

    [SerializeField] private Color available;
    [SerializeField] private Color notAvailble;
    [SerializeField] private Color territory;

    private int xCount;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>( );
        spriteRenderer.color = Color.clear;
        setXCount( );
        mapLevel = FindObjectOfType<MapLevel>( );
    }

    public void setXCount( )
    {
        xCount = Define.XCOUNT;
    }

    public void EnableAvailability( )
    {
        if( CheckRange( ) )
        {
            if( this.transform.childCount != 0 )
            {
                spriteRenderer.color = notAvailble;
            }
            else
            {
                spriteRenderer.color = available;
            }
        }
        else
        {
            DisableAvailability( );
        }
    }

    public void DisableAvailability( )
    {
        spriteRenderer.color = Color.clear;
    }

    public void EnableTerritories( )
    {
        if( CheckRange( ) )
        {
            spriteRenderer.color = territory;
        }
        else
        {
            DisableAvailability( );
        }
    }

    private bool CheckRange( )
    {
        var level = 1;

        if( SceneManager.GetActiveScene( ).name == "Stage" )
        {
            level = mapLevel.GetMapLevel( );
        }

        var GridNum = this.transform.GetSiblingIndex( );

        var x = mapLevel.GetNowMapXCount( );
        var y = mapLevel.GetNowMapYCount( ); ;

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
