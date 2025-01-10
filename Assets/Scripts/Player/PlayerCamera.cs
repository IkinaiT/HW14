using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField]
    private Transform _player;
    [SerializeField, Range(0.1f, 3f)]
    private float _cameraSpeed = 0.5f;

    private void Awake()
    {
        transform.position = new Vector3(6.75f, _player.position.y, _player.position.z);
    }

    private void FixedUpdate()
    {
        transform.LookAt(_player.position);

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(6.75f, _player.position.y, _player.position.z), _cameraSpeed);
    }
}
