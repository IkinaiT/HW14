using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikedBallBehavoiur : MonoBehaviour
{
    [SerializeField]
    private PlayerBehaviour _playerBehaviour;
    [SerializeField]
    private Transform _point1;
    [SerializeField]
    private Transform _point2;
    [SerializeField, Range(0, 10)]
    private float _speed = 2.0f;

    private ParticleSystem _particleSystem;
    private bool _goToPoint1;

    private void Awake()
    {
        _particleSystem = GetComponentInChildren<ParticleSystem>();
    }

    private void Update()
    {
        var currentPoint = _goToPoint1 ? _point1 : _point2;

        transform.position = Vector3.MoveTowards(transform.position, currentPoint.position, _speed * Time.deltaTime);

        if (transform.position == currentPoint.position)
            _goToPoint1 = !_goToPoint1;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _playerBehaviour.Dead();
            _particleSystem.Play();
        }
    }
}
