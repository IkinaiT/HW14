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

    private PlayerStatus _playerStatus;
    private GameObject _player;

    private void Awake()
    {
        transform.position = _respawnPoint.position;
        _player = GetComponentsInChildren<Transform>().First(_ => _.name == "PlayerObject").gameObject;
        _playerStatus = _player.GetComponent<PlayerStatus>();
    }

    public void Dead()
    {
        SoundManager.PlayMusic(GetComponent<AudioSource>());
        _playerStatus.DecraseHealth();
        _player.SetActive(false);
        StartCoroutine(OnDeadCoroutine());
    }

    private IEnumerator OnDeadCoroutine()
    {
        yield return new WaitForSeconds(2);

        if (_playerStatus.GetHealth() < 0)
        {
            Instantiate(_gameOverPanel);
        }
        else
        {
            _player.transform.position = _respawnPoint.position;
            _player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            _player.SetActive(true);
        }

    }
}
