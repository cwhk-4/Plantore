using UnityEngine;

public class ItemUIScroll : MonoBehaviour
{
    [SerializeField] private RectTransform ScrollTransform;
    [SerializeField] private float ScrollingSpeed;
    [SerializeField] private float ScrollLimit = 800f;

    [SerializeField] private int[] PageLimit = { 1, 2, 3, 4 };
    [SerializeField] private int NowPage = 0;

    [SerializeField] private MapLevel map;
    private int mapLevel;

    [SerializeField] private bool ToLeft = false;
    [SerializeField] private bool ToRight = false;

    private void Start( )
    {
        ResetScrollValue( );
        mapLevel = map.getMapLevel( );
    }

    private void Update( )
    {
        if( ToLeft && ( ScrollTransform.localPosition.x != NowPage * -800f ) )
        {
            ScrollTransform.localPosition =
                new Vector3( ScrollTransform.localPosition.x + ScrollingSpeed,
                             ScrollTransform.localPosition.y,
                             ScrollTransform.localPosition.z );
        }
        else
        {
            ToLeft = false;
        }

        if( ToRight && ( ScrollTransform.localPosition.x != NowPage * -800f ) )
        {
            ScrollTransform.localPosition =
                new Vector3( ScrollTransform.localPosition.x - ScrollingSpeed,
                             ScrollTransform.localPosition.y,
                             ScrollTransform.localPosition.z );
        }
        else
        {
            ToRight = false;
        }

        //if( ToLeft && Mathf.Abs( ScrollTransform.localPosition.x - StartingValue ) < 800f )
        //{
        //    ToRight = false;
        //    ScrollTransform.localPosition =
        //        new Vector3( ScrollTransform.localPosition.x + ScrollingSpeed,
        //                     ScrollTransform.localPosition.y,
        //                     ScrollTransform.localPosition.z );
        //}

        //if( ToRight && Mathf.Abs( ScrollTransform.localPosition.x - StartingValue ) < 800f )
        //{
        //    ToLeft = false;
        //    ScrollTransform.localPosition =
        //        new Vector3( ScrollTransform.localPosition.x - ScrollingSpeed,
        //                     ScrollTransform.localPosition.y,
        //                     ScrollTransform.localPosition.z );
        //}

        //if( Mathf.Abs( ScrollTransform.localPosition.x - StartingValue ) >= 800f )
        //{
        //    ToLeft = false;
        //    ToRight = false;
        //}

        //if( ScrollTransform.localPosition.x > 0 )
        //{
        //    ScrollTransform.localPosition = new Vector3( 0,
        //                                             ScrollTransform.localPosition.y,
        //                                             ScrollTransform.localPosition.z );
        //}

        //if( ScrollTransform.localPosition.x < -ScrollLimit * mapLevel )
        //{
        //    ScrollTransform.localPosition = new Vector3( -ScrollLimit * mapLevel,
        //                                             ScrollTransform.localPosition.y,
        //                                             ScrollTransform.localPosition.z );
        //}
    }

    public void LeftButtonClicked( )
    {
        if( NowPage > 0 )
        {
            NowPage -= 1;
            ToLeft = true;
            ToRight = false;
            mapLevel = map.getMapLevel( );
        }
    }

    public void RightButtonClick( )
    {
        mapLevel = map.getMapLevel( );

        if( NowPage < PageLimit[mapLevel - 1] )
        {
            NowPage += 1;
            ToRight = true;
            ToLeft = false;
        }
    }

    public void ResetScrollValue( )
    {
        NowPage = 0;
        ScrollTransform.localPosition = new Vector3( 0,
                                                     ScrollTransform.localPosition.y,
                                                     ScrollTransform.localPosition.z );
        ToLeft = false;
        ToRight = false;
    }
}
