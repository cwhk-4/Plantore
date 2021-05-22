using UnityEngine;

public class ItemUIScroll : MonoBehaviour
{
    [SerializeField] private RectTransform ScrollTransform;
    [SerializeField] private float ScrollingSpeed;
    [SerializeField] private float ScrollLimit = 800f;

    [SerializeField] private MapLevel map;
    private int mapLevel;

    [SerializeField] private float StartingValue;
    [SerializeField] private bool ToLeft = false;
    [SerializeField] private bool ToRight = false;

    private void Start( )
    {
        ResetScrollValue( );
        mapLevel = map.getMapLevel( );
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

        if( ScrollTransform.localPosition.x > 0 )
        {
            ScrollTransform.localPosition = new Vector3( 0,
                                                     ScrollTransform.localPosition.y,
                                                     ScrollTransform.localPosition.z );
        }

        if( ScrollTransform.localPosition.x < -ScrollLimit * mapLevel )
        {
            ScrollTransform.localPosition = new Vector3( -ScrollLimit * mapLevel,
                                                     ScrollTransform.localPosition.y,
                                                     ScrollTransform.localPosition.z );
        }
    }

    public void LeftButtonClicked( )
    {
        if( ScrollTransform.localPosition.x < 0 )
        {
            ToLeft = true;
            ToRight = false;
            StartingValue = ScrollTransform.localPosition.x;
            mapLevel = map.getMapLevel( );
        }
    }

    public void RightButtonClick( )
    {
        if( ScrollTransform.localPosition.x > -ScrollLimit * mapLevel )
        {
            ToRight = true;
            ToLeft = false;
            StartingValue = ScrollTransform.localPosition.x;
            mapLevel = map.getMapLevel( );
        }
    }

    public void ResetScrollValue( )
    {
        ScrollTransform.localPosition = new Vector3( 0,
                                                     ScrollTransform.localPosition.y,
                                                     ScrollTransform.localPosition.z );
        StartingValue = ScrollTransform.localPosition.x;
        ToLeft = false;
        ToRight = false;
    }
}
