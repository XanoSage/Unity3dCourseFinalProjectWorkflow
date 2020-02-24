using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryController : MonoBehaviour
{
	[SerializeField] private MainGameDataHolder dataHolder;
	public WeaponController GetWeaponController(WeaponTypeBullet weaponType, HumanModel human)
	{
		var weaponModel = dataHolder.GetWeaponModel(weaponType);
		return new WeaponController(weaponModel, human);
	}

	public HumanController CreateHuman(HumanModel human, IShootable shootable)
	{
		var humanController = new HumanController(human, shootable);
		return humanController;
	}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
