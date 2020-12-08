using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalAnimation : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public Sprite[] sprites;

    private int i = 0;
    private float count = 0;

    // Start is called before the first frame update
    void Start( )
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[i];
    }

    // Update is called once per frame
    void Update( )
    {
        count++;

        if( count % 6 == 0)
        {
            spriteRenderer.sprite = sprites[i];
            i++;
            if( i >= sprites.Length - 1 )
            {
                i = 0;
            }
        }
    }
}