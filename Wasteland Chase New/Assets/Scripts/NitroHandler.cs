using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NitroHandler : MonoBehaviour
{
    [SerializeField] private NitroBar nitroBar;
    float MaxNitroQuantity = 200f;
    float CurrNitroQuantity;
    void Awake()
    {
        nitroBar.SetSize(1f);
        CurrNitroQuantity = MaxNitroQuantity;
    }

    public bool BurnNitro()     //If Player has nitro, updates Nitro amount and Bar and return true
    {
        if(CurrNitroQuantity-- > 0){
            nitroBar.SetSize(CurrNitroQuantity/MaxNitroQuantity);
            return true;
        }
        return false;
    }
}
