using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public GameObject specifiedTooth; //Drag desired tooth game object into this script which is attached to an enemy
    public GameObject player; //Drag player object into script
    public float speed; //How fast enemy moves towards tooth, can be changed in inspector
  

    private float toothDist;
    private float playerDist;
    
    void Update()
    {
        playerDist = Vector2.Distance(transform.position, player.transform.position); //Distance between player and enemy
        Vector2 playerDirection = player.transform.position - transform.position;
        playerDirection.Normalize();
        float playerAngle = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg;

        toothDist = Vector2.Distance(transform.position, specifiedTooth.transform.position); //Distance between enemy and specified tooth
        Vector2 toothDirection = specifiedTooth.transform.position - transform.position; //Difference between the tooth's position and enemy's current position
        toothDirection.Normalize(); //Normalize function maintains direction but sets length (magnitude) = 1, stops buggy errors when enemy rotates
        float toothAngle = Mathf.Atan2(toothDirection.y, toothDirection.x) * Mathf.Rad2Deg;
        //Maths function used to find angle between 2 points   //Converts radians to degrees


        if (toothDist < playerDist) //if the distance between the enemy and the tooth is less than to the player, the enemy will move towards the tooth

        {

            transform.position = Vector2.MoveTowards(this.transform.position, specifiedTooth.transform.position, speed * Time.deltaTime);
            //Enemy's position          //MoveTowards is a function within Unity that moves something towards a target
            //"this".transform.position refers to the enemy that the script is attached to, the enemy's position

            transform.rotation = Quaternion.Euler(Vector3.forward * toothAngle);
            //Quaternion.Euler us just maths stuff concerned with rotations
            //The .forward is part of Unity, and tells the enemy to go forward
        }
        else
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * playerAngle);
        }


    }
}
