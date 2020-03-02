using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SpawnPoint : MonoBehaviour
{
    public bool IsEmpty { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        IsEmpty = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other) {
        //Debug.Log($"OnTriggerStay: other: {other.gameObject.name}");
        IsEmpty = false;
    }

    private void OnTriggerExit(Collider other) {
        Debug.Log($"OnTriggerExit: other: {other.gameObject.name}");
        IsEmpty = true;

    }
}
