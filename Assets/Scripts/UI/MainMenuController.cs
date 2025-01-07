using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private Button _continueButton;
    [SerializeField]
    private GameObject _mainMenuPanel;
    [SerializeField]
    private GameObject _selectLevelPanel;
    [SerializeField]
    private GameObject _parametersPanel;
    

    private async void Start()
    {
        SaveData saveData = await GameDataManager.GetData();

        

        if(saveData.ColpletedLevels > 0)
        {
            _continueButton.interactable = true;
        }
    }

    public async void Continue() => SceneManager.LoadScene((await GameDataManager.GetData()).ColpletedLevels + 1);

    public void NewGame() => SceneManager.LoadScene(1);

    public void SelectLevel()
    {
        _selectLevelPanel.SetActive(true);
        _mainMenuPanel.SetActive(false);
    }

    public void Parameters()
    {
        _parametersPanel.SetActive(true);
        _mainMenuPanel.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
