using UnityEngine;

public class ItemUIControl : MonoBehaviour
{
    [SerializeField] private GameObject ItemMenu;
    [SerializeField] private TimeController TimeController;

    void Start( )
    {
        ItemMenu.SetActive( false );
    }

    public void openUIMenu( )
    {
        ItemMenu.SetActive( true );
        TimeController.StopTime( );
    }

    public void closeUIMenu( )
    {
        ItemMenu.SetActive( false );
        TimeController.StartTime( );
    }
}
