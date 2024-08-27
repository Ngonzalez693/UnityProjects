using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Animator animator;
    public GameObject target;
    public GameObject range;
    public GameObject Hit;

    public int rutine;
    public float cronometer;
    public int direction;
    public float walkSpeed;
    public float runSpeed;
    public bool isAttacking;
    public float visionRange;
    public float attackRange;

    void Start()
    {
        animator = GetComponent<Animator>();
        target = GameObject.Find("Player");
    }

    void Update()
    {
        Behaviors();
    }

    public void Behaviors()
    {
        if (Mathf.Abs(transform.position.x - target.transform.position.x) > visionRange && !isAttacking)
        {

            animator.SetBool("Run", false);
            cronometer += 1 * Time.deltaTime;

            if (cronometer >= 4)
            {
                rutine = Random.Range(0, 2);
                cronometer = 0;
            }

            switch (rutine)
            {
                case 0:
                    animator.SetBool("Walk", false);
                    break;

                case 1:
                    direction = Random.Range(0, 2);
                    rutine++;
                    break;

                case 2:

                    switch (direction)
                    {
                        case 0:
                            transform.rotation = Quaternion.Euler(0, 0, 0);
                            transform.Translate(Vector3.right * walkSpeed * Time.deltaTime);
                            break;

                        case 1:
                            transform.rotation = Quaternion.Euler(0, 0, 0);
                            transform.Translate(Vector3.right * walkSpeed * Time.deltaTime);
                            break;
                    }
                    animator.SetBool("Walk", true);
                    break;
            }

        }
        else
        {
           if (Mathf.Abs(transform.position.x - target.transform.position.x) > attackRange && !isAttacking)
            {
               if (transform.position.x < target.transform.position.x)
               {
                    animator.SetBool("Walk", false);
                    animator.SetBool("Run", true);
                    transform.Translate(Vector3.right * runSpeed * Time.deltaTime);
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    animator.SetBool("Attack", false);
               }
               else
               {
                    animator.SetBool("Walk", false);
                    animator.SetBool("Run", true);
                    transform.Translate(Vector3.right * runSpeed * Time.deltaTime);
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                    animator.SetBool("Attack", false);
               }
            }     
            else
            {
                if (!isAttacking)
                {
                    if (transform.position.x < target.transform.position.x)
                    {                        
                        transform.rotation = Quaternion.Euler(0, 0, 0);                      
                    }
                    else
                    { 
                        transform.rotation = Quaternion.Euler(0, 180, 0);
                    }
                    animator.SetBool("Walk", false);
                    animator.SetBool("Run", false);                    
                }
            }
        }

    }

    public void FinalAnimation()
    {
        animator.SetBool("Attack", false);
        isAttacking = false;     
        range.GetComponent<BoxCollider2D>().enabled = true;
    }
    public void ColliderWeaponTrue()
    {
        Hit.GetComponent<BoxCollider2D>().enabled = true;
    }
    public void ColliderWeaponFalse()
    {
        Hit.GetComponent<BoxCollider2D>().enabled = false;
    }

}