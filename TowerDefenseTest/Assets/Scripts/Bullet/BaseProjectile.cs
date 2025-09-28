using UnityEngine;

public abstract class BaseProjectile : PoolObject
{
    [SerializeField] protected float _lifetime = 5f;

    protected int _damage;

    public virtual void Initialize(int damage)
    {
        _damage = damage;
    }
}
