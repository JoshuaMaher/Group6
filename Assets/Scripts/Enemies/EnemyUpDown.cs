using UnityEngine;

public class EnemyUpDown : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float moveDistance;
    [SerializeField] private float speed;
    private bool movingLeft;
    private float edgeLeft;
    private float edgeRight;
    
   
   private void Awake()
   {
    edgeLeft = transform.position.y - moveDistance;
    edgeRight = transform.position.y + moveDistance; 
   }

    private void Update()
    {
        if (movingLeft)
        {
            if (transform.position.y > edgeLeft)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - speed *Time.deltaTime, transform.position.z);
            }
            else
                movingLeft = false;
        }
        else
        {
            if (transform.position.y < edgeRight)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + speed *Time.deltaTime, transform.position.z);
            }
            else
                movingLeft = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}

