using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    [SerializeField] private StatusBarControl healthBar;
    private float MaxHealthQuantity = 1000f;
    private float DamageScalar = 5f;
    private float CurrHealthQuantity;
    private bool insideStorm = false;
    public float StormDamage = 1f;
    public bool Alive;
    void Awake()
    {
        Alive = true;
        SetHealthBar(1f);
        CurrHealthQuantity = MaxHealthQuantity;
    }

    // Update is called once per frame
    void Update()
    {
        if (insideStorm)
        {
            DamagePlayer(StormDamage);
        }
        if(CurrHealthQuantity <= 0 && Alive)
        {
            Alive = false;
            Time.timeScale = 0;
        }
    }

    private void SetHealthBar( float BarStatus)
    {
        healthBar.SetSize(BarStatus);
    }

    public void DamagePlayer( float DamagePoints )
    {
        if(CurrHealthQuantity < DamagePoints)
        {
            CurrHealthQuantity = 0;
        }
        else
        {
            CurrHealthQuantity -= DamagePoints * Time.timeScale;
        }
        SetHealthBar(CurrHealthQuantity / MaxHealthQuantity);
    }

    public void CollisionDamage( float relativeVelocity)
    {
        DamagePlayer(relativeVelocity * DamageScalar);
    }

    public void EnterSandStorm()
    {
        insideStorm = true;
    }

    public void ExitSandStorm()
    {
        insideStorm = false;
    }
}
