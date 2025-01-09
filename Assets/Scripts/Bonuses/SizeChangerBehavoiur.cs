using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeChangerBehavoiur : MonoBehaviour
{
    [SerializeField]
    private SizeChangerType _type;
    [SerializeField]
    private PlayerStatus _playerStatus;

    private Action OnCollision;

    private void Awake() => OnCollision += _type == SizeChangerType.SizeUp ? SizeUp : SizeDown;

    private void SizeUp() => _playerStatus.PumpUp();

    private void SizeDown() => _playerStatus.PumpDown();

    private void OnCollisionEnter(Collision collision) => OnCollision?.Invoke();
}

public enum SizeChangerType
{
    SizeUp,
    SizeDown
}
