using UnityEngine;

public class ItemUIControl : MonoBehaviour
{
    public GameObject ItemMenu;

    void Start( )
    {
        closeUIMenu( );
        Time.timeScale = 1;
    }

    public void openUIMenu( )
    {
        ItemMenu.SetActive( true );
        Time.timeScale = 0;
    }

    public void closeUIMenu( )
    {
        ItemMenu.SetActive( false );
        Time.timeScale = 1;
    }
}
