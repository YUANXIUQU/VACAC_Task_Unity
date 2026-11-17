using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ShortConveyorPrefab;
    [SerializeField] private GameObject LongConveyorPrefab;
    [SerializeField] private GameObject InclineConveyorPrefab;

    [SerializeField] private Transform spawnPoint;
    public ProductMovement movement;
    public void SpawnShortConveyor()
    {
        if (!Grabber.isDemoStart)
        {
            Instantiate(
            ShortConveyorPrefab,
            spawnPoint.position,
            ShortConveyorPrefab.transform.rotation);
        }
    }
    

    public void SpawnLongConveyor()
    {
        if (!Grabber.isDemoStart)
        {
            Instantiate(
            LongConveyorPrefab,
            spawnPoint.position,
            LongConveyorPrefab.transform.rotation);
        }
    }

    public void SpawnInclineConveyor()
    {
        if (!Grabber.isDemoStart)
        {
            Instantiate(
            InclineConveyorPrefab,
            spawnPoint.position,
            InclineConveyorPrefab.transform.rotation);
        }
    }

    public void ProductDemo()
    {
        if (!Grabber.isDemoStart)
        { movement.startProduct(); }
    }

}
