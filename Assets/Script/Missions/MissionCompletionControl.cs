using UnityEngine;
using TMPro;

public class MissionCompletionControl : MonoBehaviour
{
    [SerializeField] private MissionsList Missions;
    [SerializeField] private GameObject BoxParent;
    [SerializeField] private GameObject Box;
    [SerializeField] private GameObject Banner;

    public void CreateBanner( int index )
    {
        var banner = Instantiate( Banner, BoxParent.transform );

        banner.SetActive( false );
        banner.transform.GetChild( 0 ).GetComponent<TMP_Text>( ).text
            = "ミッション 「" + Missions.GetMissionText( index ) + "」\nをたっせいした！";
        banner.SetActive( true );
    }

    public void CreateBox( int level )
    {
        var box = Instantiate( Box, BoxParent.transform );

        box.SetActive( false );
        box.transform.GetChild( 0 ).GetChild( 0 ).GetComponent<TMP_Text>( ).text
            = Missions.GetMissionClearText( level );
        box.SetActive( true );
    }
}
