﻿using UnityEngine;
using UnityEngine.UI;

public class ItemUIScroll : MonoBehaviour
{
    [Header( "Map Info" )]
    [SerializeField] private MapLevel map;
    private int mapLevel;

    [Header("Scrolling Setting")]
    [SerializeField] private RectTransform ScrollTransform;
    [SerializeField] private float ScrollingSpeed;
    [SerializeField] private float ScrollLimit = 800f;
    [SerializeField] private bool ToLeft = false;
    [SerializeField] private bool ToRight = false;

    [Header( "Page" )]
    private int[] PageLimit = { 0, 1, 1, 1 };
    [SerializeField] private int NowPage = 0;
    [SerializeField] private Image PageImage;
    [SerializeField] private Sprite[] PageSprite;

    [Header( "Button Setup" )]
    [SerializeField] private GameObject LeftButton;
    [SerializeField] private GameObject RightButton;
    
    private void Start( )
    {
        ResetScrollValue( );
        mapLevel = map.GetMapLevel( );
        if( mapLevel == 4 )
        {
            mapLevel = 3;
        }
    }

    public void OpenScroll( )
    {
        ResetScrollValue( );
        mapLevel = map.GetMapLevel( );
        if( mapLevel == 4 )
        {
            mapLevel = 3;
        }
    }

    private void Update( )
    {
        if( ToLeft && ( ScrollTransform.localPosition.x != NowPage * -ScrollLimit ) )
        {
            ScrollTransform.localPosition =
                new Vector3( ScrollTransform.localPosition.x + ScrollingSpeed,
                             ScrollTransform.localPosition.y,
                             ScrollTransform.localPosition.z );
        }
        else
        {
            PageImage.sprite = PageSprite[NowPage];
            ToLeft = false;
        }

        if( ToRight && ( ScrollTransform.localPosition.x != NowPage * -ScrollLimit ) )
        {
            ScrollTransform.localPosition =
                new Vector3( ScrollTransform.localPosition.x - ScrollingSpeed,
                             ScrollTransform.localPosition.y,
                             ScrollTransform.localPosition.z );
        }
        else
        {
            PageImage.sprite = PageSprite[NowPage];
            ToRight = false;
        }

        if( NowPage == 0 )
        {
            LeftButton.SetActive( false );
        }
        else
        {
            LeftButton.SetActive( true );
        }

        if( NowPage == PageLimit[mapLevel - 1] )
        {
            RightButton.SetActive( false );
        }
        else
        {
            RightButton.SetActive( true );
        }
    }

    public void LeftButtonClicked( )
    {
        if( NowPage > 0 )
        {
            NowPage -= 1;
            ToLeft = true;
            ToRight = false;
            mapLevel = map.GetMapLevel( );
            if( mapLevel == 4 )
            {
                mapLevel = 3;
            }
        }
    }

    public void RightButtonClick( )
    {
        mapLevel = map.GetMapLevel( );

        if( mapLevel == 4 )
        {
            mapLevel = 3;
        }

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
