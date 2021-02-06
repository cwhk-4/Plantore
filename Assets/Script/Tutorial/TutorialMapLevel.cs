using UnityEngine;

public class TutorialMapLevel : MonoBehaviour
{
    [SerializeField] private int level = 1;

    public int getMapLevel( )
    {
        return level;
    }

    public void setMapLevel( int input )
    {
        level = input;
    }

    public void loadMapLevel( int levelLoaded )
    {
        level = levelLoaded;
    }
}
