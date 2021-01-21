using UnityEngine;
using UnityEngine.UI;

public class MissionTextBoxAnimation : MonoBehaviour
{
    [SerializeField] private bool isOpen;
    [SerializeField] private bool isMoving;
    [SerializeField] private RectTransform TextBoxRect;
    [SerializeField] private float toPosX;
    [SerializeField] private float originalPosX;
    [SerializeField] private float movingSpeed;

    void Start( )
    {
        isOpen = false;
        isMoving = false;
        TextBoxRect.anchoredPosition = new Vector2( originalPosX, TextBoxRect.anchoredPosition.y );
    }

    private void Update( )
    {
        if( isMoving )
        {
            if( isOpen )
            {
                TextBoxRect.anchoredPosition = new Vector2( TextBoxRect.anchoredPosition.x - movingSpeed, TextBoxRect.anchoredPosition.y );
            }
            else
            {
                TextBoxRect.anchoredPosition = new Vector2( TextBoxRect.anchoredPosition.x + movingSpeed, TextBoxRect.anchoredPosition.y );
            }

            if( isOpen && TextBoxRect.anchoredPosition.x <= toPosX )
            {
                isMoving = false;
                TextBoxRect.anchoredPosition = new Vector2( toPosX, TextBoxRect.anchoredPosition.y );
            }

            if( !isOpen && TextBoxRect.anchoredPosition.x >= originalPosX )
            {
                isMoving = false;
                TextBoxRect.anchoredPosition = new Vector2( originalPosX, TextBoxRect.anchoredPosition.y );
            }
        }
    }

    public void ButtonClicked( )
    {
        if( isOpen )
        {
            isOpen = false;
            isMoving = true;
        }
        else
        {
            isOpen = true;
            isMoving = true;
        }
    }

    public void CloseMenu( )
    {
        isOpen = false;
        isMoving = true;
    }

    public void OpenMenu( )
    {
        isOpen = true;
        isMoving = true;
    }
}
