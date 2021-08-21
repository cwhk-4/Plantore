﻿using UnityEngine;
using UnityEngine.EventSystems;

public class ItemBase : MonoBehaviour
{
    [SerializeField] private MissionControl MissionControl;
    [SerializeField] private ToolConvertion ToolConvertion;
    [SerializeField] private MapLevel MapLevel;
    private CountDown countDown;
    private MoveItem moveItem;

    [SerializeField]private bool isOnMouse;
    private float clickDelay = 1;
    private float clickTime;
    private int click;

    void Start( )
    {
        ToolConvertion = GameObject.FindWithTag( "Cursor" ).GetComponent<ToolConvertion>( );
        MissionControl = GameObject.FindWithTag( "MissionController" ).GetComponent<MissionControl>( );
        MapLevel = GameObject.FindWithTag( "Map" ).GetComponent<MapLevel>( );
        countDown = GetComponent<CountDown>( );
        moveItem = GetComponent<MoveItem>( );
        isOnMouse = false;
    }

    private void Update( )
    {
        if(isOnMouse)
        {
            if( ToolConvertion.getIsCan( ) )
            {
                if( Input.GetMouseButtonDown( 0 ) )
                {
                    if( countDown.getCD( ) <= 0 )
                    {
                        Repair( );
                    }

                }

            }
            else
            {
                if( Input.GetMouseButtonUp( 0 ) )
                {
                    if( EventSystem.current.IsPointerOverGameObject() )
                        return;

                    if( Time.time - clickTime <= clickDelay )
                    {
                        click++;
                    }
                    else
                    {
                        click = 0;
                        clickTime = Time.time;
                    }

                    if( click == 2 )
                    {
                        MoveItem( );
                    }
                }
            }


        }
    }

    public void Repair( )
    {
        countDown.StartRepairing( );

        if( MapLevel.getMapLevel( ) == 2 )
        {
            MissionControl.FixedItem1( );
        }

        if( MapLevel.getMapLevel( ) == 3 )
        {
            MissionControl.FixedItem2( );
        }
    }

    public void MoveItem( )
    {
        moveItem.StartMoving( countDown.getStartTime( ) );
    }

    public void setOnMouse( )
    {
        isOnMouse = true;
        ToolConvertion.setOnGO( );
    }

    public void setExitMouse( )
    {
        isOnMouse = false;
        ToolConvertion.setExitGO( );
    }

    public int GetIndex( )
    {
        return transform.parent.GetSiblingIndex( );
    }
}
