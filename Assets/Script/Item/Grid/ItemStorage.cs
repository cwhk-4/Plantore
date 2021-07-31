using UnityEngine;
using System.Collections.Generic;

public class ItemStorage : MonoBehaviour
{
    [SerializeField] private GameObject gridParent;
    private List<int>[] ItemArr;

    [SerializeField] private List<int> grass = new List<int>( );
    [SerializeField] private List<int> wood = new List<int>( );
    [SerializeField] private List<int> smallRock = new List<int>( );

    [SerializeField] private List<int> grassland = new List<int>( );
    [SerializeField] private List<int> marsh = new List<int>( );

    [SerializeField] private List<int> rice = new List<int>( );
    [SerializeField] private List<int> rock = new List<int>( );

    [SerializeField] private List<int> lake = new List<int>( );
    [SerializeField] private List<int> rockGroup = new List<int>( );

    private void Start( )
    {
        Init( );
    }

    private void Init( )
    {
        ItemArr = new List<int>[( int )Define.ITEM.TOTAL_NUM];

        ItemArr[( int )Define.ITEM.GRASS] = grass;
        ItemArr[( int )Define.ITEM.WOOD] = wood;
        ItemArr[( int )Define.ITEM.SMALL_ROCK] = smallRock;

        ItemArr[( int )Define.ITEM.GRASSLAND] = grassland;
        ItemArr[( int )Define.ITEM.MARSH] = marsh;

        ItemArr[( int )Define.ITEM.RICE] = rice;
        ItemArr[( int )Define.ITEM.ROCK] = rock;

        ItemArr[( int )Define.ITEM.LAKE] = lake;
        ItemArr[( int )Define.ITEM.ROCK_GROUP] = rockGroup;

        for( int i = 0; i < ( int )Define.ITEM.TOTAL_NUM; i++ )
        {
            ItemArr[i].Clear( );
        }
    }

    public void PlaceItem( int index, int itemNum )
    {
        ItemArr[itemNum].Add( index );
        gridParent.transform.GetChild( index ).GetComponentInChildren<MoveItem>( )
                  .SetQueueNum( ItemArr[itemNum].Count - 1 );
    }

    public void RemoveItem( int queueNum, int itemNum )
    {
        ItemArr[itemNum].RemoveAt( queueNum );
    }

    public List<int> GetItem( int itemNum )
    {
        return ItemArr[itemNum];
    }
}
