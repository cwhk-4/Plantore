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

    public GameObject Grass;
    public SpriteRenderer spriteRenderer;
    public Sprite originalGrass;
    public Sprite driedGrass;

    public GameObject cursor;
    public ToolConvertion toolConvertion;

    private bool checkTool = false;

    public GameObject toStageButton;

    public GameObject _LION;
    public GameObject _ZEBRA;

    public GameObject leftGuide;
    public GameObject rightGuide;

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

        cursor = GameObject.FindWithTag( "Cursor" );
        toolConvertion = cursor.GetComponent<ToolConvertion>( );

        toStageButton = GameObject.FindWithTag( "ToStageButton" );
        toStageButton.SetActive( false );

        leftGuide.SetActive( false );
        rightGuide.SetActive( false );
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
                showDialogueWindow( );
                isCounting = false;
            }
        }

        if( checkTool )
        {
            if( toolConvertion.getIsCan( ) )
            {
                closeMouseRightGuide( );
                checkTool = false;
                showDialogueWindow( );
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

    public void openMenu( )
    {
        closeDialogueWindow( );
        showMouseLeftGuide( new Vector2( 840, 190 ) );
    }

    public void clickItemMenu( )
    {
        closeMouseRightGuide( );
        showMouseLeftGuide( new Vector2( -335, -225 ) );
    }

    public void clickItem()
    {
        showMouseLeftGuide( new Vector2( -320, -290 ) );
    }

    private void showMouseRightGuide( Vector2 toPos )
    {
        rightGuide.GetComponent<RectTransform>( ).anchoredPosition = toPos;
        rightGuide.SetActive( true );
    }

    private void showMouseLeftGuide( Vector2 toPos )
    {
        leftGuide.GetComponent<RectTransform>( ).anchoredPosition = toPos;
        leftGuide.SetActive( true );
    }

    public void closeMouseRightGuide( )
    {
        rightGuide.SetActive( false );
    }

    public void closeMouseLeftGuide( )
    {
        leftGuide.SetActive( false );
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
        itemUIInstantiate.itemInstantiate( null );
    }

    public void grassPlaced( )
    {
        showDialogueWindow( );

        Grass = GameObject.FindWithTag( "Grass" );
        spriteRenderer = Grass.GetComponent<SpriteRenderer>( );
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
        isCounting = true;
    }

    public void installAnimals( )
    {
        if( dialogueControl.getDialogueCount( ) == 5 )
        {
            installZebra( );
        }
        else if( dialogueControl.getDialogueCount( ) == 6 )
        {
            changeToDriedGrass( );
            installLion( );
        }
    }

    private void changeToDriedGrass( )
    {
        spriteRenderer.sprite = driedGrass;
    }

    //caution
    //install Animals
    private void installZebra( )
    {
        GameObject OB_ZEBRA = Resources.Load( "Animals/Prefabs/zebra" ) as GameObject;
        if( GameObject.FindWithTag( "zebra" ) == null )
        {
            Instantiate( OB_ZEBRA );
        }
    }

    private void installLion( )
    {
        GameObject OB_LION = Resources.Load( "Animals/Prefabs/lion" ) as GameObject;
        if( GameObject.FindWithTag( "lion" ) == null)
        {
            Instantiate( OB_LION );
        }
    }

    public void changeTool()
    {
        closeDialogueWindow( );
        //Vector2 pos = new Vector2( Input.mousePosition.x, Input.mousePosition.y );
        showMouseRightGuide( Vector2.zero );
        checkTool = true;
    }

    public void waitForRepair( )
    {
        closeDialogueWindow( );
        //Vector2 pos = new Vector2( Input.mousePosition.x, Input.mousePosition.y );
        showMouseLeftGuide( Vector2.zero );
    }

    public void repairGrass( )
    {
        spriteRenderer.sprite = originalGrass;
        closeMouseLeftGuide( );
        isCounting = true;
        timer = 2f;
    }

    public void showToStageButton( )
    {
        toStageButton.SetActive( true );
    }

    public void finishedTutorial( )
    {
        SceneManager.LoadScene( "Stage" );
    }
}
