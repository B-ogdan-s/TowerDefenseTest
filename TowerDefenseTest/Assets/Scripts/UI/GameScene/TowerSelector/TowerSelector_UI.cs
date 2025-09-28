using System;
using TMPro;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerSelector_UI : UI_Panel
{
    [SerializeField] private TowerSelectorPanel _panelPrefab;
    [SerializeField] private TowerSelectorData[] _towersData;
    [SerializeField] private Transform _contentTransform;
    [SerializeField] private TextMeshProUGUI _coinText;
    [SerializeField] private Button _closeButton;

    private List<TowerSelectorPanel> _panels = new();
    
    public Action<Tower, TowerUpdatableData> OnTowerSelected;
    public Action<int> OnBuy;
    public Action OnClose;

    private int _currentCoin;

    private void Awake()
    {
        foreach (var towerData in _towersData)
        {
            var panel = Instantiate(_panelPrefab, _contentTransform);
            panel.SetData(towerData, (data) => 
            { 
                OnTowerSelected?.Invoke(data.TowerPrefab, data.TowerData); 
                OnBuy?.Invoke(data.Price);
            });

            _panels.Add(panel);
        }
        _closeButton.onClick.AddListener(() => OnClose?.Invoke());
    }

    public void SetCoin(int coin)
    {
        _currentCoin = coin;
        _coinText.text = $"Coin: {coin.ToString()}";
    }

    public override void SetActive(bool value)
    {
        base.SetActive(value);

        if (value)
        {
            for (int i = 0; i < _towersData.Length; i++)
            {
                _panels[i].SetActive(_towersData[i].Price <= _currentCoin);
            }
        }
    }

    private void OnDestroy()
    {
        OnTowerSelected = null;
        OnClose = null;
    }
}
