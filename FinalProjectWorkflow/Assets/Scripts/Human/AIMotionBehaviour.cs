using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class AIMotionBehaviour : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private LayerMask _layerMask;
    // Start is called before the first frame update
    private float _attackRange = 3f;
    private float _rayDistance = 5.0f;
    private float _stoppingDistance = 1.5f;

    private Vector3 _destination;
    private Quaternion _desiredRotation;
    private Vector3 _direction;

    public void SetTarget(Vector3 position) {
        _agent.SetDestination(position);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (NeedsDestination()) {
        //    GetDestination();
        //}


        //var rayColor = IsPathBlocked() ? Color.red : Color.green;
        //Debug.DrawRay(transform.position, _direction * _rayDistance, rayColor);

        //while (IsPathBlocked()) {
        //    Debug.Log("Path Blocked");
        //    GetDestination();
        //}

        var targetToAggro = CheckForAggro();
    }

    private bool IsPathBlocked() {
        Ray ray = new Ray(transform.position, _direction);
        var hitSomething = Physics.RaycastAll(ray, _rayDistance, _layerMask);
        return hitSomething.Any();
    }

    private void GetDestination() {
        Vector3 testPosition = (transform.position + (transform.forward * 4f)) +
                               new Vector3(UnityEngine.Random.Range(-4.5f, 4.5f), 0f,
                                   UnityEngine.Random.Range(-4.5f, 4.5f));

        _destination = new Vector3(testPosition.x, transform.position.y, testPosition.z);

        _direction = Vector3.Normalize(_destination - transform.position);
        _direction = new Vector3(_direction.x, 0f, _direction.z);
        _desiredRotation = Quaternion.LookRotation(_direction);

        SetTarget(_destination);
    }

    private bool NeedsDestination() {
        if (_destination == Vector3.zero)
            return true;

        var distance = Vector3.Distance(transform.position, _destination);
        if (distance <= _stoppingDistance) {
            return true;
        }

        return false;
    }

    

    Quaternion startingAngle = Quaternion.AngleAxis(-60, Vector3.up);
    Quaternion stepAngle = Quaternion.AngleAxis(5, Vector3.up);

    private Transform CheckForAggro() {
        Debug.DrawLine(transform.position, _destination, Color.blue);
        float aggroRadius = 5f;

        RaycastHit hit;
        var angle = transform.rotation * startingAngle;
        var direction = angle * Vector3.forward;
        var pos = transform.position;
        for (var i = 0; i < 72; i++) {
            if (Physics.Raycast(pos, direction, out hit, aggroRadius)) {
                var human = hit.collider.GetComponent<HumanBehaviour>();
                if (human != null) {
                    Debug.DrawRay(pos, direction * hit.distance, Color.red);
                    return human.transform;
                }
                else {
                    Debug.DrawRay(pos, direction * hit.distance, Color.yellow);
                }
            }
            else {
                Debug.DrawRay(pos, direction * aggroRadius, Color.white);
            }
            direction = stepAngle * direction;
        }

        return null;
    }
}
