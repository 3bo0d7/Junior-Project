using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Weapon : MonoBehaviour
{
    private GameObject Player;
    Animator animator;
    Rigidbody2D playerRigidbody;

    private bool attacking = false;
    private bool Rangedattack = true;
    private bool Meleeattack = false;
    private float timer = 0f;
    private float timeToAttack = 0.25f;

    public Transform playerTransform;
    public Transform enemyTransform;
    public float meleeRange = 3f;

    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;

    public GameObject Box;
    public Transform BoxPOS;
    private float timer1;



    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(playerTransform.position, enemyTransform.position);
        print("Distance: " + distance);

        if (distance < meleeRange)
        {
            Meleeattack = true;
            Rangedattack = false;
            // Switch to melee attack
            MeleeAttack();
        }
        else if(distance < 6)
        {
            Meleeattack = false;
            Rangedattack = true;
            // Switch to ranged attack
            RangedAttack();
        }
        else
        {
            Meleeattack = false;
            Rangedattack = false;
            animator.SetBool("MeleeAttack", Meleeattack);
            animator.SetBool("RangedAttack", Rangedattack);
        }

    }

    void MeleeAttack()
    {
        // melee attack logic here
        animator.SetBool("MeleeAttack", Meleeattack);
        animator.SetBool("RangedAttack", Rangedattack);
        Debug.Log("Melee Attack!");
        Attack();

    }

    void RangedAttack()
    {
        // ranged attack logic here
        timer += Time.deltaTime;
        if (timer > 2)
        {
            timer = 0;
            shoot();
            animator.SetBool("MeleeAttack", Meleeattack);
            animator.SetBool("RangedAttack", Rangedattack);

        }
        Debug.Log("Ranged Attack!");
    }

    void shoot()
    {
        Instantiate(Box, BoxPOS.position, Quaternion.identity);
    }

    private void attack()
    {
        attacking = true;
        animator.SetBool("isAttacking", attacking);
        //swordslash.Play();
    }


    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            //colInfo.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
            Player.SendMessage("Damage");
        }
    }
    /*
        public void EnragedAttack()
        {
            Vector3 pos = transform.position;
            pos += transform.right * attackOffset.x;
            pos += transform.up * attackOffset.y;

            Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
            if (colInfo != null)
            {
               // colInfo.GetComponent<PlayerHealth>().TakeDamage(enragedAttackDamage);
            }
        }
    */
        void OnDrawGizmosSelected()
        {
            Vector3 pos = transform.position;
            pos += transform.right * attackOffset.x;
            pos += transform.up * attackOffset.y;

            Gizmos.DrawWireSphere(pos, attackRange);
        }
    void deathRoutine()
    {
        Rangedattack = false;
        Meleeattack = false;
        bool Hurt = false;
        animator.SetBool("RangedAttack", Rangedattack);
        animator.SetBool("MeleeAttack", Rangedattack);
        animator.SetBool("Hurt", Hurt);

        bool initiate = false;
        animator.SetBool("iswalk", initiate);

        bool isDead = true;
        animator.SetBool("Death", isDead);

        StartCoroutine(Die());
    }



    IEnumerator Die()
    {
        playerRigidbody.velocity = new Vector2(0, 0);
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);

    }

}
