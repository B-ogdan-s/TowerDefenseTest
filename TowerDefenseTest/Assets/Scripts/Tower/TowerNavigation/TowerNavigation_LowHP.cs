using System.Linq;
using UnityEngine;

public class TowerNavigation_LowHP : TowerNavigation
{
    public override Transform UpdateTarget()
    {
        _enemy.RemoveAll(e => !e.gameObject.activeSelf);
        if (_enemy.Count == 0)
        {
            return null;
        }

        Enemy enemy = _enemy[0];
        for (int i = 1; i < _enemy.Count; i++)
        {
            if(_enemy[i].EnemyHealth.HP < enemy.EnemyHealth.HP)
                enemy = _enemy[i];
        }

        return enemy.transform;
    }
}
