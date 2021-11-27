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

    private bool isForcingDry = false;

    [SerializeField]private Sprite OriginalImage;
    [SerializeField]private Sprite TimedOutImage;

    private void Awake( )
    {
        canvas = GetComponentInChildren<Canvas>( );
        CloseGauge( );
    }

    void Start()
    {
        timeController = GameObject.Find( "System" ).GetComponent<TimeController>( );

        spriteRenderer = GetComponent<SpriteRenderer>( );
        spriteRenderer.sprite = OriginalImage;

        slider.value = 1;
    }

    void Update()
    {
        if( isForcingDry )
        {
            spriteRenderer.sprite = TimedOutImage;
            CD = 0;
            slider.value = ( CD / Timer );
            return;
        }

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
            if( spriteRenderer.sprite != TimedOutImage)
            {
                spriteRenderer.sprite = TimedOutImage;

                var animal = transform.parent.GetComponent<GridBase>( ).GetAnimal( );
                if( animal != null )
                {
                    animal.GetComponent<AnimalBase>( ).ItemTimedOut( );
                }

            }
        }
        else
        {
            if( spriteRenderer.sprite != OriginalImage )
            {
                spriteRenderer.sprite = OriginalImage;
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

        isForcingDry = false;
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

    public void ForceDryItem()
    {
        spriteRenderer.sprite = TimedOutImage;
        CD = 0;
        slider.value = ( CD / Timer );
        isForcingDry = true;
    }
}
