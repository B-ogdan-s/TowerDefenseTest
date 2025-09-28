using System;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySpawnData", menuName = "Data/EnemySpawnData")]
public class EnemySpawnData : ScriptableObject
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] EnemyUpdatableData _data;
    public Enemy Prefab => _prefab;
    public EnemyUpdatableData Data => _data;
}
[Serializable]
public struct EnemyUpdatableData
{
    [SerializeField] private UpdatableParameter _speed;
    [SerializeField] private UpdatableParameter _coins;
    [SerializeField] private UpdatableParameter _health;
    [SerializeField] private UpdatableParameter _damage;

    public EnemyData ModifyData(int level)
    {
        EnemyData data = new EnemyData();
        data.Speed = _speed.GetFloatValue(level);
        data.Coins = _coins.GetIntValue(level);
        data.Health = _health.GetIntValue(level);
        data.Damage = _damage.GetIntValue(level);
        return data;
    }
}
