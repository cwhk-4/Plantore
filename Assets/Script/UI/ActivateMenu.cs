using UnityEngine;

public class ActivateMenu: MonoBehaviour
{
    public GameObject Menu;
    public GameObject OpenButton;
    public GameObject CloseButton;

    private void Start( )
    {
        Menu.SetActive( false );
    }

    public void CloseMenu()
    {
        Menu.SetActive( false );
        CloseButton.SetActive( false );
        OpenButton.SetActive( true );
    }

    public void OpenMenu()
    {
        Menu.SetActive( true );
        CloseButton.SetActive( true );
        OpenButton.SetActive( false );
    }

    public void InitUI( )
    {
        OpenButton.SetActive( false );
        CloseButton.SetActive( false );
        Menu.SetActive( false );
    }
}
