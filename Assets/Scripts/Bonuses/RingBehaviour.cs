using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingBehaviour : MonoBehaviour
{
    [SerializeField]
    private PlayerStatus _playerStatus;
    [SerializeField]
    private bool _isBigRing;
    [SerializeField]
    private Material _collectedMaterial;
    [SerializeField]
    private RingController _ringController;

    private bool _isCollected;
    private MeshRenderer _parrentMeshRenderer;
    private AudioSource _audioSource;

    private void Awake()
    {
        _parrentMeshRenderer = gameObject.transform.parent.GetComponent<MeshRenderer>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (!_isCollected && other.gameObject.tag == "Player")
        {
            if (!_isBigRing && _playerStatus.GetSize() == PlayerSize.Small || _isBigRing)
            {
                _ringController.RingCollected();

                _parrentMeshRenderer.material = _collectedMaterial;

                _audioSource.Play();

                _isCollected = true;
            }
        }
    }
}
