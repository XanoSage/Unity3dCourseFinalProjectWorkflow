using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.EventAggregator;
using Assets.Scripts.Events;
using UnityEngine;

public class HealthSystemLogic : MonoBehaviour
{
	public int HealthPoint = 100;

	public bool DealDamage(int damage)
    {
        bool result = false;
		//post DealDamage Event
		HealthPoint -= damage;
		
		if (HealthPoint <= 0)
		{
			HealthPoint = 0;
			result = true;
		}

        PostHealthChangeEvent(HealthPoint);
		return result;
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
        EventAggregator.Post<HealthPointChangeEvent>(this, new HealthPointChangeEvent() { HealthPoint = healthPoint});
	}
}
