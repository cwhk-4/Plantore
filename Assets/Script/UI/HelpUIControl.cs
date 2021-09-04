using UnityEngine;

public class HelpUIControl : MonoBehaviour
{
    [SerializeField] private GameObject helpUI;

    void Start( )
    {
        CloseHelpUI( );
    }

    public void CloseHelpUI( )
    {
        helpUI.SetActive( false );
        Time.timeScale = 1;
    }

    public void OpenHelpUI( )
    {
        helpUI.SetActive( true );
        Time.timeScale = 0;
    }
}
