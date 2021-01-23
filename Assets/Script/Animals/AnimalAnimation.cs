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

    void Start( )
    {
        spriteRenderer = GetComponent<SpriteRenderer>( );
        path = "Sprite/" + animalName;
        walk = Resources.LoadAll<Sprite>( path + "/Walk");
        eat = Resources.LoadAll<Sprite>( path + "/Eat" );
        setWalk( );
        spriteRenderer.sprite = nowAnimation[ 0 ];
    }

    void FixedUpdate( )
    {
        playCount++;

        if( playCount % 3 == 0 )
        {
            animationCount++;
            spriteRenderer.sprite = nowAnimation[animationCount % ( nowAnimation.Length - 1 )];
        }

    //if( ItemMovementTest._grass )
    //{
    //    if( ZEBRA._zebra.animals.transform.position == ItemMovementTest._grass.transform.position )
    //    {
    //        nowAnimation = eat;
    //    }
    //}

}

    public void setEat( )
    {
        if( nowAnimation != eat )
        {
            animationCount = 0;
            nowAnimation = eat;
        }
    }

    public void setWalk( )
    {
        if( nowAnimation != walk )
        {
            animationCount = 0;
            nowAnimation = walk;
        }
    }
}