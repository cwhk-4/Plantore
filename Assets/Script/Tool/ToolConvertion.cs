using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolConvertion : MonoBehaviour
{
    public Texture2D wateringCan;
    public Vector2 hotSpot = Vector2.zero;
    private bool isCan = false;
    private bool isOnGO = false;

    public GameObject grass = null;
    public ItemMovement itemMovement;

    void Start()
    {
        isCan = false;
    }

    void Update()
    {
        if( Input.GetMouseButtonDown( 1 ) )
        {
            if( !isCan && !isOnGO)
            {
                Cursor.SetCursor( wateringCan, hotSpot, CursorMode.Auto );
                isCan = true;
            }
            else
            {
                Cursor.SetCursor( null, hotSpot, CursorMode.Auto );
                isCan = false;
            }
        }
    }

    public bool getIsCan( )
    {
        return isCan;
    }

    public void setOnGO( )
    {
        isOnGO = true;
    }

    public void setExitGO()
    {
        isOnGO = false;
    }
}
