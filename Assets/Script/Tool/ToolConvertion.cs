using UnityEngine;

public class ToolConvertion : MonoBehaviour
{
    public Texture2D wateringCan;
    public Vector2 canhotSpot = Vector2.zero;
    private bool isCan = false;
    private bool isOnGO = false;

    void Start()
    {
        isCan = false;
        canhotSpot = new Vector2( 0f , wateringCan.height / 3 * 2 );
        Cursor.SetCursor( null, Vector2.zero, CursorMode.Auto );
    }

    void Update()
    {
        if( Input.GetMouseButtonDown( 1 ) )
        {
            if( !isCan && !isOnGO)
            {
                Cursor.SetCursor( wateringCan, canhotSpot, CursorMode.Auto );
                isCan = true;
            }
            else
            {
                Cursor.SetCursor( null, Vector2.zero, CursorMode.Auto );
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
