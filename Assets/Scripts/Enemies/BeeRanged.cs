
using UnityEngine;

public class BeeRanged : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damamge;

    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;
    [SerializeField] private AudioClip attackSound;

    [Header("Collider")]
    [SerializeField] private float colliderDist;
    [SerializeField] private BoxCollider2D boxCol;

    [Header("Projectile Attack")]
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject[] projectiles;

    //REFERENCES
    private Animator anima;
    private BeeEnemy beeWatcher;
    
    private void Awake()
    {
        anima = GetComponent<Animator>();
        beeWatcher = GetComponentInParent<BeeEnemy>();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (PlayerSpotted())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                anima.SetTrigger("attack");
            }
        }

        if (beeWatcher != null)
            beeWatcher.enabled = !PlayerSpotted();
    }

    private bool PlayerSpotted()
    {
        RaycastHit2D hit = 
            Physics2D.BoxCast(boxCol.bounds.center + transform.right * range * transform.localScale.x * colliderDist, 
            new Vector3(boxCol.bounds.size.x * range, boxCol.bounds.size.y, boxCol.bounds.size.z), 
            0, Vector2.left, 0, playerLayer);

        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCol.bounds.center + transform.right * range * transform.localScale.x * colliderDist,
            new Vector3(boxCol.bounds.size.x * range, boxCol.bounds.size.y, boxCol.bounds.size.z));
    }

    private void ShootProjectile()
    {
        SoundManager.instance.PlaySound(attackSound);
        cooldownTimer = 0;
        projectiles[FindProjectile()].transform.position = firepoint.position;
        projectiles[FindProjectile()].GetComponent<EnemyProjectile>().ActivateProjectile();

    }

    private int FindProjectile()
    {
        for (int i = 0; i < projectiles.Length; i++)
        {
            if(!projectiles[i].activeInHierarchy)
                return i;
        }
        return 0;
    }

}
