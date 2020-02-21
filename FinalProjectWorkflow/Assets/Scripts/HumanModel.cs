using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ControllingType
{
	AI,
	Player
}

public enum VisualType
{
	Terrorist,
	CounterTerrorist
}

[Serializable]
public class HumanModel 
{
	public ControllingType ControllType;
	public VisualType Visual;
	public string Name;
	public int HealtPoint;
	public float MotionSpeed;
	public float RotationSpeed;
}
