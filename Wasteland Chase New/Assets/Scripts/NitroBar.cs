using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NitroBar : MonoBehaviour
{
    private Transform bar;
    private void Start()
    {
        bar = transform.Find("Bar");
    }

    public void SetSize(float sizeNormalized)
    {
        bar = transform.Find("Bar");
        Debug.Log("SetSize");
        bar.localScale = new Vector3(1f, sizeNormalized);
    }
}
