using System;
using UnityEngine;

[Serializable]
public class UpdatableParameter
{
    [SerializeField] private float _baseValue;
    [SerializeField] private float _firstStep;

    [SerializeField] private float _maxVelue;
    [SerializeField] private float _maxStep;


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

        float value = _firstStep + (level+1) * (_maxVelue - _baseValue) / (_maxStep-1);

        return value;
    }
}