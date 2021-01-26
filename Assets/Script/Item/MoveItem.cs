using UnityEngine;

public class MoveItem : MonoBehaviour
{
    [SerializeField] private InstantiateMoveControl imController;
    [SerializeField] private GameObject itemToBeInstantiate;
    [SerializeField] private int xCount = 8;

    void Start( )
    {
        imController = GameObject.FindWithTag( "InstantiateMoveControl" ).GetComponent<InstantiateMoveControl>( );
    }

    public void StartMoving( float time )
    {
        imController.StartMoving( time );
        Vector3 mousePos = Camera.main.ScreenToWorldPoint( Input.mousePosition );
        mousePos = new Vector3( mousePos.x, mousePos.y, 0 );
        var item = Instantiate( itemToBeInstantiate, mousePos, Quaternion.identity );

        if(name == "wood(Clone)" )
        {
            var extraGridNum = transform.parent.GetSiblingIndex( ) + xCount;
            Destroy( transform.parent.parent.GetChild( extraGridNum ).GetChild( 0 ).gameObject );
        }

        if( name == "grassland(Clone)" )
        {
            var extraGridNum = transform.parent.GetSiblingIndex( ) - 1;
            Destroy( transform.parent.parent.GetChild( extraGridNum ).GetChild( 0 ).gameObject );
        }

        if( name == "marsh(Clone)" )
        {
            var extraGridNumA = transform.parent.GetSiblingIndex( ) - 1;
            Destroy( transform.parent.parent.GetChild( extraGridNumA ).GetChild( 0 ).gameObject );

            var extraGridNumB = transform.parent.GetSiblingIndex( ) + xCount;
            Destroy( transform.parent.parent.GetChild( extraGridNumB ).GetChild( 0 ).gameObject );

            var extraGridNumC = transform.parent.GetSiblingIndex( ) + xCount - 1;
            Destroy( transform.parent.parent.GetChild( extraGridNumC ).GetChild( 0 ).gameObject );
        }

        Destroy( gameObject );
    }
}
