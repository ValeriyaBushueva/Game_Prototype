using System.Collections.Generic;
using System.IO;
using System.Linq;
using RollBall;
using SaveSystem;
using UnityEngine;
using UnityEngine.UIElements;

public sealed class SaveDataRepository 
{
    private readonly IData<List<SaveData>> _data;

    private const string _folderName = "dataSave";
    private const string _fileName = "data.bat";
    private readonly string _path;

    public SaveDataRepository()
    {
        _data = new JsonData<List<SaveData>>();
        _path = Path.Combine(Application.dataPath, _folderName);
        Debug.Log("SAVE");
    }

    public void Save(Player player, BonusMark[] bonuses)
    {
        if (!Directory.Exists(Path.Combine(_path)))
        {
            Directory.CreateDirectory(_path);
        }
        List<SaveData> dataSave = new List<SaveData>();

        var savePlayer = new SaveData
        {
            Position = player.transform.position,
            Name = "Player"
        };

        dataSave.Add(savePlayer);
       
        foreach (var bonusMark in bonuses)
        {
            var saveBonuses = new SaveData
            {
                Position = bonusMark.transform.position,
                Name = "Bonus" + bonusMark.BonusName
            };
            
            dataSave.Add(saveBonuses);
        }
        
        _data.Save(dataSave, Path.Combine(_path, _fileName));
    }

    public void Load(Player player)
    {
        var file = Path.Combine(_path, _fileName);
        if (!File.Exists(file)) return;
        List<SaveData> dataSave = _data.Load(file);

        SaveData playerData = dataSave.First(data => data.Name == "Player");

        player.transform.position = playerData.Position;
        player.name = playerData.Name;

        BonusPrefabHub prefabHub = Object.FindObjectOfType<BonusPrefabHub>();

        
        BonusMark[] toDestroyAllBonusBeforeLoad = Object.FindObjectsOfType<BonusMark>();
        
        
        foreach (BonusMark bonusMark in toDestroyAllBonusBeforeLoad)
        {
            Object.Destroy(bonusMark.gameObject);
        }
        

        foreach (SaveData saveData in dataSave.Where(x => x.Name.StartsWith("Bonus")))
        {
            string bonusName = saveData.Name.Replace("Bonus", "");

            GameObject bonusPrefab = prefabHub.GetBonusPrefab(bonusName);

            Object.Instantiate(bonusPrefab, saveData.Position, Quaternion.identity);
        }
        
    }
}



