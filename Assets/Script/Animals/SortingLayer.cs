using UnityEngine;

public class SortingLayer : MonoBehaviour
{
    private int orderNumber;
    void Start()
    {
        ChangeOrderInLayer( );
        SpriteRenderer spriterenderer = gameObject.GetComponent<SpriteRenderer>( );
        spriterenderer.sortingLayerName = "Animal";
        spriterenderer.sortingOrder = orderNumber;
    }

    void ChangeOrderInLayer( )
    {
        switch( gameObject.tag )
        {
            case "ZEBRAS":
                orderNumber = 1;
                break;
            case "LIONS":
                orderNumber = 2;
                break;
            case "GIRAFFES":
                orderNumber = 3;
                break;
        }
    }
}
