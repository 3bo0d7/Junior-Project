using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public GameObject projectile;
    private float timeBtwShots;
    public float startTime;
    Animator playerAnimator;
    [SerializeField] GameObject player;
    bool Fire = false;
    private float timer = 0f;
    private float timeToAttack = 0.667f;

    [SerializeField] GameObject ProjPos;
    int playerDir;



    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    IEnumerator InitiateProj()
    {
        yield return new WaitForSeconds(0.6f);
        GameObject e = Instantiate(projectile, ProjPos.transform.position, Quaternion.identity);
        GunProj g = e.GetComponent<GunProj>();
        g.projDir = playerDir;
    }

    // Update is called once per frame
    void Update()
    {

        if (timeBtwShots >= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Fire = true;
                playerAnimator.SetBool("Fire", Fire);

                /*GameObject e = Instantiate(projectile, transform);
                e.transform.position = transform.position;
                MovePlayer mp = player.GetComponent<MovePlayer>();
                GunProj g = e.GetComponent<GunProj>();
                g.projDir = mp.playerRunningDirection;*/

                /*GameObject e = Instantiate(projectile, ProjPos.transform.position, Quaternion.identity);
                GunProj g = e.GetComponent<GunProj>();
                g.projDir = playerDir;*/

                StartCoroutine(InitiateProj());

                print("playerDir " + playerDir);

                timeBtwShots = startTime;

            }
        }
        if (Fire)
        {
            timer += Time.deltaTime;
            if (timer >= timeToAttack)
            {
                timer = 0f;
                Fire = false;
                playerAnimator.SetBool("Fire", Fire);

            }
        }
        else
        {
            // timeBtwShots -= Time.deltaTime;

        }
    }

    void DirLeft()
    {
        playerDir = -1;
    }

    void DirRight()
    {
        playerDir = 1;
    }
}


