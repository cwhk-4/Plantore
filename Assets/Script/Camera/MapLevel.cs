using UnityEngine;

public class MapLevel : MonoBehaviour
{
    [SerializeField] private int level = 1;

    [SerializeField] private MissionTextDisplay MissionText;
    [SerializeField] private ItemUIDisplay ItemUIDisplay;

    private void Awake( )
    {
        MissionText.MapLevelChanged( level );
    }

    public int getMapLevel()
    {
        return level;
    }

    public void setMapLevel( int input )
    {
        level = input;
        MissionText.MapLevelChanged( level );
        ItemUIDisplay.SetMapLevel( level );
    }

    public void loadMapLevel( int levelLoaded)
    {
        level = levelLoaded;
    }
}
