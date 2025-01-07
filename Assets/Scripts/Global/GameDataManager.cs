using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

public class GameDataManager : MonoBehaviour 
{
    private static GameDataManager _instance;
    private static SaveData _saveData;

    public static GameDataManager Instance
    {
        get
        {
            if(_instance != null)
                return _instance;

            return new GameObject("(singleton) GameDataManager").AddComponent<GameDataManager>();
        }
    }

    private async void Awake()
    {
        await GetOrLoadData();

        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public static async Task<SaveData> GetData()
    {
        if (_saveData == null)
            await GetOrLoadData();

        return _saveData;
    }

    public static void ChangeData(float soundLevel, bool soundState)
    {
        _saveData.SoundLevel = soundLevel;
        _saveData.IsSoundsOn = soundState;

        Save();
    }

    public static void ChangeData(int complitedLevel)
    {
        _saveData.ColpletedLevels = complitedLevel;

        Save();
    }

    private static void Save()
    {
        using (StreamWriter sw = new(Application.persistentDataPath + "/Save1.sv"))
        {
            var temp = JsonUtility.ToJson(_saveData);

            sw.WriteLine(temp);
        }
    }
    private static async Task GetOrLoadData()
    {
        if (File.Exists(Application.persistentDataPath + "/Save1.sv"))
        {
            using (StreamReader sr = new(Application.persistentDataPath + "/Save1.sv"))
            {
                try
                {
                    var temp = await sr.ReadToEndAsync();

                    if (!string.IsNullOrEmpty(temp))
                        _saveData = JsonUtility.FromJson<SaveData>(temp);
                    else
                        _saveData = new();
                }
                catch (Exception ex)
                {

                }
            }
        }
        else
        {
            _saveData = new();

            using (StreamWriter sw = new(Application.persistentDataPath + "/Save1.sv"))
            {
                var temp = JsonUtility.ToJson(_saveData);

                sw.WriteLine(temp);
            }
        }
    }
}
