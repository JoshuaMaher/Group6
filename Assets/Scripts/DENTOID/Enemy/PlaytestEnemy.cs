using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaytestEnemy : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    public int currentHealth;
    private Animator anima;
    private EnemyFollow speedage;
 
    private void Awake()
    {
        currentHealth = maxHealth;
        anima = GetComponent<Animator>();
        speedage = GetComponent<EnemyFollow>();
    }

    public void damageEnemy(int damage)
    {
        currentHealth -= damage;

       

        if (currentHealth <= 0)
        {
            //Deactivate();
            anima.SetTrigger("Death");
            speedage.speed = 0f;
        }
    }

    public void Die()
    {
        //GetComponent<Collider2D>().enabled = false;
        //this.enabled = false;
        Destroy(gameObject);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }


}
