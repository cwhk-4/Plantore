using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugCmd : MonoBehaviour
{
    void Update()
    {
        if( Input.GetKey( KeyCode.LeftShift ) )
        {
            if( Input.GetKey( KeyCode.Q ) )
            {
                SceneManager.LoadSceneAsync( "Title" );
            }

            if( Input.GetKey( KeyCode.W ) )
            {
                SceneManager.LoadSceneAsync( "Tutorial" );
            }

            if( Input.GetKey( KeyCode.E ) )
            {
                SceneManager.LoadSceneAsync( "Stage" );
            }

            if( Input.GetKey( KeyCode.X ) )
            {
                Application.Quit( );
            }
        }
    }
}
