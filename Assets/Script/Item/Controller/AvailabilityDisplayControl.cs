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

            case ( int )Define.ITEM.ROCK:
                EnableRock( );
                break;
        }

    }

    private void EnableWood( )
    {
        var extraNum = onGridNum + ItemData.WOOD_SIZE[1];
        if( CheckRange( extraNum ) )
        {
            availability.EnableAva( extraNum );
        }
    }

    private void EnableSmallRock( )
    {
        for( int i = 1; i < ItemData.SMALL_ROCK_SIZE.Length; i++ )
        {
            var extraNum = onGridNum + ItemData.SMALL_ROCK_SIZE[i];
            if( CheckRange( extraNum ) )
            {
                availability.EnableAva( extraNum );
            }
        }
    }

    private void EnableGrassland( )
    {
        var extraNum = onGridNum + ItemData.GRASSLAND_SIZE[1];
        if( CheckRange( extraNum ) )
        {
            availability.EnableAva( extraNum );
        }
    }

    private void EnableMarsh( )
    {
        for( int i = 1; i < ItemData.MARSH_SIZE.Length; i++ )
        {
            var extraNum = onGridNum + ItemData.MARSH_SIZE[i];
            if( CheckRange( extraNum ) )
            {
                availability.EnableAva( extraNum );
            }
        }
    }

    private void EnableRock( )
    {
        for( int i = 1; i < ItemData.ROCK_SIZE.Length; i++ )
        {
            var extraNum = onGridNum + ItemData.ROCK_SIZE[i];
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

                case ( int )Define.ITEM.ROCK:
                    DisableRock( );
                    break;

            }
        }
    }

    private void DisableWood( )
    {
        var extraNum = lastGridNum + ItemData.WOOD_SIZE[1];
        if( CheckRange( extraNum ) )
        {
            availability.DisableAva( extraNum );
        }
    }

    private void DisableSmallRock( )
    {
        for( int i = 1; i < ItemData.SMALL_ROCK_SIZE.Length; i++ )
        {
            var extraNum = lastGridNum + ItemData.SMALL_ROCK_SIZE[i];
            if( CheckRange( extraNum ) )
            {
                availability.DisableAva( extraNum );
            }
        }
    }

    private void DisableGrassland( )
    {
        var extraNum = lastGridNum + ItemData.GRASSLAND_SIZE[1];
        if( CheckRange( extraNum ) )
        {
            availability.DisableAva( extraNum );
        }
    }

    private void DisableMarsh( )
    {
        for( int i = 1; i < ItemData.MARSH_SIZE.Length; i++ )
        {
            var extraNum = lastGridNum + ItemData.MARSH_SIZE[i];
            if( CheckRange( extraNum ) )
            {
                availability.DisableAva( extraNum );
            }
        }
    }

    private void DisableRock( )
    {
        for( int i = 1; i < ItemData.ROCK_SIZE.Length; i++ )
        {
            var extraNum = lastGridNum + ItemData.ROCK_SIZE[i];
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