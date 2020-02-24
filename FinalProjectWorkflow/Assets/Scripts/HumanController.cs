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

	public HumanController(HumanModel humanModel, IShootable shootable)
	{
		_humanModel = humanModel;
		
		_shootable = shootable;

		_shootable.FireEvent += FireEventHandler;
	}

	public void AddWeapon(WeaponController weaponController)
	{
		_weaponController = weaponController;
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
	event Action GrenadeEvent;
}