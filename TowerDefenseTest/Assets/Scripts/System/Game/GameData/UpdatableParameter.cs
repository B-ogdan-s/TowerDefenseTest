using System;
using UnityEngine;

[Serializable]
public class UpdatableParameter
{
    [SerializeField] private float _baseValue;
    [SerializeField] private float _firstStep;

    [SerializeField] private MaxParameter[] _maxParameters;


    public int GetIntValue(int level)
    {
        return (int)CalculateValue(level);
    }
    public float GetFloatValue(int level)
    {
        return CalculateValue(level);
    }

    private float CalculateValue(int level)
    {
        if (level == 0)
            return _baseValue;

        float delta= GetDelta(level, _baseValue);

        float value = _firstStep + CalculateValue(level-1) * delta;
        return value;
    }

    private float GetDelta(int level, float baseValue)
    {
        if (_maxParameters[0].MaxStep >= baseValue || _maxParameters.Length == 1)
        {
            return (_maxParameters[0].MaxValue - baseValue) / (_maxParameters[0].MaxStep - 1);
        }

        for (int i = 1; i < _maxParameters.Length; i++)
        {
            if (_maxParameters[i].MaxStep >= baseValue)
            {
                return (_maxParameters[i].MaxValue - _maxParameters[i-1].MaxValue) / 
                    (_maxParameters[i].MaxStep - _maxParameters[i-1].MaxStep);
            }
        }
        int index = _maxParameters.Length - 1;

        return (_maxParameters[index].MaxValue - _maxParameters[index - 1].MaxValue) /
            (_maxParameters[index].MaxStep - _maxParameters[index - 1].MaxStep);

    }
}

[Serializable]
public class MaxParameter
{
    [SerializeField] private float _maxVelue;
    [SerializeField] private float _maxStep;

    public float MaxValue => _maxVelue;
    public float MaxStep => _maxStep;
}
