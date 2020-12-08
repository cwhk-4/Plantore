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
    private float count = 0;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        path = "Sprite/" + name;
        Debug.Log( "path: " + path );
        sprites = Resources.LoadAll<Sprite>( path );
        spriteRenderer.sprite = sprites[0];
    }

    // Update is called once per frame
    void Update()
    {
        count++;

        if( count % 2 == 0 )
        {
            spriteRenderer.sprite = sprites[i];
            i++;
            if( i >= sprites.Length - 1)
            {
                i = 0;
            }
        }
    }
}