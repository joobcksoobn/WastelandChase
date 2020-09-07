using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof( CarMovement ))]
public class CarInputBase : MonoBehaviour{
    CarMovement m_Movement;
    NitroHandler m_Nitro;

    private void Awake()
    {
        m_Movement = GetComponent<CarMovement>();
        m_Nitro = GetComponent<NitroHandler>();
    }
    
    protected void SetSteeringDirection( float steeringDirection )
    {
        m_Movement.SetSteeringDirection( steeringDirection );
    }

    protected void SetEnginePower( float enginePower)
    {
        m_Movement.SetEnginePower( enginePower );
    }

    protected void SetNitro( bool nitroStatus)
    {
        if(nitroStatus && m_Nitro.BurnNitro())
        {
            m_Movement.ActivateNitro();
        }
        else{
            m_Movement.DeactivateNitro();
        }
    }
}
