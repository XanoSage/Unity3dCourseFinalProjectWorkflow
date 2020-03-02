using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanBehaviour : MonoBehaviour
{
    [SerializeField] private ControllingType _controllingType;
    [SerializeField] private ShootableComponent _shootableComponent;

    private HumanController _humanController;

    public HumanController Human => _humanController;
    void Start()
    {
        _humanController = FactoryController.CreateHumanController(MainGameDataHolder.GetHumanModel(_controllingType), _shootableComponent);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
