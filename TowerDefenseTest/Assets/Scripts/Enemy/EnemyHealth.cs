using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private EnemyHealthShow _show;
    private int _hp;

    public int HP => _hp;

    public Action OnDead;

	public void SetData(int value)
    {
        _hp = value;
        _show.Initialized(value);
    }

    public void SetDamage(int value)
    {
        _hp -= value;
        _show.UpdateData(_hp);

        if (_hp <= 0)
        {
            OnDead?.Invoke();
        }
    }
}
