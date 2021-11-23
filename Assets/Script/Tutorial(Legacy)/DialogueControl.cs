﻿using UnityEngine;
using TMPro;

public class DialogueControl : MonoBehaviour
{
    [SerializeField] private TMP_Text dialogue;
    [SerializeField] private DialogueEvent dialogueEvent;

    private int dialogueCount = 1;

    private void Start( )
    {
        dialogueEvent = GetComponent<DialogueEvent>( );

        dialogue.text = DialogueText.getDialogue( dialogueCount );
    }

    void Update( )
    {
        if( dialogueEvent.getDialogueWindowState( ) )
        {
            if( Input.GetMouseButtonDown( 0 ) )
            {
                jumpToNext( );
            }
        }

    }

    private void jumpToNext( )
    {
        if( dialogueCount <= 9 )
        {
            nextDialogue( );
        }

        dialogue.text = DialogueText.getDialogue( dialogueCount );

        if( dialogueCount == 9 )
        {
            dialogueEvent.showToStageButton( );
        }

    }

    public int getDialogueCount( )
    {
        return dialogueCount;
    }

    private void nextDialogue( )
    {
        switch( dialogueCount )
        {
            case 1:
                dialogueCount++;
                break;

            case 2:
                dialogueEvent.openMenu( );
                dialogueEvent.showGrass( );
                dialogueCount++;
                break;

            case 3:
                dialogueEvent.placeGrass( );
                dialogueCount++;
                break;

            case 4:
            case 5:
                dialogueEvent.showBlackScreen( );
                dialogueCount++;
                break;

            case 6:
                dialogueEvent.changeTool( );
                dialogueCount++;
                break;

            case 7:
                dialogueEvent.waitForRepair( );
                dialogueCount++;
                break;

            case 8:
                dialogueCount++;
                break;
        }
    }
}