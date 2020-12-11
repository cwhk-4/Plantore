using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalAnimation : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public Sprite[] sprites;

    public string name;
    private string path;
    private int i = 0;
    private float playCount = 0;
    private int animationCount = 0;

    void Start( )
    {
        spriteRenderer = GetComponent<SpriteRenderer>( );
        path = "Sprite/" + name;
        Debug.Log( "path: " + path );
        sprites = Resources.LoadAll<Sprite>( path );
        spriteRenderer.sprite = sprites[ 0 ];
    }

    void Update( )
    {
        playCount++;

        if( playCount % 2 == 0 )
        {
            animationCount++;
            spriteRenderer.sprite = sprites[animationCount % ( sprites.Length - 1 )];
        }
    }
}