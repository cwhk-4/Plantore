using TMPro;
using UnityEngine;

public class MissionControl : MonoBehaviour
{
    [SerializeField] private MissionsList missions;
    [SerializeField] private MapLevel MapLevel;

    [SerializeField] private TMP_Text mission1Num;
    [SerializeField] private TMP_Text mission2Num;
    [SerializeField] private TMP_Text mission3Num;

    [SerializeField] private int AnimalFound = 0;
    [SerializeField] private int ItemPlaced = 0;
    [SerializeField] private int ItemFixed = 0;
    [SerializeField] private int HippoRhinoFound = 0;
    [SerializeField] private bool Rhino = false;
    [SerializeField] private bool Hippo = false;
    [SerializeField] private int Hunting = 0;
    [SerializeField] private int EventCleared = 0;

    private int NowStartingMission = 0;

    public void SetNowStartingMission( int num )
    {
        NowStartingMission = num;
        setMissionNum( );
    }

    private void setMissionNum( )
    {
        if( NowStartingMission == 0 )
        {
            mission1Num.text = AnimalFound.ToString( );
            mission2Num.text = ItemPlaced.ToString( );
            mission3Num.text = ItemFixed.ToString( );
        }

        if( NowStartingMission == 3 )
        {
            mission1Num.text = HippoRhinoFound.ToString( );
            mission2Num.text = Hunting.ToString( );
            mission3Num.text = EventCleared.ToString( );
        }
    }

    public void FoundAnimal( )
    {
        AnimalFound++;
        if( NowStartingMission == 0 )
        {
            mission1Num.text = AnimalFound.ToString( );
        }
        checkMissionFinished( );
    }

    public void PlacedItem( )
    {
        ItemPlaced++;
        if( NowStartingMission == 0 )
        {
            mission2Num.text = ItemPlaced.ToString( );
        }
        checkMissionFinished( );
    }

    public void FixedItem( )
    {
        ItemFixed++;
        if( NowStartingMission == 0 )
        {
            mission3Num.text = ItemFixed.ToString( );
        }
        checkMissionFinished( );
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
        HippoRhinoFound++;
        if( NowStartingMission == 3 )
        {
            mission1Num.text = HippoRhinoFound.ToString( );
        }
    }

    public void HuntingHappened( )
    {
        Hunting++;
        if( NowStartingMission == 3 )
        {
            mission2Num.text = Hunting.ToString( );
        }
    }

    public void ClearedEvent( )
    {
        EventCleared++;
        if( NowStartingMission == 3 )
        {
            mission3Num.text = Hunting.ToString( );
        }
    }

    private void checkMissionFinished()
    {
        if( NowStartingMission == 0 )
        {
            var mission1Num = missions.GetValue( 0 ).totalNum;
            var mission2Num = missions.GetValue( 1 ).totalNum;
            var mission3Num = missions.GetValue( 2 ).totalNum;

            if( AnimalFound == mission1Num && ItemPlaced == mission2Num && ItemFixed == mission3Num )
            {
                MapLevel.setMapLevel( 2 ); 
            }
        }

        if( NowStartingMission == 1 )
        {
            var mission1Num = missions.GetValue( 3 ).totalNum;
            var mission2Num = missions.GetValue( 4 ).totalNum;
            var mission3Num = missions.GetValue( 5 ).totalNum;

            if( HippoRhinoFound == mission1Num && Hunting == mission2Num && EventCleared == mission3Num )
            {
                MapLevel.setMapLevel( 3 );
            }
        }
    }
}
