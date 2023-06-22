using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JarScript : MonoBehaviour
{
    private Transform player; // reference to the player's transform
    bool isbreak = false;
    Animator animator;
    [SerializeField] AudioSource jarsoundbreak;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // find the player game object
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //print("Jar");

    }
    private void OnMouseDown()
    {
        print("Jar click");
        player.SendMessage("jar");
        isbreak = true;

        animator.SetBool("isBreak", isbreak);
        jarsoundbreak.Play();

        StartCoroutine(destroying());

    }
    IEnumerator destroying()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);

    }

}
