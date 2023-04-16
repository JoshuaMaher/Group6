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
    public Text VictoryText;
    private string Victory;
    private float TeethClean;

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
        VictoryScreen();
    }


    public void VictoryScreen()
    {

        if (TopCanine1Health.currentHealth >= 3)
        {
            TeethClean += 1;
        }
        if (TopCanine2Health.currentHealth >= 3)
        {
            TeethClean += 1;
        }
        if (TopIncisor1Health.currentHealth >= 3)
        {
            TeethClean += 1;
        }
        if (TopIncisor2Health.currentHealth >= 3)
        {
            TeethClean += 1;
        }
        if (TopMolar1Health.currentHealth >= 3)
        {
            TeethClean += 1;
        }
        if (TopMolar2Health.currentHealth >= 3)
        {
            TeethClean += 1;
        }
        if (BotCanine1Health.currentHealth >= 3)
        {
            TeethClean += 1;
        }
        if (BotCanine2Health.currentHealth >= 3)
        {
            TeethClean += 1;
        }
        if (BotIncisor1Health.currentHealth >= 3)
        {
            TeethClean += 1;
        }
        if (BotIncisor2Health.currentHealth >= 3)
        {
            TeethClean += 1;
        }
        if (BotMolar1Health.currentHealth >= 3)
        {
            TeethClean += 1;
        }
        if (BotMolar2Health.currentHealth >= 3)
        {
            TeethClean += 1;
        }
        if (TeethClean >= 0 && TeethClean <= 6)
        {
            Victory = "you cleaned some teeth";
            VictoryText.text = Victory;
            HappyFace.SetActive(true);
            VeryHappyFace.SetActive(false);
            Star.SetActive(true);
            Star2.SetActive(false);
            Star3.SetActive(false);
        }
        if (TeethClean >= 7 && TeethClean < 12)
        {
            Victory = "you cleaned most of the teeth";
            VictoryText.text = Victory;
            HappyFace.SetActive(true);
            VeryHappyFace.SetActive(false);
            Star.SetActive(true);
            Star2.SetActive(true);
            Star3.SetActive(false);
        }

        if (TeethClean == 12)
        {
            Victory = "you cleaned all the teeth";
            VictoryText.text = Victory;
            HappyFace.SetActive(false);
            VeryHappyFace.SetActive(true);
            Star.SetActive(true);
            Star2.SetActive(true);
            Star3.SetActive(true);
        }
        TeethClean = 0;
    }
}