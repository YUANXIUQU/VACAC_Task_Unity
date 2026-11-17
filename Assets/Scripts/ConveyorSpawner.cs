using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ShortConveyorPrefab;
    [SerializeField] private GameObject LongConveyorPrefab;
    [SerializeField] private GameObject InclineConveyorPrefab;

    [SerializeField] private Transform spawnPoint;
    public void SpawnShortConveyor()
    {
        Instantiate(
            ShortConveyorPrefab,
            spawnPoint.position,
            ShortConveyorPrefab.transform.rotation
        );
    }

    public void SpawnLongConveyor()
    {
        Instantiate(
            LongConveyorPrefab,
            spawnPoint.position,
            LongConveyorPrefab.transform.rotation
        );
    }

    public void SpawnInclineConveyor()
    {
        Instantiate(
            InclineConveyorPrefab,
            spawnPoint.position,
            InclineConveyorPrefab.transform.rotation
        );
    }


}
