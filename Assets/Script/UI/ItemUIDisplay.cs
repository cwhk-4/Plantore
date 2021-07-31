using UnityEngine;
using UnityEngine.UI;

public class ItemUIDisplay : MonoBehaviour
{
    [SerializeField] private Transform ItemUI;
    [SerializeField] private GameObject[] Items;
    [SerializeField] private Button[] ItemButtons;
    [SerializeField] private MapLevel map;

    [SerializeField] private int level1Limit = 3;
    [SerializeField] private int level2Limit = 5;
    [SerializeField] private int level3Limit = 7;
    [SerializeField] private int level4Limit = 9;
    [SerializeField] private int totalNum;

    [SerializeField] private MapLevel Map;
    [SerializeField] private int mapLevel;

    void Start()
    {
        mapLevel = map.getMapLevel( );
        Init( );
        SetItemDisplayLevel( );
    }

    private void Init( )
    {
        totalNum = ( int )Define.ITEM.TOTAL_NUM;

        if( ( int )Define.ITEM.TOTAL_NUM % 2 != 0 )
        {
            totalNum += 1;
        }

        Items = new GameObject[totalNum];
        ItemButtons = new Button[totalNum];

        for( int i = 0; i < totalNum; i++ )
        {
            Items[i] = ItemUI.GetChild( i ).GetChild(0).gameObject;
            ItemButtons[i] = ItemUI.GetChild( i ).GetComponent<Button>( );
        }
    }

    public void SetMapLevel( int level )
    {
        mapLevel = level;
        SetItemDisplayLevel( );
    }

    public void SetItemDisplayLevel( )
    {
        mapLevel = Map.getMapLevel( );

        switch( mapLevel )
        {
            case 1:
                SetItemVisibility( level1Limit );
                break;

            case 2:
                SetItemVisibility( level2Limit );
                break;

            case 3:
                SetItemVisibility( level3Limit );
                break;

            case 4:
                SetItemVisibility( level4Limit );
                break;
        }
    }

    private void SetItemVisibility( int limit )
    {
        for( int i = 0; i < totalNum; i++ )
        {
            if( i < limit )
            {
                Items[i].SetActive( true );
                ItemButtons[i].interactable = true;
            }
            else
            {
                Items[i].SetActive( false );
                ItemButtons[i].interactable = false;
            }
        }
    }
}
