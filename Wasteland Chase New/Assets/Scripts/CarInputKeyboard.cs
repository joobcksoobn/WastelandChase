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
