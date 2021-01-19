using UnityEngine;

public class MapLevel : MonoBehaviour
{
    [SerializeField] private int level = 1;

    [SerializeField] private MissionTextDisplay MissionText;

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
    }

    public void loadMapLevel( int levelLoaded)
    {
        level = levelLoaded;
    }
}
