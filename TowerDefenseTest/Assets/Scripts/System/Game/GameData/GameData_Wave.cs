using UnityEngine;
using System;

public class GameData_Wave
{
    private int _wave = 0;
    public int Wave => _wave;

    public Action OnWaveChanged;

    public void AddWave()
    {
        _wave++;
        OnWaveChanged?.Invoke();
    }

    public void Save(string id)
    {
        int value = PlayerPrefs.GetInt($"{id}_record");

        if (_wave > value)
            PlayerPrefs.SetInt($"{id}_record", _wave);
        PlayerPrefs.SetInt($"{id}_last", _wave);
    }
}
