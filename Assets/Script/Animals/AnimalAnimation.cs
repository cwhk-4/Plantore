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
        nowAnimation = walk;
        spriteRenderer.sprite = nowAnimation[ 0 ];
    }

    void Update( )
    {
        playCount++;

        /*if( playCount % 2 == 0 )
        {*/
            animationCount++;
            spriteRenderer.sprite = nowAnimation[animationCount % ( nowAnimation.Length - 1 )];
        
    }

    public void setEat( )
    {
        nowAnimation = eat;
    }

    public void setWalk( )
    {
        nowAnimation = walk;
    }
}