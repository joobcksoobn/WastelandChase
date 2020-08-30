using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CarMovement))]
public class EnemyControl : MonoBehaviour
{
    CarMovement m_Movement;
    [SerializeField] private Transform target;
    public float MaximumEnginePower = 1f;
    public float MaximumSteeringPower = 1f;
    private void Awake()
    {
        m_Movement = GetComponent<CarMovement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(target == null)
        {
            target = GameObject.FindWithTag("Player").transform;
        }
        UpdateSteering();
        UpdateEnginePower();
    }
    void UpdateSteering()
    {
        Vector3 relativePosition = this.transform.InverseTransformPoint(target.transform.position);
        if(relativePosition.x < 0)
        {
            m_Movement.SetSteeringDirection(Mathf.Clamp(MaximumSteeringPower * relativePosition.x,-1f,1f));
        }
        if(relativePosition.x > 0)
        {
            m_Movement.SetSteeringDirection(Mathf.Clamp(MaximumSteeringPower * relativePosition.x,-1f,1f));
        }
    }
    void UpdateEnginePower()
    {
        m_Movement.SetEnginePower(MaximumEnginePower);
    }
}
