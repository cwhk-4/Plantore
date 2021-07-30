using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MissionControl : MonoBehaviour
{
    [SerializeField] private MissionsList MissionsList;
    [SerializeField] private MapLevel MapLevel;
    [SerializeField] private PopUpAnimation Animation;

    private int NowMapLevel;

    private readonly int[] MissionStartingNum = { 0, 2, 5, 9, 11 };
    [SerializeField] private int[] MissionNum = new int[11];
    private int[] MissionTotalNum = new int[11];

    [SerializeField] private GameObject MissionParent;
    [SerializeField] private GameObject[] MissionCheck = new GameObject[4];

    [SerializeField] private TMP_Text[] MissionNowNum = new TMP_Text[4];

    [SerializeField] private int NowStartingMission = 0;

    #region ControlBool
    private bool Index = false;
    private bool Rhino = false;
    private bool Hippo = false;
    #endregion

    private void Start( )
    {
        InitAllData( );
    }

    private void InitAllData( )
    {
        NowMapLevel = MapLevel.getMapLevel( );

        for( int i = 0; i < 11; i++ )
        {
            MissionNum[i] = 0;
            MissionTotalNum[i] = MissionsList.GetTotalNum( i );
        }

        for( int i = 0; i < 4; i++ )
        {
            MissionCheck[i] = MissionParent.transform.GetChild( i ).GetChild( 2 ).GetChild( 0 ).gameObject;
            MissionCheck[i].SetActive( false );
            MissionNowNum[i] = MissionParent.transform.GetChild( i ).GetChild( 1 ).GetComponent<TMP_Text>( );
        }
    }

    public void OpenMission( )
    {
        NowMapLevel = MapLevel.getMapLevel( );
        NowStartingMission = MissionStartingNum[NowMapLevel - 1];

        UpdateMissionNum( );
        CheckMissionsCompletion( );

        Animation.BoardButtonClick( );
    }

    private void UpdateMissionNum( )
    {
        for( int i = NowStartingMission; i < MissionStartingNum[NowMapLevel]; i++ )
        {
            MissionNowNum[i - NowStartingMission].text = MissionNum[i].ToString( );
        }
    }

    private void CheckMissionsCompletion( )
    {
        for( int i = NowStartingMission; i < MissionStartingNum[NowMapLevel]; i++ )
        {
            if( MissionNum[i] >= MissionTotalNum[i] )
            {
                MissionCheck[i - NowStartingMission].SetActive( true );
            }
            else
            {
                MissionCheck[i - NowStartingMission].SetActive( false );
            }
        }

        CheckLevelCompletion( );
    }

    private void CheckLevelCompletion( )
    {
        for( int i = NowStartingMission; i < MissionStartingNum[NowMapLevel]; i++ )
        {
            if( MissionNum[i] < MissionTotalNum[i] )
            {
                return;
            }
        }

        GoToNextLevel( );
    }


    //Lv 1
    public void PlacedItem( )
    {
        MissionNum[0] += 1;
        CheckMissionsCompletion( );
    }

    public void ReadIndex( )
    {
        if( Index )
        {
            return;
        }
        else
        {
            Index = true;
            MissionNum[1] = 1;
            CheckMissionsCompletion( );
        }
    }

    //Lv 2
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
        MissionNum[2] += 1;
        CheckMissionsCompletion( );
    }

    public void FixedItem( )
    {
        MissionNum[3] += 1;
        MissionNum[5] += 1;
        CheckMissionsCompletion( );
    }

    public void HuntedByLion( )
    {
        MissionNum[4] += 1;
        CheckMissionsCompletion( );
    }

    //Lv 3
    public void FoundHerbivore( )
    {
        MissionNum[6] += 1;
        CheckMissionsCompletion( );
    }

    public void HuntingSucceed( )
    {
        MissionNum[7] += 1;
        CheckMissionsCompletion( );
    }

    public void FoundBuffalo( )
    {
        MissionNum[8] += 1;
        CheckMissionsCompletion( );
    }

    //Lv 4
    public void FilledIndex( )
    {
        MissionNum[9] += 1;
        CheckMissionsCompletion( );
    }

    public void AllAnimal( )
    {
        //caution ????
    }

    private void GoToNextLevel( )
    {
        MapLevel.setMapLevel( NowMapLevel + 1 );
    }

    //caution
    #region Old
    private int DisplayBoardNum;

    [SerializeField] private int[] missionTotalNum = new int[6];
    [SerializeField] private int[] missionNowNum = new int[6];
    [SerializeField] private bool[] missionCompleted = new bool[6];

    [SerializeField] private RectTransform[] MissionClearBoard;
    [SerializeField] private float AnimationSpeed;
    #endregion
    #region LegacyCode
    //{
    //    for( int i = 0; i < missionTotalNum.Length - 1; i++ )
    //    {
    //        missionTotalNum[i] = missions.GetValue( i ).totalNum;
    //        missionCompleted[i] = false;
    //    }

    //    clearMissionBox( );

    //    for( int i = 0; i < MissionClearBoard.Length; i++ )
    //    {
    //        MissionClearBoard[i].localScale = Vector3.zero;
    //        MissionClearBoard[i].gameObject.SetActive( false );

    //    }
    //}

    //private void Update( )
    //{
    //    if( ShowMission )
    //    {
    //        if( DisplayBoardNum != -1 )
    //        {
    //            if( MissionClearBoard[DisplayBoardNum].localScale.x >= 1 )
    //            {
    //                MissionClearBoard[DisplayBoardNum].localScale = Vector3.one;
    //            }
    //            else
    //            {
    //                MissionClearBoard[DisplayBoardNum].localScale =
    //                    new Vector3( MissionClearBoard[DisplayBoardNum].localScale.x + AnimationSpeed,
    //                    MissionClearBoard[DisplayBoardNum].localScale.y + AnimationSpeed,
    //                    MissionClearBoard[DisplayBoardNum].localScale.z + AnimationSpeed );
    //            }

    //            if( MissionClearBoard[DisplayBoardNum].localScale == Vector3.one )
    //            {
    //                ShowMission = false;
    //                MissionShown = true;
    //                MapLevel.setMapLevel( ToMapLevel );
    //                DisplayBoardNum = -1;
    //            }
    //        }
    //        else
    //        {
    //            ShowMission = false;
    //            MissionShown = true;
    //        }
    //    }

    //    if( CloseMission )
    //    {
    //        if( DisplayBoardNum != -1 )
    //        {
    //            if( MissionClearBoard[DisplayBoardNum].localScale.x <= 0 )
    //            {
    //                MissionClearBoard[DisplayBoardNum].localScale = Vector3.zero;
    //            }
    //            else
    //            {
    //                MissionClearBoard[DisplayBoardNum].localScale =
    //                    new Vector3( MissionClearBoard[DisplayBoardNum].localScale.x - AnimationSpeed,
    //                    MissionClearBoard[DisplayBoardNum].localScale.y - AnimationSpeed,
    //                    MissionClearBoard[DisplayBoardNum].localScale.z - AnimationSpeed );
    //            }

    //            if( MissionClearBoard[DisplayBoardNum].localScale == Vector3.zero )
    //            {
    //                CloseMission = false;
    //                MissionShown = false;
    //                MissionClearBoard[DisplayBoardNum].gameObject.SetActive( false );
    //                DisplayBoardNum = -1;
    //            }
    //        }
    //        else
    //        {
    //            CloseMission = false;
    //            MissionShown = false;
    //        }
    //    }
    //}

    public void SetNowStartingMission( int num )
    {
        //NowStartingMission = num;
        //setMissionNum( );
        //clearMissionBox( );
    }

    public void InitMissionBox( )
    {
        //clearMissionBox( );
        //setMissionNum( );
    }

    private void setMissionNum( )
    {
        //mission1Num.text = missionNowNum[NowStartingMission].ToString( );
        //mission2Num.text = missionNowNum[NowStartingMission + 1].ToString( );
        //mission3Num.text = missionNowNum[NowStartingMission + 2].ToString( );
    }

    
    public void FoundAnimal( )
    {
        //missionNowNum[0]++;
        //if( NowStartingMission == 0 )
        //{
        //    mission1Num.text = missionNowNum[0].ToString( );
        //}
        //checkMissionCompleted( 0 );
    }

    public void ClearedEvent( )
    {
        //missionNowNum[5]++;
        //if( NowStartingMission == 3 )
        //{
        //    mission3Num.text = missionNowNum[5].ToString( );
        //}
        //checkMissionCompleted( 5 );
    }

    private void checkMissionCompleted( int input )
    {
        //if( missionNowNum[input] >= missionTotalNum[input] )
        //{
        //    missionCompleted[input] = true;
        //    checkMissionBox( input );
        //    checkLevelMissionCompleted( );
        //}
    }

    private void checkMissionBox( int input )
    {
        //if( missionCompleted[input] )
        //{
        //    missionCheck[input % 3].SetActive( true );
        //}
        //else
        //{
        //    missionCheck[input % 3].SetActive( false );
        //}
    }

    private void clearMissionBox( )
    {
        //for( int i = 0; i < 3; i++ )
        //{
        //    checkMissionBox( NowStartingMission + i );
        //}
    }

    private void checkLevelMissionCompleted( )
    {
        //var startingNum = NowStartingMission;

        ////we are special ver
        //if( startingNum == 3 )
        //{
        //    if( missionCompleted[startingNum] && missionCompleted[startingNum + 1] )
        //    {
        //        MissionCleared( 3 );
        //    }
        //}
        //else
        //{
        //    if( missionCompleted[startingNum] && missionCompleted[startingNum + 1] && missionCompleted[startingNum + 2] )
        //    {
        //        MissionCleared( 2 );
        //    }
        //}
    }

    private void MissionCleared( int ToLevel )
    {
        //if( ToLevel == 2 )
        //{
        //    ToMapLevel = ToLevel;
        //    ShowMission = true;
        //    MissionClearBoard[0].gameObject.SetActive( true );
        //    DisplayBoardNum = 0;
        //}
        //else
        //{
        //    if( ToLevel == 3 )
        //    {
        //        ShowMission = true;
        //        MissionClearBoard[1].gameObject.SetActive( true );
        //        DisplayBoardNum = 1;
        //    }
        //}
    }

    public void CloseMissionClearBoard( int boardNum )
    {
        //if( MissionShown )
        //{
        //    CloseMission = true;
        //    DisplayBoardNum = boardNum;
        //}
    }

    /*
    public void TrialEnd( )
    {
        trial.ShowEnd( );
    }
    */

    #endregion
}