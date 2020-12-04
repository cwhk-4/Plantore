using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public void clickStart()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void clickSkipTutorial( )
    {
        SceneManager.LoadScene( "Stage" );
    }    
}
