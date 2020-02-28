using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager 
{
    private static Dictionary<string, LinkedList<GameObject>> _poolDictionary;
    private static Transform _poolParent;

    public static void Init(Transform poolParent)
    {
        _poolParent = poolParent;
        _poolDictionary = new Dictionary<string, LinkedList<GameObject>>();
    }

    public static GameObject GetGameObjectFromPool(GameObject prefab)
    {
        if (!_poolDictionary.ContainsKey(prefab.name))
        {
            _poolDictionary[prefab.name] = new LinkedList<GameObject>();
        }

        GameObject result = null;

        if (_poolDictionary[prefab.name].Count > 0)
        {
            result = _poolDictionary[prefab.name].First.Value;
            _poolDictionary[prefab.name].RemoveFirst();
            result.SetActive(true);
            return result;
        }

        result = GameObject.Instantiate(prefab);
        result.name = prefab.name;

        return result;
    }

    public static void PutGameObjectToPool(GameObject target)
    {
		if (!_poolDictionary.ContainsKey(target.name))
		{
			_poolDictionary[target.name] = new LinkedList<GameObject>();
		}

		_poolDictionary[target.name].AddFirst(target);
        target.transform.SetParent(_poolParent);
        target.SetActive(false);
    }
}
