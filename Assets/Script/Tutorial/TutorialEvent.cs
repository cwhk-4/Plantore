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
    [SerializeField] private GameObject RightClick;

    [SerializeField] private AnimalBase ZebraBase = null;
    [SerializeField] private CountDown GrassCD = null;

    private List<int> FillException = new List<int> { 0, 45 };
    [SerializeField] private Transform GridParent;
    [SerializeField] private GameObject GridBlock;

    [SerializeField] private ToolConvertion Tool;

    [Header( "Parents" )]
    [SerializeField] private Transform StageParent;
    [SerializeField] private Transform MenuParent;
    [SerializeField] private Transform ItemParent;

    [Header( "Buttons" )]
    [SerializeField] private GameObject ItemButton;
    [SerializeField] private GameObject GrassButton;
    [SerializeField] private GameObject RockButton;
    [SerializeField] private GameObject MissionButton;

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
        ItemButton.transform.parent = StageBlock;

        ShowPointer( Vector2.zero );
    }

    public void MenuClicked( )
    {
        if( TutorialControl.GetTextCount() < 12 )
        {
            StageBlock.gameObject.SetActive( false );
            ItemButton.transform.parent = MenuParent;
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
        GrassButton.transform.parent = UIBlock;
        ShowPointer( Vector2.zero );
    }

    public void ClickRock( )
    {
        ItemButton.transform.parent = MenuParent;
        RockButton.transform.parent = UIBlock;
        ShowPointer( Vector2.zero );
    }

    public void ItemClicked( )
    {
        GrassButton.transform.parent = ItemParent;
        RockButton.transform.parent = ItemParent;

        isWaitingOnGrid = true;

        UIBlock.gameObject.SetActive( false );

        if( isGrass )
        {
            isGrass = false;
        }

        TutorialControl.FinishedAction( );
        ShowPointer( Vector2.zero );

    }

    private void ShowPointer( Vector2 toPos )
    {
        Pointer.GetComponent<RectTransform>( ).anchoredPosition = toPos;
        Pointer.SetActive( true );
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
        ShowPointer( Vector2.zero );
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
        ShowPointer( Vector2.zero );

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
        ShowPointer( Vector2.zero );
    }

    public void OpenMission( )
    {
        StageBlock.gameObject.SetActive( true );
        MissionButton.transform.parent = StageBlock;
    }

    public void ClickedMission( )
    {
        StageBlock.gameObject.SetActive( false );
        MissionButton.transform.parent = MenuParent;

        if( TutorialControl.GetTextCount( ) < 20 )
        {
            TutorialControl.FinishedThisAction( );
        }
    }
}