using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrushSwing : MonoBehaviour
{
    private Animator anima;
    [SerializeField] private Transform brushPoint;
    [SerializeField] private float brushRange;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private LayerMask teethLayer;
    [SerializeField] private float brushCooldown;
    private float cooldownTimer = Mathf.Infinity;
    [SerializeField] private AudioClip brushSound;
    [SerializeField] private int brushDamage = 1;
    [SerializeField] public GameObject Timer;
    private Rigidbody2D body;
    public Text KillsText;
    public int KillCount;

    public bool canRevive;
    private float reviveTime;
    public float powerupDuration;
    private MinutesTimer TimerValue;

    [SerializeField] private AudioSource sparkle;
    [SerializeField] private AudioSource killEnemy;
    [SerializeField] private ParticleSystem powerUpParticles;

    public bool canSpin = true;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();
        TimerValue = Timer.GetComponent<MinutesTimer>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && cooldownTimer > brushCooldown && canSpin == true)
            Swing();

        cooldownTimer += Time.deltaTime;
        KillsText.text = KillCount.ToString();

        if (canRevive)
        {
            reviveTime += Time.deltaTime;

            if (reviveTime >= powerupDuration)
            {
                canRevive = false;
                powerUpParticles.Stop();
            }
        }

        //PLAYS POWERED UP ANIMATION WHEN POWER UP IS ACTIVE
        anima.SetBool("PoweredUp", canRevive == true);
    }

    private void Swing()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(brushPoint.position, brushRange, enemyLayer);

        foreach(Collider2D enemy in hitEnemies)
        {
            if (enemy.tag == "Enemy")
            {

                enemy.GetComponent<EnemyHealth>().damageEnemy(brushDamage);
                if (KillCount > 0)
                {
                    KillCount = KillCount - 1;
                }
                if (KillCount <= 0)
                {
                    KillCount = 0;
                }
                killEnemy.Play();

            }

            if (enemy.tag == "FlyingEnemy")
            {

                enemy.GetComponent<PlaytestEnemy>().damageEnemy(brushDamage);
                if (KillCount > 0)
                {
                    KillCount = KillCount - 1;
                }
                if (KillCount <= 0)
                {
                    KillCount = 0;
                    if(TimerValue.timeValue <=15)
                    {
                        TimerValue.timeValue = TimerValue.timeValue;
                    }
                    else
                    {
                        TimerValue.timeValue = 15;
                    }
                    
                }
                killEnemy.Play();
            }
        }

        Collider2D[] hitTeeth = Physics2D.OverlapCircleAll(brushPoint.position, brushRange, teethLayer);

        foreach(Collider2D tooth in hitTeeth)
        {
            if (tooth.tag == "Molar" || tooth.tag == "Canine" || tooth.tag == "Incisor") //if spin and hit any tooth
            {

                if (canRevive && tooth.GetComponent<ToothHealth>().varnished == false) //if powerup is active
                {
                    sparkle.Play();
                    tooth.GetComponent<ToothHealth>().foamer.GetComponent<FoamerScript>().foamNow = true;

                    if (tooth.GetComponent<ToothHealth>().currentHealth == 4)
                    {
                        tooth.GetComponent<ToothHealth>().currentHealth = 4;
                        tooth.GetComponent<ToothHealth>().varnished = true; //powerup can't be used again on same tooth
                    }

                    if (tooth.GetComponent<ToothHealth>().currentHealth == 0 || tooth.GetComponent<ToothHealth>().currentHealth == 3) //if decayed or full health
                    {
                        if (tooth.GetComponent<ToothHealth>().varnished == false) //if hasn't used powerup on that tooth yet
                        {
                            tooth.GetComponent<ToothHealth>().currentHealth = 4;
                            tooth.GetComponent<ToothHealth>().varnished = true;
                        }

                    }

                    
                }

                if (tooth.GetComponent<ToothHealth>().currentHealth == 4 && tooth.GetComponent<ToothHealth>().varnished == true) //if you clean a varnished tooth nothing happens
                    {
                        tooth.GetComponent<ToothHealth>().currentHealth = 4;
                        tooth.GetComponent<ToothHealth>().varnished = true;
                    }

            

                else
                     //cleans normally if no powerup

                if (tooth.GetComponent<ToothHealth>().currentHealth == 1 || tooth.GetComponent<ToothHealth>().currentHealth == 2)
                {
                    sparkle.Play();
                    tooth.GetComponent<ToothHealth>().AddHealth(1);
                    tooth.GetComponent<ToothHealth>().foamer.GetComponent<FoamerScript>().foamNow = true;
                }

               

            }

          
        }

        SoundManager.instance.PlaySound(brushSound);
        anima.SetTrigger("BRUSH");
        cooldownTimer = 0;

    }

    private void OnDrawGizmosSelected()
    {
        if (brushPoint == null)
            return;

        Gizmos.DrawWireSphere(brushPoint.position, brushRange);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Gem")
        {
            collision.gameObject.SetActive(false);
            canRevive = true;
            powerUpParticles.Play();
            
        }

    }


}