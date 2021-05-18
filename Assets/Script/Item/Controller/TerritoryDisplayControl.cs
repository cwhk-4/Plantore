﻿using UnityEngine;

public class TerritoryDisplayControl : MonoBehaviour
{
    [SerializeField] private InstantiateMoveControl imController;
    private GridAvailabilityControl availability;

    private int nowItemNum;

    private int onGridNum;
    private int lastGridNum;

    private void Start( )
    {
        nowItemNum = onGridNum = lastGridNum = -1;
        availability = GetComponent<GridAvailabilityControl>( );
    }

    public void EnableTerritories( int gridNum )
    {
        nowItemNum = imController.getGOItemNum( );
        onGridNum = gridNum;

        switch( nowItemNum )
        {
            case ( int )Define.ITEM.GRASS:
                EnableGrassTerritories( );
                break;

            case ( int )Define.ITEM.WOOD:
                EnableWoodTerritories( );
                break;

            case ( int )Define.ITEM.GRASSLAND:
                EnableGrasslandTerritories( );
                break;

            case ( int )Define.ITEM.MARSH:
                EnableMarshTerritories( );
                break;

            case ( int )Define.ITEM.SMALL_ROCK:
                EnableSmallRockTerritories( );
                break;
        }
    }

    private void EnableGrassTerritories( )
    {
        for( int i = Define.GRASS_SIZE.Length; i < Define.GRASS_TERRITORY.Length; i++ )
        {
            var territoryNum = onGridNum + Define.GRASS_TERRITORY[i];
            if( CheckRange( territoryNum ) )
            {
                availability.EnableTerritory( territoryNum );
            }
        }
    }

    private void EnableWoodTerritories( )
    {
        for( int i = Define.WOOD_SIZE.Length; i < Define.WOOD_TERRITORY.Length; i++ )
        {
            var territoryNum = onGridNum + Define.WOOD_TERRITORY[i];
            if( CheckRange( territoryNum ) )
            {
                availability.EnableTerritory( territoryNum );
            }
        }
    }

    private void EnableGrasslandTerritories( )
    {
        for( int i = Define.GRASSLAND_SIZE.Length; i < Define.GRASSLAND_TERRITORY.Length; i++ )
        {
            var territoryNum = onGridNum + Define.GRASSLAND_TERRITORY[i];
            if( CheckRange( territoryNum ) )
            {
                availability.EnableTerritory( territoryNum );
            }
        }
    }

    private void EnableMarshTerritories( )
    {
        for( int i = Define.MARSH_SIZE.Length; i < Define.MARSH_TERRITORY.Length; i++ )
        {
            var territoryNum = onGridNum + Define.MARSH_TERRITORY[i];
            if( CheckRange( territoryNum ) )
            {
                availability.EnableTerritory( territoryNum );
            }
        }
    }

    private void EnableSmallRockTerritories( )
    {
        for( int i = Define.SMALL_ROCK_SIZE.Length; i < Define.SMALL_ROCK_TERRITORY.Length; i++ )
        {
            var territoryNum = onGridNum + Define.SMALL_ROCK_TERRITORY[i];
            if( CheckRange( territoryNum ) )
            {
                availability.EnableTerritory( territoryNum );
            }
        }
    }

    public void DisableTerritories( int lastGrid )
    {
        lastGridNum = lastGrid;

        nowItemNum = imController.getGOItemNum( );

        if( lastGridNum != -1 )
        {
            switch( nowItemNum )
            {
                case ( int )Define.ITEM.GRASS:
                    DisableGrassTerritories( );
                    break;

                case ( int )Define.ITEM.WOOD:
                    DisableWoodTerritories( );
                    break;

                case ( int )Define.ITEM.GRASSLAND:
                    DisableGrasslandTerritories( );
                    break;

                case ( int )Define.ITEM.MARSH:
                    DisableMarshTerritories( );
                    break;

                case ( int )Define.ITEM.SMALL_ROCK:
                    DisableSmallRockTerritories( );
                    break;
            }
        }
    }

    private void DisableGrassTerritories( )
    {
        for( int i = Define.GRASS_SIZE.Length; i < Define.GRASS_TERRITORY.Length; i++ )
        {
            var territoryNum = lastGridNum + Define.GRASS_TERRITORY[i];
            if( CheckRange( territoryNum ) )
            {
                availability.DisableTerritory( territoryNum );
            }
        }
    }

    private void DisableWoodTerritories( )
    {
        for( int i = Define.WOOD_SIZE.Length; i < Define.WOOD_TERRITORY.Length; i++ )
        {
            var territoryNum = lastGridNum + Define.WOOD_TERRITORY[i];
            if( CheckRange( territoryNum ) )
            {
                availability.DisableTerritory( territoryNum );
            }
        }
    }

    private void DisableGrasslandTerritories( )
    {
        for( int i = Define.GRASSLAND_SIZE.Length; i < Define.GRASSLAND_TERRITORY.Length; i++ )
        {
            var territoryNum = lastGridNum + Define.GRASSLAND_TERRITORY[i];
            if( CheckRange( territoryNum ) )
            {
                availability.DisableTerritory( territoryNum );
            }
        }
    }

    private void DisableMarshTerritories( )
    {
        for( int i = Define.MARSH_SIZE.Length; i < Define.MARSH_TERRITORY.Length; i++ )
        {
            var territoryNum = lastGridNum + Define.MARSH_TERRITORY[i];
            if( CheckRange( territoryNum ) )
            {
                availability.DisableTerritory( territoryNum );
            }
        }
    }

    private void DisableSmallRockTerritories( )
    {
        for( int i = Define.SMALL_ROCK_SIZE.Length; i < Define.SMALL_ROCK_TERRITORY.Length; i++ )
        {
            var territoryNum = lastGridNum + Define.SMALL_ROCK_TERRITORY[i];
            if( CheckRange( territoryNum ) )
            {
                availability.DisableTerritory( territoryNum );
            }
        }
    }

    private bool CheckRange( int index )
    {
        if( index >= 0 && index < Define.TOTAL_GRID_NUM )
        {
            return true;
        }

        return false;
    }
}