using UnityEngine;

public class ActivateMenu: MonoBehaviour
{
    [SerializeField] private GameObject Menu;
    [SerializeField] private GameObject MenuButton;

    private void Start( )
    {
        CloseMenu( );
    }

    public void CloseMenu()
    {
        Menu.SetActive( false );
    }

    public void OpenMenu()
    {
        Menu.SetActive( true );
    }

    public void CloseAllUI()
    {
        Menu.SetActive( false );
        MenuButton.SetActive( false );
    }

    public void InitUI( )
    {
        Menu.SetActive( false );
        MenuButton.SetActive( true );
    }
}
