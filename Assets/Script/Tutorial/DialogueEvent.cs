using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueEvent : MonoBehaviour
{
    public GameObject dialogueWindow;
    public ActivateMenu activateMenu;

    public GameObject UIController;
    public ItemUIInstantiate itemUIInstantiate;

    public GameObject BlackScreen;

    private void Start( )
    {
        dialogueWindow = GameObject.FindWithTag( "DialogueWindow" );
        showDialogueWindow( );

        activateMenu = GetComponent<ActivateMenu>( );
        activateMenu.disableMenuButton( );

        UIController = GameObject.FindWithTag( "UI" );
        itemUIInstantiate = UIController.GetComponent<ItemUIInstantiate>( );

        BlackScreen.SetActive( false );
    }

    public void showDialogueWindow( )
    {
        dialogueWindow.SetActive( true );
    }

    public void closeDialogueWindow( )
    {
        dialogueWindow.SetActive( false );
    }

    public bool getDialogueWindowState( )
    {
        return dialogueWindow.activeSelf;
    }

    public void showGrass( )
    {
        closeDialogueWindow( );
        activateMenu.enableMenuButton( );
    }

    public void grassClicked( )
    {
        showDialogueWindow( );
        activateMenu.disableMenuButton( );
    }

    public void placeGrass( )
    {
        closeDialogueWindow( );
        itemUIInstantiate.itemInstantiate( );
    }

    public void grassPlaced( )
    {
        showDialogueWindow( );
    }

    public void showBlackScreen( )
    {
        closeDialogueWindow( );
        BlackScreen.SetActive( true );
        BlackScreen.GetComponent<BlackScreenAnimationController>( ).show = true;
    }

    public void calledZebra( )
    {
        showDialogueWindow( );
    }

    public void calledLion( )
    {
        showDialogueWindow( );
    }

    public void finishedLoading( )
    {
        BlackScreen.SetActive( false );
        showDialogueWindow( );
    }

    public void finishedTutorial( )
    {
        SceneManager.LoadScene( "Stage" );
    }
}
