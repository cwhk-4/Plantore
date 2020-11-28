using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLevel : MonoBehaviour
{
    [SerializeField]
    private int level = 1;

    public int getMapLevel()
    {
        return level;
    }

    public void loadMapLevel( int levelLoaded)
    {
        level = levelLoaded;
    }
}
