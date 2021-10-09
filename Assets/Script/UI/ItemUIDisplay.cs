using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemUIDisplay : MonoBehaviour
{
    [SerializeField] private ItemStorage storage;

    [SerializeField] private Transform ItemUI;
    [SerializeField] private GameObject[] Items;
    [SerializeField] private Button[] ItemButtons;
    [SerializeField] private MapLevel map;

    private int level1Limit = 3;
    private int level2Limit = 5;
    private int level3Limit = 6;
    [SerializeField] private int totalNum;

    [SerializeField] private MapLevel Map;
    [SerializeField] private int mapLevel;

    void Start()
    {
        mapLevel = map.getMapLevel( );
        Init( );
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
                SetItemLimit( level1Limit );
                break;

            case 2:
                SetItemVisibility( level2Limit );
                SetItemLimit( level2Limit );
                break;

            case 3:
                SetItemVisibility( level3Limit );
                SetItemLimit( level3Limit );
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

    private void SetItemLimit( int limit )
    {
        for( int i = 0; i < totalNum; i++ )
        {
            if( i < limit )
            {
                var remain = ItemData.ITEM_LIMIT[mapLevel - 1, i] - storage.GetNumOfItemPlaced( i );
                Items[i].transform.GetChild( 2 ).GetComponent<TMP_Text>( ).text = "x " + remain;

                if( remain == 0 )
                {
                    ItemButtons[i].interactable = false;
                }
            }
        }
    }
}
