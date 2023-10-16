using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.GraphView;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class Boss_weapon_bullet : MonoBehaviour
{
    private GameObject Player;
    private Rigidbody2D rb;
    public Transform Player1;



    public float force;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = Player.transform.position - transform.position;
        rb.velocity = new Vector2 (direction.x, direction.y).normalized * force;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.transform.position.x > Player1.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (rb.transform.position.x < Player1.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player.SendMessage("Damage");
            gameObject.SetActive(false);


        }
    }


 


}
