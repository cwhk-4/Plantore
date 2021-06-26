using UnityEngine;
using TMPro;

public class MissionTextDisplay : MonoBehaviour
{
    [SerializeField] private MissionsList missions;
    [SerializeField] private MissionControl MissionControl;

    [SerializeField] private GameObject MissionParent;

    private TMP_Text[,] MissionText = new TMP_Text[4, 2];

    [SerializeField] private int MapLevel;
    private int MissionStartingNum;

    private void Awake( )
    {
        for( int i = 0; i < 4; i++ )
        {
            MissionText[i, 0] = MissionParent.transform.GetChild( i ).GetComponent<TMP_Text>( );
            MissionText[i, 1] = MissionParent.transform.GetChild( i ).GetChild( 0 ).GetComponent<TMP_Text>( );
        }
    }

    private void Start()
    {
        missionSwitch( );
    }

    public void MapLevelChanged( int level )
    {
        MapLevel = level;
        missionSwitch( );
    }

    private void setText( )
    {
        for( int i = 0; i < 4; i++ )
        {
            if( missions.GetLevel( MissionStartingNum + i ) == MapLevel )
            {
                MissionText[i, 0].gameObject.SetActive( true );
                MissionText[i, 0].text = missions.GetValue( MissionStartingNum ).MissionText;
                MissionText[i, 1].text = "/" + missions.GetValue( MissionStartingNum ).totalNum.ToString( );
            }
            else
            {
                MissionText[i, 0].gameObject.SetActive( false );
            }
        }

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
            case 3:
                MissionStartingNum = 5;
                break;
            case 4:
                MissionStartingNum = 9;
                break;
        }

        setText( );
        MissionControl.SetNowStartingMission( MissionStartingNum );
    }
}
