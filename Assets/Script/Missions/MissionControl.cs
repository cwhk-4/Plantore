using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MissionControl : MonoBehaviour
{
    [SerializeField] private MissionsList missions;
    [SerializeField] private MapLevel MapLevel;
    [SerializeField] private TrialEnd trial;

    [SerializeField] private TMP_Text mission1Num;
    [SerializeField] private TMP_Text mission2Num;
    [SerializeField] private TMP_Text mission3Num;

    [SerializeField] private GameObject[] missionCheckBox = new GameObject[3];

    [SerializeField] private Sprite uncheckedBox;
    [SerializeField] private Sprite checkedBox;

    [SerializeField] private bool Rhino = false;
    [SerializeField] private bool Hippo = false;

    [SerializeField] private int[] missionTotalNum = new int[6];
    [SerializeField] private int[] missionNowNum = new int[6];
    [SerializeField] private bool[] missionCompleted = new bool[6];

    [SerializeField] private int NowStartingMission = 0;

    [SerializeField] private RectTransform[] MissionClearBoard;
    [SerializeField] private float AnimationSpeed;
    private int DisplayBoardNum;

    private int ToMapLevel = 1;
    private bool ShowMission = false;
    private bool CloseMission = false;
    private bool MissionShown = false;

    private void Start( )
    {
        for( int i = 0; i < missionTotalNum.Length - 1; i++ )
        {
            missionTotalNum[i] = missions.GetValue( i ).totalNum;
            missionCompleted[i] = false;
        }

        clearMissionBox( );

        for( int i = 0; i < MissionClearBoard.Length; i++ )
        {
            MissionClearBoard[i].localScale = Vector3.zero;
            MissionClearBoard[i].gameObject.SetActive( false );

        }
    }

    private void Update( )
    {
        if( ShowMission )
        {
            if( DisplayBoardNum != -1 )
            {
                if( MissionClearBoard[DisplayBoardNum].localScale.x >= 1 )
                {
                    MissionClearBoard[DisplayBoardNum].localScale = Vector3.one;
                }
                else
                {
                    MissionClearBoard[DisplayBoardNum].localScale =
                        new Vector3( MissionClearBoard[DisplayBoardNum].localScale.x + AnimationSpeed,
                        MissionClearBoard[DisplayBoardNum].localScale.y + AnimationSpeed,
                        MissionClearBoard[DisplayBoardNum].localScale.z + AnimationSpeed );
                }

                if( MissionClearBoard[DisplayBoardNum].localScale == Vector3.one )
                {
                    ShowMission = false;
                    MissionShown = true;
                    MapLevel.setMapLevel( ToMapLevel );
                    DisplayBoardNum = -1;
                }
            }
            else
            {
                ShowMission = false;
                MissionShown = true;
            }
        }

        if( CloseMission )
        {
            if( DisplayBoardNum != -1 )
            {
                if( MissionClearBoard[DisplayBoardNum].localScale.x <= 0 )
                {
                    MissionClearBoard[DisplayBoardNum].localScale = Vector3.zero;
                }
                else
                {
                    MissionClearBoard[DisplayBoardNum].localScale =
                        new Vector3( MissionClearBoard[DisplayBoardNum].localScale.x - AnimationSpeed,
                        MissionClearBoard[DisplayBoardNum].localScale.y - AnimationSpeed,
                        MissionClearBoard[DisplayBoardNum].localScale.z - AnimationSpeed );
                }

                if( MissionClearBoard[DisplayBoardNum].localScale == Vector3.zero )
                {
                    CloseMission = false;
                    MissionShown = false;
                    MissionClearBoard[DisplayBoardNum].gameObject.SetActive( false );
                    DisplayBoardNum = -1;
                }
            }
            else
            {
                CloseMission = false;
                MissionShown = false;
            }
        }
    }

    public void SetNowStartingMission( int num )
    {
        NowStartingMission = num;
        setMissionNum( );
        clearMissionBox( );
    }

    public void InitMissionBox( )
    {
        clearMissionBox( );
        setMissionNum( );
    }

    private void setMissionNum( )
    {
        mission1Num.text = missionNowNum[NowStartingMission].ToString( );
        mission2Num.text = missionNowNum[NowStartingMission + 1].ToString( );
        mission3Num.text = missionNowNum[NowStartingMission + 2].ToString( );
    }

    public void FoundAnimal( )
    {
        missionNowNum[0]++;
        if( NowStartingMission == 0 )
        {
            mission1Num.text = missionNowNum[0].ToString( );
        }
        checkMissionCompleted( 0 );
    }

    public void PlacedItem( )
    {
        missionNowNum[1]++;
        if( NowStartingMission == 0 )
        {
            mission2Num.text = missionNowNum[1].ToString( );
        }
        checkMissionCompleted( 1 );
    }

    public void FixedItem( )
    {
        missionNowNum[2]++;
        if( NowStartingMission == 0 )
        {
            mission3Num.text = missionNowNum[2].ToString( );
        }
        checkMissionCompleted( 2 );
    }

    public void FoundHippo( )
    {
        if( !Hippo )
        {
            Hippo = true;
            FoundHippoRhino( );
        }
    }

    public void FoundRhino( )
    {
        if( !Rhino )
        {
            Rhino = true;
            FoundHippoRhino( );
        }
    }

    private void FoundHippoRhino( )
    {
        missionNowNum[3]++;
        if( NowStartingMission == 3 )
        {
            mission1Num.text = missionNowNum[3].ToString( );
        }
        checkMissionCompleted( 3 );
    }

    public void HuntingHappened( )
    {
        missionNowNum[4]++;
        if( NowStartingMission == 3 )
        {
            mission2Num.text = missionNowNum[4].ToString( );
        }
        checkMissionCompleted( 4 );
    }

    public void ClearedEvent( )
    {
        missionNowNum[5]++;
        if( NowStartingMission == 3 )
        {
            mission3Num.text = missionNowNum[5].ToString( );
        }
        checkMissionCompleted( 5 );
    }

    private void checkMissionCompleted( int input )
    {
        if( missionNowNum[input] >= missionTotalNum[input] )
        {
            missionCompleted[input] = true;
            checkMissionBox( input );
            checkLevelMissionCompleted( );
        }
    }

    private void checkMissionBox( int input )
    {
        if( missionCompleted[input] )
        {
            missionCheckBox[input % 3].GetComponent<Image>( ).sprite = checkedBox;
        }
        else
        {
            missionCheckBox[input % 3].GetComponent<Image>( ).sprite = uncheckedBox;
        }
    }

    private void clearMissionBox( )
    {
        for( int i = 0; i < 3; i++ )
        {
            checkMissionBox( NowStartingMission + i );
        }
    }

    private void checkLevelMissionCompleted( )
    {
        var startingNum = NowStartingMission;

        //we are special ver
        if( startingNum == 3 )
        {
            if( missionCompleted[startingNum] && missionCompleted[startingNum + 1] )
            {
                MissionCleared( 3 );
            }
        }
        else
        {
            if( missionCompleted[startingNum] && missionCompleted[startingNum + 1] && missionCompleted[startingNum + 2] )
            {
                MissionCleared( 2 );
            }
        }
    }

    private void MissionCleared( int ToLevel )
    {
        if( ToLevel == 2 )
        {
            ToMapLevel = ToLevel;
            ShowMission = true;
            MissionClearBoard[0].gameObject.SetActive( true );
            DisplayBoardNum = 0;
        }
        else
        {
            if( ToLevel == 3 )
            {
                ShowMission = true;
                MissionClearBoard[1].gameObject.SetActive( true );
                DisplayBoardNum = 1;
            }
        }
    }

    public void CloseMissionClearBoard( int boardNum )
    {
        if( MissionShown )
        {
            CloseMission = true;
            DisplayBoardNum = boardNum;
        }
    }

    public void TrialEnd( )
    {
        trial.ShowEnd( );
    }
}
