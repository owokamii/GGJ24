using System.Collections.Generic;
using UnityEngine;

public class RandomItemSpawner : MonoBehaviour
{
    public List<GameObject> itemsToSpawn;
    public List<Transform> spawnPoints;

    public List<GameObject> spawns;
    public List<Transform> waterPosition;

    void Start()
    {
        SpawnItems();
        SpawnFloorItem();
    }

    void SpawnItems()
    {
        foreach (var item in itemsToSpawn)
        {
            if (spawnPoints.Count == 0)
            {
                Debug.LogWarning("No more spawn points available.");
                break;
            }

            int spawnIndex = Random.Range(0, spawnPoints.Count);
            Transform spawnPoint = spawnPoints[spawnIndex];
            spawnPoints.RemoveAt(spawnIndex);

            Instantiate(item, spawnPoint.position, spawnPoint.rotation);
        }
    }

    void SpawnFloorItem()
    {
        foreach (var itemList in spawns)
        {
            foreach (var item in spawns)
            {
                if (waterPosition.Count == 0)
                {
                    Debug.LogWarning("No more water spawn points available.");
                    break;
                }

                int spawnIndex = Random.Range(0, waterPosition.Count);
                Transform spawnPoint = waterPosition[spawnIndex];
                waterPosition.RemoveAt(spawnIndex);

                Instantiate(item, spawnPoint.position, spawnPoint.rotation);
            }
        }
    }

}
