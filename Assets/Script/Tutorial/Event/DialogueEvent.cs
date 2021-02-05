using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueEvent : MonoBehaviour
{
    [SerializeField] private GameObject dialogueWindow;

    [SerializeField] private ActivateMenu activateMenu;
    [SerializeField] private ItemUIInstantiate itemUIInstantiate;
    [SerializeField] private ToolConvertion toolConvertion;

    [SerializeField] private DialogueControl dialogueControl;

    [SerializeField] private GameObject BlackScreen;

    private bool isCounting = false;
    private float timer = 3f;

    [SerializeField] private GameObject Grass;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite originalGrass;
    [SerializeField] private Sprite driedGrass;


    private bool checkTool = false;

    [SerializeField] private GameObject toStageButton;

    [SerializeField] private GameObject _LION;
    [SerializeField] private GameObject _ZEBRA;

    [SerializeField] private GameObject leftGuide;
    [SerializeField] private GameObject rightGuide;

    private void Start( )
    {
        showDialogueWindow( );
        activateMenu.CloseMenu( );
        dialogueControl = GetComponent<DialogueControl>( );

        BlackScreen.SetActive( false );
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
        activateMenu.OpenMenu( );
    }

    public void grassClicked( )
    {
        showDialogueWindow( );
        activateMenu.CloseMenu( );
    }

    public void placeGrass( )
    {
        closeDialogueWindow( );
        itemUIInstantiate.itemInstantiate( Grass );
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

    private void installZebra( )
    {
        //GameObject OB_ZEBRA = Resources.Load( "Animals/Prefabs/zebra" ) as GameObject;
        if( GameObject.FindWithTag( "zebra" ) == null )
        {
            Instantiate( _ZEBRA );
        }
    }

    private void installLion( )
    {
        //GameObject OB_LION = Resources.Load( "Animals/Prefabs/lion" ) as GameObject;
        if( GameObject.FindWithTag( "lion" ) == null)
        {
            Instantiate( _LION );
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
