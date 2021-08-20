using UnityEngine;

public class GridBase : MonoBehaviour
{
    [SerializeField] private int totalAnimalNum = ( int )Define.ANIMAL.TOTAL_NUM;
    [SerializeField] private bool[] territory;

    private void Start( )
    {
        TerritoryInit( );
    }

    private void TerritoryInit( )
    {
        territory = new bool[totalAnimalNum];

        for( int i = 0; i < totalAnimalNum; i++ )
        {
            territory[i] = false;
        }
    }

    public void SetTerritory( int animalNum )
    {
        territory[animalNum] = true;
    }

    public void RemoveTerritory( int animalNum )
    {
        territory[animalNum] = false;
    }

    public bool GetTerritory( int animalNum )
    {
        return territory[animalNum];
    }
}
