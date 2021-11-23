using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagementScript : MonoBehaviour
{
    public void GoToTutorial( )
    {
        SceneManager.LoadSceneAsync( "Tutorial" );
    }

    public void GoToStage( )
    {
        SceneManager.LoadSceneAsync( "Stage" );
    }

    public void GoToTitle( )
    {
        SceneManager.LoadSceneAsync( "Title" );
    }
}
