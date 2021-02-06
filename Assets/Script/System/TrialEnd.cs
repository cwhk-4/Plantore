using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TrialEnd : MonoBehaviour
{
    [SerializeField] private RawImage Background;
    [SerializeField] private GameObject Thanks;
    [SerializeField] private TMP_Text Blink_Text;

    [SerializeField] private float FadingTime;

    private Color color = Color.black;

    private bool Show = false;

    void Start()
    {
        Background.gameObject.SetActive( false );
        Thanks.SetActive( false );
        Blink_Text.gameObject.SetActive( false );
        color.a = 0;
        Background.color = color;
    }

    void FixedUpdate()
    {
        if( Show )
        {
            if( color.a < 1 )
            {
                color.a += Time.fixedDeltaTime / FadingTime;
                Background.color = color;
            }

            if( color.a >= 1 )
            {
                Thanks.SetActive( true );
                Blink_Text.gameObject.SetActive( true );
                Show = false;
            }
        }
        else if( color.a >= 1)
        {
            if( Input.GetMouseButtonDown( 0 ) )
            {
                SceneManager.LoadSceneAsync( "Title" );
            }
        }
    }

    public void ShowEnd( )
    {
        Show = true;
        Background.gameObject.SetActive( true );
    }
}
