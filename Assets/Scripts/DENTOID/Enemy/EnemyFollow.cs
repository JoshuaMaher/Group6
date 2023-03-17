using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public GameObject specifiedTooth; //Drag desired tooth game object into this script which is attached to an enemy
    public GameObject player;

    public float speed; //How fast enemy moves towards tooth, can be changed in inspector


    private float toothDist;
    private float playerDist;

    [SerializeField] protected float damage;

    public float toothAngle;
    public float playerAngle;

    private float lifetime;

    SpriteRenderer spi;

    void Start()
    {
        spi = GetComponent<SpriteRenderer>();
      
    }

    void Update()
    {
        lifetime += Time.deltaTime;

        if (lifetime < 2)
        {
           

            playerAngle = Vector2.Distance(transform.position, player.transform.position);
            Vector2 playerDirection = player.transform.position - transform.position;
            playerDirection.Normalize();
            playerAngle = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg;

            if (playerAngle < -90)
            {
                playerAngle += 180;

                spi.flipX = true;
            }

            if (playerAngle > 90)
            {
                playerAngle -= 180;

                spi.flipX = true;
            }

            transform.rotation = Quaternion.Euler(Vector3.forward * playerAngle);
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

        }

        if (lifetime > 2)
        {

            toothDist = Vector2.Distance(transform.position, specifiedTooth.transform.position); //Distance between enemy and specified tooth
            Vector2 toothDirection = specifiedTooth.transform.position - transform.position; //Difference between the tooth's position and enemy's current position
            toothDirection.Normalize(); //Normalize function maintains direction but sets length (magnitude) = 1, stops buggy errors when enemy rotates
            toothAngle = Mathf.Atan2(toothDirection.y, toothDirection.x) * Mathf.Rad2Deg;
            //Maths function used to find angle between 2 points   //Converts radians to degrees


            if (toothAngle < -90)
            {
                toothAngle += 180;

                spi.flipX = true;
            }

            if (toothAngle > 90)
            {
                toothAngle -= 180;

                spi.flipX = true;
            }

            transform.position = Vector2.MoveTowards(this.transform.position, specifiedTooth.transform.position, speed * Time.deltaTime);
            //Enemy's position          //MoveTowards is a function within Unity that moves something towards a target
            //"this".transform.position refers to the enemy that the script is attached to, the enemy's position

            transform.rotation = Quaternion.Euler(Vector3.forward * toothAngle);
            //Quaternion.Euler us just maths stuff concerned with rotations
            //The .forward is part of Unity, and tells the enemy to go forward
        }
        
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == specifiedTooth)
        {
            collision.GetComponent<ToothHealth>().TakeDamage(damage);
            Destroy(gameObject);
           
        }

    }

}
