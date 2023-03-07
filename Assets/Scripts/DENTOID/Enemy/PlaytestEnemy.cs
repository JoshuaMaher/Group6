using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaytestEnemy : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    public int currentHealth;
 
   


    private void Awake()
    {
        currentHealth = maxHealth;
       
    }

    public void damageEnemy(int damage)
    {
        currentHealth -= damage;

       

        if (currentHealth <= 0)
        {
            //Deactivate();
            Die();
        }
    }

    private void Die()
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
