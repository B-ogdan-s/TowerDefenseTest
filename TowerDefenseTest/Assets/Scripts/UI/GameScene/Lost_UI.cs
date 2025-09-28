using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Lost_UI : UI_Panel
{
    [SerializeField] private TextMeshProUGUI _waveText;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;

    public Action OnRestart;
    public Action OnExit;

    public void Awake()
    {
        _restartButton.onClick.AddListener(() => OnRestart?.Invoke());
        _exitButton.onClick.AddListener(() => OnExit?.Invoke());
    }

    public void SetWave(int wave)
    {
        _waveText.text = $"You reached wave {wave}";
    }
}
