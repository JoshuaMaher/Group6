
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] protected float damage;


    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Molar")
        {
            collision.GetComponent<ToothHealth>().TakeDamage(damage);
        }
        else if (collision.tag == "Canine")
        {
            collision.GetComponent<ToothHealth>().TakeDamage(damage);
        }
        else if (collision.tag == "Incisor")
        {
            collision.GetComponent<ToothHealth>().TakeDamage(damage);
        }
    }
}
