using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    private TimeController timeController;
    private SpriteRenderer spriteRenderer;

    [SerializeField]private Slider slider;
    public Text text;
    private Canvas canvas;

    [SerializeField] private float Timer;
    private float startingTime;
    private float CD;

    [SerializeField]private Sprite original;
    [SerializeField]private Sprite timeOutImage;

    private void Awake( )
    {
        canvas = GetComponentInChildren<Canvas>( );
        closeGauge( );
    }

    void Start()
    {
        timeController = GameObject.Find( "System" ).GetComponent<TimeController>( );

        spriteRenderer = GetComponent<SpriteRenderer>( );
        spriteRenderer.sprite = original;

        slider.value = 1;
    }

    void Update()
    {
        CD = Timer - ( timeController.getNowRealSec( ) - startingTime );
        slider.value = ( CD / Timer );

        CheckSprite( slider.value );

        text.text = ( int )CD + "s Left";
    }

    private void CheckSprite( float val )
    {
        if( val <= 0 )
        {
            if( spriteRenderer.sprite != timeOutImage)
            {
                spriteRenderer.sprite = timeOutImage;
                gameObject.tag = "DriedGrass";

            }
        }
        else
        {
            if( spriteRenderer.sprite != original )
            {
                spriteRenderer.sprite = original;
                gameObject.tag = "Grass";
            }
        }
    }

    public void showGauge( )
    {
        canvas.enabled = true;
    }

    public void closeGauge( )
    {
        canvas.enabled = false;
    }

    public void ResetStartingTime( )
    {
        startingTime = timeController.getNowRealSec( );
    }

    public float getStartTime( )
    {
        return startingTime;
    }

    public void setStartingTime( float time )
    {
        startingTime = time;
    }

    public float getCD( )
    {
        return CD;
    }
}
