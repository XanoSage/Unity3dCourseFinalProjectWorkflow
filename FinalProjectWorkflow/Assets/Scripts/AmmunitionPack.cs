using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmunitionPack : MonoBehaviour
{
	[SerializeField] private List<WeaponTypeBullet> _weapons;
	[SerializeField] private List<BulletAmmunitionData> _bullets;

	public Tuple<List<WeaponTypeBullet>, List<BulletAmmunitionData>> GetAmmunition()
	{
		return new Tuple<List<WeaponTypeBullet>, List<BulletAmmunitionData>>(_weapons, _bullets);
	}

	public void DestroyOnCollision()
	{
		Destroy(gameObject);
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

[Serializable]
public class BulletAmmunitionData
{
	public WeaponTypeBullet TypeBullet;
	public int Count;
}