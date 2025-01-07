using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectLevelController : MonoBehaviour
{
    [SerializeField]
    private GameObject _mainMenuPanel;

    private Button[] _levelButtons;

    private async void Awake()
    {
        _levelButtons = transform.GetChild(0).GetComponentsInChildren<Button>();
        var tempData = await GameDataManager.GetData();

        for (int i = 0; i <= tempData.ColpletedLevels && i < _levelButtons.Length - 1; i++)
        {
            _levelButtons[i].interactable = true;
        }
    }

    public void LoadLevel(int level) => SceneManager.LoadScene(level);

    public void BackToMenu()
    {
        _mainMenuPanel.SetActive(true);
        gameObject.SetActive(false);
    }
}
