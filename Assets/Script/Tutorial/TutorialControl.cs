using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class TutorialControl : MonoBehaviour
{
    [SerializeField] private TutorialList TutorialList;
    [SerializeField] private GameObject TutorialUI;
    [SerializeField] private TMP_Text TextBox;

    [SerializeField] private int TextCount = 0;
    [SerializeField] private string[] TextShown;

    //[SerializeField] private Transform StageBlock;
    //[SerializeField] private Transform StageOriginalParent;

    void Start()
    {
        TutorialUI.SetActive( true );
        TextCount = 0;
        TextShown = TutorialList.GetTutorialText( TextCount );
        for( int i = 1; i < TextShown.Length; i++ )
        {
            TextShown[0] = string.Concat( TextShown[0], "\n", TextShown[i] );
        }
        TextBox.text = TextShown[0];
    }

    void Update()
    {
        if( Input.GetMouseButtonDown( 0 ) )
        {
            if( TextCount < 23 )
            {
                TextCount++;
                TextShown = TutorialList.GetTutorialText( TextCount );
                for( int i = 1; i < TextShown.Length; i++ )
                {
                    TextShown[0] = string.Concat( TextShown[0], "\n", TextShown[i] );
                }
                TextBox.text = TextShown[0];
            }
            else
            {
                TutorialUI.SetActive( false );   
            }
        }
    }
}
