using UnityEngine;
using UnityEngine.UI;

public class MenuUIControl : MonoBehaviour
{
    [SerializeField] private GameObject Menu;
    [SerializeField] Image MenuButton;

    private void Start( )
    {
        Menu.SetActive( false );
    }

    public void InitUI( )
    {
        MenuButton.gameObject.SetActive( false );
        Menu.SetActive( false );
    }
}
