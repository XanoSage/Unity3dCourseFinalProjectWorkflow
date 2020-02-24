using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlockBehaviour : MonoBehaviour
{
	[SerializeField] private GameObject parentForLight;

	[ContextMenu("Test Fire")]
	public void Fire()
	{
		SetLightActive(true);
		CoroutineBehaviour.DelayedAction(0.1f, ()=> SetLightActive(false));
	}
	
    // Start is called before the first frame update
    void Awake()
    {
		SetLightActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
		{
			Fire();
		}
    }

	private void SetLightActive(bool active)
	{
		parentForLight.SetActive(active);
	}
}
