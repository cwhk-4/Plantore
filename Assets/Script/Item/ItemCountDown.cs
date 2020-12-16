using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCountDown : MonoBehaviour
{
    public GameObject parentItem;
    public GameObject system;
    public TimeController timeController;
    public Slider slider;
    public Text text;
    public Canvas canvas;

    private SpriteRenderer spriteRenderer;
    public Sprite original;
    public Sprite driedGrass;

    [SerializeField] private float timer = 10;
    private float startTime = 0;
    private bool isChanged = false;

    public static float CD;

    private void Awake( )
    {
        canvas = GetComponent<Canvas>( );
        closeGauge( );
    }

    void Start()
    {
        if( system == null )
        {
            system = GameObject.FindWithTag( "System" );
        }

        timeController = system.GetComponent<TimeController>( );
        parentItem = this.transform.parent.gameObject;
        spriteRenderer = GetComponentInParent<SpriteRenderer>( );
        spriteRenderer.sprite = original;
    }

    void Update()
    {
        if( !isChanged )
        {
            startTime = timeController.getNowRealSec( );
            isChanged = true;
        }

        CD = timer - ( timeController.getNowRealSec( ) - startTime );
        slider.value = ( CD / timer );
        if( slider.value == 0 )
        {
            spriteRenderer.sprite = driedGrass;
            //new
            spriteRenderer.tag = "GRASS";
        }

        text.text = ( int )CD + "s Left";
    }

    public void showGauge( )
    {
        canvas.enabled = true;
    }

    public void closeGauge()
    {
        canvas.enabled = false;
    }

    public void repair()
    {
        startTime = timeController.getNowRealSec( );
        spriteRenderer.sprite = original;
    }

    public float getStartTime()
    {
        return startTime;
    }

    public void setStartTime( float startingTime )
    {
        startTime = startingTime;
        isChanged = true;
    }

}
