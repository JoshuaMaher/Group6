using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPowerUp : MonoBehaviour
{
   
    public GameObject timer;
    public float randomNumber;

    public float currentTime; //number value equal to current timer value
    private bool hasDecided; //random number has been chosen
    [SerializeField] private ParticleSystem spawnGlow;

    [SerializeField] private Vector3[] newLocation;

    void Start()
    {
        gameObject.transform.position = new Vector3(-10f, 1.23f, 0f); //sets gem off screen
        
    }

    
    void Update()
    {
        currentTime = timer.GetComponent<MinutesTimer>().timeValue; //sets this number equal to timeValue in timer script on timer object

        if (currentTime <= 85 && !hasDecided) //Spawns at 85 secs left and random number only decided once
        {
            gameObject.transform.position = newLocation[0];
            hasDecided = true;
            spawnGlow.Play();
        }

        
    }
}

