using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingSounds : MonoBehaviour
{
    [SerializeField] AudioSource footsteps;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            footsteps.enabled = true;
        }
        else
        {
            footsteps.enabled = false;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            footsteps.enabled = false;
        }

    }


}