using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float PLAYER_DIST_SPAWN_LEVEL_PART = 30f;
    [SerializeField] private Transform LevelPartStart;
    [SerializeField] private List<Transform> LevelPartList;
    [SerializeField] private Transform player;
    private Vector3 lastEndPosition;
    private float currRoadRotation = 0f;
    private void Awake()
    {
        lastEndPosition = LevelPartStart.Find("EndPosition").position;
        int startingSpawnLevelParts = 2;
        for(int i = 0; i < startingSpawnLevelParts; i++)
        {
            SpawnLevelPart();
        }
    }    

    private void Update()
    {
        if(Vector3.Distance(player.position, lastEndPosition) < PLAYER_DIST_SPAWN_LEVEL_PART)
        {
            // Spawn another level part
            SpawnLevelPart();
        }
    }
    
    private void SpawnLevelPart()
    {
        Transform chosenLevelPart = LevelPartList[Random.Range(0, LevelPartList.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition, currRoadRotation);
        currRoadRotation = lastLevelPartTransform.Find("EndPosition").transform.rotation.eulerAngles.z;
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }
    private Transform SpawnLevelPart( Transform LevelPart, Vector3 spawnPosition, float rotation )
    {
        Transform levelPartTransform = Instantiate(LevelPart, spawnPosition, Quaternion.Euler(new Vector3(0,0,rotation)));
        return levelPartTransform;
    }
}
