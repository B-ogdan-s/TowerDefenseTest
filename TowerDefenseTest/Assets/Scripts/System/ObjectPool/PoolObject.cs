using System;
using UnityEngine;

public abstract class PoolObject : MonoBehaviour
{
    public Action OnDisableObject;

    public virtual void EnableObject()
    {
        gameObject.SetActive(true);
    }
    public virtual void DisableObject()
    {
        OnDisableObject?.Invoke();
        gameObject.SetActive(false);
    }
}
