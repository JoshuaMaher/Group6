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
}