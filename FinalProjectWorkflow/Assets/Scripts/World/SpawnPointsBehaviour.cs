using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointsBehaviour : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> _spawnPoints;
    // Start is called before the first frame update
    private void Awake() {
    }

    // Update is called once per frame
    void Update() {

    }
    public SpawnPoint GetFreeSpawnPoint() {
        var index = Random.Range(0, _spawnPoints.Count);
        var result = _spawnPoints[index];
        var counter = 0;
        while (!result.IsEmpty) {
            index = Random.Range(0, _spawnPoints.Count);
            result = _spawnPoints[index];
            counter++;

            if (counter >= 10)
                return null;
        }

        return result;
    }

    public SpawnPoint GetRandomSpawnPoint() {
        var index = Random.Range(0, _spawnPoints.Count);
        var result = _spawnPoints[index];
        return result;
    }

    public SpawnPoint GetNearestPosition(Vector3 position) {
        SpawnPoint result = null;
        var minDistance = 100000f;
        var minDistanceExeptPlayer = 4f;
        foreach (var spawnPoint in _spawnPoints) {
            var distance = Vector3.Distance(position, spawnPoint.transform.position);
            if (distance < minDistance && distance >= minDistanceExeptPlayer) {
                minDistance = distance;
                result = spawnPoint;
            }
        }

        return result;
    }

    public SpawnPoint GetRandomSpawnPointExceptCurrent(Vector3 position) {
        var nearestSpawnPoint = GetNearestPosition(position);
        foreach (var spawnPoint in _spawnPoints) {
            if (nearestSpawnPoint != spawnPoint)
                return spawnPoint;
        }
        return null;

    }
}
