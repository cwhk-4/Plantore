﻿using TMPro;
using UnityEngine;

public class MissionControl : MonoBehaviour
{
    [SerializeField] private MissionsList missions;
    [SerializeField] private MapLevel MapLevel;

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

    private void Start( )
    {
        for( int i = 0; i < missionTotalNum.Length - 1; i++ )
        {
            missionTotalNum[i] = missions.GetValue( i ).totalNum;
            missionCompleted[i] = false;
        }
    }

    public void SetNowStartingMission( int num )
    {
        NowStartingMission = num;
        setMissionNum( );
    }

    private void setMissionNum( )
    {
        if( NowStartingMission == 0 )
        {
            mission1Num.text = missionNowNum[0].ToString( );
            mission2Num.text = missionNowNum[1].ToString( );
            mission3Num.text = missionNowNum[2].ToString( );
        }

        if( NowStartingMission == 3 )
        {
            mission1Num.text = missionNowNum[3].ToString( );
            mission2Num.text = missionNowNum[4].ToString( );
            mission3Num.text = missionNowNum[5].ToString( );
        }
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
            //check Box
            checkLevelMissionCompleted( );
        }
    }

    private void checkLevelMissionCompleted( )
    {
        var startingNum = NowStartingMission;

        if( missionCompleted[startingNum] && missionCompleted[startingNum + 1] && missionCompleted[startingNum + 2] )
        {
            Debug.Log( startingNum / 3 + 2 );
            MapLevel.setMapLevel( startingNum / 3 + 2 );
        }
    }

}
