using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionFoundAnimal : MonoBehaviour
{
    [SerializeField]private MissionControl getThisAnimal;
    private float foundpositionY = 4.0f; 
    private bool plusMissionNum = true;

    void Start()
    {
        
    }

    void Update( )
    {
        canFindThisAnimal( );
    }

    private void canFindThisAnimal( )
    {
        if ( this.gameObject.transform.position.y < foundpositionY && plusMissionNum )
        {
            getThisAnimal.FoundAnimal( );
            plusMissionNum = false;
        }
    }
}
