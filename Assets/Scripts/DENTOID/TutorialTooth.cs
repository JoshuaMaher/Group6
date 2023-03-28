using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTooth : MonoBehaviour
{
  public GameObject timer;
  private float currentTime;
  public GameObject thisTooth;
  

  void Update()
  {
    currentTime = timer.GetComponent<MinutesTimer>().timeValue;
    
    if(currentTime <= 105)
    {
        thisTooth.GetComponent<ToothHealth>().currentHealth = 0;
        thisTooth.GetComponent<ToothHealth>().decay = true;
    }

    if(currentTime <= 95)
    {
        thisTooth.GetComponent<ToothHealth>().currentHealth = 3;
        thisTooth.GetComponent<ToothHealth>().decay = false;
        this.enabled = false;
    }
  }

}
