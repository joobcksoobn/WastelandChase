using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float MaximumEngineForce;
    public float MaximumSteeringTorque;
    public float MaximumReverseEngineForce;
    public float ReversePower;
    public float Acceleration;
    public float Deceleration;
    public float MinSpeedToTurn = 0.1f;
    public float SandSlowDown;
    float m_EnginePower = 0f;
    float m_TargetEnginePower = 0f;
    float m_steeringDirection = 0f;
    float m_CurrentMaximumEnginePower = 1f;
    Rigidbody2D m_Body;
    public Vector3 COM;
    public float MaximumNitroForce;
    float CurrNitroForce;


    private void Awake(){
        m_Body = GetComponent<Rigidbody2D>();
        m_Body.centerOfMass = COM;
        CurrNitroForce = 0f;
    }

    private void Update()
    {
        UpdateEnginePower();
    }

    void UpdateEnginePower()    //Update engine power progressively moving towards target
    {
        float acceleration = Acceleration;

        if( m_TargetEnginePower == 0f )
        {
            acceleration = Deceleration;
        }
        float targetEnginePower = m_TargetEnginePower * m_CurrentMaximumEnginePower;    //factor in if player is slowed down (like by sand)
        m_EnginePower = Mathf.MoveTowards( m_EnginePower, targetEnginePower, acceleration * Time.deltaTime );   //set engine power closer to target (eventually reaching full power)
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ApplyEngineForce();
        ApplySteeringForce();
        ApplyNitro();
    }

    void ApplyEngineForce()
    {
        float maximumEngineForce = MaximumEngineForce;
        if( m_EnginePower < 0f )
        {
            maximumEngineForce = MaximumEngineForce;
        }
        m_Body.AddForce( transform.up * m_EnginePower * MaximumEngineForce, ForceMode2D.Force );
    }

    void ApplySteeringForce()
    {
        if (m_Body.velocity.magnitude > MinSpeedToTurn)
        {
            m_Body.AddTorque(m_steeringDirection * MaximumSteeringTorque, ForceMode2D.Force);
        }
    }

    void ApplyNitro()
    {
        m_Body.AddForce( transform.up * CurrNitroForce, ForceMode2D.Force );
    }

    public void SetEnginePower( float enginePower ){    //set engine power based on input from user
        m_TargetEnginePower = Mathf.Clamp( enginePower, -1f, 1f);
    }
    public void SetSteeringDirection( float steeringDirection){
        m_steeringDirection = steeringDirection;
    }
    public void OnCollideWithObstacle()
    {
        m_EnginePower = 0f;
    }

    public void OnCollideWithOil()
    {
        m_EnginePower = 0f;
    }

    public void OnEnterOffCourseArea()
    {
        m_CurrentMaximumEnginePower = SandSlowDown;
    }

    public void OnExitOffCourseArea()
    {
        m_CurrentMaximumEnginePower = 1f;
    }

    public void ActivateNitro()
    {
        CurrNitroForce = MaximumNitroForce;
    }
    
    public void DeactivateNitro()
    {
        CurrNitroForce = 0f;
    }
}
