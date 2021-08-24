using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHandler : MonoBehaviour
{
    public float speed;

    private Transform player;
    private Vector3 shootDir;
    private bool stuck = false;
    private Transform enemyCar;
    public float TimeToDestruct = 1000f;
    private float Counter = 0f;
    private Transform ropeAnchorPoint;

    private LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lineRenderer = GetComponentInChildren<LineRenderer>();
        lineRenderer.positionCount = 2;
        ropeAnchorPoint = transform.Find("RopeAnchor").transform;
    }

    public void setup(Vector3 shootDir, Transform firedBy) {
        this.shootDir = shootDir;
        transform.right = shootDir;
        this.enemyCar = firedBy;

    }
    
    // Update is called once per frame
    void Update() {
        if (!stuck)
        {
            transform.position -= shootDir * speed * Time.deltaTime;
            ++Counter;
            if(Counter >= TimeToDestruct){ 
                DestroyProjectile();
            }
        }
        if(transform != null){
        lineRenderer.SetPosition(0, ropeAnchorPoint.position);
        lineRenderer.SetPosition(1, enemyCar.position);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            enemyCar.GetComponent<EnemyShootingHandler>().SetFiring(false);
            this.transform.parent = other.transform;
            stuck = true;
            DistanceJoint2D joint = other.gameObject.AddComponent<DistanceJoint2D>();
            //joint.anchor = other.gameObject.GetComponent<Collider2D>().bounds.ClosestPoint(transform.position);
            joint.connectedBody = enemyCar.GetComponent<Rigidbody2D>();
            joint.maxDistanceOnly = true;
            //joint.autoConfigureDistance = true;
            joint.enableCollision = false;
            enemyCar.GetComponent<EnemyControl>().EnemyDead();
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
