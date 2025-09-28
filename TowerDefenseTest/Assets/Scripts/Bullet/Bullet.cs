using System.Collections;
using UnityEngine;

public class Bullet : BaseProjectile
{
    [SerializeField] private float _speed = 10f;

    private Coroutine _coroutine;

    public override void Initialize(int damage)
    {
        base.Initialize(damage);
        _coroutine = StartCoroutine(Timer());
    }

    private void Update()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out EnemyHealth health))
        {
            health.SetDamage(_damage);
            DisableObject();
        }
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(_lifetime);
        _coroutine = null;
        DisableObject();
    }

    public override void DisableObject()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }

        base.DisableObject();
    }

}
