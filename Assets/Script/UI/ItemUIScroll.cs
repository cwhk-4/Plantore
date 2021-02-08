using UnityEngine;

public class ItemUIScroll : MonoBehaviour
{
    [SerializeField] private RectTransform ScrollTransform;
    [SerializeField] private float ScrollingSpeed;

    [SerializeField] private float StartingValue;
    [SerializeField] private bool ToLeft = false;
    [SerializeField] private bool ToRight = false;

    private void Start( )
    {
        ResetScrollValue( );
    }

    private void Update( )
    {
        if( ToLeft && Mathf.Abs( ScrollTransform.localPosition.x - StartingValue ) < 800f )
        {
            ToRight = false;
            ScrollTransform.localPosition =
                new Vector3( ScrollTransform.localPosition.x + ScrollingSpeed,
                             ScrollTransform.localPosition.y,
                             ScrollTransform.localPosition.z );
        }

        if( ToRight && Mathf.Abs( ScrollTransform.localPosition.x - StartingValue ) < 800f )
        {
            ToLeft = false;
            ScrollTransform.localPosition =
                new Vector3( ScrollTransform.localPosition.x - ScrollingSpeed,
                             ScrollTransform.localPosition.y,
                             ScrollTransform.localPosition.z );
        }

        if( Mathf.Abs( ScrollTransform.localPosition.x - StartingValue ) >= 800f )
        {
            ToLeft = false;
            ToRight = false;
        }
    }

    public void LeftButtonClicked( )
    {
        if( ScrollTransform.localPosition.x == -400f )
        {
            ToLeft = true;
            StartingValue = ScrollTransform.localPosition.x;
        }
    }

    public void RightButtonClick( )
    {
        if( ScrollTransform.localPosition.x == 400f )
        {
            ToRight = true;
            StartingValue = ScrollTransform.localPosition.x;
        }
    }

    public void ResetScrollValue( )
    {
        ScrollTransform.localPosition = new Vector3( 400,
                                                     ScrollTransform.localPosition.y,
                                                     ScrollTransform.localPosition.z );
        StartingValue = ScrollTransform.localPosition.x;
        ToLeft = false;
        ToRight = false;
    }
}
