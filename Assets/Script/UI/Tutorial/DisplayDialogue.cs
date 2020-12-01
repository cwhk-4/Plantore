using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayDialogue : MonoBehaviour
{
    public TMP_Text dialogue;
    
    private int dialogueCount = 1;

    public GameObject dialogueWindow;

    private void Start() 
    {
        dialogueWindow = this.transform.parent.gameObject;
        dialogue = this.GetComponent<TMP_Text>();
        dialogue.text = DialogueText.getDialogue(dialogueCount);
    }

    void Update( )
    {
        if( Input.GetMouseButtonDown( 0 ) )
        {
            if( dialogueCount < 9 )
            {
                nextDialogue();
            }
            dialogue.text = DialogueText.getDialogue(dialogueCount);
        }
    }

    private void nextDialogue()
    {
        switch(dialogueCount)
        {
            case 1:
            case 7:
            case 8:
                dialogueCount++;
                break;

            case 2:
                //click grass
                dialogueCount++;
                break;

            case 3:
                //finish grass
                dialogueCount++;
                break;

            case 4:
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

    private void switchInvisibility(bool on)
    {
        dialogueWindow.GetComponent<RawImage>().enabled = on;
        dialogue.enabled = on;
        //caution
        //instruction enable = on;
    }
}
