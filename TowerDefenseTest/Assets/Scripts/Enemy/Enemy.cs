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

    public Action<int> OnFinish;
    public Action<int> OnAddCoin;
    public Action OnDead;


    public void Initialize(EnemyData data, Waypoint _waypoint)
    {
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
            OnDead?.Invoke();
        }; 

        _enemyHealth.OnDead += ()=>
        {
            DisableObject();
            OnAddCoin?.Invoke(_coin);
            OnDead?.Invoke();
        };
    }
    private void OnDestroy()
    {
        _waypointAgent.OnFinish = null;
        _enemyHealth.OnDead = null;
    }
}
