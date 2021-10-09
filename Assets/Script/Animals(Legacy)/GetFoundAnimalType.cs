using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetFoundAnimalType : MonoBehaviour
{
    private bool[ ] GetAnimals;
    private int animalsNum = 12;

    private void Start( )
    {
        GetAnimals = new bool[ animalsNum ];   
    }

    public void FoundAnimals( )
    {

    }
}
