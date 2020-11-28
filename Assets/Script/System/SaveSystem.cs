using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

// >>json
public static class SaveSystem
{
    public static void savePlayer( PlayerData player )
    {
        BinaryFormatter formatter = new BinaryFormatter( );

        string path = Application.persistentDataPath + "/player.data";
        FileStream stream = new FileStream( path, FileMode.Create );

        SaveData data = new SaveData( player );

        formatter.Serialize( stream, data );
        stream.Close( );
    }

    public static SaveData loadPlayer( )
    {
        string path = Application.persistentDataPath + "/player.data";
        if( File.Exists( path ) )
        {
            BinaryFormatter formatter = new BinaryFormatter( );
            FileStream stream = new FileStream( path, FileMode.Open );

            SaveData data = formatter.Deserialize( stream ) as SaveData;
            stream.Close( );

            return data;
        }
        else
        {
            Debug.LogError( "Not Found " + path );
            return null;
        }
    }

}
