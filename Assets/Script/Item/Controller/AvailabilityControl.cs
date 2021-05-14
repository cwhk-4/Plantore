using UnityEngine;

public class AvailabilityControl : MonoBehaviour
{
    [SerializeField] private GridColorControl[] Grids;
    [SerializeField] private InstantiateMoveControl imController;

    private int xCount;
    private int yCount;

    [SerializeField] private int onGridNum;
    [SerializeField] private int lastGridNum = 0;

    private int nowItemNum;

    private void Start( )
    {
        onGridNum = -1;
    }

    public void SetGridSize( int x, int y)
    {
        xCount = x;
        yCount = y;
        Grids = new GridColorControl[xCount * yCount];
    }

    public void SetGrid( int num, GameObject child )
    {
        Grids[num] = child.GetComponent<GridColorControl>( );
    }

    public void OnGrid( int num )
    {
        if( onGridNum != num )
        {
            lastGridNum = onGridNum;
            onGridNum = num;

            imController.setNowGrid( onGridNum );

            DisableTerritories( );
            DisableLastGrids( );
        }
    }

    private void Update( )
    {
        if( onGridNum != -1 && ( imController.GetIsInstantiating( ) || imController.GetIsMoving( ) ) )
        {
            nowItemNum = imController.getGOItemNum( );
            Grids[onGridNum].EnableAvailability( );

            EnableTerritories( );
            EnableExtraGrids( );
        }
    }

    private void EnableExtraGrids( )
    {
        switch( nowItemNum )
        {
            case ( int )Define.ITEM.WOOD:
                EnableWood( );
                break;

            case ( int )Define.ITEM.GRASSLAND:
                EnableGrassland( );
                break;

            case ( int )Define.ITEM.MARSH:
                EnableMarsh( );
                break;
        }
        
    }

    private void EnableWood( )
    {
        Grids[onGridNum + xCount].EnableAvailability( );
    }

    private void EnableGrassland( )
    {
        Grids[onGridNum - 1].EnableAvailability( );
    }

    private void EnableMarsh( )
    {
        for( int i = 1; i < Define.MARSH_SIZE.Length; i++ )
        {
            Grids[onGridNum - Define.MARSH_SIZE[i]].EnableAvailability( );
        }
    }

    private void DisableLastGrids( )
    {
        if( lastGridNum != -1 )
        {
            Grids[lastGridNum].DisableAvailability( );

            switch( imController.getGOItemNum( ) )
            {
                case ( int )Define.ITEM.WOOD:
                    DisableWood( );
                    break;

                case ( int )Define.ITEM.GRASSLAND:
                    DisableGrassland( );
                    break;

                case ( int )Define.ITEM.MARSH:
                    DisableMarsh( );
                    break;
            }
        }
    }


    private void DisableWood( )
    {
        Grids[lastGridNum + Define.WOOD_SIZE[1]].DisableAvailability( );
    }

    private void DisableGrassland( )
    {
        Grids[lastGridNum + Define.GRASSLAND_SIZE[1]].DisableAvailability( );
    }

    private void DisableMarsh( )
    {
        for( int i = 1; i < Define.MARSH_SIZE.Length; i++ )
        {
            Grids[lastGridNum + Define.MARSH_SIZE[i]].DisableAvailability( );
        }
    }

    private void EnableTerritories( )
    {
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

            case ( int )Define.ITEM.ROCK:
                EnableRockTerritories( );
                break;

            default:
                EnableMarshTerritories( );
                break;
        }
    }

    private void EnableGrassTerritories( )
    {
        for( int i = Define.GRASS_SIZE.Length; i < Define.GRASS_TERRITORY.Length; i++ )
        {
            var territoryNum = onGridNum + Define.GRASS_TERRITORY[i];
            if(CheckRange(territoryNum))
            {
                Grids[territoryNum].EnableTerritories( );
            }
        }
    }

    private void EnableWoodTerritories( )
    {
        for(int i = Define.WOOD_SIZE.Length; i<Define.WOOD_TERRITORY.Length;i++ )
        {
            var territoryNum = onGridNum + Define.WOOD_TERRITORY[i];
            if( CheckRange( territoryNum ) )
            {
                Grids[territoryNum].EnableTerritories( );
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
                Grids[territoryNum].EnableTerritories( );
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
                Grids[territoryNum].EnableTerritories( );
            }
        }
    }

    private void EnableRockTerritories( )
    {
        for( int i = Define.ROCK_SIZE.Length; i < Define.ROCK_TERRITORY.Length; i++ )
        {
            var territoryNum = onGridNum + Define.ROCK_TERRITORY[i];
            if( CheckRange( territoryNum ) )
            {
                Grids[territoryNum].EnableTerritories( );
            }
        }
    }

    private void DisableTerritories( )
    {
        if( lastGridNum != -1 )
        {
            switch( imController.getGOItemNum( ) )
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

                case ( int )Define.ITEM.ROCK:
                    DisableRockTerritories( );
                    break;

                default:
                    DisableMarshTerritories( );
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
                Grids[territoryNum].DisableAvailability( );
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
                Grids[territoryNum].DisableAvailability( );
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
                Grids[territoryNum].DisableAvailability( );
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
                Grids[territoryNum].DisableAvailability( );
            }
        }
    }

    private void DisableRockTerritories( )
    {
        for( int i = Define.ROCK_SIZE.Length; i < Define.ROCK_TERRITORY.Length; i++ )
        {
            var territoryNum = lastGridNum + Define.ROCK_TERRITORY[i];
            if( CheckRange( territoryNum ) )
            {
                Grids[territoryNum].DisableAvailability( );
            }
        }
    }

    private bool CheckRange( int index )
    {
        if(index >=0 && index < xCount * yCount)
        {
            return true;
        }

        return false;
    }
}
