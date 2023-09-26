using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MovePlayer : MonoBehaviour
{
    Rigidbody2D playerRigidbody;
    float xMove, yMove;
    int counter = 0;
    int hitcounter = 0;
    [SerializeField] float runSpeed = 10;
    [SerializeField] Image background;
    bool isPlayerRunning = false;
    bool isJumpingUp = false;
    bool isJumpingDown = false;
    bool isIdle = true;
    int playerRunningDirection = 1;
    bool isDeath = false;
    Animator playerAnimator;
    int KeyCounter = 0;
    [SerializeField] float jumpSpeed = 10;
    CapsuleCollider2D playerCapsuleCollider;


    float playerDefaultGravityScale;

    [SerializeField] GameObject player;
 
    [SerializeField] GameObject hayena;
    [SerializeField] GameObject hayena1;
    [SerializeField] GameObject hayena2;
    [SerializeField] GameObject hayena3;
    [SerializeField] GameObject hayena4;
    [SerializeField] GameObject hayena5;
    [SerializeField] Image heart1;
    [SerializeField] Image heart2;
    [SerializeField] Image heart3;
    [SerializeField] Image key;
    [SerializeField] GameObject spawn1;
    [SerializeField] AudioSource death1;
    [SerializeField] AudioSource keyjingle;

    public ParticleSystem dust;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerCapsuleCollider = GetComponent<CapsuleCollider2D>();

        death1 = GetComponent<AudioSource>();
        playerDefaultGravityScale = playerRigidbody.gravityScale;
        key.enabled = false;
    }

    void getInput()
    {
        xMove = Input.GetAxis("Horizontal");
        yMove = Input.GetAxis("Vertical");
    }

    void identifyRun()
    {
        isPlayerRunning = false;

        if (Mathf.Abs(xMove) > Mathf.Epsilon && isJumpingDown ==false && isJumpingUp == false )
        {
            isPlayerRunning = true;

            if (xMove > Mathf.Epsilon)
                playerRunningDirection = 1;
            else
                playerRunningDirection = -1;
        }

        if (Mathf.Abs(playerRigidbody.velocity.x) > 0.2)
        {
            CreateDust();
        }
    }
    void idle()
    {
        if(isPlayerRunning==false && isJumpingDown==false && isJumpingUp == false)
        {
            isIdle = true;
        }
        isIdle = false;
    }

    void Run()
    {
        playerAnimator.SetBool("isRunning", isPlayerRunning);

        Vector2 playerMove = new Vector2(xMove * runSpeed, playerRigidbody.velocity.y);
        playerRigidbody.velocity = playerMove;

        transform.localScale = new Vector2(playerRunningDirection, 1);

        
        
    }

    void Jump()
    {
        print("velocity: " + playerRigidbody.velocity.x + ", " + playerRigidbody.velocity.y);

        if (playerRigidbody.velocity.y > 0.001 | playerRigidbody.velocity.y < -0.001)
        {
            isJumpingUp = true;
            CreateDust();
        }
            
        else
        {
            isJumpingUp = false;
            counter = 0;

        }
        


            playerAnimator.SetBool("Player_Jump", isJumpingUp);
        playerAnimator.SetBool("JumpDown", isJumpingDown);

        if (!playerCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Water")))
        {

            return;
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && counter == 0)
        {
            counter++;
            
            playerRigidbody.velocity = playerRigidbody.velocity + new Vector2(0, jumpSpeed);
        }
    }
   


    // Update is called once per frame
    void Update()
    {
        if (!isDeath)
        {
          
            getInput();
            identifyRun();
            Run();
            Jump();
        }
        //JumpDown();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
    

        if (collision.gameObject.tag == "ExitPortal")
        {
            Invoke("NextLevel", 1.0f);
        }
        if(collision.gameObject.tag == "Trap")
        {
            death1.Play();

            StartCoroutine(death());
        }
        if(collision.gameObject.tag == "Bushes")
        {
            runSpeed = 2;
        }

        if (collision.gameObject.tag == "Barn")
        {
            SceneManager.LoadScene("Barn1");
        }
        if(collision.gameObject.tag == "MobTrigger")
        {
            hayena.SendMessage("begin", true);
        }
        if (collision.gameObject.tag == "Mobtrigger1")
        {
            hayena1.SendMessage("begin", true);
        }
        if (collision.gameObject.tag == "Mobtrigger2")
        {
            hayena2.SendMessage("begin", true);
        }
        if (collision.gameObject.tag == "Mobtrigger3")
        {
            hayena3.SendMessage("begin", true);
        }
        if (collision.gameObject.tag == "Mobtrigger4")
        {
            hayena4.SendMessage("begin", true);
        }
        if (collision.gameObject.tag == "Mobtrigger5")
        {
            hayena5.SendMessage("begin", true);
        }
        if (collision.gameObject.tag == "Keys")
        {
            Destroy(collision.gameObject);
            key.enabled = true;
            KeyCounter++;
            keyjingle.Play();
        }
        if (collision.gameObject.tag == "DoorEnd" && KeyCounter > 0)
        {
            SceneManager.LoadScene("Main");
        }
        
    }
  
    void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
            nextSceneIndex = 0;

        SceneManager.LoadScene(nextSceneIndex);
    }
    IEnumerator death()
    {
        isDeath=true;
        playerRigidbody.velocity = new Vector2(0, 0);
        playerAnimator.SetBool("isDeath",isDeath);
        yield return new WaitForSeconds(1.5f);
        heart1.enabled = false;
        heart2.enabled = false;
        heart3.enabled = false;
        gameObject.SetActive(false);
        SceneManager.LoadScene("Main");
        
    }
    void Damage()
    {
        hitcounter++;
        if(hitcounter == 2)
        {
            heart1.enabled = false;

        }
        if(hitcounter == 4)
        {
            heart2.enabled = false;
        }
        if(hitcounter == 6)
        {
            heart3.enabled =false;
            StartCoroutine(death());

        }
    }

    void CreateDust()
    {
        dust.Play();
    }
  
}
