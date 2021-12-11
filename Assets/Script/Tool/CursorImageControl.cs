using UnityEngine;

public class CursorImageControl : MonoBehaviour
{
    public Texture2D defaultCursor;

    void Start()
    {
        Cursor.SetCursor( defaultCursor, Vector2.zero, CursorMode.ForceSoftware );
    }

}
