using UnityEngine;

public class ItemBase : MonoBehaviour
{
    [SerializeField] private InstantiateMoveController imController;
    [SerializeField] private ToolConvertion toolConvertion;
    private CountDown countDown;
    private MoveItem moveItem;

    private bool isOnMouse;

    void Start( )
    {
        imController = GameObject.FindWithTag( "InstantiateMoveControl" ).GetComponent<InstantiateMoveController>( );
        toolConvertion = GameObject.FindWithTag( "Cursor" ).GetComponent<ToolConvertion>( );
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

                if( Input.GetMouseButton( 0 ) )
                {
                    if( toolConvertion.getIsCan( ) )
                    {
                        Repair( );
                    }
                }
            }

            if( Input.GetMouseButton( 1 ) )
            {
                MoveGrass( );
            }
        }
    }

    private void Repair( )
    {
        countDown.ResetStartingTime( );
    }

    private void MoveGrass( )
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
