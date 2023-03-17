using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MinutesTimer : MonoBehaviour
{
    public float timeValue;
    public Text timeText;

    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime; 
        }
        else
        {
            timeValue = 0;
        }
        DisplayTime(timeValue);
    
    }
    void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
            SceneManager.LoadScene("Complete");
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
