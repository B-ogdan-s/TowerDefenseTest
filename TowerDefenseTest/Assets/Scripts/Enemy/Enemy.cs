using System;
using UnityEngine;
using WaypointSystem;

public struct EnemyData
{
    public float Speed;
    public int Coins;
    public int Health;
    public int Damage;
}
public class Enemy : PoolObject
{
    [SerializeField] private WaypointAgent _waypointAgent;
    [SerializeField] private EnemyHealth _enemyHealth;

    public EnemyHealth EnemyHealth => _enemyHealth;

    private int _damage;
    private int _coin;

    private bool _isDead = false;

    public Action<int> OnFinish;
    public Action<int> OnAddCoin;
    public Action<Enemy> OnDead;


    public void Initialize(EnemyData data, Waypoint _waypoint)
    {
        _isDead = false;
        _waypointAgent.SetData(data.Speed, _waypoint);
        _enemyHealth.SetData(data.Health);
        _damage = data.Damage;
        _coin = data.Coins;
    }

    private void Awake()
    {
        _waypointAgent.OnFinish += () =>
        {
            DisableObject();
            OnFinish?.Invoke(_damage);
            OnDead?.Invoke(this);
        }; 

        _enemyHealth.OnDead += ()=>
        {
            if (_isDead)
                return;
            _isDead = true;

            DisableObject();
            OnAddCoin?.Invoke(_coin);
            OnDead?.Invoke(this);
        };
    }
    private void OnDestroy()
    {
        _waypointAgent.OnFinish = null;
        _enemyHealth.OnDead = null;
    }
}
