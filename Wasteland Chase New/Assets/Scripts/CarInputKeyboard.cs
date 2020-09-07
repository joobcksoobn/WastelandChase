using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInputKeyboard : CarInputBase
{

    // Update is called once per frame
    void Update()
    {
        UpdateSteering();
        UpdateEnginePower();
        UpdateNitro();
    }

    void UpdateNitro()
    {
        SetNitro(Input.GetKey(KeyCode.F));
    }
    void UpdateSteering()
    {
        SetSteeringDirection( Input.GetAxisRaw( "Horizontal" ) );
    }
    void UpdateEnginePower()
    {
        SetEnginePower( Input.GetAxisRaw( "Vertical") );
    }
}
