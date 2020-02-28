using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseShootableComponent : ShootableComponent
{
    
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            PostFireEvent();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            PostFireUpEvent();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            PostGrenadeEvent();
        }
    }
}
