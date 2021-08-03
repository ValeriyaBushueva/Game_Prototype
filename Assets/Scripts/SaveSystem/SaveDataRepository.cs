using System.IO;
using RollBall;
using UnityEngine;

public sealed class SaveDataRepository 
{
    private readonly IData<SaveData> _data;

    private const string _folderName = "dataSave";
    private const string _fileName = "data.bat";
    private readonly string _path;

    public SaveDataRepository()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            _data = new XMLData();
        }
        else
        {
            _data = new JsonData<SaveData>();
        }
        _path = Path.Combine(Application.dataPath, _folderName);
        Debug.Log("SAVE");
    }

    public void Save(Player player)
    {
        if (!Directory.Exists(Path.Combine(_path)))
        {
            Directory.CreateDirectory(_path);
        }
        var savePlayer = new SaveData
        {
            Position = player.transform.position,
            Name = "Player"
        };

        _data.Save(savePlayer, Path.Combine(_path, _fileName));
    }

    public void Load(Player player)
    {
        var file = Path.Combine(_path, _fileName);
        if (!File.Exists(file)) return;
        var newPlayer = _data.Load(file);
        player.transform.position = newPlayer.Position;
        player.name = newPlayer.Name;

        Debug.Log(newPlayer);
    }
}



