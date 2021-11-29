using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Linq;

public class TutorialControl : MonoBehaviour
{
    [Header( "Flag" )]
    [SerializeField] private bool isTutorial = true;
    [SerializeField] private bool isReadText = false;
    [SerializeField] private bool isInAction = false;
    [SerializeField] private bool isFinishedAction = false;

    [Header( "Tutorial Setup" )]
    [SerializeField] private MapLevel MapLevel;
    [SerializeField] private TimeController TimeController;
    [SerializeField] private TutorialEvent TutorialEvent;
    [SerializeField] private TutorialList TutorialList;
    [SerializeField] private GameObject TutorialUI;
    [SerializeField] private GameObject TutorialText;
    [SerializeField] private GameObject PointerParent;
    [SerializeField] private TMP_Text TextBox;
    [SerializeField] private int TextCount = 0;
    [SerializeField] private string[] TextShown;

    private int[,] TextLink = { { 12, 17 }, { 19, 13 }, { 16, 20 } };
    private List<int> ActionCount = new List<int> { 2, 3, 5, 8, 9, 10, 17, 19, 15, 16 };

    void Init( )
    {
        TutorialUI.SetActive( true );
        TutorialText.SetActive( true );
    }

    void Start()
    {
        StartTutorial( );
        TextCount = 0;
        isFinishedAction = false;

        Init( );
        SetText( );
    }

    void Update()
    {
        if( !isTutorial )
        {
            return;
        }

        if(isInAction)
        {
            return;
        }

        if(!isReadText)
        {
            SetAction( );
            return;
        }

        if( isFinishedAction )
        {
            SetTextCount( );
            SetText( );
            TutorialUI.SetActive( true );
            TutorialText.SetActive( true );
            isFinishedAction = false;
            TimeController.StopTime( );
        }

        if( Input.GetMouseButtonDown( 0 ) )
        {
            if( TextCount < 23 )
            {
                if( CheckAction( ) )
                {
                    SetTextCount( );
                }

                SetText( );

            }
            else
            {
                StopTutorial( );
                TutorialUI.SetActive( false );
                isReadText = false;
                isInAction = true;
                TimeController.StartTime( );
                TutorialEvent.HidePointer( );
            }
        }
    }

    public void StartTutorial( )
    {
        if( TextCount == 23 )
        {
            StopTutorial( );
            return;
        }

        Debug.Log( "Called" );
        isTutorial = true;
        isReadText = true;
        isInAction = false;
        isFinishedAction = true;
        TimeController.StopTime( );
        TutorialUI.SetActive( true );
        TutorialText.SetActive( true );
        PointerParent.SetActive( true );
    }

    public void StopTutorial()
    {
        isTutorial = false;
        TutorialUI.SetActive( false );
        TutorialText.SetActive( false );
        TutorialEvent.HidePointer( );
        PointerParent.SetActive( false );
    }

    public void LevelUp( )
    {
        if( MapLevel.GetMapLevel( ) == 2 )
        {
            StartTutorial( );
        }

        if( MapLevel.GetMapLevel( ) == 4 )
        {
            StartTutorial( );
        }

        isFinishedAction = true;
    }

    #region text
    private void SetTextCount()
    {
        TimeController.StopTime( );

        for( int i = 0; i < 3; i++ )
        {
            if( TextCount == TextLink[i, 0] )
            {
                TextCount = TextLink[i, 1];
                return;
            }
        }

        TextCount++;
    }

    private void SetText( )
    {
        TextShown = null;
        TextShown = TutorialList.GetTutorialText( TextCount );
        for( int i = 1; i < TextShown.Length; i++ )
        {
            TextShown[0] = string.Concat( TextShown[0], "\n", TextShown[i] );
        }
        TextBox.text = TextShown[0];
    }
    

    private bool CheckAction( )
    {
        if( ActionCount.Any( x => x == TextCount ) )
        {
            TutorialUI.SetActive( false );
            isReadText = false;
            return false;
        }

        return true;
    }
    #endregion

    #region ActionControl
    public void BlockStageOnly( )
    {
        TutorialUI.SetActive( true );
        TutorialText.SetActive( false );
    }

    public int GetTextCount( )
    {
        return TextCount;
    }

    public void FinishedAction( )
    {
        isInAction = false;
    }

    public void FinishedThisAction( )
    {
        if( TextCount == 23 )
        {
            StopTutorial( );
            return;
        }

        isInAction = false;
        isReadText = true;
        isFinishedAction = true;

        TutorialText.SetActive( true );
        TimeController.StopTime( );
    }

    private void SetAction()
    {
        TimeController.StartTime( );
        isInAction = true;
        isFinishedAction = false;
        TutorialUI.SetActive( false );

        switch(TextCount)
        {
            case 2:
                TimeController.StopTime( );
                TutorialEvent.OpenItem( );
                break;

            case 3:
                BlockStageOnly( );
                TutorialEvent.CallZebra( );
                break;

            case 5:
                TimeController.StopTime( );
                TutorialEvent.OpenItem( );
                break;

            case 8:
                TimeController.StopTime( );
                TutorialEvent.ClickRock( );
                break;

            case 9:
                BlockStageOnly( );
                TutorialEvent.CallLion( );
                TutorialEvent.DryGrass( );
                break;

            case 10:
                TutorialEvent.HidePointer( );
                TutorialEvent.GuideToChangeTool( );
                break;

            case 17:
                TimeController.StopTime( );
                TutorialEvent.OpenMission( );
                break;

            case 19:
                StopTutorial( );
                break;

            case 15:
                TutorialEvent.GuideToMapArrow( );
                break;

            case 16:
                StopTutorial( );
                break;
        }
    }
    #endregion

}
