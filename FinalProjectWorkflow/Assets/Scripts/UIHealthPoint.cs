using EventAggregation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEventHealthPointChange: IEventBase
{
	void EventHandler(int healthPoint);
}

public class UIHealthPoint : MonoBehaviour, IEventHealthPointChange
{
	//[SerializeField] private TextMeshProUGUI _healthPointText; 
	// Start is called before the first frame update
	private string _healthPoint;

	public void EventHandler(int healthPoint)
	{
		throw new System.NotImplementedException();
	}

	void Start()
    {
		EventAggregation.EventAggregator.Subscribe<HealthPointChangeEvent>();
    }


	private void HealthPointChangeHandler(IEventHealthPointChange args)
	{

	}
    // Update is called once per frame
    void Update()
    {
        
    }
}
