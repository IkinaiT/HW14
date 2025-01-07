using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;

    public static SoundManager Instance
    {
        get
        {
            if (_instance != null)
            {
                return _instance;
            }

            // Do not modify _instance here. It will be assigned in awake
            return new GameObject("(singleton) SoundManager").AddComponent<SoundManager>();
        }
    }

    void Awake()
    {
        // Only one instance of SoundManager at a time!
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public static async void PlayMusic(AudioSource audio)
    {
        var temp = await GameDataManager.GetData();

        if (temp.IsSoundsOn)
        {
            audio.volume = temp.SoundLevel;
            audio.Play();
        }
    }
}
