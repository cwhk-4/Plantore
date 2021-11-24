using UnityEngine;

public class MapLevel : MonoBehaviour
{
    [SerializeField] private int level = 1;
    private int[,] MapSize = new int[3,2] { { 6, 5 }, { 8, 7 }, { 10, 9 } };

    [SerializeField] private MissionTextDisplay MissionText;
    [SerializeField] private ItemUIDisplay ItemUIDisplay;

    public int GetMapLevel( )
    {
        return level;
    }

    public void SetMapLevel( int input )
    {
        level = input;
        ItemUIDisplay.SetMapLevel( level );
    }

    public void LoadMapLevel( int levelLoaded )
    {
        level = levelLoaded;
    }

    public int GetNowMapXCount( )
    {
        return MapSize[level - 1, 0];
    }

    public int GetNowMapYCount( )
    {
        return MapSize[level - 1, 1];
    }
}
