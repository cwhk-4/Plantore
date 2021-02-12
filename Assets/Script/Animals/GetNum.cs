using UnityEngine;

public class GetNum : MonoBehaviour
{

    [SerializeField] public GameObject[ ] _animals;

    [SerializeField] private int animalsNum;
    [SerializeField] private string animalName;

    void Update( )
    {
        animalType( );
    }

    public int getAnimalsNum( )
    {
        return animalsNum;
    }

    private void animalType(  )
    {
        switch ( this.gameObject.tag )
        {
            case "LIONS":
                animalName = "lion";
                break;
            case "ZEBRAS":
                animalName = "zebra";
                break;
            case "GIRAFFES":
                animalName = "giraffe";
                break;
            case "IMPALAS":
                animalName = "impala";
                break;
            case "WHITERHINOS":
                animalName = "whiterhino";
                break;
            case "BLUEWILDEBEESTS":
                animalName = "bluewildebeest";
                break;
            case "AFRICANWILDDOGS":
                animalName = "africanwilddog";
                break;
            case "SPOTTEDHYENAS":
                animalName = "spottedhyena";
                break;
            case "HIPPOS":
                animalName = "hippo";
                break;
        }
        _animals = GameObject.FindGameObjectsWithTag( animalName );
        animalsNum = _animals.Length;
    }
}
