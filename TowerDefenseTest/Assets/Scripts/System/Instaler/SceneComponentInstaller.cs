using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SceneComponentInstaller : MonoInstaller
{
    [SerializeField] private GameHandler _gameHandler;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private TowerHandler _towerHandler;
    [SerializeField] private UI_Manager _uiManager;
    public override void InstallBindings()
    {
        Container.BindInstances(_gameHandler);
        Container.BindInstances(_enemySpawner);
        Container.BindInstances(_towerHandler);
        Container.BindInstances(_uiManager);
    }
}