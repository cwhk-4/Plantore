using UnityEngine;

public class SettingUIControl : MonoBehaviour
{
    [SerializeField] private GameObject settingUI;
    [SerializeField] private TimeController TimeController;

    void Start()
    {
        settingUI.SetActive( false );
    }

    public void CloseSettingUI( )
    {
        settingUI.SetActive( false );
        TimeController.StartTime( );
    }

    public void OpenSettingUI( )
    {
        settingUI.SetActive( true );
        TimeController.StopTime( );
    }
}
