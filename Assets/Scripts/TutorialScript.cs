using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
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
            TutorialText.text = "Use the left and right arrow keys to move. Press Enter";
            Time.timeScale = 0;
            GumGuard = 1;
        }

        if (TimeValue > 5 && TimeValue < 5.1)
        {
            TutorialScene.SetActive(true);
            TutorialText.text = "Use the up arrow to jump. Press Enter";
            Time.timeScale = 0;
            GumGuard = 1;
        }
        if (TimeValue > 7 && TimeValue < 7.1)
        {
            TutorialScene.SetActive(true);
            TutorialText.text = "Spin using the space bar. Press Enter";
            Time.timeScale = 0;
            GumGuard = 1;
        }
        if (TimeValue > 10 && TimeValue < 10.1)
        {
            TutorialScene.SetActive(true);
            SecondTextBox.SetActive(true);
            TutorialText.text = "Oh no! an enemy is attacking a tooth use your spin to kill it. Press Enter";
            TutorialText2.text = "It clings on to the plaque on the tooth and releases acid to damage it, use your spin to clean the teeth.";
            Time.timeScale = 0;
            GumGuard = 1;
        }

        if (TimeValue > 15 && TimeValue < 15.1)
        {
            TutorialScene.SetActive(true);
            SecondTextBox.SetActive(true);
            TutorialText.text = "If two enemys attach to the teeth it'll take double the cleaning. Press Enter";
            TutorialText2.text = "Be carefull not to let three enemies reach a tooth otherwise, IT WILL BECOME DECAYED!";
            Time.timeScale = 0;
            GumGuard = 1;
        }

        if (TimeValue > 20 && TimeValue < 20.1)
        {
            TutorialScene.SetActive(true);
            SecondTextBox.SetActive(true);
            TutorialText.text = "This is a power up, when applied to the teeth they get a blue shine which acts as a protective shield. Press Enter";
            TutorialText2.text = "This power up only works once on each tooth.";
            Time.timeScale = 0;
            GumGuard = 1;
        }

        if (TimeValue > 23 && TimeValue < 23.1)
        {
            TutorialScene.SetActive(true);
            SecondTextBox.SetActive(false);
            Timer.SetActive(true);
            KillCounter.SetActive(true);
            TutorialText.text = "You have 2:00 minutes to kill 20 enemies GET PROTECTING THOSE TEETH! Press Enter";
            TutorialText2.text = "Be carefull not to let three enemies reach a tooth otherwise, IT WILL BECOME DECAYED!";
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
    
