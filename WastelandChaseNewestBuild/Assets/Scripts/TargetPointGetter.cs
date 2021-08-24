using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPointGetter : MonoBehaviour
{
    [SerializeField] public List<Transform> TargetPoints;
    
    //  retuns point attached to player car for enemy to target
    public Transform GetTargetPoint( int PointNum)
    {
        return TargetPoints[PointNum];
    }
}
