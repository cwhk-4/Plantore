using System;
using UnityEngine;

public class AnimalAnimation : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public Sprite[] nowAnimation;

    public Sprite[] walk;
    public Sprite[] eat;

    [SerializeField] private string animalName;
    private string path;
    private float playCount = 0;
    private int animationCount = 0;

    private float Delay;

    void Start( )
    {
        spriteRenderer = GetComponent<SpriteRenderer>( );
        path = "Sprite/" + animalName;
        walk = Resources.LoadAll<Sprite>( path + "/Walk");
        eat = Resources.LoadAll<Sprite>( path + "/Eat" );
        setWalk( );
        spriteRenderer.sprite = nowAnimation[ 0 ];
        Delay = UnityEngine.Random.Range( 0f, 5f );
    }

    void FixedUpdate( )
    {
        if( Delay >= 0 )
        {
            Delay -= Time.fixedDeltaTime;
        }
        else
        {
            playCount++;

            if( playCount % 3 == 0 )
            {
                animationCount++;
                spriteRenderer.sprite = nowAnimation[animationCount % nowAnimation.Length];
            }
        }
}

    public void setEat( )
    {
        if( nowAnimation != eat )
        {
            animationCount = 0;
            Array.Resize( ref nowAnimation, eat.Length );
            nowAnimation = eat;
        }
    }

    public void setWalk( )
    {
        if( nowAnimation != walk )
        {
            animationCount = 0;
            Array.Resize( ref nowAnimation, walk.Length );
            nowAnimation = walk;
        }
    }
}