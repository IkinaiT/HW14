using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIContriller : MonoBehaviour, IDisposable
{
    [SerializeField]
    private PlayerStatus _playerStatus;
    [SerializeField]
    private RingController _ringController;

    [SerializeField]
    private GameObject _ringsPanel;
    [SerializeField]
    private GameObject _healthPanel;

    [SerializeField]
    private Sprite _ringsSprite;
    [SerializeField]
    private Sprite _healthSprite;

    [SerializeField]
    private GameObject _pausePanel;

    private int _health;
    private int _ringsCount;


    private void Awake()
    {
        _ringsCount = _ringController.transform.childCount;

        _playerStatus.OnHealthChanged += _ =>
        {
            if(_health < _)
            { 
                AddHealth(); 
            }
            else
            {
                if(_health > 0)
                    Destroy(_healthPanel.transform.GetChild(_health - 1).gameObject);
            }

            _health = _;
        };
        _ringController.OnRingCollected += () =>
        {

            if(_ringsCount > 0)
                Destroy(_ringsPanel.transform.GetChild(_ringsCount - 1).gameObject);

            _ringsCount--;
        };

        _health = _playerStatus.GetHealth();

        for(int i = 0; i < _ringsCount; i++)
        {
            GameObject spr = new();
            Image newImg = spr.AddComponent<Image>();
            newImg.sprite = _ringsSprite;
            var rectTrans = spr.GetComponent<RectTransform>();
            rectTrans.SetParent(_ringsPanel.transform);
            rectTrans.localScale = Vector3.one;
            spr.SetActive(true);

            //rectTrans.anchorMin = new(0, 0.5f);
            //rectTrans.anchorMax = new(0, 0.5f);
            //rectTrans.pivot = new(0.5f, 0.5f);
        }

        for(int i = 0; i < _health; i++)
        {
            AddHealth();
        }
    }

    private void AddHealth()
    {
        GameObject spr = new();
        Image newImg = spr.AddComponent<Image>();
        newImg.sprite = _healthSprite;
        var rectTrans = spr.GetComponent<RectTransform>();
        rectTrans.SetParent(_healthPanel.transform);
        rectTrans.localScale = Vector3.one;
        spr.SetActive(true);
    }

    public void OnClickPauseButton()
    {
        Time.timeScale = 0;

        _pausePanel.SetActive(true);
    }

    public void OnClickResumeButton()
    {
        Time.timeScale = 1;

        _pausePanel.SetActive(false);
    }

    public void OnClickMainMenuButton()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(0);
    }

    public void Dispose()
    {
        _playerStatus.OnHealthChanged -= _ => _health = _;
        _ringController.OnRingCollected -= () => _ringsCount--;
    }
}
