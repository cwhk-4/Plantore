﻿using UnityEngine;

public class MoveItem : MonoBehaviour
{
    private InstantiateMoveControl imController;
    private GridTerritoryControl territoryController;
    private ItemStorage storage;
    [SerializeField] private GameObject itemToBeInstantiate;
    [SerializeField] private int xCount = 8;
    [SerializeField] private int queueNum = -1;

    void Start( )
    {
        imController = GameObject.FindWithTag( "InstantiateMoveControl" ).GetComponent<InstantiateMoveControl>( );
        territoryController = GameObject.Find( "TerritoryController" ).GetComponent<GridTerritoryControl>( );
        storage = GameObject.Find( "ItemStorage" ).GetComponent<ItemStorage>( );
        xCount = Define.XCOUNT;
    }

    public void StartMoving( float time )
    {
        imController.StartMoving( time );
        Vector3 mousePos = Camera.main.ScreenToWorldPoint( Input.mousePosition );
        mousePos = new Vector3( mousePos.x, mousePos.y, 0 );
        Instantiate( itemToBeInstantiate, mousePos, Quaternion.identity );
        var index = transform.parent.GetSiblingIndex( );

        switch( name )
        {
            case "grass(Clone)":
                territoryController.RemoveItem( index, ( int )Define.ITEM.GRASS );
                storage.RemoveItem( queueNum, ( int )Define.ITEM.GRASS );
                break;

            case "wood(Clone)":
                RemoveExtraGrid( ( int )Define.ITEM.WOOD, index );
                territoryController.RemoveItem( index, ( int )Define.ITEM.WOOD );
                storage.RemoveItem( queueNum, ( int )Define.ITEM.WOOD );
                break;

            case "grassland(Clone)":
                RemoveExtraGrid( ( int )Define.ITEM.GRASSLAND, index );
                territoryController.RemoveItem( index, ( int )Define.ITEM.GRASSLAND );
                storage.RemoveItem( queueNum, ( int )Define.ITEM.GRASSLAND );
                break;

            case "marsh(Clone)":
                RemoveExtraGrid( ( int )Define.ITEM.MARSH, index );
                territoryController.RemoveItem( index, ( int )Define.ITEM.MARSH );
                storage.RemoveItem( queueNum, ( int )Define.ITEM.MARSH );
                break;
        }

        Destroy( gameObject );
    }

    private void RemoveExtraGrid( int itemNum, int index )
    {
        switch( itemNum )
        {
            case ( int )Define.ITEM.WOOD:
                RemoveWoodExtra( index );
                break;

            case ( int )Define.ITEM.GRASSLAND:
                RemoveGrasslandExtra( index );
                break;

            case ( int )Define.ITEM.MARSH:
                RemoveMarshExtra( index );
                break;
        }
    }

    private void RemoveWoodExtra( int index )
    {
        var extraGridNum = index + Define.WOOD_SIZE[1];
        Destroy( transform.parent.parent.GetChild( extraGridNum ).GetChild( 0 ).gameObject );
    }

    private void RemoveGrasslandExtra( int index )
    {
        var extraGridNum = index + Define.GRASSLAND_SIZE[1];
        Destroy( transform.parent.parent.GetChild( extraGridNum ).GetChild( 0 ).gameObject );
    }

    private void RemoveMarshExtra( int index )
    {
        for( int i = 1; i < Define.MARSH_SIZE.Length; i++ )
        {
            Destroy( transform.parent.parent.GetChild( index + Define.MARSH_SIZE[i] ).GetChild( 0 ).gameObject );
        }
    }

    public void SetQueueNum( int num )
    {
        queueNum = num;
    }

}
