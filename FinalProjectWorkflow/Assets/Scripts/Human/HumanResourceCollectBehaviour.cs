using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.EventAggregator;
using Assets.Scripts.Events;
using UnityEngine;

public class HumanResourceCollectBehaviour : MonoBehaviour
{
    private HumanBehaviour _humanBehaviour;
    // Start is called before the first frame update
    void Start()
    {
        _humanBehaviour = GetComponent<HumanBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collision: {collision.gameObject.name}");


        if (collision.transform.CompareTag("Ammunition"))
        {
            if (_humanBehaviour.Human.IsWeaponExist)
                return;

            var ammunition = collision.transform.GetComponent<AmmunitionPack>();
            var ammunitionData = ammunition.GetAmmunition();
            Debug.Log($"data: {ammunitionData}");
            var weaponController = FactoryController.CreateWeaponController(ammunitionData.Item1[0], _humanBehaviour.Human.Human);
            _humanBehaviour.Human.AddWeapon(weaponController);
            PostWeaponAddedEvent(weaponController);
            ammunition.DestroyOnCollision();
        }
    }

    private void PostWeaponAddedEvent(WeaponController weaponController)
    {
        EventAggregator.Post(_humanBehaviour, new WeaponAddedEvent(){Owner = _humanBehaviour, Weapon = weaponController});
    }
}
