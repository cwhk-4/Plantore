using UnityEngine;

public class MoveItem : MonoBehaviour
{
    private InstantiateMoveControl imController;
    private GridTerritoryControl territoryController;
    [SerializeField] private GameObject itemToBeInstantiate;
    [SerializeField] private int xCount = 8;

    void Start( )
    {
        imController = GameObject.FindWithTag( "InstantiateMoveControl" ).GetComponent<InstantiateMoveControl>( );
        territoryController = GameObject.Find( "TerritoryController" ).GetComponent<GridTerritoryControl>( );
        xCount = imController.GetXCount( );
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
                territoryController.RemoveItem( index, ItemDefine.GRASS );
                break;

            case "wood(Clone)":
                RemoveExtraGrid( ItemDefine.WOOD, index );
                territoryController.RemoveItem( index, ItemDefine.WOOD );
                break;

            case "grassland(Clone)":
                RemoveExtraGrid( ItemDefine.GRASSLAND, index );
                territoryController.RemoveItem( index, ItemDefine.GRASSLAND );
                break;

            case "marsh(Clone)":
                RemoveExtraGrid( ItemDefine.MARSH, index );
                territoryController.RemoveItem( index, ItemDefine.MARSH );
                break;
        }

        Destroy( gameObject );
    }

    private void RemoveExtraGrid( int itemNum, int index )
    {
        switch( itemNum )
        {
            case 1:
                RemoveWoodExtra( index );
                break;

            case 2:
                RemoveGrasslandExtra( index );
                break;

            case 3:
                RemoveMarshExtra( index );
                break;
        }
    }

    private void RemoveWoodExtra( int index )
    {
        var extraGridNum = index + xCount;
        Destroy( transform.parent.parent.GetChild( extraGridNum ).GetChild( 0 ).gameObject );
    }

    private void RemoveGrasslandExtra( int index )
    {
        var extraGridNum = index - 1;
        Destroy( transform.parent.parent.GetChild( extraGridNum ).GetChild( 0 ).gameObject );
    }

    private void RemoveMarshExtra( int index )
    {
        var extraGridNumA = index - 1;
        Destroy( transform.parent.parent.GetChild( extraGridNumA ).GetChild( 0 ).gameObject );

        var extraGridNumB = index + xCount;
        Destroy( transform.parent.parent.GetChild( extraGridNumB ).GetChild( 0 ).gameObject );

        var extraGridNumC = index + xCount - 1;
        Destroy( transform.parent.parent.GetChild( extraGridNumC ).GetChild( 0 ).gameObject );
    }
}
