using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActiveAreaControl : MonoBehaviour
{
    private Transform Player;
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
        transform.position = Player.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.position;
    }
}
