using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class MapSelector_UI : UI_Panel
{
    [SerializeField] private Button _closeButton;
    [SerializeField] private MapData[] _maps;
    [SerializeField] private MapSelectorPanel _panelPrefab;
    [SerializeField] private Transform _contant;

    private List<MapSelectorPanel> _panels = new();

    public Action<string> OnClick;
    public Action OnClose;

    private void Awake()
    {
        _closeButton.onClick.AddListener(() => OnClose?.Invoke());

        foreach(var map in _maps)
        {
            MapSelectorPanel panel = Instantiate(_panelPrefab, _contant);
            panel.SetMapData(map);
            panel.OnClick += (value) => 
            {
                OnClick?.Invoke(value); 
            };
            _panels.Add(panel);
        }
    }

    private void OnDestroy()
    {
        foreach(var panel in _panels)
        {
            panel.OnClick -= OnClick;
        }
    }
}
