using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WaypointSystem;
using Zenject;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemySpawnerData _spawnerData;
    [SerializeField] private Waypoint _waypoint;
    [SerializeField] private float _spawnSpeed;

    [Inject] GameData_Wave _wave;

    private PoolHandler<Enemy> _poolHandler = new();
    private int _enemyCount;

    public System.Action<int> OnSetDamage;
    public System.Action<int> OnSetCoin;

    public System.Action OnClearAll;

    public void StartSpawnEnemy()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        int spawnCount = _spawnerData.GetEnemyCount(_wave.Wave);
        _enemyCount = spawnCount;
        int count = 0;
        float time = 1f / _spawnSpeed;

        while (count < spawnCount)
        {
            yield return new WaitForSeconds(time);

            EnemySpawnData enemySpawnData = _spawnerData.GetEnemySpawnData();
            Enemy enemy = _poolHandler.GetFreeObject(enemySpawnData.Prefab);

            EnemyData data = enemySpawnData.Data.ModifyData(_wave.Wave);

            enemy.OnFinish = OnSetDamage;
            enemy.OnAddCoin = OnSetCoin;
            enemy.OnDead = DeadEnemy;
            enemy.transform.position = _waypoint.transform.position;
            enemy.Initialize(data, _waypoint);

            count++;
        }
    }

    private void DeadEnemy(Enemy enemy)
    {
        enemy.OnDead = null;
        _enemyCount--;
        if (_enemyCount <= 0)
        {
            OnClearAll?.Invoke();
        }
    }
}
