using UnityEngine;

public class PopUpAnimation : MonoBehaviour
{
    [SerializeField] private MenuUIControl menuControl;
    [SerializeField] private RectTransform targetBoard;
    [SerializeField] private float animationRate;
    private float animationSpeed;

    private bool IsShowing = false;
    private bool IsClosing = false;
    private bool BoardShown = false;

    void Start()
    {
        targetBoard.localScale = Vector3.zero;
        targetBoard.gameObject.SetActive( false );
        animationSpeed = ( 1 / animationRate );
    }

    void Update()
    {
        if( IsShowing )
        {
            targetBoard.localScale =
                new Vector3( targetBoard.localScale.x + animationSpeed,
                targetBoard.localScale.y + animationSpeed,
                targetBoard.localScale.z + animationSpeed );

            if( targetBoard.localScale == Vector3.one )
            {
                IsShowing = false;
                BoardShown = true;
                Time.timeScale = 0;
            }
        }

        if( IsClosing )
        {
            targetBoard.localScale =
                new Vector3( targetBoard.localScale.x - animationSpeed,
                targetBoard.localScale.y - animationSpeed,
                targetBoard.localScale.z - animationSpeed );

            if( targetBoard.localScale == Vector3.zero )
            {
                IsClosing = false;
                BoardShown = false;
                menuControl.DisableBG( );
                targetBoard.gameObject.SetActive( false );
                Time.timeScale = 1;
            }
        }
    }

    public void BoardButtonClick( )
    {
        BoardShown = targetBoard.gameObject.activeSelf;

        if( BoardShown )
        {
            IsClosing = true;
        }
        else
        {
            IsShowing = true;
            targetBoard.localScale = Vector3.zero;
            targetBoard.gameObject.SetActive( true );
        }
    }
}
