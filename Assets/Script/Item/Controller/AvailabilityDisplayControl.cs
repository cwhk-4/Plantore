using UnityEngine;

public class AvailabilityDisplayControl : MonoBehaviour
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

    public void EnableExtraGrids( int GridNum )
    {
        nowItemNum = imController.getGOItemNum( );
        onGridNum = GridNum;

        availability.EnableAva( GridNum );

        switch( nowItemNum )
        {
            case ( int )Define.ITEM.WOOD:
                EnableWood( );
                break;

            case ( int )Define.ITEM.SMALL_ROCK:
                EnableSmallRock( );
                break;

            case ( int )Define.ITEM.GRASSLAND:
                EnableGrassland( );
                break;

            case ( int )Define.ITEM.MARSH:
                EnableMarsh( );
                break;

            case ( int )Define.ITEM.RICE:
                EnableRice( );
                break;

            case ( int )Define.ITEM.ROCK:
                EnableRock( );
                break;

            case ( int )Define.ITEM.LAKE:
                EnableLake( );
                break;

            case ( int )Define.ITEM.ROCK_GROUP:
                EnableRockGroup( );
                break;
        }

    }

    private void EnableWood( )
    {
        var extraNum = onGridNum + Define.WOOD_SIZE[1];
        if( CheckRange( extraNum ) )
        {
            availability.EnableAva( extraNum );
        }
    }

    private void EnableSmallRock( )
    {
        for( int i = 1; i < Define.SMALL_ROCK_SIZE.Length; i++ )
        {
            var extraNum = onGridNum + Define.SMALL_ROCK_SIZE[i];
            if( CheckRange( extraNum ) )
            {
                availability.EnableAva( extraNum );
            }
        }
    }

    private void EnableGrassland( )
    {
        var extraNum = onGridNum + Define.GRASSLAND_SIZE[1];
        if( CheckRange( extraNum ) )
        {
            availability.EnableAva( extraNum );
        }
    }

    private void EnableMarsh( )
    {
        for( int i = 1; i < Define.MARSH_SIZE.Length; i++ )
        {
            var extraNum = onGridNum + Define.MARSH_SIZE[i];
            if( CheckRange( extraNum ) )
            {
                availability.EnableAva( extraNum );
            }
        }
    }

    private void EnableRice( )
    {
        for( int i = 1; i < Define.RICE_SIZE.Length; i++ )
        {
            var extraNum = onGridNum + Define.RICE_SIZE[i];
            if( CheckRange( extraNum ) )
            {
                availability.EnableAva( extraNum );
            }
        }
    }

    private void EnableRock( )
    {
        for( int i = 1; i < Define.ROCK_SIZE.Length; i++ )
        {
            var extraNum = onGridNum + Define.ROCK_SIZE[i];
            if( CheckRange( extraNum ) )
            {
                availability.EnableAva( extraNum );
            }
        }
    }

    private void EnableLake( )
    {
        for( int i = 1; i < Define.LAKE_SIZE.Length; i++ )
        {
            var extraNum = onGridNum + Define.LAKE_SIZE[i];
            if( CheckRange( extraNum ) )
            {
                availability.EnableAva( extraNum );
            }
        }
    }

    private void EnableRockGroup( )
    {
        for( int i = 1; i < Define.ROCK_GROUP_SIZE.Length; i++ )
        {
            var extraNum = onGridNum + Define.ROCK_GROUP_SIZE[i];
            if( CheckRange( extraNum ) )
            {
                availability.EnableAva( extraNum );
            }
        }
    }

    public void DisableLastGrids( int lastGrid )
    {
        lastGridNum = lastGrid;

        if( lastGridNum != -1 )
        {
            availability.DisableAva( lastGrid );

            switch( imController.getGOItemNum( ) )
            {
                case ( int )Define.ITEM.WOOD:
                    DisableWood( );
                    break;

                case ( int )Define.ITEM.SMALL_ROCK:
                    DisableSmallRock( );
                    break;

                case ( int )Define.ITEM.GRASSLAND:
                    DisableGrassland( );
                    break;

                case ( int )Define.ITEM.MARSH:
                    DisableMarsh( );
                    break;

                case ( int )Define.ITEM.RICE:
                    DisableRice( );
                    break;

                case ( int )Define.ITEM.ROCK:
                    DisableRock( );
                    break;

                case ( int )Define.ITEM.LAKE:
                    DisableLake( );
                    break;

                case ( int )Define.ITEM.ROCK_GROUP:
                    DisableRockGroup( );
                    break;
            }
        }
    }

    private void DisableWood( )
    {
        var extraNum = lastGridNum + Define.WOOD_SIZE[1];
        if( CheckRange( extraNum ) )
        {
            availability.DisableAva( extraNum );
        }
    }

    private void DisableSmallRock( )
    {
        for( int i = 1; i < Define.SMALL_ROCK_SIZE.Length; i++ )
        {
            var extraNum = lastGridNum + Define.SMALL_ROCK_SIZE[i];
            if( CheckRange( extraNum ) )
            {
                availability.DisableAva( extraNum );
            }
        }
    }

    private void DisableGrassland( )
    {
        var extraNum = lastGridNum + Define.GRASSLAND_SIZE[1];
        if( CheckRange( extraNum ) )
        {
            availability.DisableAva( extraNum );
        }
    }

    private void DisableMarsh( )
    {
        for( int i = 1; i < Define.MARSH_SIZE.Length; i++ )
        {
            var extraNum = lastGridNum + Define.MARSH_SIZE[i];
            if( CheckRange( extraNum ) )
            {
                availability.DisableAva( extraNum );
            }
        }
    }

    private void DisableRice( )
    {
        for( int i = 1; i < Define.RICE_SIZE.Length; i++ )
        {
            var extraNum = lastGridNum + Define.RICE_SIZE[i];
            if( CheckRange( extraNum ) )
            {
                availability.DisableAva( extraNum );
            }
        }
    }

    private void DisableRock( )
    {
        for( int i = 1; i < Define.ROCK_SIZE.Length; i++ )
        {
            var extraNum = lastGridNum + Define.ROCK_SIZE[i];
            if( CheckRange( extraNum ) )
            {
                availability.DisableAva( extraNum );
            }
        }
    }

    private void DisableLake( )
    {
        for( int i = 1; i < Define.LAKE_SIZE.Length; i++ )
        {
            var extraNum = lastGridNum + Define.LAKE_SIZE[i];
            if( CheckRange( extraNum ) )
            {
                availability.DisableAva( extraNum );
            }
        }
    }

    private void DisableRockGroup( )
    {
        for( int i = 1; i < Define.ROCK_GROUP_SIZE.Length; i++ )
        {
            var extraNum = lastGridNum + Define.ROCK_GROUP_SIZE[i];
            if( CheckRange( extraNum ) )
            {
                availability.DisableAva( extraNum );
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