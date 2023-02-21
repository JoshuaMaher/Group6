using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    //HEALTH
    [SerializeField] private float startHealth;
    public float currentHealth {get; private set;}
    private Animator anima;
    private bool dead;
    //iFRAMES
    private float invulTime = 1;
    private int flashNum = 3;
    private SpriteRenderer spriteRen;

    [Header("Components")]
    [SerializeField] private Behaviour[] components;
    [Header("Audio")]
    [SerializeField] private AudioClip deathNoise;
    [SerializeField] private AudioClip hurtNoise;


    private void Awake()
    {
        currentHealth = startHealth;
        anima = GetComponent<Animator>();
        spriteRen = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startHealth);

        if (currentHealth > 0)
        {
            anima.SetTrigger("hurt");
            StartCoroutine(Invunerability());
            SoundManager.instance.PlaySound(hurtNoise);
        }
        else
        {
            if(!dead)
            {
                anima.SetTrigger("death");

                foreach (Behaviour component in components)
                    component.enabled = false;
            
                dead = true;
                SoundManager.instance.PlaySound(deathNoise);
            }
        }

    }

    public void AddHealth(float _amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + _amount, 0, startHealth);
    }

    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(7, 8, true);
        //DURATION OF INVUNERABILITY
        for (int i = 0; i < flashNum; i++)
        {
            spriteRen.color = new Color(255,0,0,127.5f);
            yield return new WaitForSeconds(invulTime / (flashNum * 2));
            spriteRen.color = Color.white;
            yield return new WaitForSeconds(invulTime / (flashNum * 2));
        }
        Physics2D.IgnoreLayerCollision(7, 8, false);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public void Respawn()
    {
        dead = false;
        AddHealth(startHealth);
        anima.ResetTrigger("death");
        anima.Play("idle");
        StartCoroutine(Invunerability());
        
        foreach (Behaviour component in components)
            component.enabled = true;
    }
}
