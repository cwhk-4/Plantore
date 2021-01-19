using UnityEngine;
using TMPro;

public class MissionTextDisplay : MonoBehaviour
{
    [SerializeField] private MissionsList missions;

    [SerializeField] private TMP_Text Mission1Num;
    [SerializeField] private TMP_Text Mission1;
    [SerializeField] private TMP_Text Mission2Num;
    [SerializeField] private TMP_Text Mission2;
    [SerializeField] private TMP_Text Mission3Num;
    [SerializeField] private TMP_Text Mission3;

    [SerializeField] private int MapLevel;
    private int MissionStartingNum;

    void Start()
    {
        missionSwitch( );
    }

    public void MapLevelChanged( int level )
    {
        MapLevel = level;
        missionSwitch( );
    }

    private void setText( int num )
    {
        Mission1Num.text = "/" + missions.GetValue( MissionStartingNum ).totalNum.ToString( );
        Mission1.text = missions.GetValue( MissionStartingNum ).MissionText;
        Mission2Num.text = "/" + missions.GetValue( MissionStartingNum + 1 ).totalNum.ToString( );
        Mission2.text = missions.GetValue( MissionStartingNum + 1 ).MissionText;
        Mission3Num.text = "/" + missions.GetValue( MissionStartingNum + 2 ).totalNum.ToString( );
        Mission3.text = missions.GetValue( MissionStartingNum + 2 ).MissionText;
    }

    private void missionSwitch( )
    {
        switch( MapLevel )
        {
            case 1:
                MissionStartingNum = 0;
                break;
            case 2:
                MissionStartingNum = 3;
                break;
        }

        setText( MissionStartingNum );
    }
}
