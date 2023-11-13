using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunProj : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float lifetime;
    public int projDir;
    int initDir;
    bool initOnce = false;

    void Start()
    {
        Invoke("DestroyProjectile", lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        if(!initOnce)
        {
            initDir = projDir;
            initOnce = true;
        }
        print("ProjDir = " + projDir);
        //print("initDir: " + initDir + " and " + transform.right);
        if (initDir == 1)
            transform.Translate(transform.right * speed * Time.deltaTime);
        else
            transform.Translate(-transform.right * speed * Time.deltaTime);
    }
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
