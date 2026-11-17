using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorManager : MonoBehaviour
{
    public Conveyor Head;
    public void Start()
    {
    }
    public void AddConveyor(Conveyor oldCon,Conveyor newCon)
    {
        oldCon.nextConveyor = newCon;
        newCon.previousConveyor = oldCon;
    }

    public void DetachConveyor(Conveyor curCon)
    {
        Conveyor previous = curCon.previousConveyor;
        Conveyor next = curCon.nextConveyor;

        // Update previous node
        if (previous != null)
        {
            previous.nextConveyor = null;
            Debug.Log("Detach!");
        }

        // Update next node
        if (next != null)
        {
            next.previousConveyor = null;
            Debug.Log("Detach!");
        }
        curCon.nextConveyor = null;
        curCon.previousConveyor = null;
    }


}
