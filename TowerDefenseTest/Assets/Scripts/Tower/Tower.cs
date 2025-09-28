using UnityEngine;

public struct TowerData
{
    public int Damage;
    public float AttackSpeed;
    public int Cost;
}

public class Tower : MonoBehaviour
{
    [SerializeField] private AttackingTower _attackingTower;
    [SerializeField] private TowerShowData _towerShowData;

    [SerializeField] private TowerNavigation _towerNavigation;

    private int _level = 0;

    TowerUpdatableData _updatableData;
    TowerData _data;


    private void Awake()
    {
        _towerNavigation.OnTargetAppeared += _attackingTower.StartAttack;
        _towerNavigation.OnTargetDisappeared += _attackingTower.StopAttack;
    }
    
    public void InitializedData(TowerUpdatableData data)
    {
        _updatableData = data;
        _data = _updatableData.ModifyData(_level);
        _towerNavigation.SetRadius(data.Radius);
        _towerNavigation.gameObject.SetActive(false);
        UpdateData();
    }

    public void Activate(bool value)
    {
        _towerNavigation.gameObject.SetActive(value);
    }

    public int GetCost()
    {
        return _data.Cost;
    }
    public void LevelUp()
    {
        _level++;
        _data = _updatableData.ModifyData(_level);
        UpdateData();
    }
    private void UpdateData()
    {
        int damage = _data.Damage;
        float rechargeTime = 1 / _data.AttackSpeed;
        _attackingTower.SetData(damage, rechargeTime);
    }

    public void ShowPanel(bool activate,  int coin)
    {
        _towerShowData.ShowLevel(activate);
        _towerShowData.UpdateLevel(_level + 1);

        bool value = coin >= _data.Cost;
        _towerShowData.ShowLevelUp(value && activate);
        _towerShowData.UpdateLevelUp(_data.Cost);
    }
    private void OnDestroy()
    {
        _towerNavigation.OnTargetAppeared -= _attackingTower.StartAttack;
        _towerNavigation.OnTargetDisappeared -= _attackingTower.StopAttack;
    }
}