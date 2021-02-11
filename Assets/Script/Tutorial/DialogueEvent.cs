using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueEvent : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject dialogueWindow;

    [SerializeField] private ActivateMenu activateMenu;
    [SerializeField] private PopUpAnimation popUp;
    [SerializeField] private TutorialInstanFromUI itemUIInstantiate;
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
        activateMenu.CloseAllUI( );
        dialogueControl = GetComponent<DialogueControl>( );

        BlackScreen.SetActive( false );
        toStageButton.SetActive( false );
        closeMouseRightGuide( );
        closeMouseLeftGuide( );
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
        activateMenu.InitUI( );
        showMouseLeftGuide( new Vector2( 840, 190 ) );
    }

    public void clickItemMenu( )
    {
        closeMouseRightGuide( );
        showMouseLeftGuide( new Vector2( -335, -225 ) );
    }

    public void clickItem()
    {
        showMouseLeftGuide( new Vector2( -75, -390 ) );
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
        activateMenu.CloseMenu( );
    }

    public void grassClicked( )
    {
        showDialogueWindow( );
        activateMenu.CloseAllUI( );
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
            var grass = GameObject.FindWithTag( "Grass" ).transform.position;
            var zebra = Instantiate( _ZEBRA );
            zebra.transform.position = new Vector3( grass.x + 2, grass.y, grass.z );
        }
    }

    private void installLion( )
    {
        //GameObject OB_LION = Resources.Load( "Animals/Prefabs/lion" ) as GameObject;
        if( GameObject.FindWithTag( "lion" ) == null)
        {
            var zebra = GameObject.FindWithTag( "zebra" ).transform.position;
            var lion = Instantiate( _LION );
            lion.transform.position = new Vector3( zebra.x + 1, zebra.y + 1, zebra.z );
        }
    }

    public void changeTool()
    {
        closeDialogueWindow( );

        var grass = GameObject.FindWithTag( "Grass" ).transform.position;
        showMouseRightGuide(
            new Vector2(
                cam.WorldToScreenPoint( new Vector2( grass.x + 2.1f, grass.y - 1.55f) ).x - 960,
                cam.WorldToScreenPoint( new Vector2( grass.x + 2.1f, grass.y - 1.55f ) ).y - 540 ) );
        checkTool = true;
    }

    public void waitForRepair( )
    {
        closeDialogueWindow( );
        var grass = GameObject.FindWithTag( "Grass" ).transform.position;
        showMouseLeftGuide(
            new Vector2(
                cam.WorldToScreenPoint( new Vector2( grass.x + 2.1f, grass.y - 1.55f ) ).x - 960,
                cam.WorldToScreenPoint( new Vector2( grass.x + 2.1f, grass.y - 1.55f ) ).y - 540 ) );
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

    public void ToStage( )
    {
        showBlackScreen( );
        BlackScreen.GetComponent<BlackScreenAnimationController>( ).setToStage( );
    }
}
