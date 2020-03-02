using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableComponent : MonoBehaviour, IShootable
{
    public event Action FireEvent;
    public event Action FireUpEvent;
    public event Action GrenadeEvent;

    // Update is called once per frame

    public virtual void PostFireEvent()
    {
        FireEvent?.Invoke();
    }

    public virtual void PostGrenadeEvent()
    {
        GrenadeEvent?.Invoke();
    }

    public virtual void PostFireUpEvent()
    {
        FireUpEvent?.Invoke();
    }
}
