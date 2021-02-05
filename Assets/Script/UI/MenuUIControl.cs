using UnityEngine;

public class MenuUIControl : MonoBehaviour
{
    public GameObject Menu;
    public GameObject OpenButton;
    public GameObject CloseButton;

    private void Start( )
    {
        closeMenu( );
    }

    public void openMenu()
    {
        //Menu.SetActive( true );
        CloseButton.SetActive( true );
        OpenButton.SetActive( false );
        Time.timeScale = 0;
    }

    public void closeMenu()
    {
        //Menu.SetActive(false);
        CloseButton.SetActive( false );
        OpenButton.SetActive( true );
        Time.timeScale = 1;
    }
}
