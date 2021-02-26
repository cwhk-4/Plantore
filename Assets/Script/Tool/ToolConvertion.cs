using UnityEngine;

public class ToolConvertion : MonoBehaviour
{
    public Texture2D wateringCan;
    public Vector2 canhotSpot = Vector2.zero;
    private bool isCan = false;
    private bool isOnGO = false;

    void Start()
    {
        ResetCan( );
    }

    void Update()
    {
        if( Input.GetMouseButtonDown( 1 ) )
        {
            if( !isCan )
            {
                Cursor.SetCursor( wateringCan, canhotSpot, CursorMode.ForceSoftware );
                isCan = true;
            }
            else
            {
                Cursor.SetCursor( null, Vector2.zero, CursorMode.ForceSoftware );
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

    public void ResetCan( )
    {
        isCan = false;
        canhotSpot = new Vector2( 0f, wateringCan.height / 3 * 2 );
        Cursor.SetCursor( null, Vector2.zero, CursorMode.Auto );
    }
}
