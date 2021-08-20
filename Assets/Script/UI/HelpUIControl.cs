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
    }

    public void OpenHelpUI( )
    {
        helpUI.SetActive( true );
    }
}
