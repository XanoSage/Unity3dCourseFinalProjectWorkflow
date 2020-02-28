using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.EventAggregator;
using Assets.Scripts.Events;
using TMPro;
using UnityEngine;


public class UIHealthPoint : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healthPointText;
    

	public void EventHandler(int healthPoint)
	{
		throw new System.NotImplementedException();
	}

	void Start()
    {
        // подписываемся на нужное для нас событие на старте
		EventAggregator.Subscribe<HealthPointChangeEvent>(HealthpointChangedHandler);
    }

    private void OnDestroy()
    {
        // отписываемся от события перед уничтожением объекта
        EventAggregator.Unsubscribe<HealthPointChangeEvent>(HealthpointChangedHandler);
    }

    //сам обработчик события
    private void HealthpointChangedHandler(object arg1, HealthPointChangeEvent arg2)
    {
        _healthPointText.SetText(arg2.HealthPoint.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
