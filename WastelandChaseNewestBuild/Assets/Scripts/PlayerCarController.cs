using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CarMovement))]


public class PlayerCarController : CarInputBase
{

    CarMovement m_Movement;
    StatusBarControl m_NitroBar;
    CarInputBase carInput;

    public float NitroBoost = 1f;
    public float MaximumNitroBoost = 1.5f;
    public static float MaxNitroQuantity = 200f;
    public float CurrNitroQuantity = 200f;
    public bool Boosting = false;

    void Awake()
    {
        m_Movement = GetComponent<CarMovement>();
        m_NitroBar = GetComponent<StatusBarControl>();
        carInput = GetComponent<CarInputBase>();
        CurrNitroQuantity = MaxNitroQuantity;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Boosting)
        {
            //CurrNitroQuantity--;
            m_NitroBar.SetSize(CurrNitroQuantity / MaxNitroQuantity);
            if (CurrNitroQuantity == 0)
            {
                m_Movement.DeactivateNitro();
            }
        }
    }

    protected void UpdateSteeringDirection(float steeringDirection)
    {
        SetSteeringDirection(steeringDirection);
    }

    protected void UpdateEnginePower(float enginePower)
    {
        SetEnginePower(enginePower);
    }

    /*public void ActivateNitro()
    {
        //Debug.Log(CurrNitroQuantity);
        if (CurrNitroQuantity > 0)
        {
            
            Boosting = true;
            NitroActive();
        }
    }

    public void DeactivateNitro()
    {
        Boosting = false;
        NitroDeactive();
    }*/

}
