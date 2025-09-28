using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Lazer : BaseProjectile
{
    [SerializeField] private float _attackSpeed = 2;
    [SerializeField] private float _radius = 20;

    private List<EnemyHealth> _enemy = new();


    public override void Initialize(int damage)
    {
        base.Initialize(damage);
        Vector3 scale = transform.localScale;
        scale.z = _radius;
        transform.localScale = scale;

        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        int attackCount = (int)(_lifetime * _attackSpeed);

        int count = 0;
        while (count < attackCount)
        {
            yield return new WaitForSeconds(1/_attackSpeed);
            Attack();
            count++;
        }

        Debug.Log("Disable");
        DisableObject();
    }

    private void Attack()
    {
        Debug.Log(_enemy.Count);
        foreach(var enemy in _enemy)
        {
            if(enemy.isActiveAndEnabled)
                enemy.SetDamage(_damage);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out EnemyHealth health))
        {
            _enemy.Add(health);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out EnemyHealth health))
        {
            _enemy.Remove(health);
        }
    }
}
