using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.EventAggregator;
using UnityEngine;

public class WeaponBehaviour : MonoBehaviour
{
    [SerializeField] private WeaponTypeBullet _weaponType;
    [SerializeField] private Transform _bulletStartPoint;
	[SerializeField] private GameObject _parentForLight;

    private BulletBehaviour _bulletBehaviourPrefab;
    private WeaponController _weaponController;
    private Vector3 _position;
    private Quaternion _rotation;

    public void Init(WeaponController weaponController)
    {
        _weaponController = weaponController;
        var prefabData = MainGameDataHolder.GetBulletPrefabData(_weaponController.Weapon.WeaponType);
        _bulletBehaviourPrefab = prefabData.Prefab;
        transform.localPosition = _position;
        transform.localRotation = _rotation;
    }

	[ContextMenu("Test Fire")]
	public void Fire(BulletShootInfo bulletShootInfo)
	{
        Debug.Log($"[{GetType().Name}][Fire] bullet: {bulletShootInfo.Bullet}, owner: {bulletShootInfo.Owner.Name}");        
        CreateBullet(bulletShootInfo);
        SetLightActive(true);
		CoroutineBehaviour.DelayedAction(0.1f, ()=> SetLightActive(false));
	}

    private void CreateBullet(BulletShootInfo bulletShootInfo)
    {
        var go = PoolManager.GetGameObjectFromPool(_bulletBehaviourPrefab.gameObject);
        go.transform.position = _bulletStartPoint.position;
        go.transform.rotation = _bulletStartPoint.rotation;
        var bulletBehaviour = go.GetComponent<BulletBehaviour>();
        if (bulletBehaviour != null)
        {
            bulletBehaviour.Init(bulletShootInfo);
        }
    }
	
    // Start is called before the first frame update
    void Awake()
    {
		SetLightActive(false);
        EventAggregator.Subscribe<BulletShootInfo>(OnFireEventHandler);
        _position = transform.localPosition;
        _rotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void SetLightActive(bool active)
	{
		_parentForLight.SetActive(active);
	}

    private void OnFireEventHandler(object sender, BulletShootInfo bulletShootInfo)
    {
        if (_weaponController == null)
            return;

        if (_weaponController.Owner != bulletShootInfo.Owner)
        {
            return;
        }
        Fire(bulletShootInfo);
    }
}
