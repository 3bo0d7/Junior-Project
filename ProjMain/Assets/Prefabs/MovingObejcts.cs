using UnityEngine;

public class MovingObejcts : MonoBehaviour
{
    // Start is called before the first frame update
    int moveDirection = 1;
    Rigidbody2D enemyRigidBody;

    void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyRigidBody.velocity = new Vector2(moveDirection * 2, 0);
        transform.localScale = new Vector2(moveDirection, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Rborder")
            moveDirection *= -1;
    }
}
