using UnityEngine;
using UnityEngine.UI;

public class MenuUIControl : MonoBehaviour
{
    [SerializeField] private GameObject Menu;
    [SerializeField] Image MenuButton;

    [SerializeField] private Sprite Open;
    [SerializeField] private Sprite Close;

    private void Start( )
    {
        Menu.SetActive( false );
        CloseMenu( );
    }

    public void MenuButtonClick( )
    {
        if( Menu.activeSelf )
        {
            CloseMenu( );
        }
        else
        {
            OpenMenu( );
        }
    }

    public void CloseMenu( )
    {
        MenuButton.sprite = Close;
    }

    public void OpenMenu( )
    {
        MenuButton.sprite = Open;
    }

    public void InitUI( )
    {
        MenuButton.gameObject.SetActive( false );
        Menu.SetActive( false );
    }
}
