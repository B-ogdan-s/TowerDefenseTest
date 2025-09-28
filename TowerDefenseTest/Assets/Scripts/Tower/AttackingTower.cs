using System.Collections;
using UnityEngine;
using Zenject.SpaceFighter;

public class AttackingTower : MonoBehaviour
{
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private BaseProjectile _bullet;

    private PoolHandler<BaseProjectile> _poolHandler = new();

    private Coroutine _coroutine;
    private bool _isAttack;

    private int _damage;
    private float _rechargeTime;
    public void SetData(int damage, float rechargeTime)
    {
        _damage = damage;
        _rechargeTime = rechargeTime;
    }

    public void StartAttack()
    {
        _isAttack = true;
        if(_coroutine == null)
            _coroutine = StartCoroutine(Attack());
    }
    public void StopAttack()
    {
        _isAttack = false;
        if(_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private IEnumerator Attack()
    {
        while (_isAttack)
        {
            BaseProjectile bullet = _poolHandler.GetFreeObject(_bullet);
            bullet.transform.position = _spawnPosition.position;
            bullet.transform.rotation = _spawnPosition.rotation;
            bullet.Initialize(_damage);

            yield return new WaitForSeconds(_rechargeTime);
        }
    }
}
