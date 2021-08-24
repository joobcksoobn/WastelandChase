using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointHandler : MonoBehaviour
{
    [SerializeField] public List<Transform> waypoints;
    private Transform sandStorm;
    private FollowPath waypointPath;

    // Start is called before the first frame update
    void Start()
    {
        sandStorm = GameObject.FindWithTag("SandStorm").transform;
        waypointPath = sandStorm.GetComponent<FollowPath>();
        PassWaypoints();
    }

    public void PassWaypoints()
    {
        foreach(Transform point in waypoints)
        {
            waypointPath.AddWaypoint(point);
        }
    }
}
