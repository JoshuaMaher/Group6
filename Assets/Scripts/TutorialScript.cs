using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialScript : MonoBehaviour
{
    [SerializeField] private GameObject TutorialScene;
    [SerializeField] private GameObject SecondTextBox;
    [SerializeField] private GameObject KillCounter;
    [SerializeField] private GameObject Timer;
    [SerializeField] private GameObject Happy;
    [SerializeField] private GameObject Angry;
    [SerializeField] private GameObject ExtremeHappy;
    [SerializeField] private GameObject Stress;
    [SerializeField] private GameObject Happy2;
    [SerializeField] private GameObject Angry2;
    [SerializeField] private GameObject ExtremeHappy2;
    [SerializeField] private GameObject Stress2;
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
            Happy.SetActive(false);
            Angry.SetActive(false);
            ExtremeHappy.SetActive(false);
            Stress.SetActive(false);
            Happy2.SetActive(true);
            Angry2.SetActive(false);
            ExtremeHappy2.SetActive(false);
            Stress2.SetActive(false);
            TutorialText.text = "Use the ARROW KEYS to move left and right. Press Enter";
            Time.timeScale = 0;
            GumGuard = 1;
        }

        if (TimeValue > 5 && TimeValue < 5.1)
        {
            TutorialScene.SetActive(true);
            Happy.SetActive(false);
            Angry.SetActive(false);
            ExtremeHappy.SetActive(false);
            Stress.SetActive(false);
            Happy2.SetActive(true);
            Angry2.SetActive(false);
            ExtremeHappy2.SetActive(false);
            Stress2.SetActive(false);
            TutorialText.text = "Use the UP ARROW to jump. Press Enter";
            Time.timeScale = 0;
            GumGuard = 1;
        }
        if (TimeValue > 14 && TimeValue < 14.1)
        {
            TutorialScene.SetActive(true);
            SecondTextBox.SetActive(true);
            Happy.SetActive(false);
            Angry.SetActive(false);
            ExtremeHappy.SetActive(false);
            Stress.SetActive(true);
            Happy2.SetActive(false);
            Angry2.SetActive(false);
            ExtremeHappy2.SetActive(false);
            Stress2.SetActive(false);
            TutorialText.text = "Use SPACE BAR to spin and clean the tooth. Press Enter";
            TutorialText2.text = "Oh no! A bacteria is attacking the tooth. It clings to the sticky plaque and releases acid.";
            Time.timeScale = 0;
            GumGuard = 1;
        }
        if (TimeValue >  29 && TimeValue < 29.1)
        {
            TutorialScene.SetActive(true);
            SecondTextBox.SetActive(true);
            Happy.SetActive(false);
            Angry.SetActive(false);
            ExtremeHappy.SetActive(false);
            Stress.SetActive(true);
            Happy2.SetActive(false);
            Angry2.SetActive(false);
            ExtremeHappy2.SetActive(false);
            Stress2.SetActive(false);
            TutorialText.text = "The spiky green bacteria move faster. Use SPACE BAR to KILL them. Press Enter";
            TutorialText2.text = "Double the enemies means double the cleaning.";
            Time.timeScale = 0;
            GumGuard = 1;
        }

        if (TimeValue > 47 && TimeValue < 47.1)
        {
            TutorialScene.SetActive(true);
            SecondTextBox.SetActive(true);
            Happy.SetActive(false);
            Angry.SetActive(false);
            ExtremeHappy.SetActive(true);
            Stress.SetActive(false);
            Happy2.SetActive(false);
            Angry2.SetActive(false);
            ExtremeHappy2.SetActive(false);
            Stress2.SetActive(false);
            TutorialText.text = "Not without high fluoride toothpaste. With the POWERUP, use SPACE BAR to reverse the decay. Press Enter";
            TutorialText2.text = "The tooth is decayed! it can't be brought back.";
            Time.timeScale = 0;
            GumGuard = 1;
        }

        if (TimeValue > 56 && TimeValue < 56.1)
        {
            TutorialScene.SetActive(true);
            SecondTextBox.SetActive(true);
            Happy.SetActive(true);
            Angry.SetActive(false);
            ExtremeHappy.SetActive(false);
            Stress.SetActive(false);
            Happy2.SetActive(false);
            Angry2.SetActive(false);
            ExtremeHappy2.SetActive(false);
            Stress2.SetActive(false);
            TutorialText.text = "The powerup doesn't last forever. Press Enter";
            TutorialText2.text = "The fluoride strengthens the enamel: your tooth's protective shield.";
            Time.timeScale = 0;
            GumGuard = 1;
        }

        if (TimeValue > 63 && TimeValue < 63.1)
        {
            TutorialScene.SetActive(true);
            SecondTextBox.SetActive(true);
            Happy.SetActive(true);
            Angry.SetActive(false);
            ExtremeHappy.SetActive(false);
            Stress.SetActive(false);
            Happy2.SetActive(false);
            Angry2.SetActive(false);
            ExtremeHappy2.SetActive(false);
            Stress2.SetActive(false);
            TutorialText.text = "You will have 2 minutes to kill 20 enemies. Use leftover time to clean any damaged teeth.Press Enter";
            TutorialText2.text = "That concludes your training.";
            Time.timeScale = 0;
            GumGuard = 2;
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
        if (GumGuard == 2)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("Level1");
                Time.timeScale = 1;
            }
        }
        TimeValue += Time.deltaTime;       
    }       
           
}
    
