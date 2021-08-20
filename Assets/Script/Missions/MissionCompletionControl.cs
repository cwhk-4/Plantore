using UnityEngine;
using TMPro;

public class MissionCompletionControl : MonoBehaviour
{
    [SerializeField] private MissionsList Missions;
    [SerializeField] private GameObject BoxParent;
    [SerializeField] private GameObject Box;

    public void CreateBox( int index )
    {
        var box = Instantiate( Box, BoxParent.transform );

        box.SetActive( false );
        box.transform.GetChild( 0 ).GetChild( 1 ).GetComponent<TMP_Text>( ).text
            = Missions.GetMissionText( index ) + "\nを完成した！";
        box.SetActive( true );
    }
}
