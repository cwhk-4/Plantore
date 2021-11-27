using UnityEngine;

public class PopUpAnimation : MonoBehaviour
{
    [SerializeField] private TimeController TimeController;
    [SerializeField] private GameObject MapUI;
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
                TimeController.StopTime( );
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
                TimeController.StartTime( );
            }
        }
    }

    public void BoardButtonClick( )
    {
        BoardShown = targetBoard.gameObject.activeSelf;

        if( BoardShown )
        {
            MapUI.SetActive( true );
            IsClosing = true;
        }
        else
        {
            menuControl.EnableBG( );
            MapUI.SetActive( false );
            IsShowing = true;
            targetBoard.localScale = Vector3.zero;
            targetBoard.gameObject.SetActive( true );
        }
    }
}
