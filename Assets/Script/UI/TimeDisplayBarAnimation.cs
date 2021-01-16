using UnityEngine;
using UnityEngine.UI;

public class TimeDisplayBarAnimation : MonoBehaviour
{
    [SerializeField] private bool isOpen;
    [SerializeField] private bool isMoving;
    [SerializeField] private GameObject openButton;
    [SerializeField] private RectTransform buttonRect;
    [SerializeField] private float toPosX;
    [SerializeField] private float originalPosX;
    [SerializeField] private float movingSpeed;

    void Start()
    {
        isOpen = false;
        isMoving = false;
        buttonRect = openButton.GetComponent<RectTransform>( );
    }

    private void Update( )
    {
        if( isMoving )
        {
            if( isOpen )
            {
                buttonRect.anchoredPosition = new Vector2( buttonRect.anchoredPosition.x - movingSpeed, buttonRect.anchoredPosition.y );
            }
            else
            {
                buttonRect.anchoredPosition = new Vector2( buttonRect.anchoredPosition.x + movingSpeed, buttonRect.anchoredPosition.y );
            }

            if( isOpen && buttonRect.anchoredPosition.x <= toPosX)
            {
                isMoving = false;
            }

            if( !isOpen && buttonRect.anchoredPosition.x >= originalPosX )
            {
                isMoving = false;
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
}
