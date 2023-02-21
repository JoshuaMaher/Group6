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
    


    private void Awake()
    {
        anima = GetComponent<Animator>();
    }


    private void Update()
    {

        if (Input.GetMouseButton(0) && cooldownTimer > brushCooldown)
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
    }

    private void OnDrawGizmosSelected()
    {
        if (brushPoint == null)
            return;

        Gizmos.DrawWireSphere(brushPoint.position, brushRange);
    }
}