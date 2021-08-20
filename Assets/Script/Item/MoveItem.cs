using UnityEngine;

public class MoveItem : MonoBehaviour
{
    private InstantiateMoveControl imController;
    private GridTerritoryControl territoryController;
    private ItemStorage storage;

    [SerializeField] private GameObject itemToBeInstantiate;
    [SerializeField] private int queueNum = -1;

    void Start( )
    {
        imController = GameObject.FindWithTag( "InstantiateMoveControl" ).GetComponent<InstantiateMoveControl>( );
        territoryController = GameObject.Find( "TerritoryController" ).GetComponent<GridTerritoryControl>( );
        storage = GameObject.Find( "ItemStorage" ).GetComponent<ItemStorage>( );
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

            case "rice(Clone)":
                RemoveExtraGrid( ( int )Define.ITEM.RICE, index );
                territoryController.RemoveItem( index, ( int )Define.ITEM.RICE );
                storage.RemoveItem( queueNum, ( int )Define.ITEM.RICE );
                break;

            case "rock(Clone)":
                RemoveExtraGrid( ( int )Define.ITEM.ROCK, index );
                territoryController.RemoveItem( index, ( int )Define.ITEM.ROCK );
                storage.RemoveItem( queueNum, ( int )Define.ITEM.ROCK );
                break;

            case "lake(Clone)":
                RemoveExtraGrid( ( int )Define.ITEM.LAKE, index );
                territoryController.RemoveItem( index, ( int )Define.ITEM.LAKE );
                storage.RemoveItem( queueNum, ( int )Define.ITEM.LAKE );
                break;

            case "rockGroup(Clone)":
                RemoveExtraGrid( ( int )Define.ITEM.ROCK_GROUP, index );
                territoryController.RemoveItem( index, ( int )Define.ITEM.ROCK_GROUP );
                storage.RemoveItem( queueNum, ( int )Define.ITEM.ROCK_GROUP );
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

            case ( int )Define.ITEM.RICE:
                RemoveRiceExtra( index );
                break;

            case ( int )Define.ITEM.ROCK:
                RemoveRockExtra( index );
                break;
                
            case ( int )Define.ITEM.LAKE:
                RemoveLakeExtra( index );
                break;

            case ( int )Define.ITEM.ROCK_GROUP:
                RemoveRockGroupExtra( index );
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

    private void RemoveRiceExtra( int index )
    {
        for( int i = 1; i < Define.RICE_SIZE.Length; i++ )
        {
            Destroy( transform.parent.parent.GetChild( index + Define.RICE_SIZE[i] ).GetChild( 0 ).gameObject );
        }
    }

    private void RemoveRockExtra( int index )
    {
        for( int i = 1; i < Define.ROCK_SIZE.Length; i++ )
        {
            Destroy( transform.parent.parent.GetChild( index + Define.ROCK_SIZE[i] ).GetChild( 0 ).gameObject );
        }
    }

    private void RemoveLakeExtra( int index )
    {
        for( int i = 1; i < Define.LAKE_SIZE.Length; i++ )
        {
            Destroy( transform.parent.parent.GetChild( index + Define.LAKE_SIZE[i] ).GetChild( 0 ).gameObject );
        }
    }

    private void RemoveRockGroupExtra( int index )
    {
        for( int i = 1; i < Define.ROCK_GROUP_SIZE.Length; i++ )
        {
            Destroy( transform.parent.parent.GetChild( index + Define.ROCK_GROUP_SIZE[i] ).GetChild( 0 ).gameObject );
        }
    }

    public void SetQueueNum( int num )
    {
        queueNum = num;
    }

}
