using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class TutorialList : MonoBehaviour
{
    [SerializeField] TextAsset Tutorialcsv;
    [SerializeField] List<string> TutorialText = new List<string>( );

    void Start( )
    {
        StringReader reader = new StringReader( Tutorialcsv.text );

        while( reader.Peek( ) != -1 )
        {
            string line = reader.ReadLine( );
            TutorialText.Add( line );
        }
    }

    public string GetTutorialText( int index )
    {
        return TutorialText[index];
    }
}
