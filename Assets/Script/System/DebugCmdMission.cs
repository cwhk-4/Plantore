using UnityEngine;

public class DebugCmdMission : MonoBehaviour
{
    [SerializeField] private MissionControl MissionControl;

    void Update()
    {
        if( Input.GetKey( KeyCode.LeftShift ) )
        {
            if( Input.GetKey( KeyCode.H ) )
            {
                MissionControl.FoundHippo( );
            }
        }
    }
}
