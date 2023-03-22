using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MinutesTimer : MonoBehaviour
{
    public float timeValue;
    public Text timeText;

    public float flashTimer = 0;

    public GameObject player; //kill counter is on the player

    private Text kill; //kill is the name we give to the kill text from player

    public Color customColour; //colour of flashing
    private bool canFlash = true;

    public Color killColour;
    private float flashInterval;

  


    void Start()
    {
        kill = player.GetComponent<BrushSwing>().KillsText; //kill count text in Brush Swing script
        kill.color = Color.white;
        timeText.color = Color.white;
    }

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

        if (timeValue < 10)
        {
            canFlash = false;
            flashInterval += Time.deltaTime;
            Flash();

        }

                

        if (player.GetComponent<BrushSwing>().KillCount <= 0)
        {
            kill.color = killColour;
           
        }

        flashTimer += Time.deltaTime; //flash timer starts counting up

        if (canFlash)
        {
            if (flashTimer > 20)
            {
                timeText.color = customColour; //timer text goes red

                if (player.GetComponent<BrushSwing>().KillCount > 0)
                    kill.color = customColour; //we want kill text to flash too to remind the player it's important
                else
                    kill.color = killColour;
            }

            if (flashTimer > 20.5f) //flashes white at 0.5 second intervals
            {
                timeText.color = Color.white;
                if (player.GetComponent<BrushSwing>().KillCount > 0)
                    kill.color = Color.white; 
                else
                    kill.color = killColour;
            }

            if (flashTimer > 21)
            {
                timeText.color = customColour; //timer text goes red
                if (player.GetComponent<BrushSwing>().KillCount > 0)
                    kill.color = customColour;
                else
                    kill.color = killColour;
            }

            if (flashTimer > 21.5f)
            {
                timeText.color = Color.white;
                if (player.GetComponent<BrushSwing>().KillCount > 0)
                    kill.color = Color.white;
                else
                    kill.color = killColour;
            }

            if (flashTimer > 22)
            {
                timeText.color = customColour;
                if (player.GetComponent<BrushSwing>().KillCount > 0)
                    kill.color = customColour;
                else
                    kill.color = killColour;
            }

            if (flashTimer > 22.5f)
            {
                timeText.color = Color.white;
                if (player.GetComponent<BrushSwing>().KillCount > 0)
                    kill.color = Color.white;
                else
                    kill.color = killColour;
            }

            if (flashTimer > 25)
            {
                flashTimer = 0; //timer starts counting up again so the text can flash later
            }

        }
       

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

  




    private void Flash()
    {
        if (flashInterval > 0.3f)
        {
            timeText.color = Color.red;
            if (player.GetComponent<BrushSwing>().KillCount > 0)
                kill.color = Color.red;
            else
                kill.color = killColour;
        }

        if (flashInterval > 0.6f)
        {
            timeText.color = Color.white;
            if (player.GetComponent<BrushSwing>().KillCount > 0)
                kill.color = Color.white;
            else
                kill.color = killColour;
        }

        if (flashInterval > 0.9f)
        {
            timeText.color = Color.red;
            if (player.GetComponent<BrushSwing>().KillCount > 0)
                kill.color = Color.red;
            else
                kill.color = killColour;
        }

        if (flashInterval > 1.2f)
        {
            timeText.color = Color.white;
            if (player.GetComponent<BrushSwing>().KillCount > 0)
                kill.color = Color.white;
            else
                kill.color = killColour;
        }
        if (flashInterval > 1.5f)
        {
            timeText.color = Color.red;
            if (player.GetComponent<BrushSwing>().KillCount > 0)
                kill.color = Color.red;
            else
                kill.color = killColour;
        }

        if (flashInterval > 1.8f)
        {
            timeText.color = Color.white;
            if (player.GetComponent<BrushSwing>().KillCount > 0)
                kill.color = Color.white;
            else
                kill.color = killColour;
        }

        if (flashInterval > 2.1f)
        {
            timeText.color = Color.red;
            if (player.GetComponent<BrushSwing>().KillCount > 0)
                kill.color = Color.red;
            else
                kill.color = killColour;
        }

        if (flashInterval > 2.4f)
        {
            timeText.color = Color.white;
            if (player.GetComponent<BrushSwing>().KillCount > 0)
                kill.color = Color.white;
            else
                kill.color = killColour;
        }
        if (flashInterval > 2.7f)
        {
            timeText.color = Color.red;
            if (player.GetComponent<BrushSwing>().KillCount > 0)
                kill.color = Color.red;
            else
                kill.color = killColour;
        }

        if (flashInterval > 3f)
        {
            timeText.color = Color.white;
            if (player.GetComponent<BrushSwing>().KillCount > 0)
                kill.color = Color.white;
            else
                kill.color = killColour;
        }

        if (flashInterval > 3.3f)
        {
            timeText.color = Color.red;
            if (player.GetComponent<BrushSwing>().KillCount > 0)
                kill.color = Color.red;
            else
                kill.color = killColour;
        }

        if (flashInterval > 3.6f)
        {
            timeText.color = Color.white;
            if (player.GetComponent<BrushSwing>().KillCount > 0)
                kill.color = Color.white;
            else
                kill.color = killColour;
        }
        if (flashInterval > 3.9f)
        {
            timeText.color = Color.red;
            if (player.GetComponent<BrushSwing>().KillCount > 0)
                kill.color = Color.red;
            else
                kill.color = killColour;
        }

        if (flashInterval > 4.2f)
        {
            timeText.color = Color.white;
            if (player.GetComponent<BrushSwing>().KillCount > 0)
                kill.color = Color.white;
            else
                kill.color = killColour;
        }

        if (flashInterval > 4.5f)
        {
            timeText.color = Color.red;
            if (player.GetComponent<BrushSwing>().KillCount > 0)
                kill.color = Color.red;
            else
                kill.color = killColour;
        }

        if (flashInterval > 4.8f)
        {
            timeText.color = Color.white;
            if (player.GetComponent<BrushSwing>().KillCount > 0)
                kill.color = Color.white;
            else
                kill.color = killColour;
        }
        if (flashInterval > 5.1f)
        {
            timeText.color = Color.red;
            if (player.GetComponent<BrushSwing>().KillCount > 0)
                kill.color = Color.red;
            else
                kill.color = killColour;
        }

        if (flashInterval > 5.4f)
        {
            timeText.color = Color.white;
            if (player.GetComponent<BrushSwing>().KillCount > 0)
                kill.color = Color.white;
            else
                kill.color = killColour;
        }
        if (flashInterval > 5.7f)
        {
            timeText.color = Color.red;
            if (player.GetComponent<BrushSwing>().KillCount > 0)
                kill.color = Color.red;
            else
                kill.color = killColour;
        }

        if (flashInterval > 6f)
        {
            timeText.color = Color.white;
            if (player.GetComponent<BrushSwing>().KillCount > 0)
                kill.color = Color.white;
            else
                kill.color = killColour;
        }

        if (flashInterval > 6.3f)
        {
            timeText.color = Color.red;
            if (player.GetComponent<BrushSwing>().KillCount > 0)
                kill.color = Color.red;
            else
                kill.color = killColour;
        }

        if (flashInterval > 6.6f)
        {
            timeText.color = Color.white;
            if (player.GetComponent<BrushSwing>().KillCount > 0)
                kill.color = Color.white;
            else
                kill.color = killColour;
        }
        if (flashInterval > 6.9f)
        {
            timeText.color = Color.red;
            if (player.GetComponent<BrushSwing>().KillCount > 0)
                kill.color = Color.red;
            else
                kill.color = killColour;
        }

        if (flashInterval > 7.2f)
        {
            timeText.color = Color.white;
            if (player.GetComponent<BrushSwing>().KillCount > 0)
                kill.color = Color.white;
            else
                kill.color = killColour;
        }
        if (flashInterval > 7.5f)
        {
            timeText.color = Color.red;
            if (player.GetComponent<BrushSwing>().KillCount > 0)
                kill.color = Color.red;
            else
                kill.color = killColour;
        }

        if (flashInterval > 7.8f)
        {
            timeText.color = Color.white;
            if (player.GetComponent<BrushSwing>().KillCount > 0)
                kill.color = Color.white;
            else
                kill.color = killColour;
        }

        if (flashInterval > 8.1f)
        {
            timeText.color = Color.red;
            if (player.GetComponent<BrushSwing>().KillCount > 0)
                kill.color = Color.red;
            else
                kill.color = killColour;
        }

        if (flashInterval > 8.4f)
        {
            timeText.color = Color.white;
            if (player.GetComponent<BrushSwing>().KillCount > 0)
                kill.color = Color.white;
            else
                kill.color = killColour;
        }
        if (flashInterval > 8.7f)
        {
            timeText.color = Color.red;
            if (player.GetComponent<BrushSwing>().KillCount > 0)
                kill.color = Color.red;
            else
                kill.color = killColour;
        }

        if (flashInterval > 9f)
        {
            timeText.color = Color.white;
            if (player.GetComponent<BrushSwing>().KillCount > 0)
                kill.color = Color.white;
            else
                kill.color = killColour;
        }
        if (flashInterval > 9.3f)
        {
            timeText.color = Color.red;
            if (player.GetComponent<BrushSwing>().KillCount > 0)
                kill.color = Color.red;
            else
                kill.color = killColour;
        }

        if (flashInterval > 9.6f)
        {
            timeText.color = Color.white;
            if (player.GetComponent<BrushSwing>().KillCount > 0)
                kill.color = Color.white;
            else
                kill.color = killColour;
        }

        if (flashInterval > 9.9f)
        {
            timeText.color = Color.red;
            if (player.GetComponent<BrushSwing>().KillCount > 0)
                kill.color = Color.red;
            else
                kill.color = killColour;
        }

        if (flashInterval > 10.2f)
        {
            timeText.color = Color.white;
            if (player.GetComponent<BrushSwing>().KillCount > 0)
                kill.color = Color.white;
            else
                kill.color = killColour;
        }



    }
}

