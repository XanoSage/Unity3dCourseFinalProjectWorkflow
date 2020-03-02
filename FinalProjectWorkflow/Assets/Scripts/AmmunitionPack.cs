using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmunitionPack : MonoBehaviour
{
	[SerializeField] private List<WeaponTypeBullet> _weapons;
	[SerializeField] private List<BulletAmmunitionData> _bullets;

	[SerializeField] private float _angle = 3f;
	[SerializeField] private float _rotationSpeed = 3f;


	private bool _isAnimate = true;
	public Tuple<List<WeaponTypeBullet>, List<BulletAmmunitionData>> GetAmmunition()
	{
		return new Tuple<List<WeaponTypeBullet>, List<BulletAmmunitionData>>(_weapons, _bullets);
	}

	public void DestroyOnCollision()
	{
		_isAnimate = false;
		StopAllCoroutines();
		Destroy(gameObject);
	}
	// Start is called before the first frame update
	void Start()
    {
		StartCoroutine(Rotation());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private IEnumerator Rotation() {
		yield return new WaitForFixedUpdate();
		Debug.Log("Rotation");
		while (_isAnimate) {
			var nextRoatation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y + _angle, 0f);
			transform.rotation = Quaternion.Slerp(transform.rotation, nextRoatation, Time.deltaTime * _rotationSpeed);
			yield return new WaitForFixedUpdate();
		}
		
	}
}

[Serializable]
public class BulletAmmunitionData
{
	public WeaponTypeBullet TypeBullet;
	public int Count;
}