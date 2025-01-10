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

    private void Awake()
    {
        _levelButtons = transform.GetChild(0).GetComponentsInChildren<Button>();
        var tempData = GameDataManager.GetData();

        for (int i = 0; i <= tempData.CompletedLevels && i < _levelButtons.Length - 1; i++)
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
