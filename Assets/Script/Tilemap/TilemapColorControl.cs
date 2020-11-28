using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapColorControl : MonoBehaviour
{
    public GameObject System;
    public TimeController TimeController;

    public Tilemap tilemap;
    public Color color;
    public Color toColor;
    public Color morning;
    public Color noon;
    public Color evening;
    public Color night;
    public Color midnight;
    public Color sunrise;

    private int nowGameHour;
    private float speed;

    private void Start( )
    {
        TimeController = System.GetComponent<TimeController>( );
        tilemap = GetComponent<Tilemap>( );
        getPeriodColor( );
        color = toColor;
    }

    // Update is called once per frame
    void Update( )
    {
        getPeriodColor( );
        gradualColor( );
        tilemap.color = color;
    }

    private void getPeriodColor( )
    {
        nowGameHour = TimeController.getNowGameHour( );

        switch( nowGameHour )
        {
            case 0:
                toColor = morning;
                break;
            case 2:
                toColor = noon;
                speed = 4;
                break;
            case 8:
                toColor = evening;
                speed = 6;
                break;
            case 10:
                toColor = night;
                speed = 4;
                break;
            case 13:
                toColor = midnight;
                speed = 4;
                break;
            case 21:
                toColor = sunrise;
                speed = 5;
                break;
            case 23:
                toColor = morning;
                speed = 3;
                break;
        }
    }

    private void gradualColor( )
    {
        var divider = TimeController.getSecToMinCount( ) * TimeController.getMinToHourCount( ) * TimeController.getHourToDayCount( ) / 3;

        color = Color.Lerp( color, toColor, Time.deltaTime / divider * speed );
    }
}