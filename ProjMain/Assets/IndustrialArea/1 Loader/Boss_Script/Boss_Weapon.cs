using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Weapon : MonoBehaviour
{
    private GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

        public int attackDamage = 20;
        public int enragedAttackDamage = 40;

        public Vector3 attackOffset;
        public float attackRange = 1f;
        public LayerMask attackMask;

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

        void OnDrawGizmosSelected()
        {
            Vector3 pos = transform.position;
            pos += transform.right * attackOffset.x;
            pos += transform.up * attackOffset.y;

            Gizmos.DrawWireSphere(pos, attackRange);
        }
    
}
