﻿using UnityEngine;

public class ToolConvertion : MonoBehaviour
{
    public Texture2D defaultCursor;
    public Texture2D wateringCan;
    public Vector2 canHotSpot = Vector2.zero;
    private bool isCan = false;

    void Start()
    {
        ResetCan( );
    }

    void Update()
    {
        if( Input.GetMouseButtonDown( 1 ) )
        {
            Cursor.SetCursor( wateringCan, canHotSpot, CursorMode.ForceSoftware );
            isCan = true;
        }

        if( Input.GetMouseButtonDown( 0 ) )
        {
            Cursor.SetCursor( defaultCursor, Vector2.zero, CursorMode.ForceSoftware );
            isCan = false;
        }
    }

    public bool GetIsCan( )
    {
        return isCan;
    }

    public void ResetCan( )
    {
        isCan = false;
        canHotSpot = new Vector2( 0f, wateringCan.height / 3 * 2 );
        Cursor.SetCursor( defaultCursor, Vector2.zero, CursorMode.ForceSoftware );
    }
}
