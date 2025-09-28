using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TowerHandler : MonoBehaviour
{
    [SerializeField] private PlatformForTower _platformPrefab;
    [SerializeField] private Transform[] _spawnPositions;

    [Inject] private UI_Manager _uiManager;
    [Inject] private GameData_Coin _coin;

    private List<PlatformForTower> _platforms = new List<PlatformForTower>();

    private Action<PlatformForTower> OnTowerTouch;

    private void Awake()
    {
        foreach (var position in _spawnPositions)
        {
            PlatformForTower platform = Instantiate(_platformPrefab, position.position, Quaternion.identity);
            platform.OnPlatformTouch += (platform) => OnTowerTouch?.Invoke(platform);
            _platforms.Add(platform);
        }
    }

    public void ChangeActionType(bool value) 
    {
        if (value)
        {
            OnTowerTouch = InteractWithPlatform;
            UpdateShowAction(true);
            ActivateTower(false);
        }
        else
        {
            OnTowerTouch = null;
            UpdateShowAction(false);
            ActivateTower(true);
        }
    }

    private void UpdateShowAction(bool value)
    {
        foreach (var platform in _platforms)
        {
            platform.ShowAction(value, _coin.Coins);
        }
    }

    private void ActivateTower(bool value)
    {
        foreach(var platform in _platforms)
        {
            platform.ActivateTower(value);
        }
    }

    private void InteractWithPlatform(PlatformForTower platform)
    {
        if (platform.Tower == null)
        {
            BuyNewTower(platform);
            return;
        }

        Tower tower = platform.Tower;

        if(tower.GetCost() <= _coin.Coins)
        {
            _coin.RemoveCoins(tower.GetCost());
            tower.LevelUp();
            UpdateShowAction(true);
        }
    }

    private void BuyNewTower(PlatformForTower platform)
    {
        var panel = _uiManager.OpenPanel<TowerSelector_UI>();
        panel.OnTowerSelected = (prefab, data) =>
        {
            platform.SpawnTower(prefab, data);
            _uiManager.OpenPanel<Game_UI>();
            UpdateShowAction(true);
        };
        panel.OnClose = () =>
        {
            _uiManager.OpenPanel<Game_UI>();
        };
    }
}
