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

    [SerializeField] private string originalTagName;
    [SerializeField] private string driedTagName;

    private void Awake( )
    {
        canvas = GetComponentInChildren<Canvas>( );
        CloseGauge( );
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
        if( ( timeController.GetNowSec( ) - startingTime ) > Timer )
        {
            startingTime = timeController.GetNowSec( ) - Timer;
        }

        CD = Timer - ( timeController.GetNowSec( ) - startingTime );

        slider.value = ( CD / Timer );

        CheckSprite( slider.value );

        //text.text = ( int )CD + "s Left";
    }

    private void CheckSprite( float val )
    {
        if( val <= 0 )
        {
            if( spriteRenderer.sprite != timeOutImage)
            {
                spriteRenderer.sprite = timeOutImage;

                gameObject.tag = driedTagName;

                var animal = transform.parent.GetComponent<GridBase>( ).GetAnimal( );
                if( animal != null )
                {
                    animal.GetComponent<AnimalBase>( ).ItemTimedOut( );
                }

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

    public void ShowGauge( )
    {
        canvas.enabled = true;
    }

    public void CloseGauge( )
    {
        canvas.enabled = false;
    }

    public void StartRepairing( )
    {
        startingTime = timeController.GetNowSec( );

        var animal = transform.parent.GetComponent<GridBase>( ).GetAnimal( );
        if( animal != null )
        {
            animal.GetComponent<AnimalBase>( ).ItemFixed( );
        }
    }

    public float GetStartTime( )
    {
        return startingTime;
    }

    public void SetStartingTime( float time )
    {
        startingTime = time;
    }

    public void SetCD( int cd )
    {
        Timer = cd;
    }

    public float GetCD( )
    {
        return CD;
    }
}
