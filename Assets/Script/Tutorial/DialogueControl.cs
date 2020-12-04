﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    public TMP_Text dialogue;
    public DialogueEvent dialogueEvent;

    private int dialogueCount = 1;

    private void Start( )
    {
        dialogue = GameObject.FindWithTag( "Dialogue" ).GetComponent<TMP_Text>( );
        dialogueEvent = GetComponent<DialogueEvent>( );

        dialogue.text = DialogueText.getDialogue( dialogueCount );
    }

    void Update( )
    {
        if( dialogueEvent.getDialogueWindowState( ) )
        {
            if( Input.GetMouseButtonDown( 0 ) )
            {
                if( dialogueCount < 9 )
                {
                    nextDialogue( );
                }
                dialogue.text = DialogueText.getDialogue( dialogueCount );

                if( dialogueCount == 9 )
                {
                    dialogueEvent.finishedTutorial( );
                }
            }

            Debug.Log( "count:" + dialogueCount );
        }

    }

    private void nextDialogue( )
    {
        switch( dialogueCount )
        {
            case 1:
            case 7:
            case 8:
                dialogueCount++;
                break;

            case 2:
                dialogueEvent.showGrass( );
                dialogueCount++;
                break;

            case 3:
                dialogueEvent.placeGrass( );
                dialogueCount++;
                break;

            case 4:
                dialogueEvent.showBlackScreen( );
                //zebra come
                dialogueCount++;
                break;

            case 5:
                //lion come
                dialogueCount++;
                break;

            case 6:
                //fix grass
                dialogueCount++;
                break;
        }
    }
}
