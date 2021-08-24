using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootingHandler : MonoBehaviour
{

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;
    private Transform player;
    private Transform target;


    private bool firing = true;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
        target = player.Find("ShootTargetPoint").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (firing)
        {
            if (timeBtwShots <= 0)
            {
                GameObject projectileTransform = Instantiate(projectile, transform.position, Quaternion.identity);
                Vector3 shootDir = (this.transform.position - target.transform.position).normalized;
                projectileTransform.GetComponent<ProjectileHandler>().setup(shootDir, this.transform);
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
    }

    public void SetFiring(bool toFire) {
        firing = toFire;
    }
}
