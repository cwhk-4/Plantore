using UnityEngine;

public class DebugCmdMission : MonoBehaviour
{
    [SerializeField] private MissionControl MissionControl;
    [SerializeField] private GameObject Buttons;

    private bool isButtonActive = false;

    private void Start( )
    {
        isButtonActive = false;
        Buttons.SetActive( isButtonActive );
    }

    void Update()
    {
        if( Input.GetKey( KeyCode.LeftShift ) )
        {
            if( Input.GetKeyUp( KeyCode.B ) )
            {
                if( isButtonActive )
                {
                    isButtonActive = false;
                }
                else
                {
                    isButtonActive = true;
                }

                Buttons.SetActive( isButtonActive );
            }
        }
    }
}
