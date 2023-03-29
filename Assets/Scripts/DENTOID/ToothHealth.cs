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

    [Header("Sprite")]
    [SerializeField] private Sprite health3;
    [SerializeField] private Sprite health2;
    [SerializeField] private Sprite health1;  
    [SerializeField] private Sprite health0;  
    private SpriteRenderer spriteRen;
    public GameObject toothSprite;
    //invunerability
    public float invulTime = 4;
    private int flashNum = 5;

    public Color customColour; //blue powerup colour
    public Color hurtColour; //invincibility colour

    public GameObject player;

    public bool varnished; //has tooth been cleaned with powerup?
    public bool isInvincible;
    

    private void Awake()
    {
        currentHealth = startHealth;
        decay = false;
        spriteRen = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        //PLAQUE
        
        if (currentHealth == 4)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = health3;
            spriteRen.color = customColour;
        }
         if(currentHealth == 3)
        {
            //DEFAULT TOOTH SPRITE
            this.gameObject.GetComponent<SpriteRenderer>().sprite = health3;
            toothSprite.SetActive(false);
            spriteRen.color = Color.white;
        }
        else if(currentHealth == 2)
        {
            //SPRITE WITH PLAQUE ON TOOTH
            this.gameObject.GetComponent<SpriteRenderer>().sprite = health2;
            toothSprite.SetActive(true);
            spriteRen.color = Color.white;
        }
        else if(currentHealth == 1)
        {
            //SPRITE WITH MORE PLAQUE ON TOOTH
            this.gameObject.GetComponent<SpriteRenderer>().sprite = health1;
            toothSprite.SetActive(true);
            spriteRen.color = Color.white;
        }
        else if(currentHealth <= 0 && decay)
        {
            //SPRITE WITH DECAYED TOOTH
            this.gameObject.GetComponent<SpriteRenderer>().sprite = health0;
            toothSprite.SetActive(false);
            spriteRen.color = Color.white;
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

   

        private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(7, 8, true);
        isInvincible = true;
        //DURATION OF INVUNERABILITY
        for (int i = 0; i < flashNum; i++)
        {
            toothSprite.GetComponent<SpriteRenderer>().color = hurtColour; //change colour 
            yield return new WaitForSeconds(invulTime / (flashNum * 2));
            toothSprite.GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(invulTime / (flashNum * 2));
        }
        Physics2D.IgnoreLayerCollision(7, 8, false);
        isInvincible = false;
    }
}