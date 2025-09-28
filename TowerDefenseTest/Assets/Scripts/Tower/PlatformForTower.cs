using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlatformForTower : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private GameObject _addPanel;

    private Tower _tower;
    public Tower Tower => _tower;

    public Action<PlatformForTower> OnPlatformTouch;

    private void Awake()
    {
        _addPanel.SetActive(false);
    }

    public void SpawnTower(Tower tower,  TowerUpdatableData data)
    {
        _tower = Instantiate(tower, _spawnPosition.position, Quaternion.identity, _spawnPosition);
        _tower.InitializedData(data);
        _addPanel.SetActive(false);

    }

    public void ActivateTower(bool value)
    {
        _tower?.Activate(value);
    }

    public void ShowAction(bool value, int coin)
    {
        if (_tower == null)
        {
            _addPanel.SetActive(value);
            return;
        }

        _addPanel.SetActive(false);

        _tower.ShowPanel(value, coin);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnPlatformTouch?.Invoke(this);
    }
}
