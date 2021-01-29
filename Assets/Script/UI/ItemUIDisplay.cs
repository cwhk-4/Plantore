using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUIDisplay : MonoBehaviour
{
    [SerializeField] private GameObject[] ItemUI;
    [SerializeField] private MapLevel map;

    private int MapLevel;

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

    private void SetItemDisplayLevel( )
    {
        for( int i = 0; i < ItemUI.Length - 1; i++ )
        {
            ItemUI[i].SetActive( false );
        }

        ItemUI[MapLevel - 1].SetActive( true );
    }
}
