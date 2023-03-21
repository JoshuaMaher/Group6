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
    private Rigidbody2D body;
    private PlayerMovement playerMove;
    public Text KillsText;
    public int KillCount;

    public bool canRevive;
    public float reviveTime;

    [SerializeField] private AudioSource sparkle;
    [SerializeField] private AudioSource killEnemy;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();
        playerMove = GetComponent<PlayerMovement>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && cooldownTimer > brushCooldown)
            Swing();
        
        cooldownTimer += Time.deltaTime;
        KillsText.text = KillCount.ToString();

        if (canRevive)
        {

            reviveTime += Time.deltaTime;

            if (reviveTime >= 20)
            {
                canRevive = false;
            }
        }
    }

    private void Swing()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(brushPoint.position, brushRange, enemyLayer);

        foreach(Collider2D enemy in hitEnemies)
        {
            if (enemy.tag == "Enemy")
            {

                enemy.GetComponent<EnemyHealth>().damageEnemy(brushDamage);
                KillCount = KillCount - 1;
                killEnemy.Play();

            }

            if (enemy.tag == "FlyingEnemy")
            {

                enemy.GetComponent<PlaytestEnemy>().damageEnemy(brushDamage);
                KillCount = KillCount - 1;
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

                    if (tooth.GetComponent<ToothHealth>().currentHealth == 1 || tooth.GetComponent<ToothHealth>().currentHealth == 2) //if has plaque on it
                    {
                       tooth.GetComponent<ToothHealth>().AddHealth(1); //cleans normally if not decayed or full health
                    }
                }


                    if (tooth.GetComponent<ToothHealth>().currentHealth == 4 && tooth.GetComponent<ToothHealth>().varnished == true) //if you clean a varnished tooth nothing happens
                    {
                        tooth.GetComponent<ToothHealth>().currentHealth = 4;
                        tooth.GetComponent<ToothHealth>().varnished = true;
                    }

            

                else
                    tooth.GetComponent<ToothHealth>().AddHealth(1); //cleans normally if no powerup

                if (tooth.GetComponent<ToothHealth>().currentHealth == 1)
                {
                    sparkle.Play();
                }

                if(tooth.GetComponent<ToothHealth>().currentHealth == 2)
                {
                    sparkle.Play();
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

//not needed if theres no freeze on spin anymore
    private void FallDown()
    {
        body.gravityScale = 3;
        playerMove.speed = 5f;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Gem")
        {
            collision.gameObject.SetActive(false);
            canRevive = true;
            
            
        }

    }


}