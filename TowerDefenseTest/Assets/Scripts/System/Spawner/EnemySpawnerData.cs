using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySpawnerData", menuName = "Data/EnemySpawnerData")]
public class EnemySpawnerData : ScriptableObject
{
	[SerializeField] private UpdatableParameter _enemyUpdateCount;
	[SerializeField] List<EnemySpawnData> _enemies;

	public int GetEnemyCount(int value)
	{
		return _enemyUpdateCount.GetIntValue(value);
	}

	public EnemySpawnData GetEnemySpawnData()
	{
		return _enemies[Random.Range(0, _enemies.Count)];
	}

}
