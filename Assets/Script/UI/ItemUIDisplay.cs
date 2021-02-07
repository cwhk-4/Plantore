using UnityEngine;

public class ItemUIDisplay : MonoBehaviour
{
    [SerializeField] private GameObject[] ItemUI;
    [SerializeField] private MapLevel map;

    [SerializeField] private int MapLevel;

    void Start()
    {
        MapLevel = map.getMapLevel( );
        SetItemDisplayLevel( );
    }

    public void SetMapLevel( int level )
    {
        MapLevel = level;
        SetItemDisplayLevel( );
    }

    public void SetItemDisplayLevel( )
    {
        for( int i = 0; i <= ItemUI.Length - 1; i++ )
        {
            ItemUI[i].SetActive( false );
        }

        ItemUI[MapLevel - 1].SetActive( true );
    }
}
