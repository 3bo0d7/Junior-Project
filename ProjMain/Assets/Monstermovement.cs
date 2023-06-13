using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monstermovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float attackDistance = 1f;
    public float attackRate = 1f;
    public int damage = 10;
    public bool attack = false;

    private Transform target;
    private float nextAttackTime;
    public Transform playerTransform;
    Animator playerAnimator;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        playerAnimator = GetComponent<Animator>();

    }

    void Update()
    {
        if (target != null)
        {
            float distance = Vector3.Distance(transform.position, target.position);

            if (distance < attackDistance)
            {
                if (Time.time > nextAttackTime)
                {
                    nextAttackTime = Time.time + attackRate;
                    //target.GetComponent<Player>().TakeDamage(damage);
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            }
        }

        if (transform.position.x > playerTransform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }

        if (transform.position.x < playerTransform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);

            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
    }

    private bool isTargetInRange(float range, Vector3 targetLocation)
    {
        float distance = Vector3.Distance(transform.position, targetLocation);
        if (distance < range)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            attack = true;
            playerAnimator.SetBool("isattack", attack);
        }
    }


}