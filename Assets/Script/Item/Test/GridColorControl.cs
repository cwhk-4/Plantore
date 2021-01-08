using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridColorControl : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Color available;
    [SerializeField] private Color notAvailble;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>( );
        spriteRenderer.color = Color.clear;
    }

    public void EnableAvailability( )
    {
        if( this.transform.childCount != 0 )
        {
            spriteRenderer.color = notAvailble;
        }
        else
        {
            spriteRenderer.color = available;
        }
    }

    public void DisableAvailability( )
    {
        spriteRenderer.color = Color.clear;
    }
}
