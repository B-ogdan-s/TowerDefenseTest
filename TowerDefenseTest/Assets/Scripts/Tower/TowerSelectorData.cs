using System;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerSelectorData", menuName = "Data/TowerSelectorData")]
public class TowerSelectorData : ScriptableObject
{
    [SerializeField] private Tower _towerPrefab;
    [SerializeField] private TowerUpdatableData _towerData;
    [SerializeField] private Sprite _icon;
    [SerializeField] private int _price;
    [SerializeField] private string _name;
    [SerializeField] private string _description;

    public Tower TowerPrefab => _towerPrefab;
    public TowerUpdatableData TowerData => _towerData;
    public Sprite Icon => _icon;
    public int Price => _price;
    public string Name => _name;
    public string Description => _description;
}

[Serializable]
public struct TowerUpdatableData
{
    [SerializeField] private float _radius;
    [SerializeField] private UpdatableParameter _damage;
    [SerializeField] private UpdatableParameter _attackSpeed;
    [SerializeField] private UpdatableParameter _costOfImprovement;

    public float Radius => _radius;

    public TowerData ModifyData(int level)
    {
        TowerData data = new TowerData();
        data.Damage = _damage.GetIntValue(level);
        data.AttackSpeed = _attackSpeed.GetFloatValue(level);
        data.Cost = _costOfImprovement.GetIntValue(level);
        return data;
    }
}
