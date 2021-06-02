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

    [SerializeField] private bool IsRepairing = false;
    [SerializeField] private float RepairingSpeed = 10;

    [SerializeField] private string originalTagName;
    [SerializeField] private string driedTagName;

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
        originalTagName = gameObject.tag;
        driedTagName = originalTagName.Insert( 0, "TimedOut_" );
    }

    void Update()
    {
        if( IsRepairing )
        {
            startingTime += Time.deltaTime * RepairingSpeed;

            if( slider.value >= 1 )
            {
                IsRepairing = false;
                startingTime = timeController.getNowRealSec( );
            }
        }

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

                gameObject.tag = driedTagName;

            }
        }
        else
        {
            if( spriteRenderer.sprite != original )
            {
                spriteRenderer.sprite = original;
                gameObject.tag = originalTagName;
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

    public void StartRepairing( )
    {
        IsRepairing = true;
    }

    public void StopRepairing( )
    {
        IsRepairing = false;
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
