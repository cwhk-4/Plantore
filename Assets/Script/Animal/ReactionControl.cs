using System.Collections.Generic;
using UnityEngine;

public class ReactionControl : MonoBehaviour
{
    [SerializeField] private Transform GridParent;

    private GameObject ActiveAnimal = null;
    private GameObject TargetAnimal = null;
    private bool isProcessing = false;

    private void Init( )
    {
        ActiveAnimal = null;
        TargetAnimal = null;

        isProcessing = false;
    }

    private void Start( )
    {
        Init( );
    }

    public bool RequestAction( GameObject GO, int targetIndex)
    {
        Debug.Log( "Requesting " + targetIndex );

        if( isProcessing )
        {
            Debug.Log( "is Processing" );
            return true;
        }

        TargetAnimal = GridParent.GetChild( targetIndex ).GetComponent<GridBase>( ).GetAnimal( );

        if(TargetAnimal == GO)
        {
            TargetAnimal = GridParent.GetChild( targetIndex ).GetComponent<GridBase>( ).GetAnimalbyIndex( 1 );
        }

        if( TargetAnimal == null )
        {
            Debug.Log( "No Target" );
            return true;
        }

        if(TargetAnimal.GetComponent<AnimalBase>().GetAnimalState() <= (int)AnimalData.ANIMAL_STATE.STARTING_PATROL)
        {
            Debug.Log( "Not Yet Arrive" );
            return true;
        }

        ActiveAnimal = GO;
        isProcessing = true;

        Debug.Log( "Request Succeed " + targetIndex );
        return false;
    }

    public void StartHunting( )
    {
        int ActiveType = ActiveAnimal.GetComponent<AnimalBase>( ).GetTypeNum( );
        int TargetType = TargetAnimal.GetComponent<AnimalBase>( ).GetTypeNum( );

        int rand = Random.Range( 1, 11 );
        if( rand <= AnimalData.CARN_TO_HERB_PROBI[ActiveType][TargetType] )
        {
            ActiveAnimal.GetComponent<AnimalBase>( ).BackToPatrol( true );
            TargetAnimal.GetComponent<AnimalBase>( ).Hunted( );
            Debug.Log( "Hunting Succeed" );
        }
        else
        {
            ActiveAnimal.GetComponent<AnimalBase>( ).BackToPatrol( false );
            Debug.Log( "Hunting Failed" );
        }

        isProcessing = false;
    }

    public void StartFighting( )
    {
        int ActiveType = ActiveAnimal.GetComponent<AnimalBase>( ).GetTypeNum( );
        int TargetType = TargetAnimal.GetComponent<AnimalBase>( ).GetTypeNum( );

        int rand = Random.Range( 1, 11 );
        if( rand < AnimalData.CARN_PROBI[ActiveType][TargetType] )
        {
            ActiveAnimal.GetComponent<AnimalBase>( ).BackToPatrol( true );
            TargetAnimal.GetComponent<AnimalBase>( ).Hunted( );
            Debug.Log( "Fighting Succeed" );
        }
        else
        {
            ActiveAnimal.GetComponent<AnimalBase>( ).Hunted( );
            Debug.Log( "Fighting Failed" );
        }

        isProcessing = false;
    }

}
