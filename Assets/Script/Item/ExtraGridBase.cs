﻿using UnityEngine;
using UnityEngine.EventSystems;

public class ExtraGridBase : MonoBehaviour
{
    [SerializeField] private ToolConvertion ToolConvertion;
    [SerializeField] private GameObject ParentItem;

    [SerializeField] private bool isOnMouse;
    private float clickDelay = 1;
    private float clickTime;
    [SerializeField] private int click;

    private void Start( )
    {
        ToolConvertion = GameObject.FindWithTag( "Cursor" ).GetComponent<ToolConvertion>( );
        isOnMouse = false;
    }

    public void SetParent( GameObject gameObject )
    {
        ParentItem = gameObject;
    }

    private void Update( )
    {
        if( isOnMouse )
        {
            if( ToolConvertion.GetIsCan( ) )
            {
                if( Input.GetMouseButtonDown( 0 ) )
                {
                    if( ParentItem.GetComponent<CountDown>( ).GetCD( ) <= 0 )
                    {
                        ParentItem.GetComponent<ItemBase>().Repair( );
                    }

                }

            }
            else
            {
                if( Input.GetMouseButtonUp( 0 ) )
                {
                    if( EventSystem.current.IsPointerOverGameObject( ) )
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
                        ParentItem.GetComponent<ItemBase>( ).MoveItem( );
                    }
                }
            }


        }
    }

    public void SetOnMouse( )
    {
        isOnMouse = true;
        ToolConvertion.SetOnGO( );
    }

    public void SetExitMouse( )
    {
        isOnMouse = false;
        ToolConvertion.SetExitGO( );
    }

    public void ShowGauge( )
    {
        if( ParentItem != null )
        {
            ParentItem.GetComponent<CountDown>( ).ShowGauge( );
        }
    }

    public void CloseGauge( )
    {
        if( ParentItem != null )
        {
            ParentItem.GetComponent<CountDown>( ).CloseGauge( );
        }
    }
}
