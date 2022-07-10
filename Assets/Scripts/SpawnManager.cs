using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> prefabs;
    private float zSpawn = 150;
    private GameManager gameManager;
    private float spawnInterval = 2f;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        StartCoroutine(ContinuousSpawn());
    }


    IEnumerator ContinuousSpawn()
    {
        while (gameManager.isGameActive)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnObject();
        }
        
    }

    Vector3 RandomSpawnPosition(GameObject prefabObject)
    {
        float range = prefabObject.GetComponent<Vehicle>().xSpawnRange;
        return new Vector3(Random.Range(-range, range), 0.76f, zSpawn);
    }
    void SpawnObject()
    {
        spawnInterval -= 0.01f;
        if(spawnInterval < 1)
        {
            spawnInterval = 1;
        }
        int randomIndex = Random.Range(0, prefabs.Count);
        GameObject spawnObject = prefabs[randomIndex];
        if (spawnObject.name.Equals("Bus") || spawnObject.name.Equals("Van"))
        {
            MakeObject(spawnObject);
            MakeObject(spawnObject);
            MakeObject(spawnObject);
        } else if(spawnObject.name.Equals("Car") || spawnObject.name.Equals("Truck"))
        {
            MakeObject(spawnObject);
        }
        MakeObject(spawnObject);
    }

    void MakeObject(GameObject newObject)
    {
        Instantiate(newObject, RandomSpawnPosition(newObject), newObject.transform.rotation);
    }
}
