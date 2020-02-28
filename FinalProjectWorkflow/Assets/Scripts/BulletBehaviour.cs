using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
	[SerializeField] private WeaponTypeBullet BulletType;
	private BulletModel _bulletModel;
	private bool _isActive;
	public void Init(BulletModel bullet)
	{
		_bulletModel = bullet;
	}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (!_isActive)
			return;

		if (_bulletModel.VisualType != WeaponTypeBullet.RPG_7)
		{
			CheckHit();
		}
    }

	private void CheckHit()
	{
		Ray ray = new Ray(transform.position, transform.forward);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit))
		{
			if (hit.transform.CompareTag("Human"))
			{
				var healthSystem = hit.transform.GetComponent<HealthSystemLogic>();
				if (healthSystem != null)
				{
					//hit
					var isKill = healthSystem.DealDamage(_bulletModel.Damage);
					if (isKill)
					{
						//post death event
					}

				}
			}
		}
	}
}
