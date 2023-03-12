
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] protected float damage;

    private bool hasCollided = false;

   

    


    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Molar" && !hasCollided)
        {
            collision.GetComponent<ToothHealth>().TakeDamage(damage);
            hasCollided = true;
        }
        else if (collision.tag == "Canine" && !hasCollided)
        {
            collision.GetComponent<ToothHealth>().TakeDamage(damage);
            hasCollided = true;
        }
        else if (collision.tag == "Incisor" && !hasCollided)
        {
            collision.GetComponent<ToothHealth>().TakeDamage(damage);
            hasCollided = true;
        }
    }
}
