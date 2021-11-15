using UnityEngine;

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

            case ( int )Define.ITEM.SMALL_ROCK:
                EnableSmallRockTerritories( );
                break;

            case ( int )Define.ITEM.GRASSLAND:
                EnableGrasslandTerritories( );
                break;

            case ( int )Define.ITEM.MARSH:
                EnableMarshTerritories( );
                break;

            case ( int )Define.ITEM.ROCK:
                EnableRockTerritories( );
                break;
        }
    }

    private void EnableGrassTerritories( )
    {
        for( int i = ItemData.GRASS_SIZE.Length; i < ItemData.GRASS_TERRITORY.Length; i++ )
        {
            var territoryNum = onGridNum + ItemData.GRASS_TERRITORY[i];
            if( CheckRange( territoryNum ) )
            {
                availability.EnableTerritory( territoryNum );
            }
        }
    }

    private void EnableWoodTerritories( )
    {
        for( int i = ItemData.WOOD_SIZE.Length; i < ItemData.WOOD_TERRITORY.Length; i++ )
        {
            var territoryNum = onGridNum + ItemData.WOOD_TERRITORY[i];
            if( CheckRange( territoryNum ) )
            {
                availability.EnableTerritory( territoryNum );
            }
        }
    }

    private void EnableSmallRockTerritories( )
    {
        for( int i = ItemData.SMALL_ROCK_SIZE.Length; i < ItemData.SMALL_ROCK_TERRITORY.Length; i++ )
        {
            var territoryNum = onGridNum + ItemData.SMALL_ROCK_TERRITORY[i];
            if( CheckRange( territoryNum ) )
            {
                availability.EnableTerritory( territoryNum );
            }
        }
    }

    private void EnableGrasslandTerritories( )
    {
        for( int i = ItemData.GRASSLAND_SIZE.Length; i < ItemData.GRASSLAND_TERRITORY.Length; i++ )
        {
            var territoryNum = onGridNum + ItemData.GRASSLAND_TERRITORY[i];
            if( CheckRange( territoryNum ) )
            {
                availability.EnableTerritory( territoryNum );
            }
        }
    }

    private void EnableMarshTerritories( )
    {
        for( int i = ItemData.MARSH_SIZE.Length; i < ItemData.MARSH_TERRITORY.Length; i++ )
        {
            var territoryNum = onGridNum + ItemData.MARSH_TERRITORY[i];
            if( CheckRange( territoryNum ) )
            {
                availability.EnableTerritory( territoryNum );
            }
        }
    }

    private void EnableRockTerritories( )
    {
        for( int i = ItemData.ROCK_SIZE.Length; i < ItemData.ROCK_TERRITORY.Length; i++ )
        {
            var territoryNum = onGridNum + ItemData.ROCK_TERRITORY[i];
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

                case ( int )Define.ITEM.SMALL_ROCK:
                    DisableSmallRockTerritories( );
                    break;

                case ( int )Define.ITEM.GRASSLAND:
                    DisableGrasslandTerritories( );
                    break;

                case ( int )Define.ITEM.MARSH:
                    DisableMarshTerritories( );
                    break;

                case ( int )Define.ITEM.ROCK:
                    DisableRockTerritories( );
                    break;
            }
        }
    }

    private void DisableGrassTerritories( )
    {
        for( int i = ItemData.GRASS_SIZE.Length; i < ItemData.GRASS_TERRITORY.Length; i++ )
        {
            var territoryNum = lastGridNum + ItemData.GRASS_TERRITORY[i];
            if( CheckRange( territoryNum ) )
            {
                availability.DisableTerritory( territoryNum );
            }
        }
    }

    private void DisableWoodTerritories( )
    {
        for( int i = ItemData.WOOD_SIZE.Length; i < ItemData.WOOD_TERRITORY.Length; i++ )
        {
            var territoryNum = lastGridNum + ItemData.WOOD_TERRITORY[i];
            if( CheckRange( territoryNum ) )
            {
                availability.DisableTerritory( territoryNum );
            }
        }
    }

    private void DisableSmallRockTerritories( )
    {
        for( int i = ItemData.SMALL_ROCK_SIZE.Length; i < ItemData.SMALL_ROCK_TERRITORY.Length; i++ )
        {
            var territoryNum = lastGridNum + ItemData.SMALL_ROCK_TERRITORY[i];
            if( CheckRange( territoryNum ) )
            {
                availability.DisableTerritory( territoryNum );
            }
        }
    }

    private void DisableGrasslandTerritories( )
    {
        for( int i = ItemData.GRASSLAND_SIZE.Length; i < ItemData.GRASSLAND_TERRITORY.Length; i++ )
        {
            var territoryNum = lastGridNum + ItemData.GRASSLAND_TERRITORY[i];
            if( CheckRange( territoryNum ) )
            {
                availability.DisableTerritory( territoryNum );
            }
        }
    }

    private void DisableMarshTerritories( )
    {
        for( int i = ItemData.MARSH_SIZE.Length; i < ItemData.MARSH_TERRITORY.Length; i++ )
        {
            var territoryNum = lastGridNum + ItemData.MARSH_TERRITORY[i];
            if( CheckRange( territoryNum ) )
            {
                availability.DisableTerritory( territoryNum );
            }
        }
    }

    private void DisableRockTerritories( )
    {
        for( int i = ItemData.ROCK_SIZE.Length; i < ItemData.ROCK_TERRITORY.Length; i++ )
        {
            var territoryNum = lastGridNum + ItemData.ROCK_TERRITORY[i];
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
