using System;
using UnityEngine;
using UnityEngine.UI;

public class Pause_UI : UI_Panel
{
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;

    public Action OnContinue;
    public Action OnRestart;
    public Action OnExit;

    public void Awake()
    {
        _continueButton.onClick.AddListener(() => OnContinue?.Invoke());
        _restartButton.onClick.AddListener(() => OnRestart?.Invoke());
        _exitButton.onClick.AddListener(() => OnExit?.Invoke());
    }
}
