using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameDataHolder : MonoBehaviour
{
	[SerializeField] private List<WeaponModel> _weapons;
	[SerializeField] private List<HumanModel> _humans;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public HumanModel GetUserHuman()
	{
		var result = _humans.Find(human => human.ControllType == ControllingType.Player);
		return result;
	}

	public WeaponModel GetWeaponModel(WeaponTypeBullet weaponType)
	{
		var result = _weapons.Find(model=> model.WeaponType == weaponType);
		return result;
	}
}
