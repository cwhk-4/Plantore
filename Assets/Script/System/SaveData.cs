using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public float nowTime;
    public int mapLevel;

    public SaveData( PlayerData data )
    {
        nowTime = data.nowTime;
        mapLevel = data.mapLevel;
    }
}
