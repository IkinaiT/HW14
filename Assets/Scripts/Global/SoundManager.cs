using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager
{
    public static void PlayMusic(AudioSource audio)
    {
        var temp = GameDataManager.GetData();

        if (temp.IsSoundsOn)
        {
            audio.volume = temp.SoundLevel;
            audio.Play();
        }
    }
}
