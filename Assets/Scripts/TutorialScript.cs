using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject TutorialScene;
    [SerializeField] private GameObject SecondTextBox;
    [SerializeField] private GameObject KillCounter;
    [SerializeField] private GameObject Timer;
    [SerializeField] private Text TutorialText;
    [SerializeField] private Text TutorialText2;
    public float TimeValue = 0;
    float GumGuard = 0;

    void Update()
    {
        PopUps();          
    }

    public void PopUps()
    {
        if (TimeValue == 0)
        {
            TutorialScene.SetActive(true);
            SecondTextBox.SetActive(false);
            TutorialText.text = "Use The Left And Right Arrow Keys To Move";
            Time.timeScale = 0;
            GumGuard = 1;
        }

        if (TimeValue > 5 && TimeValue < 5.1)
        {
            TutorialScene.SetActive(true);
            TutorialText.text = "Use The Up Arrow To Jump";
            Time.timeScale = 0;
            GumGuard = 1;
        }
        if (TimeValue > 7 && TimeValue < 7.1)
        {
            TutorialScene.SetActive(true);
            TutorialText.text = "Spin Using The Space Bar";
            Time.timeScale = 0;
            GumGuard = 1;
        }
        if (TimeValue > 10 && TimeValue < 10.1)
        {
            TutorialScene.SetActive(true);
            SecondTextBox.SetActive(true);
            TutorialText.text = "Oh No! An Enemy Is Attacking A Tooth Use Your Spin To Kill It";
            TutorialText2.text = "It Clings On To The Enamal On The Tooth And Releases Acid To Damage It, Use your Spin To Clean The Teeth";
            Time.timeScale = 0;
            GumGuard = 1;
        }

        if (TimeValue > 15 && TimeValue < 15.1)
        {
            TutorialScene.SetActive(true);
            SecondTextBox.SetActive(true);
            TutorialText.text = "If Two Enemys Attach To The Teeth It'll Take Double The Cleaning";
            TutorialText2.text = "Be Carefull Not To Let Three Enemies Reach A Tooth Otherwise, IT WILL BECOME DECAYED!";
            Time.timeScale = 0;
            GumGuard = 1;
        }

        if (TimeValue > 20 && TimeValue < 20.1)
        {
            TutorialScene.SetActive(true);
            SecondTextBox.SetActive(false);
            Timer.SetActive(true);
            KillCounter.SetActive(true);
            TutorialText.text = "You Have 2:00 Minutes To Kill 20 Enemies GET PROTECTING THOSE TEETH!";
            TutorialText2.text = "Be Carefull Not To Let Three Enemies Reach A Tooth Otherwise, IT WILL BECOME DECAYED!";
            Time.timeScale = 0;
            GumGuard = 1;
        }

        if (GumGuard == 1)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                TutorialScene.SetActive(false);
                Time.timeScale = 1;
                GumGuard = 0;
                TimeValue += 1;
            }

        }

        TimeValue += Time.deltaTime;       
    }       
           
}
    
