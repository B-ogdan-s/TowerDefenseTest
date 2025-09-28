using System;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private UI_Panel[] _uiPanels;
    private Type _currentPanel;

    Dictionary<Type, UI_Panel> _convertPanels = new();

    private void Awake()
    {
        foreach (var panel in _uiPanels)
        {
            panel.gameObject.SetActive(false);
            _convertPanels.Add(panel.GetType(), panel);
        }
    }

    public T GetPanel<T>() where T : UI_Panel
    {
        return _convertPanels[typeof(T)] as T;
    }

    public T OpenPanel<T>() where T : UI_Panel
    {
        if(_currentPanel == typeof(T))
        {
            return _convertPanels[typeof(T)] as T;
        }

        if (_currentPanel != null)
        {
            _convertPanels[_currentPanel].SetActive(false);
        }
        _convertPanels[typeof(T)].SetActive(true);
        _currentPanel = typeof(T);

        return _convertPanels[typeof(T)] as T;
    }
}
