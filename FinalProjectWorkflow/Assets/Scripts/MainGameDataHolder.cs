using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameDataHolder : MonoBehaviour
{
    private static MainGameDataHolder _instance;
	[SerializeField] private List<WeaponModel> _weapons;
	[SerializeField] private List<HumanModel> _humans;

    [SerializeField] private List<WeaponPrefabData> _weaponPrefabDataList;
    [SerializeField] private List<BulletPrefabData> _bulletPrefabDataList;

    private void Awake()
    {
        _instance = this;
    }

	public HumanModel GetUserHuman()
	{
		var result = _humans.Find(human => human.ControllType == ControllingType.Player);
		return result;
	}

	public WeaponModel GetWeaponModelInner(WeaponTypeBullet weaponType)
	{
		var result = _weapons.Find(model=> model.WeaponType == weaponType);
		return result;
	}

    public WeaponPrefabData GetWeaponPrefabDataInner(WeaponTypeBullet weaponType)
    {
        var result = _weaponPrefabDataList.Find(weapon => weapon.WeaponType == weaponType);
        return result;
    }

    public BulletPrefabData GetBulletPrefabDataInner(WeaponTypeBullet bulletType)
    {
        var result = _bulletPrefabDataList.Find(bullet => bullet.Bullet == bulletType);
        return result;
    }

    public static HumanModel GetUserHumanModel()
    {
        return _instance.GetUserHuman();
    }

    public static WeaponModel GetWeaponModel(WeaponTypeBullet weaponType)
    {
        return _instance.GetWeaponModelInner(weaponType);
    }

    public static WeaponPrefabData GetWeaponPrefabData(WeaponTypeBullet weaponType)
    {
        return _instance.GetWeaponPrefabDataInner(weaponType);
    }

    public static BulletPrefabData GetBulletPrefabData(WeaponTypeBullet bullet)
    {
        return _instance.GetBulletPrefabDataInner(bullet);
    }
}

[Serializable]
public class WeaponPrefabData
{
    public WeaponTypeBullet WeaponType;
    public WeaponBehaviour Prefab;
}

[Serializable]
public class BulletPrefabData
{
    public WeaponTypeBullet Bullet;
    public BulletBehaviour Prefab;
}
