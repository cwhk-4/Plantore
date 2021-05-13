using UnityEngine;
using UnityEngine.SceneManagement;

public class GridColorControl : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    [SerializeField] private Color available;
    [SerializeField] private Color notAvailble;

    private int xCount;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>( );
        spriteRenderer.color = Color.clear;
        setXCount( );
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

    private bool CheckRange( )
    {
        var mapLevel = 1;

        if( SceneManager.GetActiveScene( ).name == "Stage" )
        {
            mapLevel = FindObjectOfType<MapLevel>( ).getMapLevel( );
        }

        var GridNum = this.transform.GetSiblingIndex( );

        var x = FindObjectOfType<MapLevel>( ).GetNowMapXCount( );
        var y = FindObjectOfType<MapLevel>( ).GetNowMapYCount( ); ;

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
