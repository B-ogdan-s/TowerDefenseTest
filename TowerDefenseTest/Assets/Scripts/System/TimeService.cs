using System;
using UnityEngine;
using Zenject;

public class TimeService : MonoBehaviour
{
    [SerializeField] private int[] _timeScalers;
    [Inject] private UI_Manager _uiManager;

    private bool _isPlaying = false;
    private int _index = 0;

    private Action<int> OnUpdate;

    public int Index
    {
        get { return _index; }
        private set 
        {
            _index = value;
            if (_index >= _timeScalers.Length)
                _index = 0;
            if (_index < 0)
                _index = _timeScalers.Length - 1;

            OnUpdate?.Invoke(_timeScalers[_index]);
        }
    }
    private void Start()
    {
        Game_UI ui = _uiManager.GetPanel<Game_UI>();
        ui.OnIncreaseSpeed += IncreaseSpeed;
        ui.OnReduceSpeed += ReduceSpeed;
        OnUpdate += ui.SetSpeed;
        ui.SetSpeed(_timeScalers[_index]);
    }

    private void IncreaseSpeed()
    {
        Index++;
        if (_isPlaying)
            UsePlaySpeed();
    }
    private void ReduceSpeed()
    {
        Index--;
        if (_isPlaying)
            UsePlaySpeed();
    }

    public void Pause()
    {
        _isPlaying = false;
        Time.timeScale = 0;
    }
    public void UseDefaultSpeed()
    {
        _isPlaying = false;
        Time.timeScale = 1;
    }
    public void UsePlaySpeed()
    {
        _isPlaying = true;
        Time.timeScale = _timeScalers[Index];
    }
    private void OnDestroy()
    {
        OnUpdate = null;
    }
}
