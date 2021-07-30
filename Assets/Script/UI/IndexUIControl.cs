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
    }

    public void OpenIndexUI( )
    {
        indexUI.SetActive( true );
    }
}
