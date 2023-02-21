using UnityEngine;

public class EnemySideways : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float moveDistance;
    [SerializeField] private float speed;
    private bool movingLeft;
    private float edgeLeft;
    private float edgeRight;
    
   
   private void Awake()
   {
    edgeLeft = transform.position.x - moveDistance;
    edgeRight = transform.position.x + moveDistance; 
   }

    private void Update()
    {
        if (movingLeft)
        {
            if (transform.position.x > edgeLeft)
            {
                transform.position = new Vector3(transform.position.x - speed *Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
                movingLeft = false;
        }
        else
        {
            if (transform.position.x < edgeRight)
            {
                transform.position = new Vector3(transform.position.x + speed *Time.deltaTime, transform.position.y, transform.position.z);
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
