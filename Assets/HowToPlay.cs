using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlay : MonoBehaviour
{
    [SerializeField] private GameObject HowToPlay1;
    [SerializeField] private GameObject HowToPlay2;

    public void next()
    {
        HowToPlay1.SetActive(false);
        HowToPlay2.SetActive(true);
    }
    public void back()
    {
        HowToPlay1.SetActive(true);
        HowToPlay2.SetActive(false);
    }
}
