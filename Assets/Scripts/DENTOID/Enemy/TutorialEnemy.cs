using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEnemy : MonoBehaviour
{
    private float bulletSpeed;  //Enemies are called "bullets" right now
    public Transform shootPos; 
    public GameObject bullet; //what type of enemy you will shoot
    private float shootTimer;

    private int fireRate; //after this many seconds will shoot

    public float goTime;

    public GameObject timer;
    private float currentTime;

    public GameObject player;

    public GameObject tutorialTooth; //the tooth you want enemy to go to
 
    private bool canShoot = false;

    private bool hasShot; //has the enemy spawner fired an enemy yet?


    void Start()
    {
      
    }

    void Update()
    {

        if (shootTimer > goTime) //if current time is smaller than when you tell it to shoot
        {
            canShoot = true;
        }


        currentTime = timer.GetComponent<MinutesTimer>().timeValue; //current time from timer script on timer object


        shootTimer += Time.deltaTime; //counts up until fireRate num and then shoots   

        

        if (canShoot && !hasShot)
        {
            shootTimer = 0;
            StartCoroutine(fireBullet());
            hasShot = true;
        }

    }

    int direction()
    {
        return -1;
    }


    IEnumerator fireBullet()
    {
        GameObject newBullet = Instantiate(bullet, shootPos.position, Quaternion.Euler(0, 0, 0));
        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed * direction() * Time.fixedDeltaTime, 0f);

        newBullet.GetComponent<EnemyFollow>().player = player;
        newBullet.GetComponent<EnemyFollow>().specifiedTooth = tutorialTooth;
            
        newBullet.transform.localScale = new Vector2(newBullet.transform.localScale.x * direction(), newBullet.transform.localScale.y);
        yield return new WaitForSeconds(shootTimer);

    }

   
}
