using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    private Snapping snapping;
    public static bool isDemoStart;
    public static GameObject selectObject;
    public ConveyorManager conveyorManager;


    private void Start()
    {
        snapping = new Snapping();
        isDemoStart = false;
        //conveyorManager = GetComponent<ConveyorManager>();
    }
    private void Update()
    {
        if (isDemoStart) { return; }
        if (Input.GetMouseButtonDown(0))
        {
            // Select Object
            
            if (selectObject == null)
            {
                RaycastHit hit = CastRay();
                if (hit.collider != null)
                {
                    if (!hit.collider.CompareTag("Conveyor"))
                    {
                        return;
                    }

                    selectObject = hit.collider.gameObject;
                    conveyorManager.DetachConveyor(selectObject.GetComponent<Conveyor>());
                    Cursor.visible = false;
                }

            }
        }

        if (selectObject != null && Input.GetMouseButton(0))
        {
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y,
                Camera.main.WorldToScreenPoint(selectObject.transform.position).z);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
            selectObject.transform.position = new Vector3(worldPosition.x, 0, worldPosition.z);
        }

        // Release Object
        if (Input.GetMouseButtonUp(0) && selectObject != null)
        {
            conveyorManager.DetachConveyor(selectObject.GetComponent<Conveyor>());
            BoxCollider box = selectObject.GetComponent<BoxCollider>();
            Collider[] hits = Physics.OverlapBox(box.bounds.center,
                box.bounds.extents,
                Quaternion.identity);


            foreach (Collider hit in hits)
            {
                if (hit.transform.root == selectObject.transform.root)
                    continue;
                if (hit.gameObject.CompareTag("Conveyor"))
                {
                    bool isSelectBeforeTarget;
                    Transform newPosition = snapping.calculateNewPosition(selectObject.transform, hit.transform, out isSelectBeforeTarget);
                    selectObject.transform.position = newPosition.position;

                    // Adding the Conveyor to list
                    Conveyor oldCon = hit.gameObject.GetComponent<Conveyor>();
                    Conveyor selectCon = selectObject.GetComponent<Conveyor>();
                    if (isSelectBeforeTarget)
                    {
                        conveyorManager.AddConveyor(selectCon, oldCon);
                    }
                    else
                    {
                        conveyorManager.AddConveyor(oldCon, selectCon);
                    }

                    Debug.Log("Overlapping!" + hit.name);
                }
            }

            

            selectObject = null;
            Cursor.visible = true;
        }
        

    }

    private RaycastHit CastRay()
    {
        Vector3 screenMousePosFar = new Vector3(Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.farClipPlane);

        Vector3 screenMousePosNear = new Vector3(Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.nearClipPlane);

        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit hit;
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit);

        return hit;
    }

}