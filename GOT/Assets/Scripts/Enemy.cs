using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Animator animator;
    public LevelSystem levelSystem;

    public int maxHealth = 100;
    int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage){
        
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if(currentHealth <= 0){
            Die();
        }
    }

    void Die(){

        animator.SetBool("IsDead", true);

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

        levelSystem.ShowEnemyDefeatedMessage();
    }
}