using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParametersController : MonoBehaviour
{
    [SerializeField]
    private GameObject _mainMenuPanel;
    [SerializeField]
    private Slider _volumeSlider;
    [SerializeField]
    private Toggle _volumeToggle;

    private float _volumeLevel;
    private bool _isOnSounds;

    private async void Awake()
    {
        var saveData = await GameDataManager.GetData();

        _volumeSlider.value = saveData.SoundLevel;
        _volumeToggle.isOn = saveData.IsSoundsOn;
        _isOnSounds = saveData.IsSoundsOn;
        _volumeLevel = saveData.SoundLevel;

        _volumeSlider.onValueChanged.AddListener(SetVolume);
        _volumeToggle.onValueChanged.AddListener(ToggleSounds);
    }

    public void SetVolume(float volume) => _volumeLevel = volume;

    public void ToggleSounds(bool toggle) => _isOnSounds = toggle;

    public void Save()
    {
        GameDataManager.ChangeData(_volumeLevel, _isOnSounds);

        BackToMenu();
    }

    public async void Cancel()
    {
        var saveData = await GameDataManager.GetData();

        _volumeSlider.value = saveData.SoundLevel;
        _volumeToggle.isOn = saveData.IsSoundsOn;

        BackToMenu();
    }

    public void BackToMenu()
    {
        _mainMenuPanel.SetActive(true);
        gameObject.SetActive(false);
    }
}
