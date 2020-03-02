using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.EventAggregator;
using Assets.Scripts.Events;
using UnityEngine;



public class HumanWeaponBehaviour : MonoBehaviour
{
    [SerializeField] private Transform _parentForWeapons;
    //[SerializeField] private
    // Start is called before the first frame update
    private HumanBehaviour _humanBehaviour;
    private WeaponBehaviour _currentWeaponBehaviour;
    void Awake()
    {
        _humanBehaviour = GetComponent<HumanBehaviour>();
        EventAggregator.Subscribe<WeaponAddedEvent>(OnWeaponAddedEvent);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnWeaponAddedEvent(object sender, WeaponAddedEvent eventHandler)
    {
        if (!ReferenceEquals(sender, eventHandler.Owner))
        {
            return;
        }

        AddWeaponBehaviour(eventHandler.Weapon);
    }

    private void AddWeaponBehaviour(WeaponController controller)
    {
        var prefabData = MainGameDataHolder.GetWeaponPrefabData(controller.Weapon.WeaponType);
        var go = PoolManager.GetGameObjectFromPool(prefabData.Prefab.gameObject);
        go.transform.SetParent(_parentForWeapons);
        _currentWeaponBehaviour = go.GetComponent<WeaponBehaviour>();
        _currentWeaponBehaviour.Init(controller);
    }
}
