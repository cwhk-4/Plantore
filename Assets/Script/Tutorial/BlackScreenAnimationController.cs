using UnityEngine;
using UnityEngine.UI;

public class BlackScreenAnimationController : MonoBehaviour
{
    [SerializeField] private DialogueEvent dialogueEvent;

    private RawImage rawImage;
    public Color color = Color.black;

    [SerializeField] private GameObject loadingText;

    [SerializeField] private float fadingTime = 1f;

    [SerializeField] private float blackoutTime = 3f;

    public bool show = true;

    private bool isToStage = false;

    private void Start( )
    {
        loadingText.SetActive( false );

        rawImage = GetComponent<RawImage>( );
        color.a = 0;
        rawImage.color = color;
    }

    private void Update( )
    {
        if( show )
        {
            if( color.a <= 1 )
            {
                color.a += Time.deltaTime / fadingTime;
                rawImage.color = color;
            }
        }
        else
        {
            if( color.a >= 0 )
            {
                color.a -= Time.deltaTime / fadingTime;
                rawImage.color = color;
                loadingText.SetActive( false );
            }
            else
            {
                blackoutTime = 3f;
                dialogueEvent.finishedLoading( );
            }
        }

        if( color.a >= 1 )
        {
            loadingText.SetActive( true );
            blackoutTime -= Time.deltaTime;
        }

        if( blackoutTime <= 1f )
        {
            dialogueEvent.installAnimals( );
        }

        if( blackoutTime <= 0 )
        {
            show = false;
            loadingText.SetActive( false );
        }

        if( isToStage )
        {
            if( color.a >= 1 )
            {
                dialogueEvent.finishedTutorial( );
            }
        }
    }

    public void setToStage( )
    {
        isToStage = true;
    }
}
