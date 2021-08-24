using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NitroHandler : MonoBehaviour
{
    [SerializeField] private StatusBarControl nitroBar;
    private float MaxNitroQuantity = 1000f;
    private float CurrNitroQuantity;
    private bool Boosting = false;
    void Awake()
    {
        SetNitroBar(1f);
        CurrNitroQuantity = MaxNitroQuantity;
    }

    private void Update()
    {
        if(Boosting == false && CurrNitroQuantity < MaxNitroQuantity)
        {
            CurrNitroQuantity += 0.5f;
            SetNitroBar(CurrNitroQuantity / MaxNitroQuantity);
        }
    }

    public bool BurnNitro()     //If Player has nitro, updates Nitro amount and Bar and return true
    {
        if(CurrNitroQuantity > 0){
            SetNitroBar(--CurrNitroQuantity/MaxNitroQuantity);
            Boosting = true;
            return true;
        }
        Boosting = false;
        return false;
    }

    public void ReleaseNitro()
    {
        Boosting = false;
    }

    private void SetNitroBar( float BarStatus )
    {
        nitroBar.SetSize(BarStatus);
    }
}
