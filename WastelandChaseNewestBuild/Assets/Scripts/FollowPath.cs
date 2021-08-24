using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    // queue of waypoints to travel between
    public Queue<Transform> waypoints;
    Transform currWaypoint;

    // Speed that sandstorm moves
    [SerializeField] private float moveSpeed = 2f;
    public float rotationSpeed = 10f;

    //Index of current waypoint
    private int waypointIndex = 0;

    void Awake()
    {
        // Set position of storm to first waypoint
        waypoints = new Queue<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //  move storm
        Move();
    }

    private void Move()
    {
        if (waypoints.Count > 0)
        {
            if (currWaypoint == null)
            {
                while (currWaypoint == null)
                {
                    currWaypoint = waypoints.Dequeue();
                }
                transform.position = currWaypoint.transform.position;
            }
            else
            {
                //  move storm from current waypoint to next one
                transform.position = Vector3.MoveTowards(transform.position,
                    currWaypoint.transform.position,
                    moveSpeed * Time.deltaTime);

            }
            //  rotate the sandstorm to face the waypoint
            /*if (Vector3.Distance(currWaypoint.position, transform.position) > 0.1)
            {
                Vector3 targ = currWaypoint.transform.position;
                targ.z = 0f;

                Vector3 objectPos = transform.position;
                targ.x = targ.x - objectPos.x;
                targ.y = targ.y - objectPos.y;

                float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Slerp(transform.rotation, 
                    Quaternion.Euler(new Vector3(0, 0, angle)), 
                    Time.deltaTime * rotationSpeed);
            }*/
            if (transform.position == currWaypoint.transform.position)
            {
                currWaypoint = waypoints.Dequeue();
            }
        }
    }

    public void AddWaypoint(Transform newPoint)
    {
        waypoints.Enqueue(newPoint);
    }
}
