using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public float degToRotate = 67f;
    public bool rotateClockwise = false;
    public bool rotateCounter = false;
    [SerializeField] private Transform m_Camera;
    // Update is called once per frame
    void Update()
    {
        if(rotateClockwise)
        {
            m_Camera.transform.Rotate(0f, 0f, -1f);
            degToRotate--;
            if (degToRotate == 0)
            {
                rotateClockwise = false;
            }
        }
        if (rotateCounter)
        {
            m_Camera.transform.Rotate(0f, 0f, 1f);
            degToRotate--;
            if(degToRotate == 0)
            {
                rotateCounter = false;
            }
        }
    }
    public void CameraRotateCounterClockwise()
    {
        degToRotate = 67f;
        rotateCounter = true;
        //m_Camera.transform.Rotate(0f, 0f, degToRotate);
        
    }
    public void CameraRotateClockwise()
    {
        degToRotate = 67f;
        rotateClockwise = true;
    }
}
