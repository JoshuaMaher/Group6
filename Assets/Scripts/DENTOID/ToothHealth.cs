using UnityEngine;
using System.Collections;

public class ToothHealth : MonoBehaviour
{
    //HEALTH
    [SerializeField] private float startHealth;
    public float currentHealth {get; private set;}
    private bool decay;
    private SpriteRenderer spriteRen;

    [Header("Audio")]
    [SerializeField] private AudioClip decayNoise;
    [SerializeField] private AudioClip hurtNoise;


    private void Awake()
    {
        currentHealth = startHealth;
        spriteRen = GetComponent<SpriteRenderer>();
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
        currentHealth = Mathf.Clamp(currentHealth + _amount, 0, startHealth);
    }

    private void Plaque()
    {
        if(currentHealth == 3)
        {
            //DEFAULT TOOTH SPRITE
            //spriteRen.color = new Color(255,0,0,127.5f);
        }
        else if(currentHealth == 2)
        {
            //SPRITE WITH PLAQUE ON TOOTH
            //spriteRen.color = new Color(255,0,0,127.5f);
        }
        else if(currentHealth == 1)
        {
            //SPRITE WITH PLAQUE ON TOOTH
            //spriteRen.color = new Color(255,0,0,127.5f);
        }
        else if(currentHealth <= 0 && decay)
        {
            //PRITE WITH DECAYED TOOTH
            //spriteRen.color = new Color(255,0,0,127.5f);
        }
    }

}