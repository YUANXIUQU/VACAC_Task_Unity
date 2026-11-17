using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Snapping
{
    public Transform calculateNewPosition(Transform selectObject, Transform target)
    {
        Transform SelectStart = selectObject.Find("Start");
        Transform SelectEnd = selectObject.Find("End");
        Transform TargetStart = target.Find("Start");
        Transform TargetEnd = target.Find("End");

        Vector3 offset1 = TargetEnd.position- SelectStart.position;
        Vector3 offset2 = TargetStart.position - SelectEnd.position;
        if(offset1.magnitude>offset2.magnitude)
        {
            selectObject.position += offset2;
        }
        else
        {
            selectObject.position += offset1;
        }

        return selectObject;
    }
}