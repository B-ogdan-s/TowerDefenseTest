using System.Collections.Generic;
using UnityEngine;

public struct PoolData<T> where T : PoolObject
{
    public List<T> enableList;
    public Stack<T> disableList;
}

public class PoolHandler<T> where T : PoolObject
{
    private Dictionary<T, PoolData<T>> _objects = new();

    public T GetFreeObject(T baseObject)
    {
        if (_objects.ContainsKey(baseObject))
        {
            PoolData<T> data = _objects[baseObject];
            if (data.disableList.Count > 0)
            {
                T obj = data.disableList.Pop();
                obj.EnableObject();
                data.enableList.Add(obj);
                return obj;
            }

            return SpawnNewObject(baseObject, data);
        }
        else
        {
            PoolData<T> data = new PoolData<T>() 
                { enableList = new(), disableList = new() };

            _objects.Add(baseObject, data);
            return SpawnNewObject(baseObject, data);
        }
    }

    private T SpawnNewObject(T baseObject, PoolData<T> data)
    {
        T obj = MonoBehaviour.Instantiate(baseObject);

        obj.EnableObject();
        data.enableList.Add(obj);
        obj.OnDisableObject += () => 
        {
            data.enableList.Remove(obj);
            data.disableList.Push(obj);
        };
        return obj;
    }
}
