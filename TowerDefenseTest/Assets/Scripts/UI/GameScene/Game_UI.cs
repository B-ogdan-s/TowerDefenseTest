using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Game_UI : UI_Panel
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private TextMeshProUGUI _coinText;
    [SerializeField] private TextMeshProUGUI _waveText;

    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _startWavwButton;

    public Action OnPause;
    public Action OnStartWave;

    private void Awake()
    {
        _pauseButton.onClick.AddListener(() => OnPause?.Invoke());
        _startWavwButton.onClick.AddListener(() => OnStartWave?.Invoke());
    }

    public void SetHealth(int maxHP, int currentHP)
    {
        _healthBar.value = (float)currentHP / (float)maxHP;
        _healthText.text = currentHP + "/" + maxHP;
    }
    public void SetCoin(int coin)
    {
        _coinText.text = $"Coin: {coin.ToString()}";
    }
    public void SetWave(int value)
    {
        _waveText.text = $"Wave: {value}";
    }

    public void OpenStartWave(bool value)
    {
        _startWavwButton.gameObject.SetActive(value);
    }
}
