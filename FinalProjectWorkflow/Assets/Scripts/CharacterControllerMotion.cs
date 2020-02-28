using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerMotion : MonoBehaviour, IShootable
{
	[SerializeField] private float _speedMotion;
	[SerializeField] private float _speedRotation;
    [SerializeField] private Camera _camera;
    [SerializeField] private Rigidbody _rigidbody;

    [SerializeField] private float _minimumX = -75f;
    [SerializeField] private float _maximumX = 75f;
    [SerializeField] private float _smoothTime = 3f;
    [SerializeField] private float _jumpForce = 50f;

	[SerializeField] private FactoryController factoryController;
	[SerializeField] private MainGameDataHolder mainGameDataHolder;
    private bool _canJump = true;

	public event Action FireEvent;
	public event Action GrenadeEvent;

	private HumanController _humanController;

	public void Init(HumanController humanController)
	{
		_humanController = humanController;
	}

	// Start is called before the first frame update
	void Start()
    {
        //_rigidbody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        _camera = GetComponentInChildren<Camera>();

		_humanController = factoryController.CreateHuman(mainGameDataHolder.GetUserHuman(), this);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
		{
			RaiseFireEvent();
		}
    }



	private void FixedUpdate()
	{
		if (Input.GetKey(KeyCode.W))
		{
			Motion(transform.forward);
		}
		else if (Input.GetKey(KeyCode.S))
		{
			Motion(transform.forward * (-1));
		}

		if (Input.GetKey(KeyCode.A))
		{
			Motion(transform.right * (-1));
		}
        else if (Input.GetKey(KeyCode.D))
		{
			Motion(transform.right * 1);
		}

		var yValue = Input.GetAxis("Mouse X");
		var xValue = Input.GetAxis("Mouse Y");
		RotationCharacter(new Vector3(0f, yValue, 0f));
		RotationCamera(new Vector3(-xValue, 0f, 0f));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
	
	}

	private void Motion(Vector3 direction)
    {
        var nextPosition = transform.position + direction * _speedMotion;

		transform.position = Vector3.Lerp(transform.position, nextPosition, _smoothTime * Time.deltaTime);
	}

	private void RotationCharacter(Vector3 direction)
    {
        var nextRotation = transform.localRotation * Quaternion.Euler(direction*_speedRotation);

        transform.localRotation = Quaternion.Slerp(transform.localRotation, nextRotation, _smoothTime * Time.deltaTime);
	}

    private void RotationCamera(Vector3 direction)
    {

        var nextRotation = _camera.transform.localRotation * Quaternion.Euler(direction * _speedRotation);
        nextRotation = ClampRotationAroundXAxis(nextRotation);

		_camera.transform.localRotation = Quaternion.Slerp(_camera.transform.localRotation, nextRotation, _smoothTime * Time.deltaTime);
	}

    private void Jump()
    {
        if (!_canJump)
            return;
        _canJump = false;
        _rigidbody.AddForce(new Vector3(0, _jumpForce, 0f));
    }

    private Quaternion ClampRotationAroundXAxis(Quaternion q)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1.0f;

        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);

        angleX = Mathf.Clamp(angleX, _minimumX, _maximumX);

        q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

        return q;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collision: {collision.gameObject.name}");
        if (collision.transform.CompareTag("Ground"))
        {
            _canJump = true;
        }

		if (collision.transform.CompareTag("Ammunition"))
		{
			var ammunition = collision.transform.GetComponent<AmmunitionPack>();
			var ammunitionData = ammunition.GetAmmunition();
			Debug.Log($"data: {ammunitionData}");
			var weaponController = factoryController.GetWeaponController(ammunitionData.Item1[0], _humanController.Human);
			_humanController.AddWeapon(weaponController);
			ammunition.DestroyOnCollision();
		}
    }
	
	private void AddWeapon(WeaponTypeBullet weaponTypeBullet)
	{
		//get weaponController by weapon type
	}


	private void RaiseFireEvent()
	{
		FireEvent?.Invoke();
	}
}
