using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_weapon_ranged : MonoBehaviour
{
    public GameObject Box;
    public Transform BoxPOS;
    private float timer;
 
    /*
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2)
        {
            timer = 0;
            shoot();

        }
    }
 
    void shoot()
    {

        Instantiate(Box, BoxPOS.position, Quaternion.identity);


    }
  /*  IEnumerator Destroy()
    {
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);

    }*/
    
}
