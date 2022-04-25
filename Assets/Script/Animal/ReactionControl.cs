using UnityEngine;

//動物間の処理
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
        if( isProcessing )
        {
            return true;
        }

        TargetAnimal = GridParent.GetChild( targetIndex ).GetComponent<GridBase>( ).GetAnimal( );

        if(TargetAnimal == GO)
        {
            TargetAnimal = GridParent.GetChild( targetIndex ).GetComponent<GridBase>( ).GetAnimalbyIndex( 1 );
        }

        if( TargetAnimal == null )
        {
            return true;
        }

        if(TargetAnimal.GetComponent<AnimalBase>().GetAnimalState() <= (int)AnimalData.ANIMAL_STATE.STARTING_PATROL)
        {
            return true;
        }

        ActiveAnimal = GO;
        isProcessing = true;

        return false;
    }

    public bool StartHunting( )
    {
        if( TargetAnimal == null || ActiveAnimal == null )
        {
            return false;
        }

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

        return true;
    }

    public bool StartFighting( )
    {
        if( TargetAnimal == null || ActiveAnimal == null)
        {
            return false;
        }

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

        return true;
    }

}
