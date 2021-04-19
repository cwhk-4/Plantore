using UnityEngine;

public class GridTerritoryControl : MonoBehaviour
{
    private readonly int[] grass = { -12, -1, 0, 1, 12 };
    private readonly int[] grassAnimal = { ( int )Define.ANIMAL.ZEBRA };
    private readonly int[] wood = { -12, -1, 1, 0, 11, 12, 13, 24 };
    private readonly int[] woodAnimal = { ( int )Define.ANIMAL.GIRAFFE };

    //caution -> not yet setup
    private readonly int[] rock = { -12, -1, 1, 0, 11, 12, 13, 24 };
    private readonly int[] rockAnimal = { ( int )Define.ANIMAL.LION };

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

    private void SetRock( int index )
    {
        foreach( int i in rock )
        {
            foreach( int j in rockAnimal )
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
            case ( int )Define.ITEM.GRASS:
                SetGrass( index );
                break;

            case ( int )Define.ITEM.WOOD:
                SetWood( index );
                break;

            case ( int )Define.ITEM.ROCK:
                SetRock( index );
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

    private void RemoveRock( int index )
    {
        foreach( int i in rock )
        {
            foreach( int j in rockAnimal )
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

            case ( int )Define.ITEM.ROCK:
                RemoveRock( index );
                break;
        }
    }

}
