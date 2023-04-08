using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPowerUp : MonoBehaviour
{
   
    public GameObject timer;
    public float randomNumber;

    public float TimeValue = 0;
    private bool hasDecided; //random number has been chosen
    [SerializeField] private ParticleSystem spawnGlow;

    [SerializeField] private Vector3[] newLocation;

    void Start()
    {
        gameObject.transform.position = new Vector3(-100f, 1.23f, 0f); //sets gem off screen
        
    }

    
    void Update()
    {
        TimeValue += Time.deltaTime;  

        if (TimeValue >= 55 && !hasDecided) 
        {
            gameObject.transform.position = newLocation[0];
            hasDecided = true;
            spawnGlow.Play();
        }

        
    }
}

