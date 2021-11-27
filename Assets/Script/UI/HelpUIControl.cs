using UnityEngine;

public class HelpUIControl : MonoBehaviour
{
    [SerializeField] private GameObject helpUI;
    [SerializeField] private TimeController TimeController;

    void Start( )
    {
        helpUI.SetActive( false );
    }

    public void CloseHelpUI( )
    {
        helpUI.SetActive( false );
        TimeController.StartTime( );
    }

    public void OpenHelpUI( )
    {
        helpUI.SetActive( true );
        TimeController.StopTime( );
    }
}
