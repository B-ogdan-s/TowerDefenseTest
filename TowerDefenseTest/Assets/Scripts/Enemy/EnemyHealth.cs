using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private int _hp;

    public int HP => _hp;

    public Action OnDead;

    public void SetData(int value)
    {
        _hp = value;
    }

    public void SetDamage(int value)
    {
        _hp -= value;

        if (_hp <= 0)
        {
            OnDead?.Invoke();
        }
    }
}
