using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obstacle;
    public float spawnRate;

    private LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        InvokeRepeating("SpawnObstacle", 2f, 1.25f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnObstacle()
    {
        Vector3 randPosition = new Vector3(transform.position.x, Random.Range(-2.5f, 2.5f), transform.position.z);
        Instantiate(obstacle, randPosition, Quaternion.identity);
    }
}
