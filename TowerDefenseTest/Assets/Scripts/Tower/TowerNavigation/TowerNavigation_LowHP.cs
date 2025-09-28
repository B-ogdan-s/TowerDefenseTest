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

        Enemy enemy = _enemy.OrderBy(e => e.EnemyHealth).FirstOrDefault();

        return enemy.transform;
    }
}
