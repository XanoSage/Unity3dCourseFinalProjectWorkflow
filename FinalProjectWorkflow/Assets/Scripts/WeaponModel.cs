using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum WeaponTypeByShooting
{
	Single,
	SemiAutomatic,
	Automatic
}

[Serializable]
public class WeaponModel 
{
	public WeaponTypeBullet WeaponType;
	public WeaponTypeByShooting ShootingType;
	public BulletModel Bullet;
	public int Capacity;
	public float ReloadTime;
	public float FireRate;
	public int MaxBulletCount;
}
