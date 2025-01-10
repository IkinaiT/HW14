using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    private Transform _respawnPoint;
    [SerializeField]
    private GameObject _gameOverPanel;
    [SerializeField]
    private GameObject _playerObject;
    [SerializeField, Range(1, 10)]
    private float _respawnTime = 2;

    private PlayerStatus _playerStatus;

    private void Awake()
    {
        _playerStatus = _playerObject.GetComponent<PlayerStatus>();

        _playerObject.transform.position = _respawnPoint.position;
    }

    public void Dead()
    {
        SoundManager.PlayMusic(GetComponent<AudioSource>());
        _playerStatus.DecraseHealth();
        _playerObject.SetActive(false);
        StartCoroutine(OnDeadCoroutine());
    }

    private IEnumerator OnDeadCoroutine()
    {
        yield return new WaitForSeconds(_respawnTime);

        if (_playerStatus.GetHealth() < 0)
        {
            Instantiate(_gameOverPanel);
        }
        else
        {
            _playerStatus.ConfirmLastSize();
            _playerObject.transform.position = _respawnPoint.position;
            _playerObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            _playerObject.SetActive(true);
        }

    }
}
