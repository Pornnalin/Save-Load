using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    [SerializeField] private Data _data = new Data();
    [HideInInspector]
    [SerializeField] private List<PlayerData> _playerDatas;
    public DataSO dataSO;

    [ContextMenu("Save")]
    public void SaveJson()
    {
        string potion = JsonUtility.ToJson(_data);
        string path = Application.dataPath + "/Json/PlayerData.txt";
        File.WriteAllText(path, potion);

        Debug.Log("save");

        
    }

    [ContextMenu("Load")]
    public void LoadJson()
    {
        string loadFile = Application.dataPath + "/Json/PlayerData.txt";
        string fileContents = File.ReadAllText(loadFile);
        Data dataFile = JsonUtility.FromJson<Data>(fileContents);
        //reste old data
        _playerDatas = new List<PlayerData>();        
        //add new data
        _data.playerDatas = dataFile.playerDatas;
        dataSO.data.playerDatas = dataFile.playerDatas;
     

        Debug.Log("Laod");
    }
}
[System.Serializable]
public class Data
{
    public List<PlayerData> playerDatas = new List<PlayerData>();

}

[System.Serializable]
public class PlayerData
{
    public string ID;
    public int coin;

}
