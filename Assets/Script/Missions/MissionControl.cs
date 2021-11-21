using TMPro;
using UnityEngine;

public class MissionControl : MonoBehaviour
{
    [SerializeField] private MissionsList MissionsList;
    [SerializeField] private MapLevel MapLevel;
    [SerializeField] private PopUpAnimation Animation;
    [SerializeField] private MissionCompletionControl CompletionControl;

    private int NowMapLevel;

    private readonly int[] MissionStartingNum = { 0, 3, 6, 9 };
    private int[] MissionNum = new int[9];
    private bool[] IsMissionCompleteShown = new bool[9];
    private bool[] IsLvCompletionShown = new bool[3];
    private int[] MissionTotalNum = new int[9];
    private bool[] AnimalFound = new bool[( int )Define.ANIMAL.TOTAL_NUM];

    [SerializeField] private GameObject MissionParent;
    [SerializeField] private GameObject[] MissionCheck = new GameObject[3];
    [SerializeField] private TMP_Text[] MissionNowNum = new TMP_Text[3];

    [SerializeField] private int NowStartingMission = 0;

    #region ControlBool
    private bool Index = false;
    private bool Rhino = false;
    private bool Elephant = false;
    #endregion

    private void Start( ) 
    {
        InitAllData( );
    }

    private void InitAllData( )
    {
        NowMapLevel = MapLevel.getMapLevel( );
        NowStartingMission = MissionStartingNum[NowMapLevel - 1];

        for( int i = 0; i < 9; i++ )
        {
            MissionNum[i] = 0;
            MissionTotalNum[i] = MissionsList.GetTotalNum( i );
            IsMissionCompleteShown[i] = false;
        }

        for( int i = 0; i < 3; i++ )
        {
            MissionCheck[i] = MissionParent.transform.GetChild( i ).GetChild( 2 ).GetChild( 0 ).gameObject;
            MissionCheck[i].SetActive( false );
            MissionNowNum[i] = MissionParent.transform.GetChild( i ).GetChild( 1 ).GetComponent<TMP_Text>( );
        }

        for( int i = 0; i < 3; i++ )
        {
            IsLvCompletionShown[i] = false;
        }

        for(int i = 0; i<(int)Define.ANIMAL.TOTAL_NUM; i++ )
        {
            AnimalFound[i] = false;
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
                ShowMissionCompletionBox( i );

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

    private void ShowMissionCompletionBox( int index )
    {
        if( !IsMissionCompleteShown[index] )
        {
            CompletionControl.CreateBanner( index );
            IsMissionCompleteShown[index] = true;
        }
    }

    //Lv 1
    public void PlacedItem( )
    {
        if( MapLevel.getMapLevel( ) == 1 )
        {
            MissionNum[0] += 1;
            CheckMissionsCompletion( );
        }
    }


    public void FixedItem1( )
    {
        if( MapLevel.getMapLevel( ) == 1 )
        {
            MissionNum[1] += 1;
            CheckMissionsCompletion( );
        }
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
            MissionNum[2] = 1;
            CheckMissionsCompletion( );
        }
    }

    //Lv 2
    public void FoundElephant( )
    {
        if( !Elephant )
        {
            Elephant = true;
            FoundElephantRhino( );
        }
    }

    public void FoundRhino( )
    {
        if( !Rhino )
        {
            Rhino = true;
            FoundElephantRhino( );
        }
    }

    private void FoundElephantRhino( )
    {
        if( MapLevel.getMapLevel( ) == 2 )
        {
            MissionNum[3] += 1;
            CheckMissionsCompletion( );
        }
    }

    public void HuntedByLion( )
    {
        if( MapLevel.getMapLevel( ) == 2 )
        {
            MissionNum[4] += 1;
            CheckMissionsCompletion( );
        }
    }

    public void FixedItem2( )
    {
        MissionNum[5] += 1;
        CheckMissionsCompletion( );
    }

    //Lv 3
    public void FoundHerbivore( )
    {
        if( MapLevel.getMapLevel( ) == 3 )
        {
            MissionNum[6] += 1;
            CheckMissionsCompletion( );
        }
    }

    public void HuntingSucceed( )
    {
        if( MapLevel.getMapLevel( ) == 3 )
        {
            MissionNum[7] += 1;
            CheckMissionsCompletion( );
        }
    }

    public void FoundAnimal( int animalNum )
    {
        AnimalFound[animalNum] = true;

        MissionNum[8] += 1;

        if( MapLevel.getMapLevel( ) == 3 )
        {
            CheckMissionsCompletion( );
        }
    }

    public bool GetAnimalFound( int index )
    {
        return AnimalFound[index];
    }

    private void GoToNextLevel( )
    {
        MapLevel.setMapLevel( NowMapLevel + 1 );

        if( !IsLvCompletionShown[NowMapLevel - 1] )
        {
            CompletionControl.CreateBox( NowMapLevel );
            IsLvCompletionShown[NowMapLevel - 1] = true;
        }
    }

}