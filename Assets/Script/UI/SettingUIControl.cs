using UnityEngine;

public class SettingUIControl : MonoBehaviour
{
    [SerializeField] private GameObject settingUI;

    void Start()
    {
        CloseSettingUI( );
    }

    public void CloseSettingUI( )
    {
        settingUI.SetActive( false );
        Time.timeScale = 1;
    }

    public void OpenSettingUI( )
    {
        settingUI.SetActive( true );
        Time.timeScale = 0;
    }
}
