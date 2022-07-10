using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> prefabs;
    private float xSpawnRange = 13;
    private float zSpawn = 150;
    private GameManager gameManager;
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
