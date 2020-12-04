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

    public DialogueControl dialogueControl;

    public GameObject BlackScreen;

    private bool isCounting = false;
    private float timer = 3f;

    private void Start( )
    {
        dialogueWindow = GameObject.FindWithTag( "DialogueWindow" );
        showDialogueWindow( );

        activateMenu = GetComponent<ActivateMenu>( );
        activateMenu.disableMenuButton( );

        UIController = GameObject.FindWithTag( "UI" );
        itemUIInstantiate = UIController.GetComponent<ItemUIInstantiate>( );

        dialogueControl = GetComponent<DialogueControl>( );

        BlackScreen.SetActive( false );
    }

    private void Update( )
    {
        if( isCounting )
        {
            if( timer >= 0 )
            {
                timer -= Time.deltaTime;
            }
            else
            {
                calledAnimals( );
                timer = 3f;
                isCounting = false;
            }
        }
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

    public void finishedLoading( )
    {
        BlackScreen.SetActive( false );

        if( dialogueControl.getDialogueCount( ) == 4 )
        {
            //callZebra
        }

        if( dialogueControl.getDialogueCount( ) == 5 )
        {
            //callLion
        }

        isCounting = true;
    }

    public void calledAnimals( )
    {
        showDialogueWindow( );
    }

    public void finishedTutorial( )
    {
        SceneManager.LoadScene( "Stage" );
    }
}
