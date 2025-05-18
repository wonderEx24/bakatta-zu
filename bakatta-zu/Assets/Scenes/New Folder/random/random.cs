using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public int spawnCount = 10;
    public float range = 10f;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < spawnCount; i++)
        {
Vector3 randomPosittion = new Vector3(
        Random.Range(-range, range),
        0,
        Random.Range(-range, range)
    );

    Instantiate(prefabToSpawn, randomPosittion, Quaternion.identity);

        }
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
