using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu_UI : UI_Panel
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _exitButton;

    public Action OnStart;
    public Action OnSettings;
    public Action OnExit;

    private void Awake()
    {
        _startButton.onClick.AddListener(() => OnStart?.Invoke());
        _settingsButton.onClick.AddListener(() => OnSettings?.Invoke());
        _exitButton.onClick.AddListener(() => OnExit?.Invoke());
    }
}
