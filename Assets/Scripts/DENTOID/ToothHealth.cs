using UnityEngine;
using System.Collections;

public class ToothHealth : MonoBehaviour
{
    //HEALTH
    [SerializeField] private float startHealth;
    [SerializeField] public float currentHealth {get; private set;}
    private bool decay;

    [Header("Audio")]
    [SerializeField] private AudioClip decayNoise;
    [SerializeField] private AudioClip hurtNoise;

    [Header("Sprite")]
    [SerializeField] private Sprite health3;
    [SerializeField] private Sprite health2;
    [SerializeField] private Sprite health1;  
    [SerializeField] private Sprite health0;  

    private void Awake()
    {
        currentHealth = startHealth;
        decay = false;
    }

    private void FixedUpdate()
    {
        //PLAQUE
        
         if(currentHealth == 3)
        {
            //DEFAULT TOOTH SPRITE
            this.gameObject.GetComponent<SpriteRenderer>().sprite = health3;
        }
        else if(currentHealth == 2)
        {
            //SPRITE WITH PLAQUE ON TOOTH
            this.gameObject.GetComponent<SpriteRenderer>().sprite = health2;
        }
        else if(currentHealth == 1)
        {
            //SPRITE WITH MORE PLAQUE ON TOOTH
            this.gameObject.GetComponent<SpriteRenderer>().sprite = health1;
        }
        else if(currentHealth <= 0 && decay)
        {
            //SPRITE WITH DECAYED TOOTH
            this.gameObject.GetComponent<SpriteRenderer>().sprite = health0;
        }
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startHealth);

        if (currentHealth > 0)
        {
            SoundManager.instance.PlaySound(hurtNoise);
        }
        else
        {
            if(!decay)
            {
                decay = true;
                SoundManager.instance.PlaySound(decayNoise);
            }
        }

    }

    public void AddHealth(float _amount)
    {
        if(currentHealth != 0)
            currentHealth = Mathf.Clamp(currentHealth + _amount, 0, startHealth);
    }
}