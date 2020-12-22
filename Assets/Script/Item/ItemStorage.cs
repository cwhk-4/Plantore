using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStorage : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public GameObject childGO;
    public bool hvChild = false;

    public Color available;
    public Color notAvailable;
    public static bool isInstantiating = false;
    public static bool isMoving = false;

    private void Start( )
    {
        spriteRenderer = GetComponent<SpriteRenderer>( );
        spriteRenderer.color = Color.clear;
    }

    private void Update( )
    {
        if( this.transform.childCount != 0 )
        {
            childGO = this.transform.GetChild( 0 ).gameObject;
            hvChild = true;
        }
        else
        {
            childGO = null;
            hvChild = false;
        }

    }

    private void OnMouseOver( )
    {
        if(isInstantiating)
        {
            showAvailability();
            UseOtherGrid.setNowOnGrid( this.gameObject.name );

            if(!hvChild)
            {
                ItemInstantiate.setParentGO(this.gameObject);
            }
        }
    }

    private void OnMouseExit()
    {
        spriteRenderer.color = Color.clear;
        ItemInstantiate.setParentGO( null );
        UseOtherGrid.setNowOnGrid( null );
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        if(isMoving)
        {
            showAvailability();
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        spriteRenderer.color = Color.clear;
    }

    public void showAvailability()
    {
        if( childGO == null )
        {
            spriteRenderer.color = available;
        }
        else
        {
            spriteRenderer.color = notAvailable;
        }
    }

    public void closeAvailability( )
    {
        spriteRenderer.color = Color.clear;
    }
}
