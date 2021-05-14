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
        foreach( int i in Define.GRASS_TERRITORY )
        {
            foreach( int j in Define.GRASS_ANIMAL )
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
        foreach( int i in Define.WOOD_TERRITORY )
        {
            foreach( int j in Define.WOOD_ANIMAL )
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
        foreach( int i in Define.ROCK_TERRITORY )
        {
            foreach( int j in Define.ROCK_ANIMAL )
            {
                if( index + i < 0 )
                {
                    return;
                }
                SetTerritory( index + i, j );
            }
        }
    }

    private void SetGrassland( int index )
    {
        foreach( int i in Define.GRASSLAND_TERRITORY )
        {
            foreach( int j in Define.GRASSLAND_ANIMAL )
            {
                if( index + i < 0 )
                {
                    return;
                }
                SetTerritory( index + i, j );
            }
        }
    }

    private void SetMarsh( int index )
    {
        foreach( int i in Define.MARSH_TERRITORY )
        {
            foreach( int j in Define.MARSH_ANIMAL )
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

            case ( int )Define.ITEM.GRASSLAND:
                SetGrassland( index );
                break;

            case ( int )Define.ITEM.MARSH:
                SetMarsh( index );
                break;
        }  
    }

    //REMOVE ITEM
    private void RemoveGrass( int index )
    {
        foreach( int i in Define.GRASS_TERRITORY )
        {
            foreach( int j in Define.GRASS_ANIMAL )
            {
                RemoveTerritory( index + i, j );
            }
        }
    }

    private void RemoveWood( int index )
    {
        foreach( int i in Define.WOOD_TERRITORY )
        {
            foreach( int j in Define.WOOD_ANIMAL )
            {
                RemoveTerritory( index + i, j );
            }
        }
    }

    private void RemoveRock( int index )
    {
        foreach( int i in Define.ROCK_TERRITORY )
        {
            foreach( int j in Define.ROCK_ANIMAL )
            {
                RemoveTerritory( index + i, j );
            }
        }
    }

    private void RemoveGrassland( int index )
    {
        foreach( int i in Define.GRASSLAND_TERRITORY )
        {
            foreach( int j in Define.GRASSLAND_ANIMAL )
            {
                RemoveTerritory( index + i, j );
            }
        }
    }

    private void RemoveMarsh( int index )
    {
        foreach( int i in Define.MARSH_TERRITORY )
        {
            foreach( int j in Define.MARSH_ANIMAL )
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

            case ( int )Define.ITEM.GRASSLAND:
                RemoveGrassland( index );
                break;

            case ( int )Define.ITEM.MARSH:
                RemoveMarsh( index );
                break;
        }
    }

    public Transform GetIndexTransform( int index )
    {
        return GridParent.transform.GetChild( index );
    }
}
