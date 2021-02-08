using UnityEngine;

public class MissionFoundAnimal : MonoBehaviour
{
    [SerializeField]private MissionControl getThisAnimal;
    private float foundpositionY = 4.0f; 
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
        if ( this.gameObject.transform.position.y < foundpositionY && plusMissionNum )
        {
            getThisAnimal.FoundAnimal( );
            plusMissionNum = false;
            getThisAnimalType = true;
        }
        if ( this.gameObject.name == "WHITERHINOS" && this.gameObject.transform.position.y < foundpositionY && findRhino )
        {
            getThisAnimal.FoundRhino( );
            findRhino = false;
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
