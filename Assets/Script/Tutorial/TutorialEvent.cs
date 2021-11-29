using System.Collections.Generic;
using UnityEngine;

public class TutorialEvent : MonoBehaviour
{
    [Header( "Flag" )]
    [SerializeField] private float Starting = 0;
    private float Count = 0;
    [SerializeField] private bool isGrass = true;
    [SerializeField] private bool isWaitingOnGrid = false;
    [SerializeField] private bool isWaitingtoChangeTool = false;
    [SerializeField] private bool isWaitingToRepair = false;
    [SerializeField] private bool isCounting = false;

    [Header( "Setup" )]
    [SerializeField] private TutorialControl TutorialControl;
    [SerializeField] private Transform StageBlock;
    [SerializeField] private Transform UIBlock;
    [SerializeField] private GameObject Pointer;
    [SerializeField] private PointerAnimation PointerAnimation;
    [SerializeField] private GameObject RightClick;

    [SerializeField] private AnimalBase ZebraBase = null;
    [SerializeField] private CountDown GrassCD = null;

    private List<int> FillException = new List<int> { 0, 45 };
    [SerializeField] private Transform GridParent;
    [SerializeField] private GameObject GridBlock;

    private Vector2 LeftBottomGrid = new Vector2( -675, -480 );
    private Vector2 RightTopGrid = new Vector2( 900, 125 );
    private Vector2 Item = new Vector2( 520, 285 );
    private Vector2 Mission = new Vector2( 900, 285 );
    private Vector2 Grass = new Vector2( -210, -255 );
    private Vector2 Rock = new Vector2( 480, -255 );
    private Vector2 Arrow = new Vector2( 900, -115 );

    [SerializeField] private ToolConvertion Tool;

    [Header( "Parents" )]
    [SerializeField] private Transform MapControlParent;
    [SerializeField] private Transform MenuParent;
    [SerializeField] private Transform ItemParent;

    [Header( "Buttons" )]
    [SerializeField] private GameObject ItemButton;
    [SerializeField] private GameObject GrassButton;
    [SerializeField] private GameObject RockButton;
    [SerializeField] private GameObject MissionButton;
    [SerializeField] private GameObject MapArrow;

    private void Start( )
    {
        Pointer.SetActive( false );
        RightClick.SetActive( false );
        StageBlock.gameObject.SetActive( false );
        UIBlock.gameObject.SetActive( false );

        isGrass = true;
        isWaitingOnGrid = false;
    }

    private void FixedUpdate( )
    {
        if( ZebraBase )
        {
            if(ZebraBase.GetOnItem())
            {
                TutorialControl.FinishedThisAction( );
                ZebraBase = null;
            }
        }

        if( isWaitingtoChangeTool )
        {
            if( Tool.GetIsCan( ) )
            {
                GuideToRepair( );
                isWaitingtoChangeTool = false;
            }
        }

        if( isWaitingToRepair )
        {
            if(GrassCD.GetCD() > 0)
            {
                TutorialControl.FinishedThisAction( );
                isWaitingToRepair = false;
                GrassCD = null;
            }
        }

        if(isCounting)
        {
            Starting += Time.deltaTime;
            if( Starting > Count )
            {
                TutorialControl.FinishedThisAction( );
                isCounting = false;
            }
        }
    }

    public void OpenItem( )
    {
        if( isWaitingOnGrid )
        {
            PutOnGrid( );
        }
        else
        {
            OpenItemMenu( );
        }
    }

    private void OpenItemMenu( )
    {
        StageBlock.gameObject.SetActive( true );
        ItemButton.transform.SetParent( StageBlock );

        ShowPointer( Item );
    }

    public void MenuClicked( )
    {
        if( TutorialControl.GetTextCount() < 11 )
        {
            StageBlock.gameObject.SetActive( false );
            ItemButton.transform.SetParent( MenuParent );
            UIBlock.gameObject.SetActive( true );

            if( isGrass )
            {
                ClickGrass( );
                FillGrid( 0 );
            }
            else
            {
                TutorialControl.FinishedThisAction( );
                FillGrid( 1 );
            }

        }

    }

    private void ClickGrass( )
    {
        GrassButton.transform.SetParent( UIBlock );
        ShowPointer( Grass );
    }

    public void ClickRock( )
    {
        ItemButton.transform.SetParent( MenuParent );
        RockButton.transform.SetParent( UIBlock );
        ShowPointer( Rock );
    }

