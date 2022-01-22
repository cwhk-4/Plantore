using UnityEngine;

public class GridAvailabilityControl : MonoBehaviour
{
    [SerializeField] private GridColorControl[] Grids;
    private int xCount;
    private int yCount;

    public void SetGridSize( int x, int y )
    {
        xCount = x;
        yCount = y;
        Grids = new GridColorControl[xCount * yCount];
    }

    public void SetGrid( int num, GameObject child )
    {
        Grids[num] = child.GetComponent<GridColorControl>( );
    }

    public void EnableAva( int index )
    {
        Grids[index].EnableAvailability( );
    }

    public void DisableAva( int index )
    {
        Grids[index].DisableAvailability( );
    }

    public void EnableTerritory( int index )
    {
        Grids[index].EnableTerritories( );
    }

    public void DisableTerritory( int index )
    {
        Grids[index].DisableAvailability( );
    }

    public void ShowArea( int index, int type )
    {
        Grids[index].ShowArea( type );
    }

    public void DisableArea( int index )
    {
        Grids[index].DisableAvailability( );
    }
}
