using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftRight : MonoBehaviour
{
    // Start is called before the first frame update
    int moveDirection = 1;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(moveDirection * 2, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Flip")
            moveDirection *= -1;
    }
}
