using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInputKeyboard : CarInputBase
{

    protected Joystick joystick;
    protected Joybutton joybutton;
    // Update is called once per frame
    void Update()
    {
        joystick = FindObjectOfType<Joystick>();
        joybutton = FindObjectOfType<Joybutton>();
        UpdateSteering();
        UpdateEnginePower();
        UpdateNitro();
    }

    void UpdateNitro()
    {
        if (joybutton.pressed)
        {
            SetNitro(true);
        }
        else
        {
            SetNitro(Input.GetKey(KeyCode.F));
        }
    }
    void UpdateSteering()
    {
        float joyInput = joystick.Horizontal;
        if (joyInput != 0)
        {
            SetSteeringDirection(joyInput);
        }
        else
        {
            SetSteeringDirection(Input.GetAxisRaw("Horizontal"));
        }
    }
    void UpdateEnginePower()
    {
        float joyInput = joystick.Vertical;
        if (joyInput > 0)
        {
            SetEnginePower(1f);
        }
        else if(joyInput < 0)
        {
            SetEnginePower(-1f);
        }
        else
        {
            SetEnginePower(Input.GetAxisRaw("Vertical"));
        }
    }
}
