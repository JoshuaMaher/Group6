using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
   
    public GameObject timer;
    public float randomNumber;

    public float currentTime; //number value equal to current timer value
    private bool hasDecided; //random number has been chosen
    [SerializeField] private ParticleSystem spawnGlow;


    void Start()
    {
        gameObject.transform.position = new Vector3(-10f, 1.23f, 0f); //sets gem off screen
        
    }

    
    void Update()
    {
        currentTime = timer.GetComponent<MinutesTimer>().timeValue; //sets this number equal to timeValue in timer script on timer object

        if (currentTime <= 40 && !hasDecided) //Spawns at 40 secs left and random number only decided once
        {
            randomNumber = Random.Range(1, 3); //generates random number between 1 and 3
            hasDecided = true;
            spawnGlow.Play();
        }

        if (randomNumber == 1)
        {
            gameObject.transform.position = new Vector3(-0.08f, 1.23f, 0f); //spawns in at new location
        }
        
        if (randomNumber == 2)
        {
            gameObject.transform.position = new Vector3(3.67f, -1.52f, 0f);
        }

        if (randomNumber == 3)
        {
            gameObject.transform.position = new Vector3(-6.04f, 0.84f, 0f);
        }
    }
}
