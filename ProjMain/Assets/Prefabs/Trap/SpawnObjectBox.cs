using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectBox : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Spawn;
   
    BoxCollider2D box;
    void Start()
    {
        
        box = GetComponent<BoxCollider2D>();
        Spawner();
    }
    void Spawner()
    {
        int Rand = Random.Range(0, 10);
        if (Rand < 6)
        {
            Instantiate(Spawn, transform.position, transform.rotation);
            
            box.enabled = true;
        }
        else
        {
            
            box.enabled = false;
        }


    }

    // Update is called once per frame
    void Update()
    {

    }
}
