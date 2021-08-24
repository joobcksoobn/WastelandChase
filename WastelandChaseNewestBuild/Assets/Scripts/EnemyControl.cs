using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CarMovement))]
public class EnemyControl : MonoBehaviour
{
    CarMovement m_Movement;
    WheelTurnHandler m_wheelTurn;
    TargetPointGetter m_TargetPointGetter;
    [SerializeField] private Transform targetObj;   //  Parent player object to target
    private Transform target;   //  Specific point in target object to lock on to
    public float MaximumEnginePower = 1f;
    public float MaximumSteeringPower = 1f;
    private bool EnemyActive = false;   //  Bool keeping track of if enemy should start chasing
    public float DistToDestroy = 20f;
    public int TargetPointIndex;
    private void Awake()
    {
        targetObj = GameObject.FindWithTag("Player").transform;
        m_Movement = GetComponent<CarMovement>();
        m_wheelTurn = GetComponent<WheelTurnHandler>();
        m_TargetPointGetter = targetObj.GetComponent<TargetPointGetter>();
        SelectTargetPoint();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(targetObj == null)
        {
            targetObj = GameObject.FindWithTag("Player").transform;
        }
        if (EnemyActive)
        {
            UpdateSteering();
            UpdateEnginePower();
            //Destroy enemy if far enough away
            if(Vector3.Distance(transform.position, targetObj.transform.position) > DistToDestroy)
            {
                DestroyEnemy();
            }
            if(Vector3.Distance(transform.position, target.position) > 1) { }
        }
        
    }
    private void UpdateSteering()
    {
        Vector3 relativePosition = this.transform.InverseTransformPoint(target.transform.position);
        float steeringDirection = Mathf.Clamp(MaximumSteeringPower * relativePosition.x, -1f, 1f);
        m_Movement.SetSteeringDirection(steeringDirection);
        if (m_wheelTurn != null)
        {
            m_wheelTurn.SetWheelAngle(steeringDirection);
        }
    }
    private void UpdateEnginePower()
    {
        m_Movement.SetEnginePower(MaximumEnginePower);
    }

    public void ActivateEnemy()
    {
        EnemyActive = true;
    }

    public void DestroyEnemy()
    {
        Destroy(this.gameObject);
    }

    public void EnemyDead()
    {
        EnemyActive = false;
        m_Movement.SetEnginePower(0f);
    }

    public void SelectTargetPoint()
    {
        TargetPointIndex = Random.Range(0, 3);
        target = m_TargetPointGetter.GetTargetPoint(TargetPointIndex);
    }

    public void targetPlayer()
    {
        target = targetObj;
    }
    
}
