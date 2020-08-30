using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollision : MonoBehaviour
{
    CarMovement m_Movement;
    CameraBehavior m_Camera;
    private void Awake()
    {
        m_Movement = GetComponent<CarMovement>();
        m_Camera = GetComponent<CameraBehavior>();
    }

    private void OnCollisionEnter2D( Collision2D collision )
    {
        //Debug.Log( "Colliding with " + collision.collider.name + ".Tag: " + collision.collider.tag );
        if( collision.collider.CompareTag( "Obstacle" ) == true)
        {
            m_Movement.OnCollideWithObstacle();
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
            m_Movement.OnEnterOffCourseArea();
        }
        if( otherCollider.CompareTag( "CamRotateCounterClockwise" ) )
        {
            m_Camera.CameraRotateCounterClockwise();
        }
        if (otherCollider.CompareTag("CamRotateClockwise"))
        {
            m_Camera.CameraRotateClockwise();
        }
    }

    private void OnTriggerExit2D( Collider2D otherCollider )
    {
        if( otherCollider.CompareTag( "OffCourseArea" ) == true)
        {
            m_Movement.OnExitOffCourseArea();
        }
    }

}
