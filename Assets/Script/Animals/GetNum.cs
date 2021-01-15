using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetNum : MonoBehaviour
{

    private GameObject[ ] _animals;

    private int animalsNum;
    private string animalName;

    void Start( )
    {
    }

    void Update( )
    {
        animalType( );
        getAnimalsNum( );
        Debug.Log( animalsNum );
    }

    public int getAnimalsNum( )
    {
        _animals = GameObject.FindGameObjectsWithTag( animalName );
        animalsNum = _animals.Length;
        return animalsNum;
    }

    private void animalType( )
    {
        switch ( this.gameObject.tag )
        {
            case "LIONS":
                animalName = "lion";
                break;
            case "ZEBRAS":
                animalName = "zebra";
                break;
        }
    }
}
