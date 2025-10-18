using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private GameObject EnemyPrefab;

    void Start()
    {
        foreach(Transform point in spawnPoints)
        {
            Instantiate(EnemyPrefab, point.position, Quaternion.identity);
        }
    }

    
}
