using UnityEngine;

public class TutorialGrassRepairing : MonoBehaviour
{
    public GameObject cursor;
    public ToolConvertion toolConvertion;

    public DialogueEvent dialogueEvent;

    void Start( )
    {
        cursor = GameObject.FindWithTag( "Cursor" );
        toolConvertion = cursor.GetComponent<ToolConvertion>( );

        dialogueEvent = GameObject.FindWithTag( "DialogueControl" ).GetComponent<DialogueEvent>( );
    }

    private void OnMouseDown( )
    {
        if( toolConvertion.getIsCan( ) )
        {
            dialogueEvent.repairGrass( );
        }
    }
}