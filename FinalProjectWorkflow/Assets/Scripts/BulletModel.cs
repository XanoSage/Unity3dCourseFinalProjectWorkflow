using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DamageTypeBullet
{
	Simple,
	Hard
}

public enum WeaponTypeBullet
{
	Pistol,
	M4A1,
	SVD,
	RPG_7
}

[Serializable]
public class BulletModel
{
	public WeaponTypeBullet VisualType;
	public DamageTypeBullet DamageType;
	public int Damage;
}
