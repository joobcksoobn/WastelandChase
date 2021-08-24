using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float PLAYER_DIST_SPAWN_LEVEL_PART = 30f;
    //[SerializeField] FollowPath StormPath;
    [SerializeField] private Transform LevelPartStart;
    [SerializeField] private Transform StartPoint;
    [SerializeField] private List<Transform> LevelPartList;
    [SerializeField] private Transform player;
    private Vector3 lastEndPosition;
    private float currRoadRotation = 0f;
    private float maxNumRoadPieces = 10f;   //  number of road pieces to create before deleteing ones behind player
    public Queue<Transform> roadPieces;

    private void Awake()
    {
        roadPieces = new Queue<Transform>();
        SpawnLevelPart(LevelPartStart, StartPoint.position, currRoadRotation);
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
        if(roadPieces.Count >= maxNumRoadPieces)
        {
            DeleteLastRoadPiece();
        }
    }
    private Transform SpawnLevelPart( Transform LevelPart, Vector3 spawnPosition, float rotation )
    {
        Transform levelPartTransform = Instantiate(LevelPart, spawnPosition, Quaternion.Euler(new Vector3(0,0,rotation)));
        roadPieces.Enqueue(levelPartTransform);
        return levelPartTransform;

    }

    private void DeleteLastRoadPiece()
    {
        Transform lastRoadPiece = roadPieces.Dequeue();
        Destroy(lastRoadPiece.gameObject);
    }
}
