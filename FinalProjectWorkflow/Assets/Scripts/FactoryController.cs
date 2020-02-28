using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryController : MonoBehaviour
{
    private static FactoryController _instance;
	[SerializeField] private MainGameDataHolder dataHolder;
	public WeaponController GetWeaponController(WeaponTypeBullet weaponType, HumanModel human)
	{
		var weaponModel = MainGameDataHolder.GetWeaponModel(weaponType);
		return new WeaponController(weaponModel, human);
	}

	public HumanController CreateHuman(HumanModel human, IShootable shootable)
	{
		var humanController = new HumanController(human, shootable);
		return humanController;
	}
    // Start is called before the first frame update
    void Awake()
    {
        _instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static WeaponController CreateWeaponController(WeaponTypeBullet weaponType, HumanModel human)
    {
        return _instance.GetWeaponController(weaponType, human);
    }

    public static HumanController CreateHumanController(HumanModel human, IShootable shootable)
    {
        return _instance.CreateHuman(human, shootable);
    }
}
