using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackScreenAnimationController : MonoBehaviour
{
    public DialogueEvent dialogueEvent;

    private RawImage rawImage;
    public Color color = Color.black;

    public GameObject loadingText;

    [SerializeField]
    private float fadingTime = 1f;

    [SerializeField]
    private float blackoutTime = 3f;

    public bool show = true;

    private void Start( )
    {
        dialogueEvent = GameObject.FindWithTag( "DialogueControl" ).GetComponent<DialogueEvent>( );

        loadingText = this.transform.GetChild( 0 ).gameObject;
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

        if( blackoutTime <= 0 )
        {
            show = false;
            loadingText.SetActive( false );
        }

    }
}
