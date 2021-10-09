using UnityEngine;
using TMPro;

public class MissionTextDisplay : MonoBehaviour
{
    [SerializeField] private MissionsList Missions;
    [SerializeField] private MissionControl MissionControl;
    [SerializeField] private MapLevel MapLevel;

    [SerializeField] private GameObject MissionParent;

    private TMP_Text[,] MissionText = new TMP_Text[4, 2];

    [SerializeField] private int Level;
    private int MissionStartingNum;

    private void Awake( )
    {
        for( int i = 0; i < 3; i++ )
        {
            MissionText[i, 0] = MissionParent.transform.GetChild( i ).GetComponent<TMP_Text>( );
            MissionText[i, 1] = MissionParent.transform.GetChild( i ).GetChild( 0 ).GetComponent<TMP_Text>( );
        }
    }

    private void Start()
    {
        MissionSwitch( );
    }


    private void SetText( )
    {
        for( int i = 0; i < 3; i++ )
        {
            if( MissionStartingNum + i > 8 )
            {
                MissionText[i, 0].gameObject.SetActive( false );
                continue;
            }

            if( Missions.GetLevel( MissionStartingNum + i ) == Level )
            {
                MissionText[i, 0].gameObject.SetActive( true );
                MissionText[i, 0].text = Missions.GetValue( MissionStartingNum + i ).MissionText;
                MissionText[i, 1].text = "/" + Missions.GetValue( MissionStartingNum + i ).totalNum.ToString( );
            }
            else
            {
                MissionText[i, 0].gameObject.SetActive( false );
            }
        }
    }

    public void MissionSwitch( )
    {
        Level = MapLevel.getMapLevel( );

        switch( Level )
        {
            case 1:
                MissionStartingNum = 0;
                break;
            case 2:
                MissionStartingNum = 3;
                break;
            case 3:
                MissionStartingNum = 6;
                break;
        }

        SetText( );
    }
}
