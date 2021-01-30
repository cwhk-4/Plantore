using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopUpAnimation : MonoBehaviour
{
    [SerializeField] private Button[] buttons;
    [SerializeField] private RawImage[] rawImages;
    [SerializeField] private Image[] images;

    private RectTransform[] buttonRect;
    private RectTransform[] rawImageRect;
    private RectTransform[] ImageRect;

    [SerializeField] private float animationSpeed = 10f;

    private bool isOpen = false;
    private bool isMoving = false;

    private void Start( )
    {
        isOpen = false;
        isMoving = false;

        buttonRect = new RectTransform[buttons.Length];
        for( int i = 0; i < buttons.Length; i++ )
        {
            buttonRect[i] = buttons[i].gameObject.GetComponent<RectTransform>( );
        }
    }

    private void Update( )
    {
        if( isMoving )
        {
            if( isOpen )
            {
                for( int i = 0; i < buttons.Length; i++ )
                {
                }

                //MissionClearBoard.localScale =
                //    new Vector3( MissionClearBoard.localScale.x + AnimationSpeed,
                //    MissionClearBoard.localScale.y + AnimationSpeed,
                //    MissionClearBoard.localScale.z + AnimationSpeed );

                //if( MissionClearBoard.localScale == Vector3.one )
                //{
                //    isMoving = false;
                //}
            }

            if( !isOpen )
            {
                //MissionClearBoard.localScale =
                //    new Vector3( MissionClearBoard.localScale.x - AnimationSpeed,
                //    MissionClearBoard.localScale.y - AnimationSpeed,
                //    MissionClearBoard.localScale.z - AnimationSpeed );

                //if( MissionClearBoard.localScale == Vector3.zero )
                //{
                //    isMoving = false;
                //}
            }
        }
    }

    public void OpenBox( )
    {
        isOpen = true;
        isMoving = true;
    }

    public void CloseBox( )
    {
        isOpen = false;
        isMoving = true;
    }
}
