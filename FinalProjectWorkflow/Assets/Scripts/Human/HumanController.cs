using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController
{
	private WeaponController _weaponController;
	private HumanModel _humanModel;
	public HumanModel Human => _humanModel;
	private IShootable _shootable;

	public bool IsWeaponExist => _weaponController != null;
	public bool IsWeaponClipEmpty => _weaponController.BulletInClip == 0;
	public bool IsWeaponBulletEmpty => _weaponController.TotalBullet == 0;


	public ControllingType HumanType => _humanModel.ControllType;

	public HumanController(HumanModel humanModel, IShootable shootable)
	{
		_humanModel = humanModel;
		
		_shootable = shootable;

		_shootable.FireEvent += FireEventHandler;
		_shootable.FireUpEvent += ShootableOnFireUpEvent;
	}

    private void ShootableOnFireUpEvent()
    {
        _weaponController?.FireUp();
    }

    public void AddWeapon(WeaponController weaponController)
	{
		if (_weaponController == null)
			_weaponController = weaponController;
		_weaponController.AddBullet(weaponController.Weapon.Capacity);
		if (_weaponController.BulletInClip == 0)
			_weaponController.Reload();
	}

	private void FireEventHandler()
	{
		
		if (_weaponController == null)
			return;


		_weaponController.Fire();
	}


}


public interface IShootable
{
	event Action FireEvent;
	event Action FireUpEvent;
    event Action GrenadeEvent;
}