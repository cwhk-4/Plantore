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
    }

    public void OpenSettingUI( )
    {
        settingUI.SetActive( true );
    }
}
