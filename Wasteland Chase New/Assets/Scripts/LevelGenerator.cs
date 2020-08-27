using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float PLAYER_DIST_SPAWN_LEVEL_PART = 30f;
    [SerializeField] private Transform LevelPartStart;
    [SerializeField] private List<Transform> LevelPartList;
    [SerializeField] private Transform player;
    private Vector3 lastEndPosition;
    private void Awake()
    {
        lastEndPosition = LevelPartStart.Find("EndPosition").position;
        SpawnLevelPart();
        SpawnLevelPart();
        int startingSpawnLevelParts = 3;
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
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }
    private Transform SpawnLevelPart( Transform LevelPart, Vector3 spawnPosition )
    {
        Transform levelPartTransform = Instantiate(LevelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }
}
