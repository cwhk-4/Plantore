using UnityEngine;

public class GridTerritoryControl : MonoBehaviour
{
    [SerializeField] private GameObject GridParent;
    [SerializeField] private GridBase[] Grids;

    public void SetGridSize( int size )
    {
        Grids = new GridBase[size];
    }

    public void SetGrid( int index )
    {
        Grids[index] = GridParent.transform.GetChild( index ).gameObject.GetComponent<GridBase>( );
    }

    public void SetTerritory( GameObject GO, int index, int itemType, int animalNum )
    {
        for( int i = 0; i < ItemData.TERRITORY_ARR[itemType].Length; i++ )
        {
            int targetGrid = index + ItemData.TERRITORY_ARR[itemType][i];

            if( CheckInRange( targetGrid ) )
            {
                Grids[targetGrid].AddAnimal( GO, animalNum );
            }
        }
    }

    public void RemoveTerritory( GameObject GO, int index, int itemType, int animalNum )
    {
        for( int i = 0; i < ItemData.TERRITORY_ARR[itemType].Length; i++ )
        {
            int targetGrid = index + ItemData.TERRITORY_ARR[itemType][i];

            if( CheckInRange( targetGrid ) )
            {
                Grids[targetGrid].RemoveAnimal( GO, animalNum );
            }
        }
    }

    private bool CheckInRange( int index )
    {
        if( index < 0 || index > Define.XCOUNT * Define.YCOUNT )
        {
            return false;
        }

        return true;
    }
}
