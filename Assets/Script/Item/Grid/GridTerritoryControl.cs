using UnityEngine;

public class GridTerritoryControl : MonoBehaviour
{
    //caution -> set animal num
    private readonly int[] grass = { -12, -1, 0, 1, 12 };
    private readonly int[] grassAnimal = { 0 };
    private readonly int[] wood = { -12, -1, 1, 0, 11, 12, 13, 24 };
    private readonly int[] woodAnimal = { 0 };

    [SerializeField] private GameObject GridParent;
    [SerializeField] private GridBase[] Grids;

    public void SetGrids( int size )
    {
        Grids = new GridBase[size];

        for( int i = 0; i < size; i++ )
        {
            Grids[i] = GridParent.transform.GetChild( i ).gameObject.GetComponent<GridBase>( );
        }
    }

    //caution -> here to get if is territory
    public bool GetTerritory( int index, int animalNum )
    {
        return Grids[index].GetTerritory( animalNum );
    }

    private void SetTerritory( int index, int animalNum)
    {
        Grids[index].SetTerritory( animalNum );
    }

    private void RemoveTerritory( int index, int animalNum)
    {
        Grids[index].RemoveTerritory( animalNum );
    }

    private void setGrass( int index )
    {
        foreach( int i in grass )
        {
            foreach( int j in grassAnimal )
            {
                SetTerritory( index + i, j );
            }
        }
    }

    private void setWood( int index )
    {
        foreach( int i in wood )
        {
            foreach( int j in woodAnimal )
            {
                SetTerritory( index + i, j );
            }
        }
    }

    public void SetItem( int itemNum, int index )
    {
        switch( itemNum )
        {
            case 0: //grass
                setGrass( index );
                break;

            case 1: //wood
                setWood( index );
                break;
        }  
    }

}
