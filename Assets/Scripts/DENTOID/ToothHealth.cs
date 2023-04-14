using UnityEngine;
using System.Collections;

public class ToothHealth : MonoBehaviour
{
    //HEALTH
    [SerializeField] private float startHealth;
    public float currentHealth;
    public bool decay;

    [Header("Audio")]
    [SerializeField] private AudioClip decayNoise;
    [SerializeField] private AudioClip hurtNoise;

    //[Header("Sprite")]
    //[SerializeField] private Sprite health3;
    //[SerializeField] private Sprite health2;
    //[SerializeField] private Sprite health1;  
    //[SerializeField] private Sprite health0;  
    private SpriteRenderer spriteRen;
    
    //invunerability
    public float invulTime = 2;
    private int flashNum = 4;

    public Color customColour; //blue powerup colour
    public Color hurtColour; //invincibility colour

    public GameObject player;

    public bool varnished; //has tooth been cleaned with powerup?
    public bool isInvincible;
    public GameObject foamer;
    private Animator anima;
    [SerializeField] BrushSwing canRes;

    private void Awake()
    {
        currentHealth = startHealth;
        decay = false;
        spriteRen = GetComponent<SpriteRenderer>();
        anima = GetComponent<Animator>();
    }

    private void Update()
    {
        //PLAQUE
        
        if (currentHealth == 4)
        {
            //this.gameObject.GetComponent<SpriteRenderer>().sprite = health3;
            //spriteRen.color = customColour;
            anima.SetTrigger("4health");
        }
         if(currentHealth == 3)
        {
            //DEFAULT TOOTH SPRITE
            //this.gameObject.GetComponent<SpriteRenderer>().sprite = health3;
            //spriteRen.color = Color.white;
            anima.SetTrigger("3health");
        }
        else if(currentHealth == 2)
        {
            //SPRITE WITH PLAQUE ON TOOTH
            //this.gameObject.GetComponent<SpriteRenderer>().sprite = health2;
            //spriteRen.color = Color.white;
            anima.SetTrigger("2health");
        }
        else if(currentHealth == 1)
        {
            //SPRITE WITH MORE PLAQUE ON TOOTH
            //this.gameObject.GetComponent<SpriteRenderer>().sprite = health1;
            //spriteRen.color = Color.white;
            anima.SetTrigger("1health");
        }
        else if(currentHealth <= 0 && decay)
        {
            //SPRITE WITH DECAYED TOOTH
            //this.gameObject.GetComponent<SpriteRenderer>().sprite = health0;
            //spriteRen.color = Color.white;
            anima.SetTrigger("0health");
            
            if(canRes.canRevive == true)
            {
                anima.SetTrigger("glowdecay");
            }
        }
        
    }

    public void TakeDamage(float _damage)
    {
        

        if (!isInvincible)
        {
            currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startHealth);
        }

        if (currentHealth > 0)
        {
            SoundManager.instance.PlaySound(hurtNoise);
            StartCoroutine(Invunerability());
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
        if (currentHealth != 0 || player.GetComponent<BrushSwing>().canRevive == true)
        {
            currentHealth = Mathf.Clamp(currentHealth + _amount, 0, startHealth);
        }
    }

   

        public IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(7, 8, true);
        isInvincible = true;
        //DURATION OF INVUNERABILITY
        for (int i = 0; i < flashNum; i++)
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = hurtColour; //change colour, E0E03F, i changed it to just transparency for testing
            yield return new WaitForSeconds(invulTime / (flashNum * 1.8f));
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(invulTime / (flashNum * 1.8f));
        }
        Physics2D.IgnoreLayerCollision(7, 8, false);
        isInvincible = false;
    }
}