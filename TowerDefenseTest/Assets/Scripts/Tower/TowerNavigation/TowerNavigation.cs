using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(SphereCollider))]
public abstract class TowerNavigation : MonoBehaviour
{
    [SerializeField] private Transform _rotateTransform;
    [SerializeField] private SphereCollider _sphereCollider;

    protected List<Enemy> _enemy = new();

    private bool _isPresent = false;
    public bool IsPressent
    {
        get { return _isPresent; }
        private set 
        {
            if (_isPresent == value)
                return;
            _isPresent = value;
            Debug.LogWarning(_isPresent);
            if(IsPressent)
                OnTargetAppeared?.Invoke();
            else
                OnTargetDisappeared?.Invoke();
        }
    }

    public Action OnTargetAppeared;
    public Action OnTargetDisappeared;

    private void Update()
    {
        Transform tr = UpdateTarget();

        if (tr == null)
        {
            IsPressent = false;
            return;
        }
        Vector3 dir = tr.position - transform.position;
        dir.y = 0;
        _rotateTransform.rotation = Quaternion.LookRotation(dir);

        IsPressent = true;
    }

    public void SetRadius(float radius)
    {
        _sphereCollider.radius = radius;
    }

    public abstract Transform UpdateTarget();

    protected void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            _enemy.Add(enemy);
        }
    }
    protected void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            _enemy.Remove(enemy);
        }
    }

    private void OnDisable()
    {
        IsPressent = false;
    }
}
