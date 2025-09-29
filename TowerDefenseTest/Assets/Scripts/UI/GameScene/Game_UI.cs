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
    [SerializeField] private TextMeshProUGUI _speedText;

    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _startWavwButton;

    [SerializeField] private Button _increaseSpeedButton;
    [SerializeField] private Button _reduceSpeedButton;

    public Action OnPause;
    public Action OnStartWave;

    public Action OnIncreaseSpeed;
    public Action OnReduceSpeed;

    private void Awake()
    {
        _pauseButton.onClick.AddListener(() => OnPause?.Invoke());
        _startWavwButton.onClick.AddListener(() => OnStartWave?.Invoke());
        _increaseSpeedButton.onClick.AddListener(() => OnIncreaseSpeed?.Invoke());
        _reduceSpeedButton.onClick.AddListener(() => OnReduceSpeed?.Invoke());
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
    public void SetSpeed(int value)
    {
        _speedText.text = $"X: {value}";
    }

    public void OpenStartWave(bool value)
    {
        _startWavwButton.gameObject.SetActive(value);
    }

    private void OnDestroy()
    {
        _pauseButton.onClick.RemoveAllListeners();
        _startWavwButton.onClick.RemoveAllListeners();
        _increaseSpeedButton?.onClick.RemoveAllListeners();
        _reduceSpeedButton?.onClick.RemoveAllListeners();
    }
}
