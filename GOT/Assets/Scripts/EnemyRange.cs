using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : MonoBehaviour
{
    public Animator animator;
    public EnemyMovement enemy;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
           animator.SetBool("Walk", false);
           animator.SetBool("Run", false);
           animator.SetBool("Attack", true);
           enemy.isAttacking = true;
           GetComponent<BoxCollider2D>().enabled = false;            
        }
    }
}
