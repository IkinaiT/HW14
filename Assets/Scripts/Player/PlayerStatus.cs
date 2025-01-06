using System;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    private int _health = 3;
    private PlayerSize _size;
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

    public void PumpUp() => _size = PlayerSize.Big;

    public void PumpDown() => _size = PlayerSize.Small;

    public PlayerSize GetSize() => _size;
}
