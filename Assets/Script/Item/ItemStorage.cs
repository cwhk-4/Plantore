using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStorage : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    [SerializeField]private GameObject childGO;

    public Color available;
    public Color notAvailable;

    private void Start( )
    {
        spriteRenderer = GetComponent<SpriteRenderer>( );
        //spriteRenderer.color = Color.clear;
    }

    private void Update( )
    {
        if( this.transform.childCount != 0 )
        {
            childGO = this.transform.GetChild( 0 ).gameObject;
        }
        else
        {
            childGO = null;
        }
    }

    private void OnMouseOver( )
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
}
