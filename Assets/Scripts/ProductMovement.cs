using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductMovement : MonoBehaviour
{
    public ConveyorManager conveyorManager;
    public GameObject productPrefab;
    public GameObject product;
    private Transform productTransform;
    private Conveyor currCon;
    void Start()
    {

    }
    public void startProduct()
    {
        Grabber.isDemoStart = true;
        currCon = conveyorManager.Head;
        product = Instantiate(productPrefab, currCon.startPoint.position, productPrefab.transform.rotation);
        Vector3 direction = currCon.endPoint.position - currCon.startPoint.position;
        product.transform.rotation = Quaternion.LookRotation(direction);
        productTransform = product.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (currCon != null && product != null)
        {
            productTransform.position = Vector3.MoveTowards(
            productTransform.position, currCon.endPoint.position, 1.5f * Time.deltaTime);


            if (Vector3.Distance(
            productTransform.position,
            currCon.endPoint.position) < 0.01f)
            {
                // Switch to next conveyor
                currCon = currCon.nextConveyor;
                

                // No next conveyor
                if (currCon == null)
                {
                    Destroy(product);
                    Grabber.isDemoStart=false;
                    //return;
                }
                else
                {
                    Vector3 direction = currCon.endPoint.position - currCon.startPoint.position;
                    product.transform.rotation = Quaternion.LookRotation(direction);
                }
            }
        }
    }
}
