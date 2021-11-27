using UnityEngine;
using UnityEngine.EventSystems;

public class RubbishBin : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private InstantiateMoveControl IMController;
    private BoxCollider2D tempCollider;

    public void DestroyItem( )
    {
        Destroy( GameObject.FindWithTag( "Instantiate" ) );
        IMController.ItemDeleted( );
        tempCollider.enabled = true;
    }

    public void OnPointerExit( PointerEventData eventData )
    {
        tempCollider.enabled = true;
    }

    public void OnPointerEnter( PointerEventData eventData )
    {
        tempCollider = GameObject.FindWithTag( "Instantiate" ).GetComponent<InstantiateItem>( ).getParentGO( ).GetComponent<BoxCollider2D>( );
        tempCollider.enabled = false;
    }
}
