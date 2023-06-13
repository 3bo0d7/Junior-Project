using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject spawn;
        BoxCollider2D boxCollider;
    void Start()
    {
      boxCollider = GetComponent<BoxCollider2D>();  
        boxCollider.enabled = false;    
    }
    void Spawn()
    {
            boxCollider.enabled = true;
            Instantiate(spawn, transform.position, transform.rotation);
         
        }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Spawn();
        }
    }


}
  
