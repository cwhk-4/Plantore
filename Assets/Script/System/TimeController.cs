using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    [SerializeField]
    private float nowSec = 0;
    [SerializeField]
    private float nowMin = 0;
    [SerializeField]
    private float nowTotalGameHour = 0;
    [SerializeField]
    private int nowGamePeriod = 0;
    [SerializeField]
    private float nowGameDay = 0;
    [SerializeField]
    private float nowGameHour = 0;

    [SerializeField]
    private float secToMinCount = 2f;
    [SerializeField]
    private float minToHourCount = 2f;
    [SerializeField]
    private float hourToDayCount = 6f;

    private void FixedUpdate()
    {
        changeTime();
    }

    private void changeTime()
    {
        nowSec += Time.fixedDeltaTime;
        nowMin = nowSec / secToMinCount;
        nowTotalGameHour = nowMin / minToHourCount;
        nowGameDay = nowTotalGameHour / hourToDayCount;
        nowGameHour = (int)(nowTotalGameHour - ( ( int )nowGameDay * hourToDayCount ));
        periodCalculation( );
    }

    public float getSecToMinCount( )
    {
        return secToMinCount;
    }

    public float getMinToHourCount( )
    {
        return minToHourCount;
    }

    public float getHourToDayCount( )
    {
        return hourToDayCount;
    }

    private void periodCalculation( )
    {
        switch( nowGameHour )
        {
            case 0:
            case 1:
            case 2:
            case 3:
            case 4:
                nowGamePeriod = 1;
                break;

            case 5:
            case 6:
            case 7:
            case 8:
                nowGamePeriod = 2;
                break;

            case 9:
            case 10:
            case 11:
                nowGamePeriod = 3;
                break;

            case 12:
            case 13:
            case 14:
            case 15:
            case 16:
                nowGamePeriod = 4;
                break;

            case 17:
            case 18:
            case 19:
            case 20:
                nowGamePeriod = 5;
                break;

            case 21:
            case 22:
            case 23:
                nowGamePeriod = 6;
                break;
        }
    }

    public float getNowRealSec( )
    {
        return (nowSec + 1);
    }

    public float getNowRealMin( )
    {
        return (nowMin + 1);
    }

    public float getTotalNowGameHour( )
    {
        return nowTotalGameHour;
    }

    public int getNowGameHour( )
    {
        return ( int )nowGameHour;
    }

    public int getNowGamePeriod( )
    {
        return nowGamePeriod;
    }

    public int getNowGameDay( )
    {
        return (int)(nowGameDay + 1);
    }

    public void loadNowSec( float secLoad )
    {
        nowSec = secLoad;
    }

}
