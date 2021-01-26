using UnityEngine;

public class ItemBase : MonoBehaviour
{
    [SerializeField] private MissionControl MissionControl;
    [SerializeField] private InstantiateMoveControl imController;
    [SerializeField] private ToolConvertion toolConvertion;
    private CountDown countDown;
    private MoveItem moveItem;

    [SerializeField]private bool isOnMouse;

    void Start( )
    {
        imController = GameObject.FindWithTag( "InstantiateMoveControl" ).GetComponent<InstantiateMoveControl>( );
        toolConvertion = GameObject.FindWithTag( "Cursor" ).GetComponent<ToolConvertion>( );
        MissionControl = GameObject.FindWithTag( "MissionController" ).GetComponent<MissionControl>( );
        countDown = GetComponent<CountDown>( );
        moveItem = GetComponent<MoveItem>( );
        isOnMouse = false;
    }

    private void Update( )
    {
        if( isOnMouse )
        {
            if( !imController.GetIsInstantiating( ) || !imController.GetIsMoving( ) )
            {
                if( Input.GetMouseButtonDown( 0 ) )
                {
                    if( toolConvertion.getIsCan( ) )
                    {
                        if(countDown.getCD() <= 0)
                        {
                            Repair( );
                        }
                    }
                }
            }

            if( Input.GetMouseButtonDown( 1 ) )
            {
                MoveItem( );
            }
        }
    }

    private void Repair( )
    {
        countDown.ResetStartingTime( );
        MissionControl.FixedItem( );
    }

    private void MoveItem( )
    {
        moveItem.StartMoving( countDown.getStartTime( ) );
    }

    public void setOnMouse( )
    {
        isOnMouse = true;
        toolConvertion.setOnGO( );
    }

    public void setExitMouse( )
    {
        isOnMouse = false;
        toolConvertion.setExitGO( );
    }

}
