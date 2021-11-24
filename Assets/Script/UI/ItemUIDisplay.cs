using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemUIDisplay : MonoBehaviour
{
    [SerializeField] private ItemStorage storage;

    [SerializeField] private Transform ItemUI;
    [SerializeField] private GameObject[] Items;
    [SerializeField] private Button[] ItemButtons;
    [SerializeField] private Image[] ItemButtonsImage;
    [SerializeField] private MapLevel map;

    private int level1Limit = 3;
    private int level2Limit = 5;
    private int level3Limit = 6;
    [SerializeField] private int totalNum;

    [SerializeField] private MapLevel Map;
    [SerializeField] private int mapLevel;

    [SerializeField] private Sprite[] OpenedImage;
    [SerializeField] private Sprite[] ClosedImage;

    void Start()
    {
        mapLevel = map.GetMapLevel( );
        Init( );
    }

    private void Init( )
    {
        totalNum = ( int )Define.ITEM.TOTAL_NUM;

        Items = new GameObject[totalNum];
        ItemButtons = new Button[totalNum];
        ItemButtonsImage = new Image[totalNum];

        for( int i = 0; i < totalNum; i++ )
        {
            Items[i] = ItemUI.GetChild( i ).GetChild(0).gameObject;
            ItemButtons[i] = ItemUI.GetChild( i ).GetComponent<Button>( );
            ItemButtonsImage[i] = ItemUI.GetChild( i ).GetComponent<Image>( );
        }
    }

    public void SetMapLevel( int level )
    {
        mapLevel = level;
        SetItemDisplayLevel( );
    }

    public void SetItemDisplayLevel( )
    {
        mapLevel = Map.GetMapLevel( );

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
                ItemButtons[i].GetComponent<Image>( ).sprite = OpenedImage[i];
            }
            else
            {
                Items[i].SetActive( false );
                ItemButtons[i].interactable = false;
                ItemButtons[i].GetComponent<Image>( ).sprite = ClosedImage[i];
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

                if( remain == 0 )
                {
                    Items[i].GetComponent<TMP_Text>( ).text = "";
                    ItemButtons[i].GetComponent<Image>( ).sprite = ClosedImage[i];
                    ItemButtons[i].interactable = false;
                }
                else
                {
                    Items[i].GetComponent<TMP_Text>( ).text = remain.ToString( );
                }
            }
        }
    }
}
