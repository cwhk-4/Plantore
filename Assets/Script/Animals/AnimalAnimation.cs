using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalAnimation : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public Sprite[] sprites;

    [SerializeField] private string animalName;
    private string path;
    private float playCount = 0;
    private int animationCount = 0;

    void Start( )
    {
        spriteRenderer = GetComponent<SpriteRenderer>( );
        path = "Sprite/" + animalName;
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