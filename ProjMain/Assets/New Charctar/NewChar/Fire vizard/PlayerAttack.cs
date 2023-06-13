using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject attackArea = default;
    private bool attacking = false;
    private float timer = 0f;
    private bool isbreak = false;
    bool begins;
    private float timeToAttack = 0.25f;
    Animator animator;
    Rigidbody2D player;
    private int hits;
    private int counter = 0;
    [SerializeField] Text t;
    [SerializeField] GameObject jar1;
    [SerializeField] GameObject jar2;
    [SerializeField] GameObject jar3;
    [SerializeField] GameObject jar4;
    [SerializeField] GameObject jar5;
    [SerializeField] GameObject jar6;
    [SerializeField] GameObject jar7;
    [SerializeField] GameObject jar8;
   
    [SerializeField] AudioSource swordslash;

    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
        animator = GetComponent<Animator>();
        hits = Random.Range(7, 15);
        player = GetComponent<Rigidbody2D>();
        //swordslash = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (counter <= hits)
        {
            t.text = ""+hits;
            
            if (Input.GetKeyUp(KeyCode.H) && animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                attack();
                hits--;
              
            }
            if (attacking)
            {
                timer += Time.deltaTime;
                if (timer >= timeToAttack)
                {
                    timer = 0f;
                    attacking = false;
                    attackArea.SetActive(attacking);
                    animator.SetBool("isAttacking", attacking);

                }
            }
        }
        if (hits < 0)
        {
            attacking = false;
            animator.SetBool("isAttacking", attacking);
            attackArea.SetActive(attacking);


        }
    }
   
    private void attack()
    {
        attacking = true;
        attackArea.SetActive(attacking);
        animator.SetBool("isAttacking", attacking);
        swordslash.Play();
    }
    void jar()
    {

        hits++;
    }
   
}
