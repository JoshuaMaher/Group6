using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    [SerializeField] public Text Introduction;
    [SerializeField] public GameObject GumGuard;
    private string IntroductionText;

    private void Awake()
    {
        GumGuard.SetActive(true);
    }
    void Update()
    {
        IntroductionText = "Hello I'm the Gum Guard. Press Space";
        Introduction.text = IntroductionText;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            GumGuard.SetActive(false);
        }
    }
}
