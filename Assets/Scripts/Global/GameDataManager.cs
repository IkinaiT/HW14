using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

public class GameDataManager : MonoBehaviour 
{
    private async void Awake()
    {
        await GetOrLoadData();

        DontDestroyOnLoad(gameObject);
    }

    public static SaveData GetData()
    {
        var saveData = GetSaveDataFromPlayerPrefs();


        return saveData;
    }

    public static void ChangeData(float soundLevel, bool soundState)
    {
        var saveData = GetSaveDataFromPlayerPrefs();

        saveData.SoundLevel = soundLevel;
        saveData.IsSoundsOn = soundState;

        Save(saveData);

        SetPlayerPrefsFromSaveData(saveData);
    }

    public static void ChangeData(int completedLevel)
    {
        var saveData = GetSaveDataFromPlayerPrefs();

        saveData.CompletedLevels = completedLevel;

        Save(saveData);
    }

    private static void Save(SaveData saveData)
    {
        using (StreamWriter sw = new(Application.persistentDataPath + "/Save1.sv"))
        {
            var temp = JsonUtility.ToJson(saveData);

            sw.WriteLine(temp);
        }
    }

    private static async Task GetOrLoadData()
    {
        var saveData = new SaveData();

        if (File.Exists(Application.persistentDataPath + "/Save1.sv"))
        {
            using (StreamReader sr = new(Application.persistentDataPath + "/Save1.sv"))
            {
                var temp = await sr.ReadToEndAsync();

                if (!string.IsNullOrEmpty(temp))
                    saveData = JsonUtility.FromJson<SaveData>(temp);

                PlayerPrefs.SetFloat(GlobalStringVars.SoundLevel, saveData.SoundLevel);
                PlayerPrefs.SetInt(GlobalStringVars.CompletedLevels, saveData.CompletedLevels);
                PlayerPrefs.SetString(GlobalStringVars.IsSoundsOn, saveData.IsSoundsOn.ToString());
            }
        }
        else
        {
            using (StreamWriter sw = new(Application.persistentDataPath + "/Save1.sv"))
            {
                var temp = JsonUtility.ToJson(saveData);

                sw.WriteLine(temp);
            }
        }

        SetPlayerPrefsFromSaveData(saveData);
    }

    private static SaveData GetSaveDataFromPlayerPrefs()
    {
        return new SaveData
        {
            CompletedLevels = PlayerPrefs.GetInt(GlobalStringVars.CompletedLevels),
            IsSoundsOn = PlayerPrefs.GetString(GlobalStringVars.IsSoundsOn).ToLower() == "true",
            SoundLevel = PlayerPrefs.GetFloat(GlobalStringVars.SoundLevel)
        };
    }

    private static void SetPlayerPrefsFromSaveData(SaveData saveData)
    {
        PlayerPrefs.SetFloat(GlobalStringVars.SoundLevel, saveData.SoundLevel);
        PlayerPrefs.SetInt(GlobalStringVars.CompletedLevels, saveData.CompletedLevels);
        PlayerPrefs.SetString(GlobalStringVars.IsSoundsOn, saveData.IsSoundsOn.ToString());
    }
}
