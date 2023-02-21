using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] carrots;
    private Animator anima;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;
    [SerializeField]private AudioClip carrountSound;

    private void Awake()
    {
        anima = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if(Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerMovement.canAttack())
            Attack();
    
        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        SoundManager.instance.PlaySound(carrountSound);
        anima.SetTrigger("attack");
        cooldownTimer = 0;

        carrots[FindCarrot()].transform.position = firePoint.position;
        carrots[FindCarrot()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private int FindCarrot()
    {
        for (int i = 0; i < carrots.Length; i++)
        {
            if (!carrots[i].activeInHierarchy)
                return i;
        }
        return 0;
    }

}
