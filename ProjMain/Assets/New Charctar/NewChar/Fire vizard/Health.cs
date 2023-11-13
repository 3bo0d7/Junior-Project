using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
   
    Rigidbody2D playerRigidbody;
    Animator animator;
    bool isDead = false;
    bool initiate;
    bool begins = false;
    public float moveSpeed = 3f; // speed at which the enemy moves
    public float attackRange = 2f; // distance at which the enemy will attack the player
    public float attackDelay = 1f; // time delay between attacks
    int hitCounter = 0;
    private Transform player; // reference to the player's transform
    private bool isAttacking = false; // flag to determine if the enemy is attacking
    private float attackTimer = 0f;

    [SerializeField] AudioSource attack;
    [SerializeField] AudioSource death;
    public Transform playerTransform;
    int hitcounter = 0;


    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform; // find the player game object
        death = GetComponent<AudioSource>();

    }
    void Update()
    {
        if (!isDead && begins ==true)
        {
            hunt();
            run();
        }
        else if(isDead)
        {
            isAttacking = false;
            initiate = false;
        }

    
    }
    void run()
    {
        print("hayena run");
        initiate = true;
        animator.SetBool("iswalk", initiate);
        if (transform.position.x > playerTransform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (transform.position.x < playerTransform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);

        }
        if (isAttacking == true)
        {
            initiate = false;
            animator.SetBool("iswalk", initiate);


        }
    }
    void hunt()
    {
        print("Hayena hunt");
        if (isAttacking == false)
        {
            // calculate the distance between the enemy and the player
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);
            if (distanceToPlayer > attackRange)
            {
                // move towards the player if the distance is greater than the attack range
                transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
             
            }
            else
            {
                // stop moving and start attacking if the distance is less than or equal to the attack range
                isAttacking = true;
                animator.SetBool("isattack", isAttacking);
               
            }
        }
        else
        {
            // increment the attack timer
            attackTimer += Time.deltaTime;

            if (attackTimer >= attackDelay)
            {
                // reset the attack timer and attack the player
                attackTimer = 0f;
                Attack();
                player.SendMessage("Damage");

            }
        }
    }
    void Attack()
    {
        // add code to attack the player here
        Debug.Log("Attacking the player!");

        isAttacking = false;
        animator.SetBool("isattack", isAttacking);
        attack.Play();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerSword")
        {
           hitCounter++;
            print(hitCounter + "hit");

        }
        void deathRoutine()
        {
            isAttacking = false;
            animator.SetBool("isattack", isAttacking);
            initiate = false;
            animator.SetBool("iswalk", initiate);

            isDead = true;
            animator.SetBool("isdeath", isDead);
            death.Play();

            StartCoroutine(Die());
        }
       
    }
    public void begin(bool enm)
    {
        begins = enm;
    }
    IEnumerator Die()
    {
        playerRigidbody.velocity = new Vector2(0, 0);
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
        


    }
}
