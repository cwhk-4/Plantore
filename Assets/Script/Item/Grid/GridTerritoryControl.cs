﻿using UnityEngine;

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
                if( index + i < 0 || index + i >= Grids.Length)
                {
                    break;
                }

                if( index % Define.XCOUNT == 0 )
                {
                    if( ( index + i ) % Define.XCOUNT == ( Define.XCOUNT - 1 ) )
                    {
                        break;
                    }
                }

                if( index % Define.XCOUNT == ( Define.XCOUNT - 1 ) )
                {
                    if( ( index + i ) % Define.XCOUNT == 0 )
                    {
                        break;
                    }
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
                if( index + i < 0 || index + i >= Grids.Length )
                {
                    break;
                }

                if( index % Define.XCOUNT == 0 )
                {
                    if( ( index + i ) % Define.XCOUNT == ( Define.XCOUNT - 1 ) )
                    {
                        break;
                    }
                }

                if( index % Define.XCOUNT == ( Define.XCOUNT - 1 ) )
                {
                    if( ( index + i ) % Define.XCOUNT == 0 )
                    {
                        break;
                    }
                }

                SetTerritory( index + i, j );
            }
        }
    }

    private void SetSmallRock( int index )
    {
        foreach( int i in Define.SMALL_ROCK_TERRITORY )
        {
            foreach( int j in Define.SMALL_ROCK_ANIMAL )
            {
                if( index + i < 0 || index + i >= Grids.Length )
                {
                    break;
                }

                if( index % Define.XCOUNT == 0 )
                {
                    if( ( index + i ) % Define.XCOUNT == ( Define.XCOUNT - 1 ) )
                    {
                        break;
                    }
                }

                if( index % Define.XCOUNT == ( Define.XCOUNT - 1 ) )
                {
                    if( ( index + i ) % Define.XCOUNT == 0 )
                    {
                        break;
                    }
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
                if( index + i < 0 || index + i >= Grids.Length )
                {
                    break;
                }

                if( index % Define.XCOUNT == 0 )
                {
                    if( ( index + i ) % Define.XCOUNT == ( Define.XCOUNT - 1 ) )
                    {
                        break;
                    }
                }

                if( index % Define.XCOUNT == ( Define.XCOUNT - 1 ) )
                {
                    if( ( index + i ) % Define.XCOUNT == 0 )
                    {
                        break;
                    }
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
                if( index + i < 0 || index + i >= Grids.Length )
                {
                    break;
                }

                if( index % Define.XCOUNT == 0 )
                {
                    if( ( index + i ) % Define.XCOUNT == ( Define.XCOUNT - 1 ) )
                    {
                        break;
                    }
                }

                if( index % Define.XCOUNT == ( Define.XCOUNT - 1 ) )
                {
                    if( ( index + i ) % Define.XCOUNT == 0 )
                    {
                        break;
                    }
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
                if( index + i < 0 || index + i >= Grids.Length )
                {
                    break;
                }

                if( index % Define.XCOUNT == 0 )
                {
                    if( ( index + i ) % Define.XCOUNT == ( Define.XCOUNT - 1 ) )
                    {
                        break;
                    }
                }

                if( index % Define.XCOUNT == ( Define.XCOUNT - 1 ) )
                {
                    if( ( index + i ) % Define.XCOUNT == 0 )
                    {
                        break;
                    }
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

            case ( int )Define.ITEM.SMALL_ROCK:
                SetSmallRock( index );
                break;

            case ( int )Define.ITEM.GRASSLAND:
                SetGrassland( index );
                break;

            case ( int )Define.ITEM.MARSH:
                SetMarsh( index );
                break;

            case ( int )Define.ITEM.ROCK:
                SetRock( index );
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
                if( index + i < 0 || index + i >= Grids.Length )
                {
                    return;
                }

                if( index % Define.XCOUNT == 0 )
                {
                    if( ( index + i ) % Define.XCOUNT == ( Define.XCOUNT - 1 ) )
                    {
                        break;
                    }
                }

                if( index % Define.XCOUNT == ( Define.XCOUNT - 1 ) )
                {
                    if( ( index + i ) % Define.XCOUNT == 0 )
                    {
                        break;
                    }
                }

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
                if( index + i < 0 || index + i >= Grids.Length )
                {
                    break;
                }

                if( index % Define.XCOUNT == 0 )
                {
                    if( ( index + i ) % Define.XCOUNT == ( Define.XCOUNT - 1 ) )
                    {
                        break;
                    }
                }

                if( index % Define.XCOUNT == ( Define.XCOUNT - 1 ) )
                {
                    if( ( index + i ) % Define.XCOUNT == 0 )
                    {
                        break;
                    }
                }

                RemoveTerritory( index + i, j );
            }
        }
    }

    private void RemoveSmallRock( int index )
    {
        foreach( int i in Define.SMALL_ROCK_TERRITORY )
        {
            foreach( int j in Define.SMALL_ROCK_ANIMAL )
            {
                if( index + i < 0 || index + i >= Grids.Length )
                {
                    break;
                }

                if( index % Define.XCOUNT == 0 )
                {
                    if( ( index + i ) % Define.XCOUNT == ( Define.XCOUNT - 1 ) )
                    {
                        break;
                    }
                }

                if( index % Define.XCOUNT == ( Define.XCOUNT - 1 ) )
                {
                    if( ( index + i ) % Define.XCOUNT == 0 )
                    {
                        break;
                    }
                }

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
                if( index + i < 0 || index + i >= Grids.Length )
                {
                    break;
                }

                if( index % Define.XCOUNT == 0 )
                {
                    if( ( index + i ) % Define.XCOUNT == ( Define.XCOUNT - 1 ) )
                    {
                        break;
                    }
                }

                if( index % Define.XCOUNT == ( Define.XCOUNT - 1 ) )
                {
                    if( ( index + i ) % Define.XCOUNT == 0 )
                    {
                        break;
                    }
                }

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
                if( index + i < 0 || index + i >= Grids.Length )
                {
                    break;
                }

                if( index % Define.XCOUNT == 0 )
                {
                    if( ( index + i ) % Define.XCOUNT == ( Define.XCOUNT - 1 ) )
                    {
                        break;
                    }
                }

                if( index % Define.XCOUNT == ( Define.XCOUNT - 1 ) )
                {
                    if( ( index + i ) % Define.XCOUNT == 0 )
                    {
                        break;
                    }
                }

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
                if( index + i < 0 || index + i >= Grids.Length )
                {
                    break;
                }

                if( index % Define.XCOUNT == 0 )
                {
                    if( ( index + i ) % Define.XCOUNT == ( Define.XCOUNT - 1 ) )
                    {
                        break;
                    }
                }

                if( index % Define.XCOUNT == ( Define.XCOUNT - 1 ) )
                {
                    if( ( index + i ) % Define.XCOUNT == 0 )
                    {
                        break;
                    }
                }

                RemoveTerritory( index + i, j );
            }
        }
    }

    public void RemoveItem( int index, int itemNum )
    {
        switch( itemNum )
        {
            case (int) Define.ITEM.GRASS:
                RemoveGrass( index );
                break;

            case ( int )Define.ITEM.WOOD:
                RemoveWood( index );
                break;

            case ( int )Define.ITEM.SMALL_ROCK:
                RemoveSmallRock( index );
                break;

            case ( int )Define.ITEM.GRASSLAND:
                RemoveGrassland( index );
                break;

            case ( int )Define.ITEM.MARSH:
                RemoveMarsh( index );
                break;

            case ( int )Define.ITEM.ROCK:
                RemoveRock( index );
                break;
        }
    }

    public Transform GetIndexTransform( int index )
    {
        return GridParent.transform.GetChild( index );
    }
}
