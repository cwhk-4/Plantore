using UnityEngine;

public class MoveItem : MonoBehaviour
{
    private InstantiateMoveControl imController;
    private GridTerritoryControl GridTerritoryControl;
    private ItemStorage storage;

    [SerializeField] private GameObject itemToBeInstantiate;
    [SerializeField] private int queueNum = -1;

    void Start( )
    {
        imController = GameObject.FindWithTag( "InstantiateMoveControl" ).GetComponent<InstantiateMoveControl>( );
        GridTerritoryControl = GameObject.Find( "TerritoryController" ).GetComponent<GridTerritoryControl>( );
        storage = GameObject.Find( "ItemStorage" ).GetComponent<ItemStorage>( );
    }

    public void StartMoving( float time, GameObject animal )
    {
        var index = transform.parent.GetSiblingIndex( );
        Debug.Log( index );
        var animalNum = animal.GetComponent<AnimalBase>( ).GetAnimalNum( );

        imController.StartMoving( time, animal );
        Vector3 mousePos = Camera.main.ScreenToWorldPoint( Input.mousePosition );
        mousePos = new Vector3( mousePos.x, mousePos.y, 0 );
        Instantiate( itemToBeInstantiate, mousePos, Quaternion.identity );

        switch( name )
        {
            case "grass(Clone)":
                GridTerritoryControl.RemoveTerritory( animal, index, ( int )Define.ITEM.GRASS, animalNum );
                storage.RemoveItem( queueNum, ( int )Define.ITEM.GRASS );
                break;

            case "wood(Clone)":
                RemoveExtraGrid( ( int )Define.ITEM.WOOD, index );
                GridTerritoryControl.RemoveTerritory( animal, index, ( int )Define.ITEM.WOOD, animalNum );
                storage.RemoveItem( queueNum, ( int )Define.ITEM.WOOD );
                break;

            case "grassland(Clone)":
                RemoveExtraGrid( ( int )Define.ITEM.GRASSLAND, index );
                GridTerritoryControl.RemoveTerritory( animal, index, ( int )Define.ITEM.GRASSLAND, animalNum );
                storage.RemoveItem( queueNum, ( int )Define.ITEM.GRASSLAND );
                break;

            case "marsh(Clone)":
                RemoveExtraGrid( ( int )Define.ITEM.MARSH, index );
                GridTerritoryControl.RemoveTerritory( animal, index, ( int )Define.ITEM.MARSH, animalNum );
                storage.RemoveItem( queueNum, ( int )Define.ITEM.MARSH );
                break;

            case "rock(Clone)":
                RemoveExtraGrid( ( int )Define.ITEM.ROCK, index );
                GridTerritoryControl.RemoveTerritory( animal, index, ( int )Define.ITEM.ROCK, animalNum );
                storage.RemoveItem( queueNum, ( int )Define.ITEM.ROCK );
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

            case ( int )Define.ITEM.ROCK:
                RemoveRockExtra( index );
                break;
        }
    }

    private void RemoveWoodExtra( int index )
    {
        var extraGridNum = index + ItemData.WOOD_SIZE[1];
        Destroy( transform.parent.parent.GetChild( extraGridNum ).GetChild( 0 ).gameObject );
    }

    private void RemoveGrasslandExtra( int index )
    {
        var extraGridNum = index + ItemData.GRASSLAND_SIZE[1];
        Destroy( transform.parent.parent.GetChild( extraGridNum ).GetChild( 0 ).gameObject );
    }

    private void RemoveMarshExtra( int index )
    {
        for( int i = 1; i < ItemData.MARSH_SIZE.Length; i++ )
        {
            Destroy( transform.parent.parent.GetChild( index + ItemData.MARSH_SIZE[i] ).GetChild( 0 ).gameObject );
        }
    }

    private void RemoveRockExtra( int index )
    {
        for( int i = 1; i < ItemData.ROCK_SIZE.Length; i++ )
        {
            Destroy( transform.parent.parent.GetChild( index + ItemData.ROCK_SIZE[i] ).GetChild( 0 ).gameObject );
        }
    }

    public void SetQueueNum( int num )
    {
        queueNum = num;
    }

}
