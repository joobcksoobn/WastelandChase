using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollision : MonoBehaviour
{
    CarMovement m_Movement;
    CameraBehavior m_Camera;
    HealthHandler m_PlayerHealth;
    [SerializeField] DistCounter m_distCount;
    private int offCourseCounter = 0;   //  counter to keep track of if car drove from one off course trigger into another
    

    private void Awake()
    {
        m_Movement = GetComponent<CarMovement>();
        m_Camera = GetComponent<CameraBehavior>();
        m_PlayerHealth = GetComponent<HealthHandler>();
    }

    private void OnCollisionEnter2D( Collision2D collision )
    {
        //Debug.Log( "Colliding with " + collision.collider.name + ".Tag: " + collision.collider.tag );
        if( collision.collider.CompareTag( "Obstacle" ) == true)
        {
            m_Movement.OnCollideWithObstacle();
            m_PlayerHealth.CollisionDamage(collision.relativeVelocity.magnitude);
        }
        if (collision.collider.CompareTag("EnemyCar") == true)
        {
            m_PlayerHealth.CollisionDamage(collision.relativeVelocity.magnitude);
        }
    }

    private void OnTriggerEnter2D( Collider2D  otherCollider )
    {
        if( otherCollider.CompareTag( "Oil" ) == true)
        {
            m_Movement.OnCollideWithOil();
        }
        if( otherCollider.CompareTag( "OffCourseArea" ) == true)
        {
            offCourseCounter++;
            m_Movement.OnEnterOffCourseArea();
        }
        if( otherCollider.CompareTag( "CamRotateCounterClockwise" ) )
        {
            m_Camera.CameraRotateCounterClockwise();
            otherCollider.enabled = false;
        }
        if (otherCollider.CompareTag("CamRotateClockwise"))
        {
            m_Camera.CameraRotateClockwise();
            otherCollider.enabled = false;
        }
        if (otherCollider.CompareTag("SandStorm") == true)
        {
            m_PlayerHealth.EnterSandStorm();
        }
        if(otherCollider.CompareTag("Waypoint") == true)
        {
            m_distCount.addScore(5);
            otherCollider.enabled = false;
        }
    }

    private void OnTriggerExit2D( Collider2D otherCollider )
    {
        if( otherCollider.CompareTag( "OffCourseArea" ) == true)
        {
            if (--offCourseCounter < 1)
            {
                m_Movement.OnExitOffCourseArea();
            }
        }
        if (otherCollider.CompareTag("SandStorm") == true)
        {
            m_PlayerHealth.ExitSandStorm();
        }
    }

   

}
