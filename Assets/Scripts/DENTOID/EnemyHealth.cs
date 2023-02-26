using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    private int currentHealth;
    private Animator anima;
    [SerializeField] private AudioClip dieSound;
    [SerializeField] private AudioClip hurtSound;

    
    private void Awake()
    {
        currentHealth = maxHealth;
        anima = GetComponent<Animator>();
    }

    public void damageEnemy(int damage)
    {
        currentHealth -= damage;

        anima.SetTrigger("hurt");
        SoundManager.instance.PlaySound(hurtSound);

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        anima.SetTrigger("death");
        SoundManager.instance.PlaySound(dieSound);

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }

     private void Deactivate()
    {
        gameObject.SetActive(false);
    }


}
