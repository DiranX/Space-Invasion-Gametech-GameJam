using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    int index;
    public GameObject[] SpawnObject;
    public float spawnPosX;
    public float spawnDelay;
    public float spawnInterval;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObj", spawnDelay, spawnInterval);
    }

    // Update is called once per frame
    void SpawnObj()
    {
        index = Random.Range(0, SpawnObject.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnPosX, spawnPosX), transform.position.y, transform.position.z);

        GameObject spawnObj = Instantiate(SpawnObject[index], spawnPos, Quaternion.identity);
    }
}
