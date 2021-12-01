using UnityEngine;
using System.Collections.Generic;

public class GridBase : MonoBehaviour
{
    [SerializeField] private int GridNum = 0;
    [SerializeField] private List<int> carnivoreList = new List<int>( );
    [SerializeField] private List<int> herbivoreList = new List<int>( );
    [SerializeField] private List<GameObject> AnimalList = new List<GameObject>( );
    [SerializeField] private GameObject MainAnimal = null;

    private void Start( )
    {
        TerritoryInit( );
        GridNum = this.transform.GetSiblingIndex( );
    }

    private void TerritoryInit( )
    {
        carnivoreList.Clear( );
        herbivoreList.Clear( );
        AnimalList.Clear( );
    }

    public void AddMainAnimal( GameObject animal )
    {
        Debug.Log( "ADDED" );
        MainAnimal = animal;
    }

    public void RemoveMainAnimal( )
    {
        Debug.Log( "Removed" );
        MainAnimal = null;
    }

    public GameObject GetMainAnimal( )
    {
        return MainAnimal;
    }

    public void AddAnimal( GameObject animal, int animalNum )
    {
        SetList( animalNum );
        AnimalList.Add( animal );
    }

    public void RemoveAnimal( GameObject animal, int animalNum )
    {
        RemoveFromList( animalNum );
        AnimalList.Remove( animal );
    }

    private void SetList( int animalNum )
    {
        for( int i = 0; i < AnimalData.CARNIVORE.Length; i++ )
        {
            if(animalNum == AnimalData.CARNIVORE[i])
            {
                carnivoreList.Add( animalNum );
                return;
            }
        }

        herbivoreList.Add( animalNum );
    }

    private void RemoveFromList( int animalNum )
    {
        for( int i = 0; i < AnimalData.CARNIVORE.Length; i++ )
        {
            if( animalNum == AnimalData.CARNIVORE[i] )
            {
                carnivoreList.Remove( animalNum );
                return;
            }

        }

        herbivoreList.Remove( animalNum );
    }

    public bool GetIfOccupied( )
    {
        if( AnimalList.Count >= 2 )
        {
            return true;
        }

        return false;
    }

    public bool GetIsCarnTerr( )
    {
        if( carnivoreList.Count > 1 )
        {
            return true;
        }

        return false;
    }

    public void AnimalDestoryed( int itemType, int animalType, GameObject animal )
    {
        for( int i = 0; i < ItemData.TERRITORY_ARR[itemType].Length; i++ )
        {
            int index = GridNum + ItemData.TERRITORY_ARR[itemType][i];
            transform.parent.GetChild( index ).GetComponent<GridBase>( ).RemoveAnimal( animal, animalType );
        }
    }

    public GameObject GetAnimal( )
    {
        if( AnimalList.Count == 0 )
        {
            return null;
        }

        return AnimalList[0];
    }

    public GameObject GetAnimalbyIndex(int index)
    {
        Debug.Log( index + " " + AnimalList.Count );
        if( index >= AnimalList.Count )
        {
            return null;
        }

        return AnimalList[index];
    }

}
