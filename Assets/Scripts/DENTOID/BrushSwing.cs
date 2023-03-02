using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushSwing : MonoBehaviour
{
    private Animator anima;
    [SerializeField] private Transform brushPoint;
    [SerializeField] private float brushRange;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private float brushCooldown;
    private float cooldownTimer = Mathf.Infinity;
    [SerializeField] private AudioClip brushSound;
    [SerializeField] private int brushDamage = 1;
    private Rigidbody2D body;
    private PlayerMovement playerMove;

    //clean teeth stuff
    [SerializeField] private LayerMask topTeeth;
    private float chargeTimer = Mathf.Infinity;
    private BoxCollider2D boxCollider;
    [SerializeField] private float maxClean;
    

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();
        playerMove = GetComponent<PlayerMovement>();
        //clean teeth stuff
        boxCollider = GetComponent<BoxCollider2D>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && cooldownTimer > brushCooldown)
            Swing();
        
        cooldownTimer += Time.deltaTime;

        //clean teeth stuff
        if(Input.GetKey(KeyCode.X) && TouchingTeeth() && cooldownTimer > brushCooldown)
            chargeTimer += Time.deltaTime;
            CleanTeeth();       
    }

    private void Swing()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(brushPoint.position, brushRange, enemyLayer);

        foreach(Collider2D enemy in hitEnemies)
        {
           enemy.GetComponent<EnemyHealth>().damageEnemy(brushDamage);
        }

        SoundManager.instance.PlaySound(brushSound);
        anima.SetTrigger("BRUSH");
        cooldownTimer = 0;

           if(playerMove.midAir())
            {
                body.gravityScale = 0;
                body.velocity = Vector2.zero;
                playerMove.speed = 0f;
            }  
    }

    private void OnDrawGizmosSelected()
    {
        if (brushPoint == null)
            return;

        Gizmos.DrawWireSphere(brushPoint.position, brushRange);
    }

    private void FallDown()
    {
        body.gravityScale = 3;
        playerMove.speed = 5f;
    }

    //clean teeth stuff
     private bool TouchingTeeth()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, topTeeth);

        return raycastHit.collider != null;
    }

    //clean teeth stuff
     private void CleanTeeth()
    {
        while(chargeTimer <= maxClean && TouchingTeeth())
        {
            Collider2D[] hitTeeth = Physics2D.OverlapCircleAll(brushPoint.position, brushRange, topTeeth);

            foreach(Collider2D tooth in hitTeeth)
            {
                tooth.GetComponent<ToothHealth>().AddHealth(1);
            }

            SoundManager.instance.PlaySound(brushSound);
            anima.SetTrigger("BRUSH");
            chargeTimer = 0;
            cooldownTimer = 0;

            if(playerMove.midAir())
            {
                body.gravityScale = 0;
                body.velocity = Vector2.zero;
                playerMove.speed = 0f;
            }  
        }
    
    }
}