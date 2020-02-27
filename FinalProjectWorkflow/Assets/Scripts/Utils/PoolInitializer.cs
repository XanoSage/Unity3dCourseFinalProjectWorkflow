using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolInitializer : MonoBehaviour
{
    [SerializeField] private PoolInitializerData[] _poolInitializerDatas;

    [SerializeField] private Transform _parentForPool;
    // Start is called before the first frame update
    void Start()
    {
        PoolManager.Init(_parentForPool);

        foreach (var initializerData in _poolInitializerDatas)
        {
            for (int i = 0; i < initializerData.Count; i++)
            {
                PoolManager.PutGameObjectToPool(initializerData.Prefab);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[Serializable]
public class PoolInitializerData
{
    public GameObject Prefab;
    public int Count;
}
