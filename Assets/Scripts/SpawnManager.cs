using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> prefabs;
    private float xSpawnRange = 13;
    private float zSpawn = 150;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ContinuousSpawn());
    }


    IEnumerator ContinuousSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            SpawnObject();
        }
        
    }

    Vector3 RandomSpawnPosition()
    {
        return new Vector3(Random.Range(-xSpawnRange, xSpawnRange), 0.76f, zSpawn);
    }
    GameObject SpawnObject()
    {
        int randomIndex = Random.Range(0, prefabs.Count);
        return Instantiate(prefabs[randomIndex], RandomSpawnPosition(), prefabs[randomIndex].transform.rotation);
    }
}
