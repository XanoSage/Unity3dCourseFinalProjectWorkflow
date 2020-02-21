using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponState
{
	ReadyToFire,
	InReload
}


public class WeaponController 
{
	private WeaponModel _weaponModel;
	private HumanModel _owner;
	private int _capacityCounter;
	private int _currentBulletCounter;
	private float _reloadTimeCounter;
	private WeaponState _weaponState = WeaponState.ReadyToFire;

	public event Action<BulletShootInfo> OnFire;

	public WeaponController(WeaponModel weapon, HumanModel human)
	{
		_weaponModel = weapon;
		_owner = human;
	}

	public void Fire()
	{
		if (_weaponState == WeaponState.InReload)
			return;

		if (_currentBulletCounter <= 0)
			return;

		if (_capacityCounter <= 0)
		{
			Reload();
		}

		//check for bullet count
		_capacityCounter--;
		if (_capacityCounter == 0)
		{
			Reload();
		}
	}

	public void AddBullet(int count)
	{
		_currentBulletCounter += count;
		if (_currentBulletCounter > _weaponModel.MaxBulletCount)
		{
			_currentBulletCounter = _weaponModel.MaxBulletCount;
		}
	}

    private void Reload()
	{
		var bulletCount = Mathf.Min(_currentBulletCounter, _weaponModel.Capacity);
		_currentBulletCounter -= bulletCount;
		_capacityCounter = bulletCount;
		ChangeWeaponState(WeaponState.InReload);
		//startReloadProcess
		CouroutineBehaviour.DelayedAction(_weaponModel.ReloadTime, ReloadComplete);
	}

	private void ReloadComplete()
	{
		ChangeWeaponState(WeaponState.ReadyToFire);
	}

	private void Init()
	{
		_currentBulletCounter = _weaponModel.Capacity;
		_capacityCounter = _currentBulletCounter;
	}

	private void ChangeWeaponState(WeaponState state)
	{
		_weaponState = state;
	}

	private void RaiseOnShootEvent()
	{
		var shootInfo = new BulletShootInfo()
		{
			Bullet = _weaponModel.Bullet,
			Owner = _owner
		};

		OnFire?.Invoke(shootInfo);
	}
}

public class BulletShootInfo
{
	public BulletModel Bullet;
	public HumanModel Owner;
}

