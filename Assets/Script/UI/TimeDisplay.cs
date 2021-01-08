using UnityEngine;
using UnityEngine.UI;

public class TimeDisplay : MonoBehaviour
{
    public TimeController timeController;

    public Text dayDisplay;
    public Text periodDisplay;
    public Text timeDisplay;
    public Text AMPMDisplay;

    private int day;                    //start from 1
    private int period;                 //same
    private string periodText;
    private string period_AMPM_Text;
    private int totalGameHour;
    private float realSec;              //+10mins per time / 12hr system / **start from 1
    private int gameHour;

    private int displayMin = 0;

    private bool transparencyRevert = false;
    private bool doTransparency = false;

    private Color color = Color.black;

    [SerializeField] private int toHour = 6;
    [SerializeField] private int count = 100;

    void Awake( )
    {
        timeController = GetComponent<TimeController>( );
    }

    void FixedUpdate( )
    {
        day = timeController.getNowGameDay( );
        gameHour = timeController.getNowGameHour();
        period = timeController.getNowGamePeriod( );
        realSec = timeController.getNowRealSec( );
        totalGameHour = ( int )timeController.getTotalNowGameHour( );

        displayDay( );
        displayPeriod( );
        displayAMPMPeriod( );
        displayTime( );

        //periodTransparency( );
        //periodTransparencyRevert( );

    }

    private void displayDay( )
    {
        dayDisplay.text = ( "Day " + day );
    }

    private void displayPeriod( )
    {
        switch( period )
        {
            case 1:
                periodText = "朝";
                period_AMPM_Text = "AM";
                transparencyRevert = true;
                break;

            case 2:
                periodText = "昼";
                period_AMPM_Text = "PM";
                transparencyRevert = true;
                break;

            case 3:
                periodText = "夕方";
                period_AMPM_Text = "PM";
                transparencyRevert = true;
                break;

            case 4:
                periodText = "夜";
                period_AMPM_Text = "PM";
                transparencyRevert = true;
                break;

            case 5:
                periodText = "深夜";
                period_AMPM_Text = "AM";
                transparencyRevert = true;
                break;

            case 6:
                periodText = "早朝";
                period_AMPM_Text = "AM";
                transparencyRevert = true;
                break;

            default:
                transparencyRevert = false;
                break;
        }

        periodDisplay.text = ( periodText );
    }

    /*
    private void periodTransparency( )
    {
        switch( gameHour )
        {
            case 4:
            case 8:
            case 11:
            case 16:
            case 20:
            case 23:
                doTransparency = true;
                break;

            default:
                doTransparency = false;
                break;
        }

        if(doTransparency)
        {
            if( displayMin == 5 )
            {
                color.a -= Time.fixedDeltaTime / 3;
                periodDisplay.color = color;
            }
        }

    }

    private void periodTransparencyRevert( )
    {
        if( transparencyRevert )
        {
            if( displayMin == 0 )
            {
                color.a += Time.fixedDeltaTime / 3;
                periodDisplay.color = color;
            }
        }
    }
    */

    private void displayAMPMPeriod( )
    {
        AMPMDisplay.text = ( period_AMPM_Text );
    }

    private void displayTime( )
    {
        int displayHr = gameNowHour( );

        int displayMin = gameNowMin( );

        timeDisplay.text = ( displayHr + ":" + displayMin  + "0");
    }

    private int gameNowHour( )
    {
        int displayHr = gameHour + 7;

        if( displayHr > 24 )
        {
            displayHr -= 24;
        }
        else if( displayHr > 12 )
        {
            displayHr -= 12;
        }

        return displayHr;
    }

    private int gameNowMin( )
    {
        displayMin = ( int )( ( ( realSec - 1 ) - ( ( int )totalGameHour * timeController.getSecToMinCount( ) * timeController.getMinToHourCount( ) ) ) / toHour * count );

        //Debug.Log( displayMin );

        return displayMin;
    }

}