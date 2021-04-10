using UnityEngine;

public class GridTerritoryControl : MonoBehaviour
{
    //caution -> setup
    private readonly int[] grass = { -12, -1, 0, 1, 12 };
    private readonly int[] grassAnimal = { ( int )Define.ANIMAL.ZEBRA };
    private readonly int[] wood = { -12, -1, 1, 0, 11, 12, 13, 24 };
    private readonly int[] woodAnimal = { ( int )Define.ANIMAL.GIRAFFE };

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

    //caution -> here to get if it is territory
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

    //SET ITEM
    private void SetGrass( int index )
    {
        foreach( int i in grass )
        {
            foreach( int j in grassAnimal )
            {
                if( index + i < 0 )
                {
                    return;
                }

                SetTerritory( index + i, j );
            }
        }
    }

    private void SetWood( int index )
    {
        foreach( int i in wood )
        {
            foreach( int j in woodAnimal )
            {
                if( index + i < 0 )
                {
                    return;
                }
                SetTerritory( index + i, j );
            }
        }
    }

    public void SetItem( int index, int itemNum )
    {
        switch( itemNum )
        {
            case 0: //grass
                SetGrass( index );
                break;

            case 1: //wood
                SetWood( index );
                break;
        }  
    }

    //REMOVE ITEM
    private void RemoveGrass( int index )
    {
        foreach( int i in grass )
        {
            foreach( int j in grassAnimal )
            {
                RemoveTerritory( index + i, j );
            }
        }
    }

    private void RemoveWood( int index )
    {
        foreach( int i in wood )
        {
            foreach( int j in woodAnimal )
            {
                RemoveTerritory( index + i, j );
            }
        }
    }

    public void RemoveItem( int index, int itemNum )
    {
        switch( itemNum )
        {
            case 0:
                RemoveGrass( index );
                break;

            case 1:
                RemoveWood( index );
                break;
        }
    }

}
