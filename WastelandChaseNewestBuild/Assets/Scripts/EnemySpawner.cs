using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> EnemiesList;
    private Transform ChosenEnemy;
    private Transform EnemyInstance;
    void Awake()
    {
        ChosenEnemy = EnemiesList[Random.Range(0, 2)];
        SpawnEnemy(ChosenEnemy, transform.position, transform.rotation.eulerAngles.z);
        
    }

    private void SpawnEnemy(Transform Enemy, Vector3 spawnPosition, float rotation)
    {
        EnemyInstance = Instantiate(Enemy, spawnPosition, Quaternion.Euler(new Vector3(0, 0, rotation)));
    }
}
