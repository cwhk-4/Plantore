using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackScreenAnimationController : MonoBehaviour
{
    private RawImage rawImage;
    public Color color = Color.black;

    public GameObject loadingText;

    [SerializeField]
    private float fadingTime = 1f;

    [SerializeField]
    private float blackoutTime = 3f;

    private bool show = true;

    void Start( )
    {
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
            blackoutTime = 3f;
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
