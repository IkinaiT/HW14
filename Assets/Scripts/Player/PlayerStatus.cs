using System;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField, Range(1, 3)]
    private float _bigSizeScale = 1.5f;

    private int _health = 3;
    private PlayerSize _size;
    private PlayerSize _lastSize;
    public Action<int> OnHealthChanged;

    public void AddHealth()
    {
        _health++;
        OnHealthChanged?.Invoke(_health);
    }

    public void DecraseHealth()
    {
        _health--;
        OnHealthChanged?.Invoke(_health);
    }

    public int GetHealth() => _health;

    public void PumpUp()
    {
        _size = PlayerSize.Big;
        transform.localScale = Vector3.one * _bigSizeScale;
    }

    public void PumpDown()
    {
        _size = PlayerSize.Small;
        transform.localScale = Vector3.one;
    }

    public void SetLastSize() => _lastSize = _size;

    public void ConfirmLastSize()
    {
        if(_lastSize != _size)
        {
            if (_lastSize == PlayerSize.Small)
                PumpDown();
            else
                PumpUp();
        }
    }

    public PlayerSize GetSize() => _size;
}
