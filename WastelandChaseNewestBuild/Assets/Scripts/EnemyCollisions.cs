using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisions : MonoBehaviour
{
    CarMovement m_Movement;
    EnemyControl m_Control;
    public bool CollidesOil, CollidesSand;
    private void Awake()
    {
        m_Movement = GetComponent<CarMovement>();
        m_Control = GetComponent<EnemyControl>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Obstacle") == true)
        {
            m_Movement.OnCollideWithObstacle();
            m_Control.EnemyDead();
        }
        //if(collision.collider.CompareTag("Player") == true) { }
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if ((otherCollider.CompareTag("Oil") == true) && CollidesOil)
        {
            m_Movement.OnCollideWithOil();
        }
        if ((otherCollider.CompareTag("OffCourseArea") == true) && CollidesSand)
        {
            m_Movement.OnEnterOffCourseArea();
        }
        if ((otherCollider.CompareTag("EnemyActiveArea") == true))
        {
            m_Control.ActivateEnemy();
        }

        if ((otherCollider.CompareTag("AttackPlayerRange") == true))
        {
            m_Control.targetPlayer();
        }

    }

    private void OnTriggerExit2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag("OffCourseArea") == true)
        {
            m_Movement.OnExitOffCourseArea();
        }
        if(otherCollider.CompareTag("AttackPlayerRange") == true)
        {
            m_Control.SelectTargetPoint();
        }
    }

}