using UnityEngine;

public class MissionFoundAnimal : MonoBehaviour
{
    [SerializeField]private MissionControl getThisAnimal;
    private float foundpositionXL = -9.5f;
    private float foundpositionXR = 8.0f;
    private bool plusMissionNum = true;
    private bool getThisAnimalType;
    private bool huntingHappened = true;

    private bool findHippo = true;
    private bool findRhino = true;

    void Update( )
    {
        canFindThisAnimal( );
        Hunting( );
    }

    private void canFindThisAnimal( )
    {
        if ( this.gameObject.transform.position.x > foundpositionXL && this.gameObject.transform.position.x < foundpositionXR && plusMissionNum )
        {
            getThisAnimal.FoundAnimal( );
            plusMissionNum = false;
            getThisAnimalType = true;
        }
        if ( this.gameObject.name == "WHITERHINOS" && this.gameObject.transform.position.x > foundpositionXL && this.gameObject.transform.position.x < foundpositionXR && findRhino )
        {
            getThisAnimal.FoundRhino( );
            findRhino = false;
        }
        if ( this.gameObject.name == "HIPPOS" && this.gameObject.transform.position.y > foundpositionXL && this.gameObject.transform.position.x < foundpositionXR && findHippo )
        {
            getThisAnimal.FoundHippo( );
            findHippo = false;
        }
    }

    private void Hunting( )
    {
        if ( this.gameObject.name == "SPOTTEDHYENAS" && this.gameObject.GetComponent<SPOTTEDHYENA>( ).huntingHappened( ) && huntingHappened )
        {
            getThisAnimal.HuntingHappened( );
            huntingHappened = false;
        }
        if ( this.gameObject.name == "AFRICANWILDDOGS" && this.gameObject.GetComponent<AFRICANWILDDOG>( ).huntingHappened( ) && huntingHappened )
        {
            getThisAnimal.HuntingHappened( );
            huntingHappened = false;
        }
    }

    public bool GetAnimalType( )
    {
        return getThisAnimal;
    }
}
