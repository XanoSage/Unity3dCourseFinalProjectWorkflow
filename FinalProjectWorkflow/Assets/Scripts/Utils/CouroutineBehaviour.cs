﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CouroutineBehaviour : MonoBehaviour
{
	private static CouroutineBehaviour _instance;

	private static CouroutineBehaviour _instanceInner
	{
		get
		{
			if (_instance == null)
			{
				var go = new GameObject("CouroutineBehaviour");
				_instance = go.AddComponent<CouroutineBehaviour>();
			}
			return _instance;
		}
	}

	private void StartDelayedAction(float delay, Action action)
	{
		StartCoroutine(DelayedActionInner(delay, action));
	}

    private IEnumerator DelayedActionInner(float delay, Action action)
	{
		yield return new WaitForSeconds(delay);
		action?.Invoke();
	}
	

	public static void DelayedAction(float delay, Action action)
	{
		_instanceInner.StartDelayedAction(delay, action);
	}
}