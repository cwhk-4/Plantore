using UnityEngine;
using UnityEngine.UI;

public class TimeDisplayBarAnimation : MonoBehaviour
{
    [SerializeField] private bool isOpen;
    [SerializeField] private bool isMoving;
    [SerializeField] private RectTransform timeBarRect;
    [SerializeField] private RectTransform buttonRect;
    [SerializeField] private float toPosX;
    [SerializeField] private float originalPosX;
    [SerializeField] private float movingSpeed;

    void Start()
    {
        isOpen = false;
        isMoving = false;
        timeBarRect.anchoredPosition = new Vector2( originalPosX, timeBarRect.anchoredPosition.y );
    }

    private void Update( )
    {
        if( isMoving )
        {
            if( isOpen )
            {
                timeBarRect.anchoredPosition = new Vector2( timeBarRect.anchoredPosition.x - movingSpeed, timeBarRect.anchoredPosition.y );
            }
            else
            {
                timeBarRect.anchoredPosition = new Vector2( timeBarRect.anchoredPosition.x + movingSpeed, timeBarRect.anchoredPosition.y );
            }

            if( isOpen && timeBarRect.anchoredPosition.x <= toPosX)
            {
                isMoving = false;
                buttonRect.rotation = new Quaternion( 0, 0, 180, 0 );
                timeBarRect.anchoredPosition = new Vector2( toPosX, timeBarRect.anchoredPosition.y );
            }

            if( !isOpen && timeBarRect.anchoredPosition.x >= originalPosX )
            {
                isMoving = false;
                buttonRect.rotation = new Quaternion( 0, 0, 0, 0 );
                timeBarRect.anchoredPosition = new Vector2( originalPosX, timeBarRect.anchoredPosition.y );
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