    public void ItemClicked( )
    {
        if( TutorialControl.GetTextCount( ) > 11 )
        {
            return;
        }

        GrassButton.transform.SetParent( ItemParent );
        RockButton.transform.SetParent( ItemParent );

        isWaitingOnGrid = true;

        UIBlock.gameObject.SetActive( false );

        if( isGrass )
        {
            ShowPointer( LeftBottomGrid );
        }
        else
        {
            ShowPointer( RightTopGrid );
        }

        TutorialControl.FinishedAction( );

    }

    public void RockButtonClicked( )
    {
        RockButton.transform.SetParent( ItemParent );
        isWaitingOnGrid = true;
        UIBlock.gameObject.SetActive( false );
        ShowPointer( RightTopGrid );
    }

    private void ShowPointer( Vector2 toPos )
    {
        Pointer.SetActive( true );
        PointerAnimation.ChangePos( toPos );
    }

    public void HidePointer( )
    {
        Pointer.SetActive( false );
    } 

    public void FillGrid( int pattern )
    {
        for( int i = 0; i < 5; i++ )
        {
            for( int j = 0; j < 6; j++ )
            {
                int index = i * Define.XCOUNT + j;

                if( index != FillException[pattern] )
                {
                    if( GridParent.GetChild( index ).childCount == 0 )
                    {
                        var fillGO = Instantiate( GridBlock );
                        fillGO.transform.parent = GridParent.GetChild( index );
                    }
                }
            }
        }
    }

    private void PutOnGrid( )
    {
        if( isGrass )
        {
            isGrass = false;
            ShowPointer( LeftBottomGrid );
        }
        else
        {
            ShowPointer( RightTopGrid );
        }
    }

    public void ClearGrid( )
    {
        for( int i = 0; i < 5; i++ )
        {
            for( int j = 0; j < 6; j++ )
            {
                int index = i * Define.XCOUNT + j;

                if( GridParent.GetChild( index ).GetChild(0).name == "ExtraGrid(Clone)" )
                {
                    Destroy( GridParent.GetChild( index ).GetChild( 0 ).gameObject );
                }
            }
        }

        isWaitingOnGrid = false;
        TutorialControl.FinishedThisAction( );
        HidePointer( );
    }

    public void CallZebra( )
    {
        ZebraBase = GameObject.Find( "Zebra(Clone)" ).GetComponent<AnimalBase>( );
        ZebraBase.CallImmediatelyFromStartingCD( );
    }

    public void CallLion( )
    {
        GameObject.Find( "Lion(Clone)" ).GetComponent<AnimalBase>( )
                  .CallImmediatelyFromStartingCD( );
    }

    public void DryGrass()
    {
        GrassCD = GridParent.GetChild( 0 ).GetChild( 0 ).GetComponent<CountDown>( );
        GrassCD.ForceDryItem( );
        ShowPointer( LeftBottomGrid );

        Count = 1;
        isCounting = true;
    }

    private void ShowRightClick( Vector2 toPos )
    {
        RightClick.GetComponent<RectTransform>( ).anchoredPosition = toPos;
        RightClick.SetActive( true );
    }

    private void HideRightClick( )
    {
        RightClick.SetActive( false );
    }

    public void GuideToChangeTool()
    {
        isWaitingtoChangeTool = true;
        ShowRightClick( Vector2.zero );
    }

    private void GuideToRepair( )
    {
        isWaitingToRepair = true;
        HideRightClick( );
        ShowPointer( LeftBottomGrid );
    }

    public void OpenMission( )
    {
        ShowPointer( Mission );
        StageBlock.gameObject.SetActive( true );
        MissionButton.transform.SetParent( StageBlock );
    }

    public void ClickedMission( )
    {
        if( TutorialControl.GetTextCount( ) == 17 )
        {
            HidePointer( );
            TutorialControl.FinishedThisAction( );
            StageBlock.gameObject.SetActive( false );
            MissionButton.transform.SetParent( MenuParent );

        }
    }

    public void GuideToMapArrow( )
    {
        ShowPointer( Arrow );
        StageBlock.gameObject.SetActive( true );
        MapArrow.transform.SetParent( StageBlock );
    }

    public void MapArrowClicked( )
    {
        if( TutorialControl.GetTextCount( ) == 15 )
        {
            HidePointer( );
            TutorialControl.FinishedThisAction( );
            StageBlock.gameObject.SetActive( false );
            MapArrow.transform.SetParent( MapControlParent );

        }
    }
}