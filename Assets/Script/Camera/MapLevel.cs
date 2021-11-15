using UnityEngine;

public class MapLevel : MonoBehaviour
{
    [SerializeField] private int level = 1;
    private int[,] mapSize = new int[3,2] { { 6, 5 }, { 8, 7 }, { 10, 9 } };

    [SerializeField] private MissionTextDisplay MissionText;
    [SerializeField] private ItemUIDisplay ItemUIDisplay;

    public int getMapLevel( )
    {
        return level;
    }

    public void setMapLevel( int input )
    {
        level = input;
        ItemUIDisplay.SetMapLevel( level );
    }

    public void loadMapLevel( int levelLoaded )
    {
        level = levelLoaded;
    }

    public int GetNowMapXCount( )
    {
        return mapSize[level - 1, 0];
    }

    public int GetNowMapYCount( )
    {
        return mapSize[level - 1, 1];
    }
}
