using UnityEngine;

public class IndexUIControl : MonoBehaviour
{
    [SerializeField] private GameObject indexUI;

    void Start( )
    {
        CloseIndexUI( );
    }

    public void CloseIndexUI( )
    {
        indexUI.SetActive( false );
        Time.timeScale = 1;
    }

    public void OpenIndexUI( )
    {
        indexUI.SetActive( true );
        Time.timeScale = 0;
    }
}
