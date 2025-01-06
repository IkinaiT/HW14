using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Range(0, 10)]
    private float _speed = 10.0f;
    [SerializeField, Range(0, 30)]
    private float _jumpPower = 10.0f;

    private Rigidbody _playerRB;
    private bool _canJump = false;


    private void Awake() => _playerRB = GetComponent<Rigidbody>();

    public void MoveCharacter(Vector3 movement) => _playerRB.AddForce(movement * _speed);

    public void Jump(bool jump)
    {
        if (jump && _canJump)
        {
            _playerRB.AddForce(new(0, _jumpPower, 0), ForceMode.Impulse);
            _canJump = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Floor")
            _canJump = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Floor")
            _canJump = false;
    }

#if UNITY_EDITOR
    [ContextMenu("Reset values")]
        public void ResetValues()
        {
            _speed = 10.0f;
            _jumpPower = 10f;
        }
    #endif
}
