using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialGrass : MonoBehaviour
{
    public DialogueEvent dialogueEvent;

    private void Start( )
    {
        dialogueEvent = GameObject.FindWithTag( "DialogueControl" ).GetComponent<DialogueEvent>( );
        dialogueEvent.grassPlaced( );
    }
}
