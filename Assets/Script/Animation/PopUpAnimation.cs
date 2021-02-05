using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpAnimation : MonoBehaviour
{
    [SerializeField] private RectTransform TargetBoard;
    [SerializeField] private float AnimationRate;
    private float AnimationSpeed;

    private bool IsShowing = false;
    private bool IsClosing = false;
    private bool BoardShown = false;

    // Start is called before the first frame update
    void Start()
    {
        TargetBoard.localScale = Vector3.zero;
        TargetBoard.gameObject.SetActive( false );
        AnimationSpeed = ( 1 / AnimationRate );
    }

    // Update is called once per frame
    void Update()
    {
        if( IsShowing )
        {
            TargetBoard.localScale =
                new Vector3( TargetBoard.localScale.x + AnimationSpeed,
                TargetBoard.localScale.y + AnimationSpeed,
                TargetBoard.localScale.z + AnimationSpeed );

            if( TargetBoard.localScale == Vector3.one )
            {
                IsShowing = false;
                BoardShown = true;
            }
        }

        if( IsClosing )
        {
            TargetBoard.localScale =
                new Vector3( TargetBoard.localScale.x - AnimationSpeed,
                TargetBoard.localScale.y - AnimationSpeed,
                TargetBoard.localScale.z - AnimationSpeed );

            if( TargetBoard.localScale == Vector3.zero )
            {
                IsClosing = false;
                BoardShown = false;
                TargetBoard.gameObject.SetActive( false );
            }
        }
    }

    public void BoardButtonClick( )
    {
        if( BoardShown )
        {
            IsClosing = true;
        }
        else
        {
            IsShowing = true;
            TargetBoard.localScale = Vector3.zero;
            TargetBoard.gameObject.SetActive( true );
        }
    }
}
