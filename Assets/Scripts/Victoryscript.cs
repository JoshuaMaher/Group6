using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Victoryscript : MonoBehaviour
{
    [SerializeField] public GameObject BotMolar1;
    [SerializeField] public GameObject BotCanine1;
    [SerializeField] public GameObject BotIncisor1;
    [SerializeField] public GameObject BotIncisor2;
    [SerializeField] public GameObject BotCanine2;
    [SerializeField] public GameObject BotMolar2;
    [SerializeField] public GameObject TopMolar1;
    [SerializeField] public GameObject TopCanine1;
    [SerializeField] public GameObject TopIncisor1;
    [SerializeField] public GameObject TopIncisor2;
    [SerializeField] public GameObject TopCanine2;
    [SerializeField] public GameObject TopMolar2;
    [SerializeField] public GameObject TimerText;
    [SerializeField] public GameObject HappyFace;
    [SerializeField] public GameObject VeryHappyFace;
    [SerializeField] public GameObject Star;
    [SerializeField] public GameObject Star2;
    [SerializeField] public GameObject Star3;
    [SerializeField] public GameObject Star4;
    [SerializeField] public GameObject Star5;
    [SerializeField] public GameObject Player;

    public Text VictoryText;
    public Text BannerText;
    private string Victory;
    private string Banner;
    private float TeethClean;
    private float TeethShielded;

    private ToothHealth BotMolar1Health;
    private ToothHealth BotCanine1Health;
    private ToothHealth BotIncisor1Health;
    private ToothHealth BotIncisor2Health;
    private ToothHealth BotCanine2Health;
    private ToothHealth BotMolar2Health;

    private ToothHealth TopMolar1Health;
    private ToothHealth TopCanine1Health;
    private ToothHealth TopIncisor1Health;
    private ToothHealth TopIncisor2Health;
    private ToothHealth TopCanine2Health;
    private ToothHealth TopMolar2Health;
    private BrushSwing Killcount;

    void Update()
    {
        BotMolar1Health = BotMolar1.GetComponent<ToothHealth>();
        BotCanine1Health = BotCanine1.GetComponent<ToothHealth>();
        BotIncisor1Health = BotIncisor1.GetComponent<ToothHealth>();
        BotIncisor2Health = BotIncisor2.GetComponent<ToothHealth>();
        BotCanine2Health = BotCanine2.GetComponent<ToothHealth>();
        BotMolar2Health = BotMolar2.GetComponent<ToothHealth>();

        TopMolar1Health = TopMolar1.GetComponent<ToothHealth>();
        TopCanine1Health = TopCanine1.GetComponent<ToothHealth>();
        TopIncisor1Health = TopIncisor1.GetComponent<ToothHealth>();
        TopIncisor2Health = TopIncisor2.GetComponent<ToothHealth>();
        TopCanine2Health = TopCanine2.GetComponent<ToothHealth>();
        TopMolar2Health = TopMolar2.GetComponent<ToothHealth>();
        Killcount = Player.GetComponent<BrushSwing>();
        VictoryScreen();
    }


    public void VictoryScreen()
    {

        if (TopCanine1Health.currentHealth == 3)
        {
            TeethClean += 1;
        }
        if (TopCanine2Health.currentHealth == 3)
        {
            TeethClean += 1;
        }
        if (TopIncisor1Health.currentHealth == 3)
        {
            TeethClean += 1;
        }
        if (TopIncisor2Health.currentHealth == 3)
        {
            TeethClean += 1;
        }
        if (TopMolar1Health.currentHealth == 3)
        {
            TeethClean += 1;
        }
        if (TopMolar2Health.currentHealth == 3)
        {
            TeethClean += 1;
        }
        if (BotCanine1Health.currentHealth == 3)
        {
            TeethClean += 1;
        }
        if (BotCanine2Health.currentHealth == 3)
        {
            TeethClean += 1;
        }
        if (BotIncisor1Health.currentHealth == 3)
        {
            TeethClean += 1;
        }
        if (BotIncisor2Health.currentHealth == 3)
        {
            TeethClean += 1;
        }
        if (BotMolar1Health.currentHealth == 3)
        {
            TeethClean += 1;
        }
        if (BotMolar2Health.currentHealth == 3)
        {
            TeethClean += 1;
        }
        
        
        if (TopCanine1Health.currentHealth == 4)
        {
            TeethShielded += 1;
        }
        if (TopCanine2Health.currentHealth == 4)
        {
            TeethShielded += 1;
        }
        if (TopIncisor1Health.currentHealth == 4)
        {
            TeethShielded += 1;
        }
        if (TopIncisor2Health.currentHealth == 4)
        {
            TeethShielded += 1;
        }
        if (TopMolar1Health.currentHealth == 4)
        {
            TeethShielded += 1;
        }
        if (TopMolar2Health.currentHealth == 4)
        {
            TeethShielded += 1;
        }
        if (BotCanine1Health.currentHealth == 4)
        {
            TeethShielded += 1;
        }
        if (BotCanine2Health.currentHealth == 4)
        {
            TeethShielded += 1;
        }
        if (BotIncisor1Health.currentHealth == 4)
        {
            TeethShielded += 1;
        }
        if (BotIncisor2Health.currentHealth == 4)
        {
            TeethShielded += 1;
        }
        if (BotMolar1Health.currentHealth == 4)
        {
            TeethShielded += 1;
        }
        if (BotMolar2Health.currentHealth == 4)
        {
            TeethShielded += 1;
        }
        
        if (Killcount.KillCount > 0)
        {
            Victory = "you didn't kill all the enemies";
            VictoryText.text = Victory;
            Banner = "Better Luck Next Time";
            BannerText.text = Banner;
            HappyFace.SetActive(true);
            VeryHappyFace.SetActive(false);
            Star.SetActive(true);
            Star2.SetActive(false);
            Star3.SetActive(false);
            Star4.SetActive(false);
            Star5.SetActive(false);
        }
        
        
        if (TeethClean >= 0 && TeethClean <= 6 && Killcount.KillCount <= 0)
        {
            Victory = "you cleaned some teeth";
            VictoryText.text = Victory;
            Banner = "You Win";
            BannerText.text = Banner;
            HappyFace.SetActive(true);
            VeryHappyFace.SetActive(false);
            Star.SetActive(true);
            Star2.SetActive(true);
            Star3.SetActive(false);
            Star4.SetActive(false);
            Star5.SetActive(false);
        }
        if (TeethClean >= 7 && TeethClean < 12 && Killcount.KillCount <= 0)
        {
            Victory = "you cleaned most of the teeth";
            VictoryText.text = Victory;
            Banner = "You Win";
            BannerText.text = Banner;
            HappyFace.SetActive(true);
            VeryHappyFace.SetActive(false);
            Star.SetActive(true);
            Star2.SetActive(true);
            Star3.SetActive(true);
            Star4.SetActive(false);
            Star5.SetActive(false);
        }

        if (TeethClean == 12 && Killcount.KillCount <= 0)
        {
            Victory = "you cleaned all the teeth";
            VictoryText.text = Victory;
            Banner = "You Win";
            BannerText.text = Banner;
            HappyFace.SetActive(false);
            VeryHappyFace.SetActive(true);
            Star.SetActive(true);
            Star2.SetActive(true);
            Star3.SetActive(true);
            Star4.SetActive(true);
            Star5.SetActive(false);
        }

        if(TeethShielded == 12 & Killcount.KillCount <= 0)
        {
            Victory = "you shielded all the teeth";
            VictoryText.text = Victory;
            Banner = "You Win";
            BannerText.text = Banner;
            HappyFace.SetActive(false);
            VeryHappyFace.SetActive(true);
            Star.SetActive(true);
            Star2.SetActive(true);
            Star3.SetActive(true);
            Star4.SetActive(true);
            Star5.SetActive(true);
        }

        TeethShielded = 0;
        TeethClean = 0;
    }
}