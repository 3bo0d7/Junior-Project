using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Spawn;
    CapsuleCollider2D capsule;
    BoxCollider2D box;
    void Start()
    {
        capsule = GetComponent<CapsuleCollider2D>();
        box = GetComponent<BoxCollider2D>();
        Spawner();
    }
    void Spawner()
    {
        int Rand = Random.Range(0, 10);
        if (Rand < 6)
        {
            Instantiate(Spawn, transform.position, transform.rotation);
            capsule.enabled = true;
            box.enabled = true;
        }
        else { 
        capsule.enabled = false;
        box.enabled = false;
    }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
