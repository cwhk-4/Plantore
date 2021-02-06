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
    }

    public void setXCount( int count )
    {
        xCount = count;
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
