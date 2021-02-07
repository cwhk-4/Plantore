using UnityEngine;

public class PopUpAnimation : MonoBehaviour
{
    [SerializeField] private RectTransform TargetBoard;
    [SerializeField] private float AnimationRate;
    private float AnimationSpeed;

    private bool IsShowing = false;
    private bool IsClosing = false;
    private bool BoardShown = false;

    void Start()
    {
        TargetBoard.localScale = Vector3.zero;
        TargetBoard.gameObject.SetActive( false );
        AnimationSpeed = ( 1 / AnimationRate );
    }

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
                Time.timeScale = 0;
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
                Time.timeScale = 1;
            }
        }
    }

    public void BoardButtonClick( )
    {
        BoardShown = TargetBoard.gameObject.activeSelf;

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
