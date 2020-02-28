using EventAggregation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPointChangeEvent: IEventBase
{
	public int HeaplthPoint;
}

public class HealthSystemLogic : MonoBehaviour
{
	public int HealthPoint = 100;

	public bool DealDamage(int damage)
	{
		//post DealDamage Event
		HealthPoint -= damage;
		PostHealthChangeEvent(HealthPoint);
		if (HealthPoint <= 0)
		{
			HealthPoint = 0;
			return true;
		}
		return false;
	}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.CompareTag("Bullet"))
		{

		}
	}

	private void PostHealthChangeEvent(int healthPoint)
	{
		EventAggregator.Publish<HealthPointChangeEvent>(new HealthPointChangeEvent() { HeaplthPoint = healthPoint});
	}
}
