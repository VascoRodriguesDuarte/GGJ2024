using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem 
{
    public static void SavePlayer( GameManager gm)
    {
        BinaryFormatter formater = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.granny";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(gm);

        formater.Serialize(stream, data);

        stream.Close();
    }

    public static void SaveScoreboard(GameManager gm)
    {
        BinaryFormatter formater = new BinaryFormatter();
        string path = Application.persistentDataPath + "/scoreBoard.granny";
        FileStream stream = new FileStream(path, FileMode.Create);

        LeaderBoardData data = new LeaderBoardData(gm);

        formater.Serialize(stream, data);

        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.granny";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
                
        }
        else
        {
            Debug.LogError("Saven file not found in " + path);
            return null;
        }
    }

    public static LeaderBoardData LoadScoreboard()
    {
        string path = Application.persistentDataPath + "/scoreBoard.granny";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            LeaderBoardData data = formatter.Deserialize(stream) as LeaderBoardData;
            stream.Close();

            return data;

        }
        else
        {
            Debug.LogError("Saven file not found in " + path);
            return null;
        }
    }
}
