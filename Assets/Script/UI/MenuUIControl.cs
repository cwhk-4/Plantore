using UnityEngine;

public class MenuUIControl : MonoBehaviour
{
    [SerializeField] private GameObject MapUI;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject menuButton;
    [SerializeField] private GameObject background;

    private void Start( )
    {
        CloseMenu( );
    }

    public void CloseMenu( )
    {
        menu.SetActive( false );
    }

    public void OpenMenu( )
    {
        menu.SetActive( true );
    }

    public void CloseAllUI( )
    {
        menu.SetActive( false );
        menuButton.SetActive( false );
        background.SetActive( false );
    }

    public void InitUI( )
    {
        menu.SetActive( false );
        menuButton.SetActive( true );
        background.SetActive( false );
    }

    public void EnableBG( )
    {
        MapUI.SetActive( false );
        background.SetActive( true );
    }

    public void DisableBG( )
    {
        background.SetActive( false );
        MapUI.SetActive( true );
    }
}
