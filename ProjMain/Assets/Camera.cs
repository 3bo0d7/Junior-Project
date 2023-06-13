using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Camera : MonoBehaviour
{
    [SerializeField] GameObject backgroundTop;
    [SerializeField] GameObject backgroundCave;



    private float length, startPosition;
    public GameObject cam1;
    public float parallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position.x;
        length = GetComponent <SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float temp = (cam1.transform.position.x * (1 - parallaxEffect));
        float dist = (cam1.transform.position.x * parallaxEffect);
        transform.position = new Vector3(startPosition + dist, transform.position.y, transform.position.z);

        if(temp > startPosition + length)
        {
            startPosition += length;

        }
        else if (temp < startPosition - length)
        {
            startPosition -= length;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CaveTrigger")
        {
            backgroundCave.SetActive(true);
            backgroundTop.SetActive(false);
        }

        if (collision.gameObject.tag == "TopTrigger")
        {
            backgroundTop.SetActive(true);
            backgroundCave.SetActive(false);
            
        }


    }
}
