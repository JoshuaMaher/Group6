using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalEnemy : MonoBehaviour
{
    public float bulletSpeed;  //Enemies are called "bullets" right now
    public Transform shootPos; 
    public GameObject bullet;
    private float shootTimer;

    public GameObject topMolar1;
    public GameObject topCanine1;
    public GameObject topIncisor1;
    public GameObject topIncisor2;
    public GameObject topCanine2;
    public GameObject topMolar2;

    public GameObject bottomMolar1;
    public GameObject bottomCanine1;
    public GameObject bottomIncisor1;
    public GameObject bottomIncisor2;
    public GameObject bottomCanine2;
    public GameObject bottomMolar2;

    private float randomNumber;

    public int fireRate = 4;

    public float goTime = 60;

    public GameObject timer;
    public float currentTime;

    private bool hasReduced;
    private bool reducedFurther;

    public GameObject player;

 
    private bool canShoot;


    void Start()
    {
      
    }

    void Update()
    {

        if(player.GetComponent<BrushSwing>().KillCount <= 0)
        {
            canShoot = false;
        }
        
        if(shootTimer > goTime)
        {
            canShoot = true;
        }

        currentTime = timer.GetComponent<MinutesTimer>().timeValue; //current time from timer script on timer object


        shootTimer += Time.deltaTime; //counts up until fireRate num and then shoots


        if (shootTimer > fireRate && canShoot)
        {
            shootTimer = 0;
            StartCoroutine(fireBullet());
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

        randomNumber = Random.Range(1, 13);

        if(randomNumber == 1)
        {
            newBullet.GetComponent<EnemyFollow>().specifiedTooth = topMolar1;
            
        }
        if(randomNumber == 2)
        {
            newBullet.GetComponent<EnemyFollow>().specifiedTooth = topCanine1;
        }
        if (randomNumber == 3)
        {
            newBullet.GetComponent<EnemyFollow>().specifiedTooth = topIncisor1;
        }
        if (randomNumber == 4)
        {
            newBullet.GetComponent<EnemyFollow>().specifiedTooth = topIncisor2;
        }
        if (randomNumber == 5)
        {
            newBullet.GetComponent<EnemyFollow>().specifiedTooth = topCanine2;
        }
        if (randomNumber == 6)
        {
            newBullet.GetComponent<EnemyFollow>().specifiedTooth = topMolar2;
        }
        if (randomNumber == 7)
        {
            newBullet.GetComponent<EnemyFollow>().specifiedTooth = bottomMolar1;
        }
        if (randomNumber == 8)
        {
            newBullet.GetComponent<EnemyFollow>().specifiedTooth = bottomCanine1;
        }
        if (randomNumber == 9)
        {
            newBullet.GetComponent<EnemyFollow>().specifiedTooth = bottomIncisor1;
        }
        if (randomNumber == 10)
        {
            newBullet.GetComponent<EnemyFollow>().specifiedTooth = bottomIncisor2;
        }
        if (randomNumber == 11)
        {
            newBullet.GetComponent<EnemyFollow>().specifiedTooth = bottomCanine2;
        }
        if (randomNumber == 12)
        {
            newBullet.GetComponent<EnemyFollow>().specifiedTooth = bottomMolar2;
        }

        newBullet.transform.localScale = new Vector2(newBullet.transform.localScale.x * direction(), newBullet.transform.localScale.y);
        yield return new WaitForSeconds(shootTimer);

     

    }

   
}
