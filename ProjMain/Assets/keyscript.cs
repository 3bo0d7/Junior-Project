using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyscript : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject key;
    public Vector2[] spawnPositions;
    public float spawnDelay = 2f;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        SpawnObject();
    }

    // Update is called once per frame
    void Update()
    {
      /*  timer += Time.deltaTime;
        if (timer >= spawnDelay)
        {
            SpawnObject();
            timer = 0f;
        }*/
    }

    void SpawnObject()
    {
        int randomIndex = Random.Range(0, 5);
        Vector2 positionToSpawn = spawnPositions[randomIndex];
        print("spawning: " + positionToSpawn);
        Instantiate(key, positionToSpawn, Quaternion.identity);
    }
}

